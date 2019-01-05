using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Minesweeper.Lib;

namespace Minesweeper.Cli
{
    public class CliController
    {
        private static readonly DifficultLevel EasyLevel = new DifficultLevel { Width = 9, Height = 9, MinesCount = 10, Name = "Easy" };
        private static readonly DifficultLevel MediumLevel = new DifficultLevel { Width = 16, Height = 16, MinesCount = 40, Name = "Medium" };
        private static readonly DifficultLevel HardLevel = new DifficultLevel { Width = 30, Height = 16, MinesCount = 99, Name = "Hard" };

        public Field Field { get; }

        public List<Score> HighScores { get; set; }
        public string UserName { get; set; }

        public MainMenuItems SelectedMainMenuItem { get; set; }
        public SettingsMenuItems SelectedSettingsMenuItem { get; set; }

        public CliController()
        {
            DifficultLevel = LoadSettings();

            Field = new Field(DifficultLevel.Width, DifficultLevel.Height, DifficultLevel.MinesCount);

            HighScores = LoadScores();
            UserName = Environment.UserName;
        }

        public GameStatus GameStatus => Field.GameStatus;

        public DifficultLevel DifficultLevel { get; set; }

        public string Timer
        {
            get
            {
                var time = Field.Time;
                return $"{time.Minutes:00}:{time.Seconds:00}:{time.Milliseconds / 10:00}";
            }
        }

        public void Open(Cell cell)
        {
            Field.Open(cell);
            CheckGameStatus();
        }

        public void Mark(Cell cell)
        {
            Field.Mark(cell);
        }

        public int FieldWidth
        {
            get => Field.FieldWidth;
            set => Field.FieldWidth = value;
        }

        public int FieldHeight
        {
            get => Field.FieldHeight;
            set => Field.FieldHeight = value;
        }

        public void SetDifficultLevel(string level)
        {
            switch (level)
            {
                case "0":
                    DifficultLevel = EasyLevel;
                    break;
                case "1":
                    DifficultLevel = MediumLevel;
                    break;
                case "2":
                    DifficultLevel = HardLevel;
                    break;
                case "3":
                    DifficultLevel = new DifficultLevel
                    {
                        Name = "Custom Level",
                        Width = DifficultLevel.Width,
                        Height = DifficultLevel.Height,
                        MinesCount = DifficultLevel.MinesCount
                    };
                    break;
            }
        }

        public DifficultLevel LoadSettings()
        {
            DifficultLevel difficultLevel;
            try
            {
                var readFileStream = File.Open("settings.cfg", FileMode.Open);
                var deserializer = new BinaryFormatter();
                difficultLevel = (DifficultLevel)deserializer.Deserialize(readFileStream);
                readFileStream.Dispose();
            }
            catch (Exception)
            {
                difficultLevel = EasyLevel;
            }

            return difficultLevel;
        }

        public void SaveSettings()
        {
            using (var saveFileStream = File.Create("settings.cfg"))
            {
                var serializer = new BinaryFormatter();
                serializer.Serialize(saveFileStream, DifficultLevel);
                saveFileStream.Close();
            }
        }

        public List<Score> LoadScores()
        {
            var highScores = new List<Score>();
            try
            {
                var readFileStream = File.Open("highscores.dat", FileMode.Open);
                var deserializer = new BinaryFormatter();
                highScores = (List<Score>)deserializer.Deserialize(readFileStream);
                readFileStream.Dispose();
            }
            catch (Exception)
            {
                highScores.Add(new Score { Name = "John Smith", Time = new TimeSpan(0, 0, 0, 2, 15), DifficultLevel = EasyLevel });
            }
            return highScores;
        }

        public void SaveScores()
        {
            using (var saveFileStream = File.Create("highscores.dat"))
            {
                var serializer = new BinaryFormatter();
                serializer.Serialize(saveFileStream, HighScores);
                saveFileStream.Close();
            }
        }

        public void AddScores()
        {
            HighScores.Add(new Score { Name = UserName, DifficultLevel = DifficultLevel, Time = Field.Time });
            HighScores = HighScores.OrderBy(n => n.DifficultLevel).ThenBy(n => n.Time).ToList();
            SaveScores();
        }

        public void ClearScores()
        {
            HighScores.Clear();
            SaveScores();
        }

        private void CheckGameStatus()
        {
            switch (GameStatus)
            {
                case GameStatus.Win:
                    {
                        Console.WriteLine("You Win!");
                        Console.WriteLine($"Your time: {Timer}");
                        Console.Write("Enter your name: ");
                        UserName = Console.ReadLine();
                        AddScores();
                    }
                    break;
                case GameStatus.GameOver:
                    {
                        Console.WriteLine("Game Over!");
                        Console.ReadKey(true);
                    }
                    break;
            }
        }

        public bool TryExecuteCommand(string input)
        {
            if (input.Length < 2 || input.Length > 4)
            {
                return false;
            }

            var command = input;

            command = command.Replace('@', '[');
            command = command.Replace("#", @"\");
            command = command.Replace('$', ']');
            command = command.Replace('%', '^');

            var isMarkCommand = false;
            if (command[0] == '?')
            {
                isMarkCommand = true;
                command = command.Substring(1, command.Length - 1);
            }

            var x = command[0] - 65;
            if (x < 0 || x > FieldWidth)
            {
                return false;
            }

            command = command.Substring(1, command.Length - 1);

            if (!int.TryParse(command, out int y) || y < 1 || y > FieldHeight)
            {
                return false;
            }
            y--;

            var cell = Field.Cells[y][x];

            if (isMarkCommand)
            {
                Mark(cell);
            }
            else
            {
                Open(cell);
            }

            return true;
        }

        public static readonly Dictionary<CellStatus, ConsoleColor> CellColors =
            new Dictionary<CellStatus, ConsoleColor>
            {
                {CellStatus.Mine, ConsoleColor.Red },
                {CellStatus.Hidden, ConsoleColor.White },
                {CellStatus.Marked, ConsoleColor.Black },
                {CellStatus.Number0, ConsoleColor.DarkGray },
                {CellStatus.Number1, ConsoleColor.Blue },
                {CellStatus.Number2, ConsoleColor.DarkGreen },
                {CellStatus.Number3, ConsoleColor.Red },
                {CellStatus.Number4, ConsoleColor.DarkBlue },
                {CellStatus.Number5, ConsoleColor.DarkRed },
                {CellStatus.Number6, ConsoleColor.Cyan },
                {CellStatus.Number7, ConsoleColor.Magenta },
                {CellStatus.Number8, ConsoleColor.DarkYellow }
            };
    }
}
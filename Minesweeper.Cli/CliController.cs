using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Minesweeper.Lib;


namespace Minesweeper.Cli
{
    public class CliController
    {
        private static readonly DifficultLevel EasyLevel = new DifficultLevel { Width = 9, Height = 9, MinesCount = 10, Name = "Easy" };
        private static readonly DifficultLevel MediumLevel = new DifficultLevel { Width = 16, Height = 16, MinesCount = 40, Name = "Medium" };
        private static readonly DifficultLevel HardLevel = new DifficultLevel { Width = 30, Height = 16, MinesCount = 99, Name = "Hard" };

        public Field Field { get; }
        private DifficultLevel _difficultLevel;

        public List<Score> HighScores { get; set; }
        public string UserName { get; set; }

        public MainMenuItems SelectedMainMenuItem { get; set; }
        public SettingsMenuItems SelectedSettingsMenuItem { get; set; }

        public CliController()
        {
            _difficultLevel = LoadSettings();

            Field = new Field(_difficultLevel.Width, _difficultLevel.Height, _difficultLevel.MinesCount);

            //var dispatcherTimer = new DispatcherTimer();
            //dispatcherTimer.Tick += TickTimer;
            //dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            //dispatcherTimer.Start();

            HighScores = LoadScores();
            UserName = Environment.UserName;
        }

        public GameStatus GameStatus => Field.GameStatus;

        public DifficultLevel DifficultLevel
        {
            get => _difficultLevel;
            set => _difficultLevel = value;
        }

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

        public int MinesCount
        {
            get => Field.MinesCount;
            set => Field.MinesCount = value;
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
                    DifficultLevel.Name = "Custom Level";
                    break;
            }
        }

        public DifficultLevel LoadSettings()
        {
            var difficultLevel = new DifficultLevel();
            try
            {
                var readFileStream = File.Open("settings.cfg", FileMode.Open);
                var deserializer = new BinaryFormatter();
                difficultLevel = (DifficultLevel) deserializer.Deserialize(readFileStream);
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
                serializer.Serialize(saveFileStream, _difficultLevel);
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
            HighScores.Add(new Score { Name = UserName, DifficultLevel = _difficultLevel, Time = Field.Time });
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

                    }
                    break;
                case GameStatus.GameOver:
                    {
                        Console.WriteLine("Game Over!");
                    }
                    break;
            }
        }

        public static readonly Dictionary<CellStatus, ConsoleColor> CellColors =
            new Dictionary<CellStatus, ConsoleColor>
            {
                {CellStatus.Mine, ConsoleColor.Red },
                {CellStatus.Hidden, ConsoleColor.White },
                {CellStatus.Marked, ConsoleColor.Black },
                {CellStatus.Number0, ConsoleColor.DarkGray },
                {CellStatus.Number1, ConsoleColor.DarkBlue },
                {CellStatus.Number2, ConsoleColor.DarkGreen },
                {CellStatus.Number3, ConsoleColor.DarkYellow },
                {CellStatus.Number4, ConsoleColor.Magenta },
                {CellStatus.Number5, ConsoleColor.DarkRed },
                {CellStatus.Number6, ConsoleColor.Blue },
                {CellStatus.Number7, ConsoleColor.Green },
                {CellStatus.Number8, ConsoleColor.Yellow }
            };
    }
}

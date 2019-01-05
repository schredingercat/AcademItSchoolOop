using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;
using System.Windows.Threading;
using Minesweeper.Annotations;
using Minesweeper.Lib;

namespace Minesweeper
{
    public class GuiController : INotifyPropertyChanged
    {
        private static readonly DifficultLevel EasyLevel = new DifficultLevel { Width = 9, Height = 9, MinesCount = 10, Name = Properties.Resources.LevelEasy };
        private static readonly DifficultLevel MediumLevel = new DifficultLevel { Width = 16, Height = 16, MinesCount = 40, Name = Properties.Resources.LevelMedium };
        private static readonly DifficultLevel HardLevel = new DifficultLevel { Width = 30, Height = 16, MinesCount = 99, Name = Properties.Resources.LevelHard };

        public Field Field { get; }
        private DifficultLevel _difficultLevel;

        public List<Score> HighScores { get; set; }
        public string UserName { get; set; }

        public GuiController()
        {
            _difficultLevel = LoadSettings();
            Field = new Field(_difficultLevel.Width, _difficultLevel.Height, _difficultLevel.MinesCount);

            var dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += TickTimer;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            dispatcherTimer.Start();

            HighScores = LoadScores();
            UserName = Environment.UserName;
        }

        public GameStatus GameStatus => Field.GameStatus;

        public DifficultLevel DifficultLevel
        {
            get => _difficultLevel;
            set
            {
                _difficultLevel = value;
                OnPropertyChanged(nameof(DifficultLevel));
            }
        }

        public int FlagsCount
        {
            get => Field.FlagsCount;
            set
            {
                Field.FlagsCount = value;
                OnPropertyChanged(nameof(FlagsCount));
            }
        }

        private void TickTimer(object sender, EventArgs e)
        {
            OnPropertyChanged(nameof(Timer));
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
            OnPropertyChanged(nameof(FlagsCount));
        }

        public void Mark(Cell cell)
        {
            Field.Mark(cell);
            OnPropertyChanged(nameof(FlagsCount));
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
                        Name = Properties.Resources.LevelCustom,
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
                    var congratulationsWindow = new CongratulationsWindow();
                    congratulationsWindow.DataContext = this;
                    congratulationsWindow.ShowDialog();
                    break;
                case GameStatus.GameOver:
                    MessageBox.Show("Game Over!");
                    break;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
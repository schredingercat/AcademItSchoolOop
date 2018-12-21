using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Minesweeper.Annotations;
using Minesweeper.Lib;

namespace Minesweeper
{
    public class GuiController : INotifyPropertyChanged
    {
        private static readonly DifficultLevel EasyLevel = new DifficultLevel { Width = 9, Height = 9, MinesCount = 10, Name = Properties.Resources.LevelEasy};
        private static readonly DifficultLevel MediumLevel = new DifficultLevel { Width = 16, Height = 16, MinesCount = 40, Name = Properties.Resources.LevelMedium};
        private static readonly DifficultLevel HardLevel = new DifficultLevel { Width = 30, Height = 16, MinesCount = 99,Name = Properties.Resources.LevelHard};

        public Field Field { get; }
        private DifficultLevel _difficultLevel;
        private DispatcherTimer _dispatcherTimer;

        public List<Score> HighScores { get; set; }
        public string UserName { get; set; }
        

        public GuiController()
        {
            _difficultLevel = LoadSettings();

            Field = new Field(_difficultLevel.Width, _difficultLevel.Height, _difficultLevel.MinesCount);

            _dispatcherTimer = new DispatcherTimer();
            _dispatcherTimer.Tick += TickTimer;
            _dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            _dispatcherTimer.Start();

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

        private void TickTimer(object sender, EventArgs e)
        {
            OnPropertyChanged(nameof(Timer));
        }

        public string Timer
        {
            get
            {
                var time = Field.Time;
                return $"{time.Minutes:00}:{time.Seconds:00}:{time.Milliseconds:000}";
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
                    DifficultLevel.Name = Properties.Resources.LevelCustom;
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
                difficultLevel = (DifficultLevel)deserializer.Deserialize(readFileStream);
            }
            catch (Exception ex)
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
            catch (Exception ex)
            {
                highScores.Add(new Score{Name = "John Smith", Time = new TimeSpan(0,0,2,15), DifficultLevel = EasyLevel});
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
            HighScores.Add(new Score{Name = UserName, DifficultLevel = _difficultLevel, Time = Field.Time});
            SaveScores();
        }

        private void CheckGameStatus()
        {
            switch (GameStatus)
            {
                case GameStatus.Win:
                    {
                        //MessageBox.Show($"You Win!\nYour result: {Field.Time.Minutes:00}: {Field.Time.Seconds:00}:{Field.Time.Milliseconds:000}");
                        var congratulationsWindow = new CongratulationsWindow();
                        congratulationsWindow.DataContext = this;
                        congratulationsWindow.ShowDialog();
                    }
                    break;
                case GameStatus.GameOver:
                    {
                        MessageBox.Show("Game Over!");
                    }
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

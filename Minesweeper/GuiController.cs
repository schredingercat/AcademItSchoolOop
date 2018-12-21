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
    public class GuiController :INotifyPropertyChanged
    {
        public Field Field { get; }
        private DifficultLevel _difficultLevel;
        private DispatcherTimer _dispatcherTimer;

        public GuiController()
        {
            try
            {
                _difficultLevel = LoadSettings();
            }
            catch (Exception ex)
            {
                _difficultLevel = new DifficultLevel { Width = 8, Height = 8, MinesCount = 10 };
            }

            Field = new Field(_difficultLevel.Width, _difficultLevel.Height, _difficultLevel.MinesCount);
            
            _dispatcherTimer = new DispatcherTimer();
            _dispatcherTimer.Tick += TickTimer;
            _dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            _dispatcherTimer.Start();
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
                return $"{time.Minutes:00}:{time.Seconds:00}:{time.Milliseconds/10}";
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
                    DifficultLevel = new DifficultLevel { Width = 9, Height = 9, MinesCount = 10 };
                    break;
                case "1":
                    DifficultLevel = new DifficultLevel { Width = 16, Height = 16, MinesCount = 40 };
                    break;
                case "2":
                    DifficultLevel = new DifficultLevel { Width = 30, Height = 16, MinesCount = 99 };
                    break;
            }
        }

        public DifficultLevel LoadSettings()
        {
            var readFileStream = File.Open("settings.cfg", FileMode.Open);
            var deserializer = new BinaryFormatter();
            return (DifficultLevel)deserializer.Deserialize(readFileStream);
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

        private void CheckGameStatus()
        {
            switch (GameStatus)
            {
                case GameStatus.Win:
                    {
                        MessageBox.Show("You Win!");
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

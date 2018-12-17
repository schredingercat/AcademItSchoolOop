using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Minesweeper.Annotations;
using Minesweeper.Lib;

namespace Minesweeper
{
    public class GuiController
    {
        public Field Field { get; }
        
        public DifficultLevel DifficultLevel { get; set; }

        public GuiController(int width, int height, int minesCount)
        {
            try
            {
                DifficultLevel = LoadSettings();
            }
            catch (Exception ex)
            {
                DifficultLevel = new DifficultLevel {Width = 8, Height = 8, MinesCount = 10};
            }

            Field = new Field(DifficultLevel.Width, DifficultLevel.Height, DifficultLevel.MinesCount);
        }

        public GameStatus GameStatus => Field.GameStatus;

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
                serializer.Serialize(saveFileStream, DifficultLevel);
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
        
    }
}

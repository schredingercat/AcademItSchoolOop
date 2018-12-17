using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
            Field = new Field(width, height, minesCount);
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

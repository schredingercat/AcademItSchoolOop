using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Minesweeper.Lib;

namespace Minesweeper
{
    class GuiController
    {
        public Field Field { get; }

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

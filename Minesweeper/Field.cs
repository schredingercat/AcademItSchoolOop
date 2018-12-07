using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Minesweeper
{
    public class Field
    {
        private Cell[,] _cells;


        Field(int columns, int rows)
        {
            _cells = new Cell[columns, rows];
        }

        public void PlaceMines(int minesCount, int firstX, int firstY)
        {
            var columns = _cells.GetLength(0);
            var rows = _cells.GetLength(1);
            var random = new Random();

            while (minesCount > 0)
            {
                var x = random.Next(columns);
                var y = random.Next(rows);

                if (!_cells[x, y].Mine && x != firstX && y != firstY)
                {
                    _cells[x, y].Mine = true;
                    minesCount--;
                }
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper.Lib
{
    public class Field
    {
        private List<List<Cell>> _cells;

        public bool initialized { get; private set; }


        public Field(int columns, int rows)
        {
            _cells = new List<List<Cell>>();
            for (var i = 0; i < rows; i++)
            {
                _cells.Add(new List<Cell>());

                for (var j = 0; j < columns; j++)
                {
                    _cells[i].Add(new Cell());
                }
            }

            PlaceMines(5, 5, 5);

        }

        public List<List<Cell>> Cells
        {
            get { return _cells; }
        }

        public void PlaceMines(int minesCount, int firstX, int firstY)
        {
            var columns = _cells[0].Count;
            var raws = _cells.Count;
            var random = new Random();

            while (minesCount > 0)
            {
                var x = random.Next(columns);
                var y = random.Next(raws);

                if (!_cells[y][x].Mine && x != firstX && y != firstY)
                {
                    _cells[y][x].Mine = true;

                    for (int i = Math.Max(0, x - 1); i <= Math.Min(columns - 1, x + 1); i++)
                    {
                        for (int j = Math.Max(0, y - 1); j <= Math.Min(raws - 1, y + 1); j++)
                        {
                            _cells[j][i].MineCount++;
                        }
                    }

                    minesCount--;
                }
            }

            foreach (var row in _cells)
            {
                foreach (var cell in row)
                {
                    cell.Text = cell.Mine ? "Mine!" : cell.MineCount.ToString();
                }

            }
        }

        public void Refresh()
        {
            var areYouWin = true;
            foreach (var row in _cells)
            {
                foreach (var cell in row)
                {
                    if (cell.Open)
                    {
                        if (cell.Mine)
                        {
                            cell.Text = "Mine";
                            MessageBox.Show("Boom!");
                        }
                        else
                        {
                            cell.Text = cell.MineCount.ToString();
                        }
                    }
                    else
                    {
                        if (cell.Marked)
                        {
                            cell.Text = "?";
                        }
                        else
                        {
                            cell.Text = string.Empty;
                        }

                        if (!cell.Mine)
                        {
                            areYouWin = false;
                        }
                    }

                }

            }

            if (areYouWin)
            {
                MessageBox.Show("You Win!!!");
            }

        }


    }
}

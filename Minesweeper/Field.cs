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

            PlaceMines(2, 5, 5);

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
                    _cells[y][x].Text = "Mine!";
                    minesCount--;

                    try
                    {
                        _cells[y + 1][x + 1].MineCount++;
                        _cells[y + 1][x + 1].MineCount++;
                    }
                    catch (Exception ex)
                    {

                    }

                }
            }
        }





    }
}

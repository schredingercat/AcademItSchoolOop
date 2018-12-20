using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Minesweeper.Lib.Annotations;

namespace Minesweeper.Lib
{
    public class Field:INotifyPropertyChanged
    {
        private List<List<Cell>> _cells;
        
        public GameStatus GameStatus { get; private set; }

        private int _fieldWidth;
        private int _fieldHeight;
        public int MinesCount { get; set; }
        
        public Field(int width, int height, int minesCount)
        {
            _fieldWidth = width;
            _fieldHeight = height;
            MinesCount = minesCount;
            _cells = new List<List<Cell>>();
            for (var i = 0; i < _fieldHeight; i++)
            {
                _cells.Add(new List<Cell>());

                for (var j = 0; j < _fieldWidth; j++)
                {
                    _cells[i].Add(new Cell { X = j, Y = i });
                }
            }

            
            GameStatus = GameStatus.Wait;
        }

        public List<List<Cell>> Cells
        {
            get { return _cells; }
        }

        public int FieldWidth
        {
            get { return _fieldWidth; }
            set
            {
                _fieldWidth = value;
                OnPropertyChanged(nameof(FieldWidth));
            }
        }

        public int FieldHeight
        {
            get { return _fieldHeight; }
            set
            {
                _fieldHeight = value;
                OnPropertyChanged(nameof(FieldHeight));
            }
        }

        public void Open(Cell cell)
        {
            if (GameStatus == GameStatus.Wait)
            {
                PlaceMines(cell.X, cell.Y, MinesCount);
                GameStatus = GameStatus.Playing;
            }
            OpenNearCells(cell);
            Refresh();
        }

        private void OpenNearCells(Cell cell)
        {
            cell.Open = true;
            if (cell.MineCount == 0)
            {
                var nearCells = GetNearCells(cell.X, cell.Y);
                foreach (var curentCell in nearCells)
                {
                    if (!curentCell.Open)
                    {
                        OpenNearCells(curentCell);
                    }
                }
            }
        }

        public void Mark(Cell cell)
        {
            cell.Marked = !cell.Marked;
            Refresh();
        }

        public Cell GetCell(int x, int y)
        {
            return _cells[y][x];
        }

        public List<Cell> GetNearCells(int x, int y)
        {
            var columns = _cells[0].Count;
            var raws = _cells.Count;

            var result = new List<Cell>();

            for (int i = Math.Max(0, x - 1); i <= Math.Min(columns - 1, x + 1); i++)
            {
                for (int j = Math.Max(0, y - 1); j <= Math.Min(raws - 1, y + 1); j++)
                {
                    result.Add(_cells[j][i]);
                }
            }

            return result;
        }

        public void PlaceMines(int firstX, int firstY, int minesCount)
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

                    var nearCells = GetNearCells(x, y);
                    foreach (var cell in nearCells)
                    {
                        cell.MineCount++;
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
                            cell.Text = "Mine!";
                            GameStatus = GameStatus.GameOver;
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
                GameStatus = GameStatus.Win;
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

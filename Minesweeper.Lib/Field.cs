using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Minesweeper.Lib.Annotations;

namespace Minesweeper.Lib
{
    public class Field : INotifyPropertyChanged
    {
        private List<List<Cell>> _cells;

        public GameStatus GameStatus { get; set; }

        private int _fieldWidth;
        private int _fieldHeight;
        private Stopwatch _stopWatch;
        public int MinesCount { get; set; }
        private int _flagsCount;

        public Field(int width, int height, int minesCount)
        {
            _fieldWidth = width;
            _fieldHeight = height;
            MinesCount = minesCount;
            FlagsCount = minesCount;

            _cells = new List<List<Cell>>();

            for (var i = 0; i < _fieldHeight; i++)
            {
                _cells.Add(new List<Cell>());

                for (var j = 0; j < _fieldWidth; j++)
                {
                    _cells[i].Add(new Cell { X = j, Y = i });
                }
            }

            _stopWatch = new Stopwatch();
            GameStatus = GameStatus.Wait;
        }

        public List<List<Cell>> Cells
        {
            get { return _cells; }
        }

        public TimeSpan Time
        {
            get { return _stopWatch.Elapsed; }
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

        public int FlagsCount
        {
            get { return _flagsCount; }
            set
            {
                _flagsCount = value;
                OnPropertyChanged(nameof(FlagsCount));
            }
        }

        public void Open(Cell cell)
        {
            if (GameStatus == GameStatus.Wait)
            {
                PlaceMines(cell.X, cell.Y, MinesCount);
                GameStatus = GameStatus.Playing;
                _stopWatch.Start();
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

        private void OpenAllCells()
        {
            foreach (var raw in _cells)
            {
                foreach (var cell in raw)
                {
                    cell.Open = true;
                }

            }
        }

        public void Mark(Cell cell)
        {
            if (cell.Marked)
            {
                FlagsCount++;
                cell.Marked = false;
            }
            else
            {
                FlagsCount--;
                cell.Marked = true;
            }
            Refresh();
            OnPropertyChanged(nameof(FlagsCount));
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

        public void PlaceMines(int firstX, int firstY, int minesCountInput)
        {
            var columns = _cells[0].Count;
            var raws = _cells.Count;
            var minesCount = minesCountInput;
            var random = new Random();

            while (minesCount > 0)
            {
                var x = random.Next(columns);
                var y = random.Next(raws);

                if (!_cells[y][x].Mine && (x != firstX || y != firstY))
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
                            _stopWatch.Stop();
                            GameStatus = GameStatus.GameOver;
                            OpenAllCells();
                        }

                    }
                    else
                    {
                        if (!cell.Mine)
                        {
                            areYouWin = false;
                        }
                    }

                }

            }

            if (areYouWin)
            {
                _stopWatch.Stop();
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Minesweeper.Lib.Annotations;

namespace Minesweeper.Lib
{
    public class Field : INotifyPropertyChanged
    {
        private List<List<Cell>> _cells;

        private GameStatus _gameStatus;

        private int _fieldWidth;
        private int _fieldHeight;
        private readonly Stopwatch _stopWatch;
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

        public List<List<Cell>> Cells => _cells;

        public GameStatus GameStatus
        {
            get => _gameStatus;
            set
            {
                _gameStatus = value;
                OnPropertyChanged(nameof(GameStatus));
            }
        }

        public TimeSpan Time => _stopWatch.Elapsed;

        public int FieldWidth
        {
            get => _fieldWidth;
            set
            {
                _fieldWidth = value;
                OnPropertyChanged(nameof(FieldWidth));
            }
        }

        public int FieldHeight
        {
            get => _fieldHeight;
            set
            {
                _fieldHeight = value;
                OnPropertyChanged(nameof(FieldHeight));
            }
        }

        public int FlagsCount
        {
            get => _flagsCount;
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

        public void OpenAroundCells(Cell cell)
        {
            if (!cell.IsOpen)
            {
                return;
            }

            var aroundCloseCells = GetNearCells(cell.X, cell.Y).Where(n => !n.IsOpen).ToList();

            if (aroundCloseCells.Count(n => n.IsMarked) != cell.MineCount)
            {
                return;
            }

            var cellsToOpen = aroundCloseCells.Where(n => !n.IsMarked).ToList();

            foreach (var cellToOpen in cellsToOpen)
            {
                Open(cellToOpen);
            }
        }

        private void OpenNearCells(Cell cell)
        {
            if (cell.IsMarked)
            {
                cell.IsMarked = false;
                FlagsCount++;
            }

            cell.IsOpen = true;

            if (cell.MineCount != 0) return;
            var nearCells = GetNearCells(cell.X, cell.Y);

            foreach (var currentCell in nearCells)
            {
                if (!currentCell.IsOpen)
                {
                    OpenNearCells(currentCell);
                }
            }
        }

        private void OpenAllCells()
        {
            foreach (var raw in _cells)
            {
                foreach (var cell in raw)
                {
                    cell.IsOpen = true;
                }
            }
        }

        public void Mark(Cell cell)
        {
            if (cell.IsOpen)
            {
                return;
            }

            if (cell.IsMarked)
            {
                FlagsCount++;
                cell.IsMarked = false;
            }
            else
            {
                FlagsCount--;
                cell.IsMarked = true;
            }
            Refresh();
            OnPropertyChanged(nameof(FlagsCount));
        }

        public List<Cell> GetNearCells(int x, int y)
        {
            var columns = _cells[0].Count;
            var rows = _cells.Count;

            var result = new List<Cell>();

            for (int i = Math.Max(0, x - 1); i <= Math.Min(columns - 1, x + 1); i++)
            {
                for (int j = Math.Max(0, y - 1); j <= Math.Min(rows - 1, y + 1); j++)
                {
                    result.Add(_cells[j][i]);
                }
            }

            return result;
        }

        public void PlaceMines(int firstX, int firstY, int minesCountInput)
        {
            var columns = _cells[0].Count;
            var rows = _cells.Count;
            var minesCount = minesCountInput;
            var random = new Random();

            while (minesCount > 0)
            {
                var x = random.Next(columns);
                var y = random.Next(rows);

                if (!_cells[y][x].IsMine && (x != firstX || y != firstY))
                {
                    _cells[y][x].IsMine = true;

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
                    if (cell.IsOpen)
                    {
                        if (cell.IsMine)
                        {
                            _stopWatch.Stop();
                            OpenAllCells();
                            GameStatus = GameStatus.GameOver;
                            return;
                        }
                    }
                    else
                    {
                        if (!cell.IsMine)
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
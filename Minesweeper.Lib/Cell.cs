using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Minesweeper.Lib.Annotations;

namespace Minesweeper.Lib
{
    public class Cell : INotifyPropertyChanged
    {
        private bool _isMine;
        private bool _isOpen;
        private bool _isMarked;
        public int MineCount { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Cell()
        {
            IsMine = false;
            IsOpen = false;
        }

        public bool IsMine
        {
            get { return _isMine; }
            set
            {
                _isMine = value;
                OnPropertyChanged(nameof(IsMine));
            }
        }

        public bool IsOpen
        {
            get { return _isOpen; }
            set
            {
                _isOpen = value;
                OnPropertyChanged(nameof(IsOpen));
                OnPropertyChanged(nameof(Status));
            }
        }

        public bool IsMarked
        {
            get { return _isMarked; }
            set
            {
                _isMarked = value;
                OnPropertyChanged(nameof(IsMarked));
                OnPropertyChanged(nameof(Status));
            }
        }

        public CellStatus Status
        {
            get
            {
                if (!IsOpen)
                {
                    return IsMarked ? CellStatus.Marked : CellStatus.Hidden;
                }

                if (IsMine)
                {
                    return CellStatus.Mine;
                }

                switch (MineCount)
                {
                    case 0: return CellStatus.Number0;
                    case 1: return CellStatus.Number1;
                    case 2: return CellStatus.Number2;
                    case 3: return CellStatus.Number3;
                    case 4: return CellStatus.Number4;
                    case 5: return CellStatus.Number5;
                    case 6: return CellStatus.Number6;
                    case 7: return CellStatus.Number7;
                    case 8: return CellStatus.Number8;
                }

                return CellStatus.Hidden;
            }

        }

        public override string ToString()
        {
            if (!IsOpen)
            {
                return IsMarked ? "?" : "■";
            }

            return IsMine ? "☼" : MineCount.ToString();
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

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
        private bool _mine;
        private bool _open;
        private bool _marked;
        private string _text;
        public int MineCount { get; set; }
        public int X { get; set; }
        public int Y { get; set; }


        public Cell()
        {
            Text = string.Empty;
            Mine = false;
            Open = false;
        }

        public bool Mine
        {
            get { return _mine; }
            set
            {
                _mine = value;
                OnPropertyChanged(nameof(Mine));
            }
        }

        public bool Open
        {
            get { return _open; }
            set
            {
                _open = value;
                OnPropertyChanged(nameof(Open));
                OnPropertyChanged(nameof(Status));
            }
        }

        public bool Marked
        {
            get { return _marked; }
            set
            {
                _marked = value;
                OnPropertyChanged(nameof(Marked));
                OnPropertyChanged(nameof(Status));
            }
        }

        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                OnPropertyChanged(nameof(Text));
                OnPropertyChanged(nameof(Status));
            }
        }

        public CellStatus Status
        {
            get
            {
                if (!Open)
                {
                    if (Marked)
                    {
                        return CellStatus.Marked;
                    }

                    return CellStatus.Hidden;
                }

                if (Mine)
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


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

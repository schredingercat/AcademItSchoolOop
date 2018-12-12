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
            }
        }

        public bool Marked
        {
            get { return _marked; }
            set
            {
                _marked = value;
                OnPropertyChanged(nameof(Marked));
            }
        }

        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                OnPropertyChanged(nameof(Text));
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

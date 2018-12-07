using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class Cell
    {
        public bool Mine { get; set; }
        public bool Open { get; set; }
        public bool Marked { get; set; }
        public string Text { get; set; }

        public Cell()
        {
            Text = string.Empty;
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Lib
{
    [Serializable]
    public class DifficultLevel
    {
        public string Name { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int MinesCount { get; set; }
    }
}

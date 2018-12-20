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
    [Serializable]
    public class DifficultLevel
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int MinesCount { get; set; }
    }
}

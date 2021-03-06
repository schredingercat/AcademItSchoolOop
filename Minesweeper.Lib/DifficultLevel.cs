﻿using System;

namespace Minesweeper.Lib
{
    [Serializable]
    public class DifficultLevel : IComparable<DifficultLevel>
    {
        public string Name { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int MinesCount { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public int CompareTo(DifficultLevel obj)
        {
            if (obj is DifficultLevel difficultLevel)
            {
                return MinesCount.CompareTo(difficultLevel.MinesCount);
            }

            throw new Exception("Невозможно сравнить объекты");
        }
    }
}
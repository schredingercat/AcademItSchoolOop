using System;

namespace Minesweeper.Lib
{
    [Serializable]
    public class Score
    {
        public string Name { get; set; }
        public TimeSpan Time { get; set; }
        public DifficultLevel DifficultLevel { get; set; }

        public Score()
        {
            Name = "Empty";
            Time = new TimeSpan(0);
            DifficultLevel = new DifficultLevel();
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Lib
{
    public static class FileOperations
    {
        public static DifficultLevel LoadSettings(DifficultLevel defaultDifficultLevel)
        {
            DifficultLevel difficultLevel;
            try
            {
                using (var readFileStream = File.Open("settings.cfg", FileMode.Open))
                {
                    var deserializer = new BinaryFormatter();
                    difficultLevel = (DifficultLevel)deserializer.Deserialize(readFileStream);
                }
            }
            catch (Exception)
            {
                difficultLevel = defaultDifficultLevel;
            }

            return difficultLevel;
        }

        public static void SaveSettings(DifficultLevel difficultLevel)
        {
            using (var saveFileStream = File.Create("settings.cfg"))
            {
                var serializer = new BinaryFormatter();
                serializer.Serialize(saveFileStream, difficultLevel);
            }
        }

        public static List<Score> LoadScores(DifficultLevel defaultDifficultLevel)
        {
            var highScores = new List<Score>();
            try
            {
                using (var readFileStream = File.Open("highscores.dat", FileMode.Open))
                {
                    var deserializer = new BinaryFormatter();
                    highScores = (List<Score>)deserializer.Deserialize(readFileStream);
                }
            }
            catch (Exception)
            {
                highScores.Add(new Score { Name = "John Smith", Time = new TimeSpan(0, 0, 0, 2, 15), DifficultLevel = defaultDifficultLevel });
            }
            return highScores;
        }

        public static void SaveScores(List<Score> highScores)
        {
            using (var saveFileStream = File.Create("highscores.dat"))
            {
                var serializer = new BinaryFormatter();
                serializer.Serialize(saveFileStream, highScores);
            }
        }
    }
}

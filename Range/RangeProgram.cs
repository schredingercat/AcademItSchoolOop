using System;
using System.Globalization;

namespace Range
{
    class RangeProgram
    {
        static void Main()
        {
            Console.WriteLine("Введите начало первого диапазона");
            bool range1FromIsCorrect = double.TryParse(Console.ReadLine()?.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double range1From);

            Console.WriteLine("Введите конец первого диапазона");
            bool range1ToIsCorrect = double.TryParse(Console.ReadLine()?.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double range1To);

            Console.WriteLine("Введите начало второго диапазона");
            bool range2FromIsCorrect = double.TryParse(Console.ReadLine()?.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double range2From);

            Console.WriteLine("Введите конец второго диапазона");
            bool range2ToIsCorrect = double.TryParse(Console.ReadLine()?.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double range2To);

            Console.WriteLine("Введите вещественное число");
            bool pointIsCorrect = double.TryParse(Console.ReadLine()?.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double point);

            if (!range1FromIsCorrect || !range1ToIsCorrect || !range2FromIsCorrect || !range2ToIsCorrect || !pointIsCorrect)
            {
                Console.WriteLine("Введены некорректные данные");
                Console.ReadLine();
                return;
            }

            Range range1 = new Range(range1From, range1To);
            Range range2 = new Range(range2From, range2To);

            Console.WriteLine();
            Console.WriteLine($"Длина первого диапазона ({range1.From} - {range1.To}): {range1.GetLength()}");
            Console.WriteLine($"Длина второго диапазона ({range2.From} - {range2.To}): {range2.GetLength()}");

            Console.WriteLine();
            Console.WriteLine($"Число {point} {(range1.IsInside(point) ? "входит" : "не входит")} в диапазон {range1.From} - {range1.To}");
            Console.WriteLine($"Число {point} {(range2.IsInside(point) ? "входит" : "не входит")} в диапазон {range2.From} - {range2.To}");

            Console.WriteLine();
            var crossRange = Range.GetCrossRange(range1, range2);
            Console.WriteLine(crossRange != null ? $"Диапазоны пересекаются на интервале от {crossRange.From} до {crossRange.To}" : "Диапазоны не пересекаются");

            Console.WriteLine();
            Console.WriteLine("Объединение диапазонов:");
            var mergedRanges = Range.MergeRanges(range1, range2);
            foreach (var range in mergedRanges)
            {
                Console.WriteLine($"     интервал от {range.From} до {range.To}");
            }

            Console.WriteLine();
            Console.WriteLine("Вычитание второго диапазона из первого:");
            var subtractedRanges = Range.SubtractRanges(range1, range2);

            foreach (var range in subtractedRanges)
            {
                Console.WriteLine($"     интервал от {range.From} до {range.To}");
            }

            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;

namespace Range
{
    class Range
    {
        public double From { get; }
        public double To { get; }

        public Range(double from, double to)
        {
            From = Math.Min(from, to);
            To = Math.Max(from, to);
        }

        public double GetLength()
        {
            return To - From;
        }

        public bool IsInside(double point)
        {
            return ((From <= point) && (point <= To));
        }

        public static Range GetCrossRange(Range range1, Range range2)
        {
            Range firstRange;
            Range lastRange;
            if (range1.From <= range2.From)
            {
                firstRange = range1;
                lastRange = range2;
            }
            else
            {
                firstRange = range2;
                lastRange = range1;
            }

            if (firstRange.To <= lastRange.From)
            {
                return null;
            }
            else
            {
                return new Range(lastRange.From, Math.Min(firstRange.To, lastRange.To));
            }
        }

        public static List<Range> MergeRanges(Range range1, Range range2)
        {
            Range firstRange;
            Range lastRange;
            if (range1.From <= range2.From)
            {
                firstRange = range1;
                lastRange = range2;
            }
            else
            {
                firstRange = range2;
                lastRange = range1;
            }

            var ranges = new List<Range>();

            if (firstRange.To < lastRange.From)
            {
                ranges.Add(new Range(firstRange.From, firstRange.To));
                ranges.Add(new Range(lastRange.From, lastRange.To));
            }
            else
            {
                ranges.Add(new Range(firstRange.From, Math.Max(firstRange.To, lastRange.To)));
            }

            return ranges;
        }

        public static List<Range> SubtractRanges(Range range1, Range range2)
        {
            var ranges = new List<Range>();

            if (range1.From >= range2.To || range1.To <= range2.From)
            {
                ranges.Add(new Range(range1.From, range1.To));
                return ranges;
            }

            if (range1.From < range2.From)
            {
                ranges.Add(new Range(range1.From, range2.From));
                if (range1.To > range2.To)
                {
                    ranges.Add(new Range(range2.To, range1.To));
                }
            }
            else
            {
                if (range1.To > range2.To)
                {
                    ranges.Add(new Range(range2.To, range1.To));
                }
            }

            return ranges;
        }
    }
}

using System.Collections.Generic;

namespace Shapes.Comparers
{
    class AreaComparer : IComparer<IShape>
    {
        public int Compare(IShape shape1, IShape shape2)
        {
            return (shape1 != null && shape2 != null) ? shape2.GetArea().CompareTo(shape1.GetArea()) : 0;
        }
    }
}
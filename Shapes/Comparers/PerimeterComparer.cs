using System.Collections.Generic;

namespace Shapes.Comparers
{
    class PerimeterComparer : IComparer<IShape>
    {
        public int Compare(IShape shape1, IShape shape2)
        {
            return (shape1 != null && shape2 != null) ? shape2.GetPerimeter().CompareTo(shape1.GetPerimeter()) : 0;
        }
    }
}
﻿using System.Collections.Generic;

namespace Shapes.Comparers
{
    class PerimeterComparer : IComparer<IShape>
    {
        public int Compare(IShape shape1, IShape shape2)
        {
            if (shape1 == null && shape2 == null)
            {
                return 0;
            }

            if (shape1 == null)
            {
                return 1;
            }

            if (shape2 == null)
            {
                return -1;
            }

            return shape2.GetPerimeter().CompareTo(shape1.GetPerimeter());
        }
    }
}
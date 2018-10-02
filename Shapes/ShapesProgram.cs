using System;
using System.Collections.Generic;

namespace Shapes
{
    class ShapesProgram
    {
        static void Main()
        {
            var shapes = new List<IShape>
            {
                new Square(3),
                new Square(5),

                new Rectangle(10, 5),
                new Rectangle(13, 2.4),
                new Rectangle(3, 5),

                new Triangle(0, 0, 2, 3, 5, 4),
                new Triangle(3, 2, 5, 7, 8, 1),

                new Circle(2.9),
                new Circle(4.1),
                new Circle(0)
            };

            var firstAreaShape = FindByMaxArea(shapes, 0);
            Console.WriteLine($"Первая по площади фигура: {firstAreaShape}");
            var secondAreaShape = FindByMaxArea(shapes, 1);
            Console.WriteLine($"Вторая по площади фигура: {secondAreaShape}");

            Console.WriteLine();
            var firstPerimeterShape = FindByMaxPerimeter(shapes, 0);
            Console.WriteLine($"Первая по периметру фигура: {firstPerimeterShape}");
            var secondPerimeterShape = FindByMaxPerimeter(shapes, 1);
            Console.WriteLine($"Вторая по периметру фигура: {secondPerimeterShape}");

            Console.WriteLine();
            Console.WriteLine("Сравнение фигур с помощью переопределенного метода Equals:");
            var circle1 = new Circle(2.4);
            var circle2 = new Circle(3.87);
            var circle3 = new Circle(2.4);
            var square1 = new Square(2.4);

            Console.WriteLine($"{nameof(circle1)} - {circle1}");
            Console.WriteLine($"{nameof(circle2)} - {circle2}");
            Console.WriteLine($"{nameof(circle3)} - {circle3}");
            Console.WriteLine($"{nameof(square1)} - {square1}");

            Console.WriteLine();
            Console.WriteLine($"Фигура {nameof(circle2)} {(circle1.Equals(circle2) ? "равна" : "не равна")} фигуре {nameof(circle1)}");
            Console.WriteLine($"Фигура {nameof(circle3)} {(circle1.Equals(circle3) ? "равна" : "не равна")} фигуре {nameof(circle1)}");
            Console.WriteLine($"Фигура {nameof(square1)} {(circle1.Equals(square1) ? "равна" : "не равна")} фигуре {nameof(circle1)}");

            Console.ReadLine();
        }

        public static IShape FindByMaxArea(List<IShape> shapes, int index)
        {
            shapes.Sort(new AreaComparer());
            if (index >= 0 && shapes.Count > index)
            {
                return shapes[index];
            }
            else
            {
                return null;
            }
        }

        public static IShape FindByMaxPerimeter(List<IShape> shapes, int index)
        {
            shapes.Sort(new PerimeterComparer());
            if (index >= 0 && shapes.Count > index)
            {
                return shapes[index];
            }
            else
            {
                return null;
            }
        }
    }
}

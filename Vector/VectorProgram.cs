using System;

namespace Vector
{
    class VectorProgram
    {
        static void Main()
        {
            var vector1 = new Vector(3);
            Console.WriteLine($"Вектор 1: {vector1}");

            var vector2 = new Vector(new double[] { 2.3, 4.5, 7 });
            Console.WriteLine($"Вектор 2: {vector2}");

            var vector3 = new Vector(vector2);
            Console.WriteLine($"Вектор 3: {vector3}");

            Vector vector4 = new Vector(8, new double[] { 1, 5, 0, 8 });
            Console.WriteLine($"Вектор 4: {vector4}");

            Console.WriteLine();
            try
            {
                var invalidVector = new Vector(-7);
                Console.WriteLine(invalidVector);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Попытка передать в конструктор некорректные аргументы: {ex.Message}");
            }

            Console.WriteLine();
            Console.Write($"{vector1} + {vector2} = ");
            vector1.Add(vector2);
            Console.WriteLine(vector1);

            Console.WriteLine();
            Console.Write($"{vector1} - {vector4} = ");
            vector1.Subtract(vector4);
            Console.WriteLine(vector1);

            Console.WriteLine();
            Console.Write($"{vector1} * 6.5 = ");
            vector1.Multiply(6.5);
            Console.WriteLine(vector1);

            Console.WriteLine();
            Console.Write($"Инверсия вектора {vector1} : ");
            vector1.Invert();
            Console.WriteLine(vector1);

            Console.WriteLine();
            Console.WriteLine($"Длина вектора {vector1} равна {vector1.GetLength()}");

            Console.WriteLine();
            Console.Write($"Второй компоненте вектора {vector1} присваивается 5.9 ");
            vector1[1] = 5.9;
            Console.WriteLine(vector1);
            Console.WriteLine($"Теперь вторая компонента вектора равна {vector1[1]}");

            Console.WriteLine();
            try
            {
                Console.WriteLine(vector1[-5]);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Попытка обратиться к несуществующей компоненте вектора: {ex.Message}");
            }

            Console.WriteLine();
            Console.WriteLine($"Вектор {vector2} {(vector2.Equals(vector1) ? "равен" : "не равен")} вектору {vector1}");
            Console.WriteLine($"Вектор {vector2} {(vector2.Equals(vector3) ? "равен" : "не равен")} вектору {vector3}");

            Console.WriteLine();
            Console.WriteLine($"{vector1} + {vector2} = {Vector.Add(vector1, vector2)}");
            Console.WriteLine($"{vector1} - {vector3} = {Vector.Subtract(vector1, vector3)}");
            Console.WriteLine($"({vector1}, {vector2} ) = {Vector.ScalarProduct(vector1, vector2)}");

            Console.ReadLine();
        }
    }
}
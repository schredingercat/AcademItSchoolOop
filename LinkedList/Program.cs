using System;

namespace LinkedList
{
    class Program
    {
        static void Main()
        {
            var list = new SinglyLinkedList<string>();

            list.Add("Abc");
            list.Add("14");
            list.Add("Ef");
            list.Add("G67");
            list.Add("abcdefg");

            Console.WriteLine("Элементы списка:");
            Console.WriteLine(list);

            Console.WriteLine();
            Console.WriteLine("Получение первого элемента:");
            Console.WriteLine(list.GetFirstItemValue());

            Console.WriteLine();
            Console.WriteLine($"Элементу с индексом {2} вместо {list.SetValueAtIndex("42", 2)} присвоено значение {42}:");
            Console.WriteLine(list);
            Console.WriteLine($"Теперь значение равно {list.GetValueAtIndex(2)}");

            Console.WriteLine();
            Console.WriteLine($"Из списка удален элемент {list.RemoveAtIndex(3)} с индексом {3}:");
            Console.WriteLine(list);

            Console.WriteLine();
            list.AddToTop("XYZ");
            Console.WriteLine("В начало списка вставляется элемент XYZ:");
            Console.WriteLine(list);

            Console.WriteLine();
            list.Insert("Index", 3);
            Console.WriteLine($"По индексу {3} вставлен элемент Index:");
            Console.WriteLine(list);

            Console.WriteLine();
            Console.WriteLine($"Элемент Index {(list.RemoveByValue("Index") ? "удален из списка" : "отсутствует в списке")}:");
            Console.WriteLine(list);
            Console.WriteLine();
            Console.WriteLine($"Элемент Hello World! {(list.RemoveByValue("Hello World") ? "удален из списка" : "отсутствует в списке")}:");
            Console.WriteLine(list);

            Console.WriteLine();
            Console.WriteLine($"Первый элемент {list.RemoveFirstItem()} удален из списка:");
            Console.WriteLine(list);

            Console.WriteLine();
            Console.WriteLine("Разворот списка");
            list.Invert();
            Console.WriteLine(list);

            Console.WriteLine();
            Console.WriteLine("Копирование списка:");
            var newList = list.Copy();
            Console.WriteLine(newList);

            Console.ReadLine();
        }
    }
}
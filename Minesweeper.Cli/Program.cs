using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            var controller = new CliController();
            Console.OutputEncoding = Encoding.UTF8;

            ShowGameField(controller);
            Console.ReadLine();
        }


        public static void ShowGameField(CliController controller)
        {
            var width = controller.FieldWidth;
            var height = controller.FieldHeight;

            Console.Clear();
            Console.Write("     ");
            for (int i = 0; i < width; i++)
            {
                Console.Write( $"{i + 1}  ");
            }
            Console.WriteLine();
            Console.Write("     ");
            for (int i = 0; i < width; i++)
            {
                Console.Write("|  ");
            }
            Console.WriteLine();

            foreach (var row in controller.Field.Cells)
            {
                Console.Write($"{controller.Field.Cells.IndexOf(row)+1: ,##} - ");
                foreach (var cell in row)
                {
                    Console.Write($"{cell}  ");
                }
                Console.WriteLine();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Minesweeper.Lib;

namespace Minesweeper.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            var controller = new CliController();
            Console.OutputEncoding = Encoding.UTF8;

            ShowGameField(controller);

            while (controller.GameStatus!= GameStatus.GameOver || controller.GameStatus != GameStatus.Win)
            {
                OpenCell(controller, Console.ReadLine());
            }
            
        }

        public static void OpenCell(CliController controller, string input)
        {
            input = input.ToUpper();
            var x = input[0] - 65;
            var y = int.Parse(input[1].ToString())-1;
            controller.Open(controller.Field.Cells[y][x]);
            ShowGameField(controller);
        }


        public static void ShowGameField(CliController controller)
        {
            var width = controller.FieldWidth;
            var height = controller.FieldHeight;

            Console.Clear();
            Console.Write("     ");
            for (int i = 0; i < width; i++)
            {
                Console.Write( $"{Convert.ToChar(i + 65) }  ");
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

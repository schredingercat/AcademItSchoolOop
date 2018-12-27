using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Minesweeper.Lib;

namespace Minesweeper.Cli
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            var controller = new CliController();

            while (true)
            {
                switch (ShowMainMenu())
                {
                    case MenuItems.NewGame:
                        StastNewGame(controller);
                        break;
                    case MenuItems.Exit:
                        return;
                }
                
            }

        }

        public static void StastNewGame(CliController controller)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;

            ShowGameField(controller);

            while (controller.GameStatus == GameStatus.Playing || controller.GameStatus == GameStatus.Wait)
            {
                OpenCell(controller, Console.ReadLine());
            }

            Console.ReadLine();
        }

        public static MenuItems ShowMainMenu()
        {
            var selectedMenuItem = MenuItems.NewGame;

            Console.Clear();
            Console.WriteLine("   Minesweeper");
            Console.WriteLine();
            Console.WriteLine();

            while (true)
            {
                Console.SetCursorPosition(0, 3);
                Console.WriteLine($"  {(selectedMenuItem == MenuItems.NewGame ? "☼" : " ")}  New Game");
                Console.WriteLine($"  {(selectedMenuItem == MenuItems.HightScores ? "☼" : " ")}  High Scores");
                Console.WriteLine($"  {(selectedMenuItem == MenuItems.Settings ? "☼" : " ")}  Settings");
                Console.WriteLine($"  {(selectedMenuItem == MenuItems.About ? "☼" : " ")}  About");
                Console.WriteLine($"  {(selectedMenuItem == MenuItems.Exit ? "☼" : " ")}  Exit");
                var key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        if (selectedMenuItem == 0)
                        {
                            selectedMenuItem = Enum.GetValues(typeof(MenuItems)).Cast<MenuItems>().LastOrDefault();
                        }
                        else
                        {
                            selectedMenuItem--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (selectedMenuItem == Enum.GetValues(typeof(MenuItems)).Cast<MenuItems>().LastOrDefault())
                        {
                            selectedMenuItem = 0;
                        }
                        else
                        {
                            selectedMenuItem++;
                        }
                        break;
                    case ConsoleKey.Enter:
                        return selectedMenuItem;
                }

            }

        }



        public static void OpenCell(CliController controller, string input)
        {
            var command = input.ToUpper();
            var isMarkCommand = false;

            if (command[0].ToString() == "?")
            {
                isMarkCommand = true;
                command = command.Substring(1, command.Length - 1);
            }

            var x = command[0] - 65;
            var y = int.Parse(command[1].ToString()) - 1;

            var cell = controller.Field.Cells[y][x];

            if (isMarkCommand)
            {
                controller.Mark(cell);
            }
            else
            {
                controller.Open(cell);
            }

            ShowGameField(controller);
        }

        public static void ShowGameField(CliController controller)
        {
            var width = controller.FieldWidth;
            var height = controller.FieldHeight;

            Console.Clear();
            Console.Write("               ");
            for (int i = 0; i < width; i++)
            {
                Console.Write($"{Convert.ToChar(i + 65) }  ");
            }
            Console.WriteLine();
            Console.Write("               ");
            for (int i = 0; i < width; i++)
            {
                Console.Write("|  ");
            }
            Console.WriteLine();

            foreach (var row in controller.Field.Cells)
            {
                Console.Write($"          {controller.Field.Cells.IndexOf(row) + 1: ,##} - ");
                foreach (var cell in row)
                {
                    Console.ForegroundColor = CliController.CellColors[cell.Status];
                    Console.Write($"{cell}  ");

                    Console.ResetColor();
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;

                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Введите координаты ячейки, чтобы открыть её (например С5)");
            Console.WriteLine("?С5 чтобы пометить");
            Console.WriteLine();
        }
    }
}

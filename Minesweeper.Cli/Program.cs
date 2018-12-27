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
            Console.CursorVisible = false;
            var controller = new CliController();

            while (true)
            {
                switch (ShowMainMenu(controller))
                {
                    case MenuItems.NewGame:
                        StartNewGame(controller);
                        break;
                    case MenuItems.HightScores:
                        ShowHighScores(controller);
                        break;
                    case MenuItems.Settings:
                        ChangeDifficultLevel(controller);
                        break;
                    case MenuItems.Exit:
                        return;
                }
                
            }

        }

        public static void StartNewGame(CliController controller)
        {
            Console.CursorVisible = true;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;

            ShowGameField(controller);

            while (controller.GameStatus == GameStatus.Playing || controller.GameStatus == GameStatus.Wait)
            {
                OpenCell(controller, Console.ReadLine());
            }

            Console.ReadKey();
            Console.CursorVisible = false;
        }

        public static void ShowHighScores(CliController controller)
        {
            Console.Clear();
            Console.WriteLine("   High Scores");
            Console.WriteLine();
            Console.WriteLine();

            var scores = controller.HighScores;
            var visibleScoresCount = Math.Min(10, scores.Count);
            
            for(int i = 0; i< visibleScoresCount; i++)
            {
                Console.WriteLine($"  {scores[i].Name} - " +
                                  $"{scores[i].Time.Minutes:00}:{scores[i].Time.Seconds:00}:{scores[i].Time.Milliseconds / 10:00} - " +
                                  $"{scores[i].DifficultLevel}");
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to exit to main menu...");

            Console.ReadKey();
        }

        public static void ChangeDifficultLevel(CliController controller)
        {
            controller.SetDifficultLevel(controller.DifficultLevel.ToString() == "Easy" ? "2" : "0");
            controller.SaveSettings();
        }

        public static MenuItems ShowMainMenu(CliController controller)
        {
            Console.Clear();
            Console.WriteLine("   Minesweeper");
            Console.WriteLine();
            Console.WriteLine();

            while (true)
            {
                Console.SetCursorPosition(0, 3);
                Console.WriteLine($"  {(controller.SelectedMenuItem == MenuItems.NewGame ? "☼" : " ")}  New Game");
                Console.WriteLine($"  {(controller.SelectedMenuItem == MenuItems.HightScores ? "☼" : " ")}  High Scores");
                Console.WriteLine($"  {(controller.SelectedMenuItem == MenuItems.Settings ? "☼" : " ")}  Difficult level: {controller.DifficultLevel}");
                Console.WriteLine($"  {(controller.SelectedMenuItem == MenuItems.About ? "☼" : " ")}  About");
                Console.WriteLine($"  {(controller.SelectedMenuItem == MenuItems.Exit ? "☼" : " ")}  Exit");
                var key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        if (controller.SelectedMenuItem == 0)
                        {
                            controller.SelectedMenuItem = Enum.GetValues(typeof(MenuItems)).Cast<MenuItems>().LastOrDefault();
                        }
                        else
                        {
                            controller.SelectedMenuItem--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (controller.SelectedMenuItem == Enum.GetValues(typeof(MenuItems)).Cast<MenuItems>().LastOrDefault())
                        {
                            controller.SelectedMenuItem = 0;
                        }
                        else
                        {
                            controller.SelectedMenuItem++;
                        }
                        break;
                    case ConsoleKey.Enter:
                        return controller.SelectedMenuItem;
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
                Console.Write($"          {controller.Field.Cells.IndexOf(row) + 1, 2} - ");
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

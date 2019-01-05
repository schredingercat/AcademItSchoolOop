using System;
using System.Text;
using Minesweeper.Lib;

namespace Minesweeper.Cli
{
    class Program
    {
        static void Main()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetWindowSize(120, 30);
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;
            var controller = new CliController();

            while (true)
            {
                switch (Menu.ShowMainMenu(controller))
                {
                    case MainMenuItems.NewGame:
                        StartNewGame();
                        break;
                    case MainMenuItems.HighScores:
                        Menu.ShowHighScores(controller);
                        break;
                    case MainMenuItems.Settings:
                        Menu.ShowSettingsMenu(controller);
                        break;
                    case MainMenuItems.About:
                        Menu.ShowAbout();
                        break;
                    case MainMenuItems.Exit:
                        return;
                }
            }
        }

        public static void StartNewGame()
        {
            var controller = new CliController();
            Console.CursorVisible = true;

            ShowGameField(controller);

            while (controller.GameStatus == GameStatus.Playing || controller.GameStatus == GameStatus.Wait)
            {
                var input = Console.ReadLine()?.ToUpper();

                if (input == "EXIT")
                {
                    Console.CursorVisible = false;
                    return;
                }

                if (!controller.TryExecuteCommand(input))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong input!");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.ReadLine();
                }
                ShowGameField(controller);
            }

            Console.CursorVisible = false;

            if (controller.GameStatus == GameStatus.GameOver)
            {
                Console.ReadKey(true);
            }
        }

        public static void ShowGameField(CliController controller)
        {
            var width = controller.FieldWidth;
            var extraChars = new[] { '@', '#', '$', '%' };

            Console.Clear();
            Console.Write("               ");
            for (int i = 0; i < width; i++)
            {
                Console.Write(i < 26 ? $"{Convert.ToChar(i + 65)}  " : $"{extraChars[i - 26]}  ");
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
                Console.Write($"          {controller.Field.Cells.IndexOf(row) + 1,2} - ");
                foreach (var cell in row)
                {
                    Console.ForegroundColor = CliController.CellColors[cell.Status];
                    Console.Write($"{cell}  ");
                }
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write($"- {controller.Field.Cells.IndexOf(row) + 1,2}");
                Console.WriteLine();
            }
            Console.WriteLine();
            if (controller.GameStatus != GameStatus.GameOver)
            {
                Console.WriteLine("  To open a cell, enter its coordinates ('B7' for example)");
                Console.WriteLine("  To mark a cell, enter its coordinates with '?' prefix ('?B7')");
                Console.WriteLine("  To exit enter 'Exit'");
            }
            Console.WriteLine();
        }
    }
}
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
                switch (Menu.ShowMainMenu(controller))
                {
                    case MainMenuItems.NewGame:
                        StartNewGame();
                        break;
                    case MainMenuItems.HightScores:
                        Menu.ShowHighScores(controller);
                        break;
                    case MainMenuItems.Settings:
                        Menu.ShowSettingsMenu(controller);
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
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;

            ShowGameField(controller);

            while (controller.GameStatus == GameStatus.Playing || controller.GameStatus == GameStatus.Wait)
            {
                //OpenCell(controller, Console.ReadLine());
                if (!controller.TryExecuteCommand(Console.ReadLine()))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Неверный ввод!");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.ReadLine();
                }
                ShowGameField(controller);
            }

            Console.ReadKey();
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        

        public static void ChangeDifficultLevel(CliController controller)
        {
            switch(controller.DifficultLevel.ToString())
            {
                case "Easy":
                    controller.SetDifficultLevel("1");
                    break;
                case "Medium":
                    controller.SetDifficultLevel("2");
                    break;
                case "Hard":
                    controller.SetDifficultLevel("0");
                    break;
            }
            controller.SaveSettings();
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
            Console.WriteLine("  Введите координаты ячейки, чтобы открыть её (например 'B7')");
            Console.WriteLine("  Чтобы пометить ячейку, поставьте перед координатами знак вопроса ('?B7')");
            Console.WriteLine("  Для завершения игры введите 'Exit'");
            Console.WriteLine();
        }
    }
}

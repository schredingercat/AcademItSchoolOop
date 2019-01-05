using System;
using System.Linq;

namespace Minesweeper.Cli
{
    public static class Menu
    {
        public static MainMenuItems ShowMainMenu(CliController controller)
        {
            Console.Clear();
            Console.Title = "Minesweeper";
            Console.WriteLine("   Minesweeper");
            Console.WriteLine();
            Console.WriteLine();

            while (true)
            {
                Console.SetCursorPosition(0, 3);
                Console.WriteLine($"  {(controller.SelectedMainMenuItem == MainMenuItems.NewGame ? "☼" : " ")}  New Game");
                Console.WriteLine($"  {(controller.SelectedMainMenuItem == MainMenuItems.HighScores ? "☼" : " ")}  High Scores");
                Console.WriteLine($"  {(controller.SelectedMainMenuItem == MainMenuItems.Settings ? "☼" : " ")}  Settings");
                Console.WriteLine($"  {(controller.SelectedMainMenuItem == MainMenuItems.About ? "☼" : " ")}  About");
                Console.WriteLine($"  {(controller.SelectedMainMenuItem == MainMenuItems.Exit ? "☼" : " ")}  Exit");
                var key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        if (controller.SelectedMainMenuItem == 0)
                        {
                            controller.SelectedMainMenuItem = Enum.GetValues(typeof(MainMenuItems)).Cast<MainMenuItems>().LastOrDefault();
                        }
                        else
                        {
                            controller.SelectedMainMenuItem--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (controller.SelectedMainMenuItem == Enum.GetValues(typeof(MainMenuItems)).Cast<MainMenuItems>().LastOrDefault())
                        {
                            controller.SelectedMainMenuItem = 0;
                        }
                        else
                        {
                            controller.SelectedMainMenuItem++;
                        }
                        break;
                    case ConsoleKey.Enter:
                        return controller.SelectedMainMenuItem;
                }

            }

        }

        public static void ShowHighScores(CliController controller)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("   High Scores");
                Console.WriteLine();
                Console.WriteLine();

                controller.HighScores = controller.LoadScores();

                var scores = controller.HighScores;
                var visibleScoresCount = Math.Min(10, scores.Count);

                for (int i = 0; i < visibleScoresCount; i++)
                {
                    Console.WriteLine($"  {scores[i].Name} - " +
                                      $"{scores[i].Time.Minutes:00}:{scores[i].Time.Seconds:00}:{scores[i].Time.Milliseconds / 10:00} - " +
                                      $"{scores[i].DifficultLevel}");
                }
                Console.WriteLine();
                Console.WriteLine("Press 'C' to clear scores or press any key to exit to main menu...");

                if (Console.ReadKey(true).Key == ConsoleKey.C)
                {
                    controller.ClearScores();
                }
                else
                {
                    return;
                }
            }
        }

        public static void ShowAbout()
        {
            Console.Clear();
            Console.WriteLine("   About");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine(" Minesweeper");
            Console.WriteLine(" Author: Ilya Bogomolov");

            Console.WriteLine();
            Console.WriteLine("Press any key to exit to main menu...");

            Console.ReadKey(true);
        }

        public static void ShowSettingsMenu(CliController controller)
        {
            while (true)
            {
                Console.Clear();
                Console.CursorVisible = false;
                Console.WriteLine("   Settings");
                Console.WriteLine();
                Console.WriteLine();

                var currentDifficultLevel = controller.DifficultLevel.ToString();

                Console.ForegroundColor = currentDifficultLevel == "Easy" ? ConsoleColor.Red : ConsoleColor.Black;
                Console.WriteLine($"  {(controller.SelectedSettingsMenuItem == SettingsMenuItems.Easy ? "☼" : " ")}  Easy");

                Console.ForegroundColor = currentDifficultLevel == "Medium" ? ConsoleColor.Red : ConsoleColor.Black;
                Console.WriteLine(
                    $"  {(controller.SelectedSettingsMenuItem == SettingsMenuItems.Medium ? "☼" : " ")}  Medium");

                Console.ForegroundColor = currentDifficultLevel == "Hard" ? ConsoleColor.Red : ConsoleColor.Black;
                Console.WriteLine(
                    $"  {(controller.SelectedSettingsMenuItem == SettingsMenuItems.Hard ? "☼" : " ")}  Hard");

                Console.ForegroundColor = currentDifficultLevel == "Custom Level" ? ConsoleColor.Red : ConsoleColor.Black;
                Console.WriteLine(
                    $"  {(controller.SelectedSettingsMenuItem == SettingsMenuItems.Custom ? "☼" : " ")}  Custom ({controller.DifficultLevel.Width}x{controller.DifficultLevel.Height}x{controller.DifficultLevel.MinesCount})");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine($"  {(controller.SelectedSettingsMenuItem == SettingsMenuItems.Exit ? "☼" : " ")}  Exit to main menu");
                var key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        if (controller.SelectedSettingsMenuItem == 0)
                        {
                            controller.SelectedSettingsMenuItem = Enum.GetValues(typeof(SettingsMenuItems)).Cast<SettingsMenuItems>().LastOrDefault();
                        }
                        else
                        {
                            controller.SelectedSettingsMenuItem--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (controller.SelectedSettingsMenuItem == Enum.GetValues(typeof(SettingsMenuItems)).Cast<SettingsMenuItems>().LastOrDefault())
                        {
                            controller.SelectedSettingsMenuItem = 0;
                        }
                        else
                        {
                            controller.SelectedSettingsMenuItem++;
                        }
                        break;
                    case ConsoleKey.Enter:
                        switch (controller.SelectedSettingsMenuItem)
                        {
                            case SettingsMenuItems.Easy:
                                controller.SetDifficultLevel("0");
                                break;
                            case SettingsMenuItems.Medium:
                                controller.SetDifficultLevel("1");
                                break;
                            case SettingsMenuItems.Hard:
                                controller.SetDifficultLevel("2");
                                break;
                            case SettingsMenuItems.Custom:
                                controller.SetDifficultLevel("3");
                                Console.CursorVisible = true;
                                Console.WriteLine("Game field Width:");

                                if (!int.TryParse(Console.ReadLine(), out int inputWidth))
                                {
                                    ShowErrorMessage("Wrong input!");
                                    break;
                                }
                                if (inputWidth < 2 || inputWidth > 30)
                                {
                                    ShowErrorMessage("Width of game field must be in range 2 to 30");
                                    break;
                                }

                                Console.WriteLine("Game field Height:");
                                if (!int.TryParse(Console.ReadLine(), out int inputHeight))
                                {
                                    ShowErrorMessage("Wrong input!");
                                    break;
                                }
                                if (inputHeight < 2 || inputHeight > 16)
                                {
                                    ShowErrorMessage("Height of game field must be in range 2 to 16");
                                    break;
                                }

                                Console.WriteLine("Mines count:");
                                if (!int.TryParse(Console.ReadLine(), out int inputMinesCount))
                                {
                                    ShowErrorMessage("Wrong input!");
                                    break;
                                }
                                if (inputMinesCount < 1 || inputMinesCount > inputHeight * inputHeight - 1)
                                {
                                    ShowErrorMessage($"Mines count must be in range 1 to {inputHeight * inputHeight - 1}");
                                    break;
                                }

                                controller.DifficultLevel.Width = inputWidth;
                                controller.DifficultLevel.Height = inputHeight;
                                controller.DifficultLevel.MinesCount = inputMinesCount;
                                break;
                            case SettingsMenuItems.Exit:
                                controller.SaveSettings();
                                return;
                        }
                        break;
                }
            }
        }

        private static void ShowErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.ReadKey(true);
        }
    }
}
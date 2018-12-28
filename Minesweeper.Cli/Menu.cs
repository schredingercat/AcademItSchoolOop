using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Cli
{
    public static class Menu
    {
        public static MainMenuItems ShowMainMenu(CliController controller)
        {
            Console.Clear();
            Console.WriteLine("   Minesweeper");
            Console.WriteLine();
            Console.WriteLine();

            while (true)
            {
                Console.SetCursorPosition(0, 3);
                Console.WriteLine($"  {(controller.SelectedMainMenuItem == MainMenuItems.NewGame ? "☼" : " ")}  New Game");
                Console.WriteLine($"  {(controller.SelectedMainMenuItem == MainMenuItems.HightScores ? "☼" : " ")}  High Scores");
                Console.WriteLine($"  {(controller.SelectedMainMenuItem == MainMenuItems.Settings ? "☼" : " ")}  Settings");
                Console.WriteLine($"  {(controller.SelectedMainMenuItem == MainMenuItems.About ? "☼" : " ")}  About");
                Console.WriteLine($"  {(controller.SelectedMainMenuItem == MainMenuItems.Exit ? "☼" : " ")}  Exit");
                var key = Console.ReadKey().Key;

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
            Console.Clear();
            Console.WriteLine("   High Scores");
            Console.WriteLine();
            Console.WriteLine();

            var scores = controller.HighScores;
            var visibleScoresCount = Math.Min(10, scores.Count);

            for (int i = 0; i < visibleScoresCount; i++)
            {
                Console.WriteLine($"  {scores[i].Name} - " +
                                  $"{scores[i].Time.Minutes:00}:{scores[i].Time.Seconds:00}:{scores[i].Time.Milliseconds / 10:00} - " +
                                  $"{scores[i].DifficultLevel}");
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to exit to main menu...");

            Console.ReadKey();
        }

        public static void ShowSettingsMenu(CliController controller)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("   Settings");
                Console.WriteLine();
                Console.WriteLine();

                var currentDifficultLevel = controller.DifficultLevel.ToString();

                //Console.SetCursorPosition(0, 3);

                Console.ForegroundColor = currentDifficultLevel == "Easy" ? ConsoleColor.Red : ConsoleColor.Gray;
                Console.WriteLine($"  {(controller.SelectedSettingsMenuItem == SettingsMenuItems.Easy ? "☼" : " ")}  Easy");

                Console.ForegroundColor = currentDifficultLevel == "Medium" ? ConsoleColor.Red : ConsoleColor.Gray;
                Console.WriteLine(
                    $"  {(controller.SelectedSettingsMenuItem == SettingsMenuItems.Medium ? "☼" : " ")}  Medium");

                Console.ForegroundColor = currentDifficultLevel == "Hard" ? ConsoleColor.Red : ConsoleColor.Gray;
                Console.WriteLine(
                    $"  {(controller.SelectedSettingsMenuItem == SettingsMenuItems.Hard ? "☼" : " ")}  Hard");

                Console.ForegroundColor = currentDifficultLevel == "Custom Level" ? ConsoleColor.Red : ConsoleColor.Gray;
                Console.WriteLine($"  {(controller.SelectedSettingsMenuItem == SettingsMenuItems.Custom ? "☼" : " ")}  Custom ({controller.DifficultLevel.Width}x{controller.DifficultLevel.Height}x{controller.DifficultLevel.MinesCount})");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($"  {(controller.SelectedSettingsMenuItem == SettingsMenuItems.Exit ? "☼" : " ")}  Exit to main menu");
                var key = Console.ReadKey().Key;

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
                                controller.DifficultLevel.Width = int.Parse(Console.ReadLine());
                                Console.WriteLine("Game field Height:");
                                controller.DifficultLevel.Height = int.Parse(Console.ReadLine());
                                Console.WriteLine("Mines count:");
                                controller.DifficultLevel.MinesCount = int.Parse(Console.ReadLine());
                                Console.CursorVisible = false;
                                break;
                            case SettingsMenuItems.Exit:
                                controller.SaveSettings();
                                return;
                        }
                        break;
                }
            }
        }
    }
}

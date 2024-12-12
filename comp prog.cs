using System;
using System.Collections.Generic;

class TetrisRotationTest
{

    static readonly Dictionary<string, List<string[]>> Tetrominoes = new()
    {
        { "I", new List<string[]>
            {
                new[] { "    ", "OOOO", "    ", "    " },
                new[] { "  O ", "  O ", "  O ", "  O " },
                new[] { "    ", "OOOO", "    ", "    " },
                new[] { " O  ", " O ", " O  ", " O  " }
            }
        },
        { "O", new List<string[]>
            {
                new[] { " OO ", " OO ", "    ", "    " }
            }
        },
        { "S", new List<string[]>
            {
                new[] { "  OO", " OO ", "    ", "    " },
                new[] { " O  ", " OO ", "  O ", "    " }
            }
        },
        { "Z", new List<string[]>
            {
                new[] { " OO ", "  OO", "    ", "    " },
                new[] { "  O ", " OO ", " O  ", "    " }
            }
        },
        { "J", new List<string[]>
            {
                new[] { " O  ", " OOO", "    ", "    " },
                new[] { "  OO", "  O ", "  O ", "    " },
                new[] { " OOO", "   O", "    ", "    " },
                new[] { "  O ", "  O ", " OO ", "    " }
            }
        },
        { "L", new List<string[]>
            {
                new[] { "   O", " OOO", "    ", "    " },
                new[] { "  O ", "  O ", "  OO", "    " },
                new[] { " OOO", "   O", "    ", "    " },
                new[] { " O ", "  O ", "  O ", "    " }
            }
        },
        { "T", new List<string[]>
            {
                new[] { "  O ", " OOO", "    ", "    " },
                new[] { "  O ", "  O", "  O ", "    " },
                new[] { " OOO ", "  O ", "    ", "    " },
                new[] { "  O ", " OO ", "  O ", "    " }
            }
        }
    };

    static void Main()
    {
        string currentBlock = "I";
        int currentRotation = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("TETRIS ROTATION TEST\n");
            Console.WriteLine($"Current Block: {currentBlock}");
            Console.WriteLine("4x4 Grid:");
            PrintGrid(Tetrominoes[currentBlock][currentRotation]);

            Console.WriteLine("\nControls:");
            Console.WriteLine("  [R] Rotate Clockwise");
            Console.WriteLine("  [L] Rotate Counter-Clockwise");
            Console.WriteLine("  [C] Change Block");
            Console.WriteLine("  [Q] Quit");

            ConsoleKey key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.R)
            {
                // Rotate clockwise
                currentRotation = (currentRotation + 1) % Tetrominoes[currentBlock].Count;
            }
            else if (key == ConsoleKey.L)
            {
                // Rotate counter-clockwise
                currentRotation = (currentRotation - 1 + Tetrominoes[currentBlock].Count) % Tetrominoes[currentBlock].Count;
            }
            else if (key == ConsoleKey.C)
            {
                // Change block
                Console.WriteLine("\nAvailable Blocks: I, O, S, Z, J, L, T");
                Console.Write("Enter block name: ");
                string input = Console.ReadLine()?.ToUpper();
                if (Tetrominoes.ContainsKey(input))
                {
                    currentBlock = input;
                    currentRotation = 0;
                }
                else
                {
                    Console.WriteLine("Invalid block name. Press any key to continue.");
                    Console.ReadKey();
                }
            }
            else if (key == ConsoleKey.Q)
            {
                // Quit
                break;
            }
        }
    }

    static void PrintGrid(string[] block)
    {
        for (int i = 0; i < 4; i++)
        {
            Console.WriteLine(block[i]);
        }
    }
}

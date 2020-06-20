using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Sudoku.Core
{
    public class Puzzle
    {
        public Tile[,] Tiles { get; set; }

        public const int Width = 9;
        public const int Height = 9;

        /// <summary>
        /// Sets up the puzzle board
        /// </summary>
        public void Setup()
        {
            Tiles = new Tile[Width, Height];

            for (var x = 0; x < Width; x++)
            {
                for (var y = 0; y < Height; y++)
                {
                    Tiles[x, y] = new Tile { X = x, Y = y };
                }
            }
        }

        /// <summary>
        /// Creates a new puzzle, reading the initial state from an input file.
        /// </summary>
        /// <param name="fileName"></param>
        public static Puzzle CreateFromFile(string fileName)
        {
            var puzzle = new Puzzle();
            puzzle.Setup();

            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @$"Config\{fileName}");
            if (path != null && File.Exists(path))
            {
                var puzzleContent = File.ReadAllLines(path);
                for (var x = 0; x < Width; x++)
                {
                    for (var y = 0; y < Height; y++)
                    {
                        puzzle.Tiles[x, y].Value = int.Parse(puzzleContent[x][y].ToString());
                    }
                }
            }

            return puzzle;
        }

        /// <summary>
        /// Prints to the console window a representation of this puzzle.
        /// </summary>
        public void Print()
        {
            Console.WriteLine("=== Printing Puzzle ===");

            for (var x = 0; x < Width; x++)
            {
                if (x > 0 && x % 3 == 0)
                    Console.WriteLine(new string('-', Width+2));

                for (var y = 0; y < Height; y++)
                {
                    if (y > 0 && y % 3 == 0)
                        Console.Write("|");

                    Console.Write(Tiles[x, y].Value);
                }

                Console.WriteLine("");
            }

            Console.WriteLine("");
        }
    }
}

using Sudoku.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Core
{
    public class Solver
    {
        /// <summary>
        /// A reference to the puzzle to solve.
        /// </summary>
        private Puzzle Puzzle;

        /// <summary>
        /// Event that is fired when this puzzle is solved.
        /// </summary>
        public event EventHandler<PuzzleSolvedEventArgs> PuzzleSolved;

        /// <summary>
        /// Event that is fired when a tile in the puzzle is updated.
        /// </summary>
        public event EventHandler<TileUpdatedEventArgs> TileUpdated;

        /// <summary>
        /// The number of milliseconds delay inbetween each tile being solved.
        /// </summary>
        private int WaitFor;

        /// <summary>
        /// Solves the provided puzzle.
        /// </summary>
        /// <param name="puzzle"></param>
        public void Solve(Puzzle puzzle)
        {
            this.Puzzle = puzzle;

            // Start the recursive solving from the first cell
            Task.Run(async () =>
            {
                await PerformSolve(0, 0);

                // Once this finishes, if the puzzle is solved then fire off the event.
                if (IsPuzzleSolved())
                {
                    PuzzleSolved?.Invoke(this, new PuzzleSolvedEventArgs { Puzzle = Puzzle });
                }
            });
        }

        /// <summary>
        /// Sets the number of milliseconds to wait for inbetween each tile being solved.
        /// </summary>
        /// <param name="milliseconds"></param>
        /// <returns></returns>
        public Solver Delay(int milliseconds)
        {
            WaitFor = milliseconds;
            return this;
        }

        /// <summary>
        /// Checks whether the puzzle has been solved. That is, every tile in the puzzle has been 
        /// assigned a value.
        /// </summary>
        /// <returns></returns>
        private bool IsPuzzleSolved()
        {
            for (var x = 0; x < Puzzle.Width; x++)
            {
                for (var y = 0; y < Puzzle.Height; y++)
                {
                    if (Puzzle.Tiles[x, y].Value == 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Checks whether placing the provided value at the provided [row, col] location in the puzzle
        /// would be a valid move or not.
        /// 
        /// That is, the same value cannot appear multiple times in any row, column or 3x3 grid.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool ValidateValue(int row, int col, int value)
        {
            // The same number cannot appear more than once in any row or column.
            for (var x = 0; x < Puzzle.Width; x++)
            {
                if (Puzzle.Tiles[row, x].Value == value || Puzzle.Tiles[x, col].Value == value)
                {
                    return false;
                }
            }

            // The same number cannot appear more than once in any 3x3 sub-grid.
            var rowStart = (row / 3) * 3;
            var colStart = (col / 3) * 3;
            for (var x = rowStart; x < rowStart + 3; x++)
            {
                for (var y = colStart; y < colStart + 3; y++)
                {
                    if (Puzzle.Tiles[x, y].Value == value)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Solves the next cell in the board. Moving along the whole column before proceeding down onto the next one.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        private async Task<bool> NextSolve(int row, int col)
        {
            if (col >= Puzzle.Height - 1)
            {
                return await PerformSolve(row + 1, 0);
            }
            else
            {
                return await PerformSolve(row, col + 1);
            }
        }

        /// <summary>
        /// Recursively solves the puzzle using a brute-force backtracking algorithm.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        private async Task<bool> PerformSolve(int row, int col)
        {
            if (IsPuzzleSolved())
            {
                // Puzzle has been solved - return
                return true;
            }
            else if (Puzzle.Tiles[row, col].Value != 0)
            {
                // Tile is already solved - proceed to next
                return await NextSolve(row, col);
            }
            else
            {
                // Attempt each possible value 1-9 in this cell
                for (var value = 1; value <= Puzzle.Height; value++)
                {
                    // This is a valid placement of this value, causing no issues with constraints
                    if (ValidateValue(row, col, value))
                    {
                        // Set the tile value and attempt to recursively solve the rest of the board.
                        Puzzle.Tiles[row, col].Value = value;
                        TileUpdated?.Invoke(this, new TileUpdatedEventArgs { Tile = Puzzle.Tiles[row, col] });
                        
                        // Intentional delay inbetween solving each tile
                        if (WaitFor > 0)
                        {
                            await Task.Delay(WaitFor);
                        }

                        if (await NextSolve(row, col))
                        {
                            return true;
                        }

                        // If any position comes back with an invalid move, rollback this value and try the next
                        Puzzle.Tiles[row, col].Value = 0;
                        TileUpdated?.Invoke(this, new TileUpdatedEventArgs { Tile = Puzzle.Tiles[row, col] });
                    }
                }
            }

            return false;
        }
    }
}

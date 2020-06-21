using Sudoku.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku.Events
{
    public class PuzzleSolvedEventArgs : EventArgs
    {
        /// <summary>
        /// The puzzle that was solved.
        /// </summary>
        public Puzzle Puzzle { get; set; }
    }
}

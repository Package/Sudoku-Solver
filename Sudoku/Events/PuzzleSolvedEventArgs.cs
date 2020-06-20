using Sudoku.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku.Events
{
    public class PuzzleSolvedEventArgs : EventArgs
    {
        public Puzzle Puzzle { get; set; }
    }
}

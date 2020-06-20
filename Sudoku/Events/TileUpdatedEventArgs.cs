using Sudoku.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku.Events
{
    public class TileUpdatedEventArgs : EventArgs
    {
        public Tile Tile { get; set; }
    }
}

using Sudoku.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku.Events
{
    public class TileUpdatedEventArgs : EventArgs
    {
        /// <summary>
        /// The tile that was updated.
        /// </summary>
        public Tile Tile { get; set; }
    }
}

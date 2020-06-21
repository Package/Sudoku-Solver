using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Sudoku.Core
{
    public class Tile
    {
        /// <summary>
        /// X position of this tile in the (x, y) co-ordinate.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Y position of this tile int he (x, y) co-ordinate
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// The value of this tile in the puzzle.
        /// Should be in the range 0-9
        /// </summary>
        public int Value { get; set; }
    }
}

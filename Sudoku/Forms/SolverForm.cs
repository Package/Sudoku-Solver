using Sudoku.Core;
using Sudoku.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sudoku.Forms
{
    public partial class SolverForm : Form
    {
        public List<TextBox> TileBoxes { get; set; }
        public Solver Solver { get; set; }
        public Puzzle Puzzle { get; set; }

        public SolverForm()
        {
            InitializeComponent();
            AddComponents();
        }

        /// <summary>
        /// Dynamically creates the grid of text boxes on the form.
        /// </summary>
        private void AddComponents()
        {
            TileBoxes = new List<TextBox>();
            Puzzle = new Puzzle();
            Puzzle.Setup();

            var font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            var size = new Size(40, 40);

            for (var x = 0; x < Puzzle.Width; x++)
            {
                for (var y = 0; y < Puzzle.Height; y++)
                {
                    var control = new TextBox();
                    control.Location = new Point((45 * x) + 20, (45 * y) + 20);
                    control.Size = size;
                    control.Font = font;
                    control.Name = $"txt{x}_{y}";
                    control.TextAlign = HorizontalAlignment.Center;
                    control.TextChanged += Control_TextChanged;

                    TileBoxes.Add(control);
                    Controls.Add(control);
                }
            }
        }

        /// <summary>
        /// When the text is changed on the Text Box control, update the puzzle tiles.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Control_TextChanged(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;

            // Pull out the (x, y) location of the Tile from the text box name.
            var nameSplit = textBox.Name.Replace("txt", "").Split('_');
            var x = int.Parse(nameSplit[0]);
            var y = int.Parse(nameSplit[1]);

            // Attempt to parse the number out of the text box
            int number;
            var successful = int.TryParse(textBox.Text, out number);

            if (string.IsNullOrEmpty(textBox.Text))
            {
                // Blank input - reset back to zero
                number = 0;
            }
            else if (!successful || number < 0 || number > 9)
            {
                // Ensure it was successful and in range, otherwise reset back to 0
                number = 0;
                MessageBox.Show($"Invalid Input: {textBox.Text}", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Puzzle.Tiles[x, y].Value = number;
        }

        /// <summary>
        /// Load in a pre-set puzzle input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoad_Click(object sender, EventArgs e)
        {
            var selectedPuzzle = (string) comboDefault.SelectedItem;
            if (!string.IsNullOrEmpty(selectedPuzzle))
            {
                Puzzle = Puzzle.CreateFromFile($"{selectedPuzzle}.txt");
                UpdateAllTextBoxes();
            }
        }

        /// <summary>
        /// Solves the puzzle.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSolve_Click(object sender, EventArgs e)
        {
            // Ensure a puzzle has been selected before hand.
            if (Puzzle == null)
            {
                MessageBox.Show("Select a puzzle first", "No Puzzle Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // First time solver has been ran so initialise
            if (Solver == null)
            {
                Solver = new Solver();
                Solver.PuzzleSolved += OnPuzzleSolved;
                Solver.TileUpdated += OnTileUpdated;
            }

            Solver.Solve(Puzzle);
        }

        /// <summary>
        /// Event handler for when the puzzle has been solved.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPuzzleSolved(object sender, PuzzleSolvedEventArgs e)
        {
            UpdateAllTextBoxes();
            MessageBox.Show("Puzzle has been successfully solved.", "Puzzle Solved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Event handler for when a tile in the puzzle has been updated.
        /// We update the state in the GUI when this happens.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTileUpdated(object sender, TileUpdatedEventArgs e)
        {
            UpdateTextBoxForTile(e.Tile);
        }

        /// <summary>
        /// Returns the name of the text box control associated with this tile.
        /// </summary>
        /// <param name="tile"></param>
        /// <returns></returns>
        private string TextBoxNameFromTile(Tile tile) => $"txt{tile.X}_{tile.Y}";

        /// <summary>
        /// Updates the GUI textbox for a provided tile in the puzzle.
        /// </summary>
        /// <param name="tile"></param>
        private void UpdateTextBoxForTile(Tile tile)
        {
            var textBoxName = TextBoxNameFromTile(tile);
            var textBox = TileBoxes.FirstOrDefault(t => t.Name == textBoxName);
            textBox.Text = tile.Value.ToString();
        }

        /// <summary>
        /// Updates all the text boxes in the GUI based on the puzzle tiles.
        /// </summary>
        private void UpdateAllTextBoxes()
        {
            for (var x = 0; x < Puzzle.Width; x++)
            {
                for (var y = 0; y < Puzzle.Height; y++)
                {
                    UpdateTextBoxForTile(Puzzle.Tiles[x, y]);
                }
            }
        }

        /// <summary>
        /// Confirms from that user that they definitely want to reset this puzzle, and if they do
        /// then proceeds to reset.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you really want to reset the puzzle?", "Confirm Reset", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                TileBoxes.ForEach(t => t.Text = string.Empty);
            }
        }
    }
}

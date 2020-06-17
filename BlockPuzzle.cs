using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathsJourney
{
    public partial class BlockPuzzle : Form
    {
        private int CurrentMoves;
        private bool GameLive;

        public BlockPuzzle()
        {
            InitializeComponent();
        }

        private void BlockPuzzle_Load(object sender, EventArgs e)
        {
            NewGame();
        }

        private void NewGame()
        {
            // Hide unwanted UI
            this.GameResultLabel.Visible = false;

            // Initialise new game
            CurrentMoves = 0;
            GameLive = true;

            BlockPuzzleGrid.CalculateGrid(4, 6);

            // Setup new player
            BlockPuzzlePlayer.Initiate(BlockPuzzleGrid.StartLocation, BlockPuzzleGrid.StartValue);


            PuzzleBox.Refresh();

            this.TargetValueLabel.Text = BlockPuzzleGrid.Target.ToString();
            this.MovesValueLabel.Text = BlockPuzzleGrid.RequiredMoves.ToString();
            this.StartLabelValue.Text = BlockPuzzleGrid.StartValue.ToString();
        }

        private void PuzzleBox_Paint(object sender, PaintEventArgs e)
        {
            BlockPuzzleGrid.DrawGrid(e);
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void BlockPuzzle_KeyDown(object sender, KeyEventArgs e)
        {
            if (GameLive)
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                    case Keys.W:
                        if (BlockPuzzlePlayer.Move(0, -1)) { CurrentMoves++; }
                        break;
                    case Keys.Down:
                    case Keys.S:
                        if (BlockPuzzlePlayer.Move(0, 1)) { CurrentMoves++; }
                        break;
                    case Keys.Left:
                    case Keys.A:
                        if (BlockPuzzlePlayer.Move(-1, 0)) { CurrentMoves++; }
                        break;
                    case Keys.Right:
                    case Keys.D:
                        if (BlockPuzzlePlayer.Move(1, 0)) { CurrentMoves++; }
                        break;
                }

                this.Refresh();

                // Check game conditions
                if (GameEnded())
                {
                    EndGame();
                }
            }
        }

        private bool GameEnded()
        {
            if (CurrentMoves >= BlockPuzzleGrid.RequiredMoves)
            {
                return true;
            }

            if (BlockPuzzlePlayer.Value == BlockPuzzleGrid.Target)
            {
                return true;
            }

                return false;
        }

        private void EndGame()
        {
            GameLive = false;
            if (BlockPuzzlePlayer.Value == BlockPuzzleGrid.Target)
            {
                this.GameResultLabel.Text = "Completed!";
            }
            else
            {
                this.GameResultLabel.Text = "Unlucky :(";
            }
            this.GameResultLabel.Visible = true;
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            ResetPuzzle();
        }

        private void ResetPuzzle()
        {
            if (BlockPuzzleGrid.ResetGrid())
            {
                // Hide unwanted UI
                this.GameResultLabel.Visible = false;

                // Initialise new game
                CurrentMoves = 0;
                GameLive = true;

                // Setup new player
                BlockPuzzlePlayer.Initiate(BlockPuzzleGrid.StartLocation, BlockPuzzleGrid.StartValue);


                PuzzleBox.Refresh();

                this.TargetValueLabel.Text = BlockPuzzleGrid.Target.ToString();
                this.MovesValueLabel.Text = BlockPuzzleGrid.RequiredMoves.ToString();
                this.StartLabelValue.Text = BlockPuzzleGrid.StartValue.ToString();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace MathsJourney
{
    public partial class BlockPuzzle : Form
    {
        private int CurrentMoves;
        private bool GameLive;
        private int GridSize;
        private int PuzzleCount = 0;
        private int CurrentPuzzle = 0;
        private List<int> UncompletedPuzzleIDs;

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
            this.NewGameButton.Enabled = false;

            // Initialise new game
            CurrentMoves = 0;
            GameLive = true;

            GridSize = 5;
            PuzzleCount = 6;
            BlockPuzzleGrid.CalculateGrid(GridSize, PuzzleCount);

            // Setup new player
            BlockPuzzlePlayer.Initiate(BlockPuzzleGrid.StartLocations, BlockPuzzleGrid.StartValues, BlockPuzzleGrid.Targets);


            PuzzleBox.Refresh();

            RefreshPuzzleList();
        }

        private void RefreshPuzzleList()
        {
            // clear current items
            listView1.Clear();

            UncompletedPuzzleIDs = new List<int>();

            for (int p = 0; p < BlockPuzzleGrid.PuzzleCount; p++)
            {
                if (BlockPuzzlePlayer.Values[p] != BlockPuzzlePlayer.Targets[p])
                {
                    var listString = $"Target: {BlockPuzzleGrid.Targets[p]}";
                    if (p == CurrentPuzzle)
                    {
                        listString = "ACTIVE " + listString;
                    }
                    var item = new ListViewItem(listString);
                    item.ForeColor = BlockPuzzleGrid.Colours[p];
                    listView1.Items.Add(item);
                    UncompletedPuzzleIDs.Add(p);
                }
            }
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
                        if (BlockPuzzlePlayer.Move(CurrentPuzzle, 0, -1)) { CurrentMoves++; }
                        break;
                    case Keys.Down:
                    case Keys.S:
                        if (BlockPuzzlePlayer.Move(CurrentPuzzle, 0, 1)) { CurrentMoves++; }
                        break;
                    case Keys.Left:
                    case Keys.A:
                        if (BlockPuzzlePlayer.Move(CurrentPuzzle, - 1, 0)) { CurrentMoves++; }
                        break;
                    case Keys.Right:
                    case Keys.D:
                        if (BlockPuzzlePlayer.Move(CurrentPuzzle, 1, 0)) { CurrentMoves++; }
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
            List<bool> PuzzlesEnded = new List<bool>();

            for (int i = 0; i < BlockPuzzleGrid.Targets.Count; i++)
            {
                PuzzlesEnded.Add(false);
                // Check if there are any possible moves
                if (!PossibleMoves(i))
                {
                    PuzzlesEnded[i] = true;
                }

                if (BlockPuzzlePlayer.Values[i] == BlockPuzzlePlayer.Targets[i])
                {
                    PuzzlesEnded[i] = true;
                    RefreshPuzzleList();
                }
            }

            if (PuzzlesEnded.Contains(false))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool PossibleMoves(int puzzleID)
        {
            //Check up
            if (BlockPuzzlePlayer.Locations[puzzleID].Y - 1 >= 0 && BlockPuzzlePlayer.AllowedMove(puzzleID, 0, -1))
            {
                return true;
            }
            //Check down
            if (BlockPuzzlePlayer.Locations[puzzleID].Y + 1 < BlockPuzzleGrid.GridSize && BlockPuzzlePlayer.AllowedMove(puzzleID, 0, 1))
            {
                return true;
            }
            //Check left
            if (BlockPuzzlePlayer.Locations[puzzleID].X - 1 >= 0 && BlockPuzzlePlayer.AllowedMove(puzzleID, -1, 0))
            {
                return true;
            }
            //Check down
            if (BlockPuzzlePlayer.Locations[puzzleID].X + 1 < BlockPuzzleGrid.GridSize && BlockPuzzlePlayer.AllowedMove(puzzleID, 1, 0))
            {
                return true;
            }

            return false;
        }

        private void EndGame()
        {
            GameLive = false;
            if (BlockPuzzlePlayer.Values.SequenceEqual(BlockPuzzleGrid.Targets))
            {
                this.GameResultLabel.Text = "Completed!";
                this.NewGameButton.Enabled = true;
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
                BlockPuzzlePlayer.Initiate(BlockPuzzleGrid.StartLocations, BlockPuzzleGrid.StartValues, BlockPuzzleGrid.Targets) ;


                PuzzleBox.Refresh();

                RefreshPuzzleList();
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the currently selected item in the ListBox.
            CurrentPuzzle = UncompletedPuzzleIDs[listView1.SelectedItems[0].Index];

            RefreshPuzzleList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = UncompletedPuzzleIDs.FindIndex(i => i == CurrentPuzzle);
            index++;

            if (index >= UncompletedPuzzleIDs.Count())
            {
                index = 0;
            }

            CurrentPuzzle = UncompletedPuzzleIDs[index];
            if (CurrentPuzzle >= PuzzleCount)
            {
                CurrentPuzzle = 0;
            }

            RefreshPuzzleList();
        }
    }
}

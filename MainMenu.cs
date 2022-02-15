using MathsJourney.ColourWars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathsJourney
{
    public partial class MainMenu : Form
    {
        public static BlockHunt BlockHuntGameWindow;
        public static Thread RefreshThread;
        public static bool GameLive = false;

        public static void RunRefreshTimer()
        {
            while (GameLive)
            {
                int refreshSeconds = BlockHuntGameWindow.RefreshSeconds;
                if (refreshSeconds >= BlockHuntGameWindow.MaxRefreshSeconds)
                {
                    // Check how many used blocks there are
                    int usedBlocks = BlockHuntGrid.GetUsedBlocks();
                    if (usedBlocks <= 0)
                    {
                        GameLive = false;
                        BlockHuntGameWindow.EndGame_Safe();
                    }

                    BlockHuntGrid.Repopulate();
                    refreshSeconds = 0;
                    BlockHuntGameWindow.Refresh_Safe();
                }
                else
                {
                    refreshSeconds += 1;
                }

                BlockHuntGameWindow.UpdateUI_Safe(refreshSeconds);

                Thread.Sleep(1000);
            }
        }

        public static BlockPuzzle BlockPuzzleGameWindow;


        public MainMenu()
        {
            InitializeComponent();
        }

        private void PlayBlockHuntButton_Click(object sender, EventArgs e)
        {
            ////////////////////////
            ///  BLOCK HUNT GAME ///
            ////////////////////////

            // Setup new player
            BlockHuntPlayer.Initiate();

            // Calculate the Grid
            BlockHuntGrid.CalculateGrid();

            // Create new form window
            BlockHuntGameWindow = new BlockHunt();

            RefreshThread = new Thread(new ThreadStart(RunRefreshTimer));

            BlockHuntGameWindow.ShowDialog();

            RefreshThread.Abort();

            //// Start refresh thread
            //BlockHuntGameWindow.RefreshSeconds = 0;
            //new Thread(() =>
            //{
            //    Thread.CurrentThread.IsBackground = true;
            //    /* run your code here */
            //    if (BlockHuntGameWindow.RefreshSeconds <= BlockHuntGameWindow.MaxRefreshSeconds)
            //    {
            //        MathGrid.Repopulate();
            //        BlockHuntGameWindow.RefreshSeconds = 0;
            //    }
            //    else
            //    {
            //        BlockHuntGameWindow.RefreshSeconds += 1;
            //    }
            //    BlockHuntGameWindow.UpdateUI();

            //    Thread.Sleep(1000);
            //}).Start();
        }

        private void PlayBlockPuzzleButton_Click(object sender, EventArgs e)
        {
            //////////////////////////
            ///  BLOCK PUZZLE GAME ///
            //////////////////////////

            // Create new form window
            BlockPuzzleGameWindow = new BlockPuzzle();

            BlockPuzzleGameWindow.Show();
        }

        private void PlayColourCombineButton_Click(object sender, EventArgs e)
        {
            ////////////////////////////
            ///  COLOUR COMBINE GAME ///
            ////////////////////////////

            // Create new form window
            var colourCombineGame = new ColourCombine.ColourCombine();

            colourCombineGame.Show();
        }

        private void PlayColourWarsButton_Click(object sender, EventArgs e)
        {
            ////////////////////////////
            ///  COLOUR WARS GAME ///
            ////////////////////////////

            // A good move score weighting
            var moveScoreWeighting1 = new MoveScoreWeightings()
            {
                thisCountWeighting = -6,
                otherCountWeighting = 29,
                predictedStrengthWeighting = 26,
                predictedBlockCountWeighting = 28,
                surroundingEnemyBlockWeighting = 68,
                attackWeighting = 183,
                attackWeakWeighting = 495,
                attackStrongWeighting = 244,
                moveTowardEnemyWeighting = 497,
                chancePickingRandomMove = -23
            };
            var moveScoreWeighting2 = new MoveScoreWeightings()
            {
                thisCountWeighting = 0,
                otherCountWeighting = -26,
                predictedStrengthWeighting = 13,
                predictedBlockCountWeighting = -23,
                surroundingEnemyBlockWeighting = 106,
                attackWeighting = 193,
                attackWeakWeighting = 471,
                attackStrongWeighting = 304,
                moveTowardEnemyWeighting = 525,
                chancePickingRandomMove = 44
            };
            var moveScoreWeighting3 = new MoveScoreWeightings()
            {
                thisCountWeighting = 1,
                otherCountWeighting = 2,
                predictedStrengthWeighting = 5,
                predictedBlockCountWeighting = 8,
                surroundingEnemyBlockWeighting = 100,
                attackWeighting = 200,
                attackWeakWeighting = 500,
                attackStrongWeighting = 300,
                moveTowardEnemyWeighting = 500,
                chancePickingRandomMove = 10
            };

            // Create new form window
            var redPlayer = new Player(ColourType.Red);
            //var redPlayer = new ComputerPlayer(moveScoreWeighting1, ColourType.Red);
            var greenPlayer = new ComputerPlayer(moveScoreWeighting2, ColourType.Green);
            var bluePlayer = new ComputerPlayer(moveScoreWeighting1, ColourType.Blue);

            var colourWarsGame = new ColourWars.ColourWars(redPlayer, greenPlayer, bluePlayer, 100);

            colourWarsGame.Show();

            colourWarsGame.BeginGame();

            //colourWarsGame.Close();
        }

        private void LearnColourWarsButton_Click(object sender, EventArgs e)
        {
            new LearnColourWars().Show();
        }
    }
}

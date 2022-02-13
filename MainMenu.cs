﻿using MathsJourney.ColourWars;
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
            var moveScoreWeighting = new MoveScoreWeightings()
            {
                thisCountWeighting = 13,
                otherCountWeighting = 27,
                predictedStrengthWeighting = -61,
                predictedBlockCountWeighting = 0,
                surroundingEnemyBlockWeighting = 38,
                attackWeighting = 134,
                attackWeakWeighting = 23,
                attackStrongWeighting = -126
            };
            
            // Create new form window
            var redPlayer = new ComputerPlayer(moveScoreWeighting, ColourType.Red);
            var greenPlayer = new ComputerPlayer(moveScoreWeighting, ColourType.Green);
            var bluePlayer = new ComputerPlayer(moveScoreWeighting, ColourType.Blue);

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

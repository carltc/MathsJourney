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
    }
}

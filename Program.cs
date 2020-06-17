using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace MathsJourney
{
    static class Program
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

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //[STAThread]
        static void Main()
        {
            //////////////////////////
            ///  BLOCK PUZZLE GAME ///
            //////////////////////////

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Create new form window
            BlockPuzzleGameWindow = new BlockPuzzle();

            Application.Run(BlockPuzzleGameWindow);



            ////////////////////////
            ///  BLOCK HUNT GAME ///
            ////////////////////////

            //// Setup new player
            //PlayerBlock.Initiate();

            //// Calculate the Grid
            //BlockHuntGrid.CalculateGrid();

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);

            //// Create new form window
            //BlockHuntGameWindow = new BlockHunt();

            //RefreshThread = new Thread(new ThreadStart(RunRefreshTimer));

            //Application.Run(BlockHuntGameWindow);

            //RefreshThread.Abort();

            ////// Start refresh thread
            ////BlockHuntGameWindow.RefreshSeconds = 0;
            ////new Thread(() =>
            ////{
            ////    Thread.CurrentThread.IsBackground = true;
            ////    /* run your code here */
            ////    if (BlockHuntGameWindow.RefreshSeconds <= BlockHuntGameWindow.MaxRefreshSeconds)
            ////    {
            ////        MathGrid.Repopulate();
            ////        BlockHuntGameWindow.RefreshSeconds = 0;
            ////    }
            ////    else
            ////    {
            ////        BlockHuntGameWindow.RefreshSeconds += 1;
            ////    }
            ////    BlockHuntGameWindow.UpdateUI();

            ////    Thread.Sleep(1000);
            ////}).Start();
        }
    }
}

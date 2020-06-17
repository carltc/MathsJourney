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
    public partial class BlockHunt : Form
    {
        private delegate void SafeIntCallDelegate(int seconds);
        private delegate void SafeCallDelegate();

        private bool FirstMove = false;

        public int RefreshSeconds { get; set; }

        // First time set this to 60s
        public int MaxRefreshSeconds = 10;

        public BlockHunt()
        {
            InitializeComponent();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // Create pen.
            Pen blackPen = new Pen(Color.Black, 3);

            // Create rectangle.
            Rectangle rect = new Rectangle(0, 0, 200, 200);

            // Draw rectangle to screen.
            e.Graphics.DrawRectangle(blackPen, rect);

            string drawString = "Sample Text";
            Font drawFont = new Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            float x = 150.0F;
            float y = 50.0F;
            StringFormat drawFormat = new StringFormat();
            e.Graphics.DrawString(drawString, drawFont, drawBrush, x, y, drawFormat);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only accept input if start of game, or game is live
            if (!FirstMove || Program.GameLive)
            {
                // On first move start countdown timer
                if (!FirstMove)
                {
                    FirstMove = true;
                    Program.GameLive = true;
                    Program.RefreshThread.Start();
                }

                switch (e.KeyChar)
                {
                    case 'w':
                        BlockHuntPlayer.Move(0, -1);
                        break;
                    case 'a':
                        BlockHuntPlayer.Move(-1, 0);
                        break;
                    case 's':
                        BlockHuntPlayer.Move(0, 1);
                        break;
                    case 'd':
                        BlockHuntPlayer.Move(1, 0);
                        break;
                }

                this.Refresh();
                UpdateUI();
            }
        }

        private void pictureBox1_Paint_1(object sender, PaintEventArgs e)
        {
            if (BlockHuntPlayer.Location != null)
            {
                BlockHuntGrid.DrawGrid(e);
            }

        }

        public void UpdateUI()
        {
            // Calculate progress bar
            this.TargetProgressBar.Minimum = 0;
            this.TargetProgressBar.Maximum = MaxRefreshSeconds;
            this.TargetProgressBar.Value = RefreshSeconds;

            this.TargetValueLabel.Text = BlockHuntPlayer.Target.ToString();
            this.PlayerLevelLabel.Text = BlockHuntPlayer.Level.ToString();
        }

        public void UpdateUI_Safe(int seconds)
        {
            if (this.TargetProgressBar.InvokeRequired)
            {
                var safeSeconds = new SafeIntCallDelegate(UpdateUI_Safe);
                this.TargetProgressBar.Invoke(safeSeconds, new object[] { seconds });
            }
            else
            {
                // Now set countdown to 10s
                if (RefreshSeconds >= MaxRefreshSeconds)
                {
                    MaxRefreshSeconds = 5;
                }
                RefreshSeconds = seconds;
                this.TargetProgressBar.Minimum = 0;
                this.TargetProgressBar.Maximum = this.MaxRefreshSeconds;
                this.TargetProgressBar.Value = seconds;
            }
        }

        public void Refresh_Safe()
        {
            if (this.InvokeRequired)
            {
                var safeRefresh = new SafeCallDelegate(Refresh_Safe);
                this.Invoke(safeRefresh);
            }
            else
            {
                this.Refresh();
            }
        }

        public void EndGame_Safe()
        {
            if (this.InvokeRequired)
            {
                var safeEndGame = new SafeCallDelegate(EndGame_Safe);
                this.Invoke(safeEndGame);
            }
            else
            {
                this.GameOverLabel.Visible = true;
                this.NewGameButton.Visible = true;
            }
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            GameOverLabel.Visible = false;
            NewGameButton.Visible = false;

            MaxRefreshSeconds = 10;
            FirstMove = false;

            // Reset player
            BlockHuntPlayer.Initiate();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MathsJourney.DrawingHelper;
using static MathsJourney.ColourWars.ColourTypeHelper;

namespace MathsJourney.ColourWars
{
    public partial class ColourWars : Form
    {
        public ColourGrid ColourGrid { get; set; }

        public int TeamsTurn = 1;

        public ColourWars()
        {
            InitializeComponent();
            ColourGrid = new ColourGrid(this, GameField.Size);
        }

        private void GameField_Paint(object sender, PaintEventArgs e)
        {
            // Redraw the game field
            DrawGrid(e);

            // Update the strengths and block counts
            RedStrengthLabel.Text = $"{ColourGrid.GetStrength(ColourType.Red)}";
            GreenStrengthLabel.Text = $"{ColourGrid.GetStrength(ColourType.Green)}";
            BlueStrengthLabel.Text = $"{ColourGrid.GetStrength(ColourType.Blue)}";
            RedBlocksLabel.Text = $"{ColourGrid.GetBlockCount(ColourType.Red)}";
            GreenBlocksLabel.Text = $"{ColourGrid.GetBlockCount(ColourType.Green)}";
            BlueBlocksLabel.Text = $"{ColourGrid.GetBlockCount(ColourType.Blue)}";
        }

        public void DrawGrid(PaintEventArgs e)
        {
            // Draw all the blocks
            for (int i = 0; i < ColourGrid.GridSize; i++)
            {
                for (int j = 0; j < ColourGrid.GridSize; j++)
                {
                    var colourBlock = ColourGrid.ColourBlocks[i, j];

                    if (colourBlock != null)
                    {
                        colourBlock.DrawBlock(e);
                    }
                }
            }

            // Draw rectangle around play area showing current team whose turn it is
            DrawTurnRectangle(e);
        }

        public void NextTeamTurn()
        {
            // Switch team that is to play
            TeamsTurn++;

            if (TeamsTurn > Enum.GetNames(typeof(ColourType)).Length - 1)
            {
                TeamsTurn = 1;
            }

            // Perform some checks on this team to see if a it is knocked out or has only 1 move left or cannot do any moves
            if (ColourGrid.GetBlockCount((ColourType)TeamsTurn) <= 0)
            {
                // Then this team is knocked out. Strikethrough their label to indicate this
                StrikeOutTeamLabels(TeamsTurn);

                // Then this team has no blocks and therefore is out
                NextTeamTurn();
            }
        }

        private void StrikeOutTeamLabels(int teamsTurn)
        {
            switch ((ColourType)teamsTurn)
            {
                case ColourType.Red:
                    var redFont = new Font(RedTeamLabel.Font, FontStyle.Strikeout);
                    RedTeamLabel.Font = redFont;
                    RedStrengthLabel.Text = "";
                    RedBlocksLabel.Text = "";
                    RedBadAgainstLabel.Text = "";
                    RedGoodAgainstLabel.Text = "";
                    break;
                case ColourType.Green:
                    var greenFont = new Font(GreenTeamLabel.Font, FontStyle.Strikeout);
                    GreenTeamLabel.Font = greenFont;
                    GreenStrengthLabel.Text = "";
                    GreenBlocksLabel.Text = "";
                    GreenBadAgainstLabel.Text = "";
                    GreenGoodAgainstLabel.Text = "";
                    break;
                case ColourType.Blue:
                    var blueFont = new Font(BlueTeamLabel.Font, FontStyle.Strikeout);
                    BlueTeamLabel.Font = blueFont;
                    BlueStrengthLabel.Text = "";
                    BlocksLabel.Text = "";
                    BlueBadAgainstLabel.Text = "";
                    BlueGoodAgainstLabel.Text = "";
                    break;
            }
        }

        private void DrawTurnRectangle(PaintEventArgs e)
        {
            DrawRectangle(e, new Point(0, 0), GameField.Width, GameField.Height, GetColour((ColourType)TeamsTurn), fill: false, Color.Transparent, 10);
        }

        private void ColourCombine_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private bool _mouseIsDown = false;
        private Point _mouseDownStartPoint, _mouseDownEndPoint;

        private void GameField_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseIsDown = true;
            _mouseDownStartPoint = e.Location;
            _mouseDownEndPoint = e.Location;
        }

        private void GameField_MouseMove(object sender, MouseEventArgs e)
        {
            if (_mouseIsDown)
            {
                _mouseDownEndPoint = e.Location;
            }
        }

        private void SkipTurnButton_Click(object sender, EventArgs e)
        {
            NextTeamTurn();
            GameField.Refresh();
        }

        private void GameField_MouseUp(object sender, MouseEventArgs e)
        {
            _mouseIsDown = false;

            // Get the block that was clicked on
            var startColourBlock = ColourGrid.GetColourBlock(_mouseDownStartPoint.X, _mouseDownStartPoint.Y);
            var endColourBlock = ColourGrid.GetColourBlock(_mouseDownEndPoint.X, _mouseDownEndPoint.Y);

            // Check that mouse started and ended on a colour block
            if (startColourBlock == null || endColourBlock == null)
            {
                return;
            }

            // Check if this is colour block of current team
            if ((int)startColourBlock.ColourType != TeamsTurn)
            {
                return;
            }

            // Find the direction that the mouse was moved
            var deltaX =  _mouseDownEndPoint.X - _mouseDownStartPoint.X;
            var deltaY =  _mouseDownEndPoint.Y - _mouseDownStartPoint.Y;

            bool moveOccured = false;

            if (startColourBlock == endColourBlock)
            {
                // Then just add 1 to this block
                moveOccured = ColourGrid.AddToBlock(startColourBlock);
            }
            else if (Math.Abs(deltaX) > Math.Abs(deltaY))
            {
                // Then move this block in the X direction
                if (deltaX > 0)
                {
                    moveOccured = ColourGrid.MoveBlock(startColourBlock, BlockMove.Right);
                }
                else
                {
                    moveOccured = ColourGrid.MoveBlock(startColourBlock, BlockMove.Left);
                }
            }
            else
            {
                // Then move this block in the Y direction
                if (deltaY > 0)
                {
                    moveOccured = ColourGrid.MoveBlock(startColourBlock, BlockMove.Down);
                }
                else
                {
                    moveOccured = ColourGrid.MoveBlock(startColourBlock, BlockMove.Up);
                }
            }

            if (moveOccured)
            {
                NextTeamTurn();
                GameField.Refresh();
            }
        }
    }
}

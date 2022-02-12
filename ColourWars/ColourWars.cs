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
            TeamsTurn++;

            if (TeamsTurn > Enum.GetNames(typeof(ColourType)).Length - 1)
            {
                TeamsTurn = 1;
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
        }

        private void GameField_MouseMove(object sender, MouseEventArgs e)
        {
            if (_mouseIsDown)
            {
                _mouseDownEndPoint = e.Location;
            }
        }

        private void GameField_MouseUp(object sender, MouseEventArgs e)
        {
            _mouseIsDown = false;

            // Get the block that was clicked on
            var colourBlock = ColourGrid.GetColourBlock(_mouseDownStartPoint.X, _mouseDownStartPoint.Y);

            // Check if this is colour block of current team
            if ((int)colourBlock.ColourType != TeamsTurn)
            {
                return;
            }

            // Find the direction that the mouse was moved
            var deltaX =  _mouseDownEndPoint.X - _mouseDownStartPoint.X;
            var deltaY =  _mouseDownEndPoint.Y - _mouseDownStartPoint.Y;

            bool moveOccured = false;

            if (Math.Abs(deltaX) > Math.Abs(deltaY))
            {
                // Then move this block in the X direction
                if (deltaX > 0)
                {
                    moveOccured = ColourGrid.MoveBlock(colourBlock, BlockMove.Right);
                }
                else
                {
                    moveOccured = ColourGrid.MoveBlock(colourBlock, BlockMove.Left);
                }
            }
            else
            {
                // Then move this block in the Y direction
                if (deltaY > 0)
                {
                    moveOccured = ColourGrid.MoveBlock(colourBlock, BlockMove.Down);
                }
                else
                {
                    moveOccured = ColourGrid.MoveBlock(colourBlock, BlockMove.Up);
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

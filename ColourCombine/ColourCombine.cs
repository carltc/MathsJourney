using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathsJourney.ColourCombine
{
    public partial class ColourCombine : Form
    {
        public ColourGrid ColourGrid { get; set; }

        public ColourCombine()
        {
            InitializeComponent();
            ColourGrid = new ColourGrid(this, GameField.Size);
            IncreaseLevelButton.Text = $"Current Level: {ColourGrid.Level} - Increase Level";
        }

        private void GameField_Paint(object sender, PaintEventArgs e)
        {
            DrawGrid(e);
        }

        public void DrawGrid(PaintEventArgs e)
        {
            // Draw the game level boundary
            ColourGrid.DrawLevelBoundary(e);

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

        private void IncreaseLevelButton_Click(object sender, EventArgs e)
        {
            // Increase the grid level
            ColourGrid.Level++;
            IncreaseLevelButton.Text = $"Current Level: {ColourGrid.Level} - Increase Level";
            GameField.Refresh();
        }

        private void GameField_MouseUp(object sender, MouseEventArgs e)
        {
            _mouseIsDown = false;

            // Get the block that was clicked on
            var colourBlock = ColourGrid.GetColourBlock(_mouseDownStartPoint.X, _mouseDownStartPoint.Y);

            // Find the direction that the mouse was moved
            var deltaX =  _mouseDownEndPoint.X - _mouseDownStartPoint.X;
            var deltaY =  _mouseDownEndPoint.Y - _mouseDownStartPoint.Y;

            if (Math.Abs(deltaX) > Math.Abs(deltaY))
            {
                // Then move this block in the X direction
                if (deltaX > 0)
                {
                    ColourGrid.MoveBlock(colourBlock, BlockMove.Right);
                }
                else
                {
                    ColourGrid.MoveBlock(colourBlock, BlockMove.Left);
                }
            }
            else
            {
                // Then move this block in the Y direction
                if (deltaY > 0)
                {
                    ColourGrid.MoveBlock(colourBlock, BlockMove.Down);
                }
                else
                {
                    ColourGrid.MoveBlock(colourBlock, BlockMove.Up);
                }
            }

            GameField.Refresh();
        }
    }
}

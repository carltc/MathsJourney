using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MathsJourney.DrawingHelper;

namespace MathsJourney.ColourCombine
{
    public class ColourGrid
    {
        /// <summary>
        /// MUST be even
        /// </summary>
        public const int GridSize = 8;

        public ColourCombine Game { get; set; }
        public Size GameFieldSize { get; set; }

        public ColourBlock[,] ColourBlocks { get; set; }

        public int BlockWidth { get => GameFieldSize.Width / ColourGrid.GridSize; }
        public int BlockHeight { get => GameFieldSize.Height / ColourGrid.GridSize; }

        private int _level = 1;
        public int Level
        {
            get => _level;
            set
            {
                // Max level is the grid size / 2
                if (value <= GridSize / 2)
                {
                    _level = value;
                }
            }
        }

        public ColourGrid(ColourCombine game, Size gameFieldSize)
        {
            Game = game;
            GameFieldSize = gameFieldSize;
            PopulateStartingGrid();
        }

        public void PopulateStartingGrid()
        {

            // Create a starting grid
            ColourBlocks = new ColourBlock[GridSize, GridSize];

            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    ColourBlocks[i,j] = new ColourBlock(this, ColourType.Blank, i, j);
                }
            }

            // Set the central 4 blocks to Red, Green, Blue and Blank
            int gridCentre = GridSize / 2 - 1;
            ColourBlocks[gridCentre, gridCentre] = new ColourBlock(this, ColourType.Red, gridCentre, gridCentre);
            ColourBlocks[gridCentre + 1, gridCentre] = new ColourBlock(this, ColourType.Green, gridCentre + 1, gridCentre);
            ColourBlocks[gridCentre + 1, gridCentre + 1] = new ColourBlock(this, ColourType.Blue, gridCentre + 1, gridCentre + 1);
            ColourBlocks[gridCentre, gridCentre + 1] = new ColourBlock(this, ColourType.Blank, gridCentre, gridCentre + 1);
        }

        public ColourBlock GetColourBlock(int x, int y)
        {
            int i = (int)Math.Floor((double)x / (double)BlockWidth);
            int j = (int)Math.Floor((double)y / (double)BlockHeight);
            return ColourBlocks[i, j];
        }

        public void MoveBlock(ColourBlock colourBlock, BlockMove blockMove)
        {
            if (ValidMove(colourBlock, blockMove))
            {
                switch (blockMove)
                {
                    case BlockMove.Up:
                        ColourBlocks[colourBlock.I, colourBlock.J - 1] = colourBlock;
                        ColourBlocks[colourBlock.I, colourBlock.J] = new ColourBlock(this, ColourType.Blank, colourBlock.I, colourBlock.J);
                        colourBlock.J -= 1;
                        break;
                    case BlockMove.Down:
                        ColourBlocks[colourBlock.I, colourBlock.J + 1] = colourBlock;
                        ColourBlocks[colourBlock.I, colourBlock.J] = new ColourBlock(this, ColourType.Blank, colourBlock.I, colourBlock.J);
                        colourBlock.J += 1;
                        break;
                    case BlockMove.Left:
                        ColourBlocks[colourBlock.I - 1, colourBlock.J] = colourBlock;
                        ColourBlocks[colourBlock.I, colourBlock.J] = new ColourBlock(this, ColourType.Blank, colourBlock.I, colourBlock.J);
                        colourBlock.I -= 1;
                        break;
                    case BlockMove.Right:
                        ColourBlocks[colourBlock.I + 1, colourBlock.J] = colourBlock;
                        ColourBlocks[colourBlock.I, colourBlock.J] = new ColourBlock(this, ColourType.Blank, colourBlock.I, colourBlock.J);
                        colourBlock.I += 1;
                        break;
                }
            }
        }

        public bool ValidMove(ColourBlock colourBlock, BlockMove blockMove)
        {
            switch (blockMove)
            {
                case BlockMove.Up:
                    if (
                        colourBlock.J > 0 &&
                        ColourBlocks[colourBlock.I, colourBlock.J - 1].ColourType == ColourType.Blank
                        )
                    {
                        return true;
                    }
                    break;
                case BlockMove.Down:
                    if (
                        colourBlock.J < GridSize - 1 &&
                        ColourBlocks[colourBlock.I, colourBlock.J + 1].ColourType == ColourType.Blank
                        )
                    {
                        return true;
                    }
                    break;
                case BlockMove.Left:
                    if (
                        colourBlock.I > 0 &&
                        ColourBlocks[colourBlock.I - 1, colourBlock.J].ColourType == ColourType.Blank
                        )
                    {
                        return true;
                    }
                    break;
                case BlockMove.Right:
                    if (
                        colourBlock.I < GridSize - 1 &&
                        ColourBlocks[colourBlock.I + 1, colourBlock.J].ColourType == ColourType.Blank
                        )
                    {
                        return true;
                    }
                    break;
            }

            return false;
        }

        public void DrawLevelBoundary(PaintEventArgs e)
        {
            int gridCentre = (GridSize / 2 - 1) - (Level - 1);
            var colourBlock = ColourBlocks[gridCentre, gridCentre];

            DrawRectangle(e, colourBlock.BlockLocation, BlockWidth * Level * 2, BlockHeight * Level * 2, Color.Red, fill: false, Color.Transparent, borderWidth: 3);
        }
    }
}

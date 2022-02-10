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

        public Point LevelMin
        {
            get => new Point((GridSize / 2 - 1) - (Level - 1), (GridSize / 2 - 1) - (Level - 1));
        }

        public Point LevelMax
        {
            get => new Point((GridSize / 2) + (Level - 1), (GridSize / 2) + (Level - 1));
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
            // Get the point of the block that wants to be overwritten
            Point oldPoint = new Point(colourBlock.I, colourBlock.J);
            Point newPoint;
            switch (blockMove)
            {
                case BlockMove.Up:
                    newPoint = new Point(oldPoint.X, oldPoint.Y - 1);
                    break;
                case BlockMove.Down:
                    newPoint = new Point(oldPoint.X, oldPoint.Y + 1);
                    break;
                case BlockMove.Left:
                    newPoint = new Point(oldPoint.X - 1, oldPoint.Y);
                    break;
                case BlockMove.Right:
                    newPoint = new Point(oldPoint.X + 1, oldPoint.Y);
                    break;
                default:
                    // A new blockmove which has not been implented so therefore return
                    return;
            }

            if (ValidMove(colourBlock, newPoint))
            {

                var overwrittenColourBlock = ColourBlocks[newPoint.X, newPoint.Y];

                // Check if this was a move of the same colour overwriting, and if so then increment the count of this block
                if (overwrittenColourBlock.ColourType == colourBlock.ColourType)
                {
                    colourBlock.Count += overwrittenColourBlock.Count;
                }

                // Set the new location with the colour block
                ColourBlocks[newPoint.X, newPoint.Y] = colourBlock;
                // Set the location of the new point
                colourBlock.I = newPoint.X;
                colourBlock.J = newPoint.Y;

                // Set the old location as blank
                ColourBlocks[oldPoint.X, oldPoint.Y] = new ColourBlock(this, ColourType.Blank, oldPoint.X, oldPoint.Y);

            }
        }

        public bool ValidMove(ColourBlock colourBlock, Point newPoint)
        {
            // Check if the new point is within the level boundary
            if (
                    newPoint.Y < LevelMin.Y ||
                    newPoint.Y > LevelMax.Y ||
                    newPoint.X < LevelMin.X ||
                    newPoint.X > LevelMax.X
                )
            {
                return false;
            }

            // Check if the block to be overwritten is blank or same type
            var overwrittenColourBlock = ColourBlocks[newPoint.X, newPoint.Y];
            if (overwrittenColourBlock.ColourType != ColourType.Blank && overwrittenColourBlock.ColourType != colourBlock.ColourType)
            {
                return false;
            }

            return true;
        }

        public void DrawLevelBoundary(PaintEventArgs e)
        {
            int gridCentre = (GridSize / 2 - 1) - (Level - 1);
            var colourBlock = ColourBlocks[gridCentre, gridCentre];

            DrawRectangle(e, colourBlock.BlockLocation, BlockWidth * Level * 2, BlockHeight * Level * 2, Color.Red, fill: false, Color.Transparent, borderWidth: 3);
        }

        public void IncreaseLevel()
        {
            Level++;

            Random rand = new Random();
            // Populate the new level blank blocks with colour blocks
            for (int i = LevelMin.X; i <= LevelMax.X; i++)
            {
                for (int j = LevelMin.Y; j <= LevelMax.Y; j++)
                {
                    if (i == LevelMin.X || i == LevelMax.X || j == LevelMin.Y || j == LevelMax.Y)
                    {
                        int rand_num = rand.Next(Enum.GetNames(typeof(ColourType)).Length - 1);

                        ColourBlocks[i, j] = new ColourBlock(this, (ColourType)rand_num, i, j);
                    }
                }
            }
        }
    }
}

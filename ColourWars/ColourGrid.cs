using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MathsJourney.DrawingHelper;

namespace MathsJourney.ColourWars
{
    public class ColourGrid
    {
        /// <summary>
        /// MUST be even
        /// </summary>
        public const int GridSize = 8;

        public ColourWars Game { get; set; }
        public Size GameFieldSize { get; set; }

        public ColourBlock[,] ColourBlocks { get; set; }

        public int BlockWidth { get => GameFieldSize.Width / ColourGrid.GridSize; }
        public int BlockHeight { get => GameFieldSize.Height / ColourGrid.GridSize; }

        public ColourGrid(ColourWars game, Size gameFieldSize)
        {
            Game = game;
            GameFieldSize = gameFieldSize;
            PopulateStartingGrid();
        }

        public void PopulateStartingGrid()
        {
            // Create a starting grid
            ColourBlocks = new ColourBlock[GridSize, GridSize];

            // Loop through each team and randomly place their starting blocks
            // Start by creating a list which will store all grid locations
            List<Point> gridPoints = new List<Point>();
            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    gridPoints.Add(new Point(i, j));
                }
            }

            Random rand = new Random();
            int teamId = 1;
            // Now randomly pick one and assign to a team, changing the team each time so that each team gets an even number of blocks
            while (gridPoints.Count > 0)
            {
                int rand_num = rand.Next(gridPoints.Count - 1);
                var gridPoint = gridPoints[rand_num];
                ColourBlocks[gridPoint.X, gridPoint.Y] = new ColourBlock(this, (ColourType)teamId, gridPoint.X, gridPoint.Y);

                gridPoints.RemoveAt(rand_num);
                teamId++;

                // If the team id is greater than enum then reset it
                if (teamId > Enum.GetNames(typeof(ColourType)).Length - 1)
                {
                    teamId = 1;

                    // If there are not enough gridpoints left to give each time a block then leave this blank and end
                    if (gridPoints.Count < Enum.GetNames(typeof(ColourType)).Length)
                    {
                        foreach (var remainingGridPoint in gridPoints)
                        {
                            ColourBlocks[remainingGridPoint.X, remainingGridPoint.Y] = new ColourBlock(this, ColourType.Blank, remainingGridPoint.X, remainingGridPoint.Y);
                        }
                        break;
                    }
                }
            }
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
                else
                {
                    colourBlock.Count--;
                }

                // Check the block count. If it is less than 1 then destroy it (but leave residue)
                if (colourBlock.Count < 1)
                {
                    var destroyedBlock = new ColourBlock(this, ColourType.Blank, newPoint.X, newPoint.Y);
                    destroyedBlock.ColourResidue = colourBlock.ColourType;
                    ColourBlocks[newPoint.X, newPoint.Y] = destroyedBlock;

                    // Remove 1 from score
                    Game.Score -= 1;
                }
                else
                {
                    // Set the new location with the colour block
                    ColourBlocks[newPoint.X, newPoint.Y] = colourBlock;
                    // Set the location of the new point
                    colourBlock.I = newPoint.X;
                    colourBlock.J = newPoint.Y;

                    // Add 1 to score
                    Game.Score += 1;
                }
                // Set the old location as blank
                var newBlock = new ColourBlock(this, ColourType.Blank, oldPoint.X, oldPoint.Y);
                newBlock.ColourResidue = colourBlock.ColourType;
                ColourBlocks[oldPoint.X, oldPoint.Y] = newBlock;

            }
        }

        public bool ValidMove(ColourBlock colourBlock, Point newPoint)
        {
            // Check if colourblock is a blank
            if (colourBlock.ColourType == ColourType.Blank)
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
    }
}

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

        public bool MoveBlock(ColourBlock attackerColourBlock, BlockMove blockMove)
        {
            // Get the point of the block that wants to be overwritten
            Point oldPoint = new Point(attackerColourBlock.I, attackerColourBlock.J);
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
                    return false;
            }

            if (ValidMove(attackerColourBlock, newPoint))
            {
                var defenderColourBlock = ColourBlocks[newPoint.X, newPoint.Y];

                // Check if this was a move of the same colour overwriting, and if so then increment the count of this block
                if (defenderColourBlock.ColourType == attackerColourBlock.ColourType)
                {
                    // If so then add the counts of these blocks together
                    attackerColourBlock.Count += defenderColourBlock.Count;
                }
                else
                {
                    // If not then do damage
                    var defenderHealth = GetDefenderHealth(attackerColourBlock.ColourType, defenderColourBlock.ColourType, defenderColourBlock.Count);
                    attackerColourBlock.Count -= defenderHealth;
                }

                // Set the new location with the colour block
                ColourBlocks[newPoint.X, newPoint.Y] = attackerColourBlock;
                // Set the location of the new point
                attackerColourBlock.I = newPoint.X;
                attackerColourBlock.J = newPoint.Y;

                // Set the old location as blank
                var newBlock = new ColourBlock(this, attackerColourBlock.ColourType, oldPoint.X, oldPoint.Y);
                ColourBlocks[oldPoint.X, oldPoint.Y] = newBlock;

                return true;
            }
                
            return false;

        }

        public bool ValidMove(ColourBlock attackerColourBlock, Point newPoint)
        {
            // Check if colourblock is a blank
            if (attackerColourBlock.ColourType == ColourType.Blank)
            {
                return false;
            }

            var defenderColourBlock = ColourBlocks[newPoint.X, newPoint.Y];

            // Check if the block to be overwritten can be overwritten by the count of this block
            var defenderHealth = defenderColourBlock.Count;
            var attackerStrength = attackerColourBlock.Count - 1;

            // Upgrade defender health if weak colour attacking
            defenderHealth = GetDefenderHealth(attackerColourBlock.ColourType, defenderColourBlock.ColourType, defenderHealth);

            // Check if attack can be made
            if (defenderHealth > attackerStrength && attackerColourBlock.ColourType != defenderColourBlock.ColourType)
            {
                return false;
            }

            return true;
        }

        public int GetDefenderHealth(ColourType attacker, ColourType defender, int initialHealth)
        {
            // Upgrade defender health if weak colur attacking
            switch (attacker)
            {
                case ColourType.Red:
                    // RED is worse against BLUE
                    if (defender == ColourType.Blue)
                    {
                        initialHealth *= 2;
                    }
                    break;
                case ColourType.Green:
                    // GREEN is worse against RED
                    if (defender == ColourType.Red)
                    {
                        initialHealth *= 2;
                    }
                    break;
                case ColourType.Blue:
                    // BLUE is worse against GREEN
                    if (defender == ColourType.Green)
                    {
                        initialHealth *= 2;
                    }
                    break;
            }

            return initialHealth;
        }
    }
}

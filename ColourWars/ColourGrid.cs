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
        public const int GridSize = 5;

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

            if (i < 0 || i >= GridSize || j < 0 || j >= GridSize)
            {
                return null;
            }

            return ColourBlocks[i, j];
        }

        /// <summary>
        /// This is a move where you take you block stack and move it onto a neighbouring stack (if possible)
        /// </summary>
        /// <param name="attackerColourBlock"></param>
        /// <param name="blockMove"></param>
        /// <returns></returns>
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
                bool attackMove = false;
                var defenderColourBlock = ColourBlocks[newPoint.X, newPoint.Y];

                // Check if this was a move of the same colour overwriting, and if so then increment the count of this block
                if (defenderColourBlock.ColourType == attackerColourBlock.ColourType)
                {
                    // If so then add the counts of these blocks together
                    attackerColourBlock.Count += defenderColourBlock.Count;
                }
                else
                {
                    attackMove = true;
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

                // Check if this move has resulted in a square of any size of attackers own colour (and if so award +1 to each block in that square)
                if (attackMove)
                {
                    List<ColourBlock> blocksInSquare = CheckSquareCreated(attackerColourBlock);
                    if (blocksInSquare.Count > 0)
                    {
                        // Add a +1 to each block in this square
                        foreach (var blockInSquare in blocksInSquare)
                        {
                            blockInSquare.Count += 1;
                        }
                    }
                }

                return true;
            }
                
            return false;

        }

        /// <summary>
        /// This is a move where you just add 1 count to the block
        /// </summary>
        /// <param name="colourBlock"></param>
        /// <returns></returns>
        public bool AddToBlock(ColourBlock colourBlock)
        {
            colourBlock.Count += 1;
            return true;
        }

        private List<ColourBlock> CheckSquareCreated(ColourBlock colourBlock)
        {
            List<ColourBlock> blocksInSqaure = new List<ColourBlock>();
            var bestDir = 0;

            // By going out in each direction from this colour block, find the largest 'square' that this belongs to
            int[] xAdd = new int[4] { 1, 1, -1, -1 };
            int[] yAdd = new int[4] { 1, -1, -1, 1 };
            int squareSize = 1;

            bool noMoreSquares = false;

            while(!noMoreSquares)
            {
                // Start by incrementing the square size to check
                squareSize++;
                noMoreSquares = true;

                for (int dir = 0; dir < 4; dir++)
                {
                    bool validSquare = true;
                    List<ColourBlock> blocksInSquareCheck = new List<ColourBlock>();
                    for (int i = 0; i < squareSize; i++)
                    {
                        for (int j = 0; j < squareSize; j++)
                        {
                            var iIndex = colourBlock.I + (i * xAdd[dir]);
                            var jIndex = colourBlock.J + (j * yAdd[dir]);

                            // Check if these indices are within limits
                            if (iIndex >= 0 && iIndex < GridSize && jIndex >= 0 && jIndex < GridSize)
                            {
                                // Get this block
                                var checkBlock = ColourBlocks[iIndex, jIndex];
                                //Check if block is the same colour as starting block
                                if (checkBlock.ColourType == colourBlock.ColourType)
                                {
                                    blocksInSquareCheck.Add(checkBlock);
                                }
                                else
                                {
                                    validSquare = false;
                                    break;
                                }
                            }
                            else
                            {
                                validSquare = false;
                                break;
                            }
                        }

                        if (!validSquare)
                        {
                            break;
                        }
                    }

                    // If this square is valid then set it as the largest square found
                    if (validSquare)
                    {
                        blocksInSqaure = blocksInSquareCheck;
                        bestDir = dir;
                        noMoreSquares = false;
                    }
                }
            }

            // Finally just reverse the check to see if a bigger square can be found by searching with this square in the opposite direction
            if (blocksInSqaure.Count > 0)
            {
                bool validSquare = true;
                List<ColourBlock> blocksInSquareCheck = new List<ColourBlock>();

                while (validSquare)
                {
                    for(int i = 0; i < squareSize; i++)
                    {
                        int iIndex = colourBlock.I + (i * -xAdd[bestDir]);
                        int jIndex = colourBlock.J + -yAdd[bestDir];

                        // Check if these indices are within limits
                        if (iIndex >= 0 && iIndex < GridSize && jIndex >= 0 && jIndex < GridSize)
                        {
                            // Get this block
                            var checkBlock = ColourBlocks[iIndex, jIndex];
                            //Check if block is the same colour as starting block
                            if (checkBlock.ColourType == colourBlock.ColourType)
                            {
                                blocksInSquareCheck.Add(checkBlock);
                            }
                            else
                            {
                                validSquare = false;
                                break;
                            }
                        }
                        else
                        {
                            validSquare = false;
                            break;
                        }
                    }
                    
                    if(validSquare)
                    {
                        for (int j = 0; j < squareSize; j++)
                        {
                            int iIndex = colourBlock.I + -xAdd[bestDir];
                            int jIndex = colourBlock.J + (j * -yAdd[bestDir]);

                            // Check if these indices are within limits
                            if (iIndex >= 0 && iIndex < GridSize && jIndex >= 0 && jIndex < GridSize)
                            {
                                // Get this block
                                var checkBlock = ColourBlocks[iIndex, jIndex];
                                //Check if block is the same colour as starting block
                                if (checkBlock.ColourType == colourBlock.ColourType)
                                {
                                    blocksInSquareCheck.Add(checkBlock);
                                }
                                else
                                {
                                    validSquare = false;
                                    break;
                                }
                            }
                            else
                            {
                                validSquare = false;
                                break;
                            }
                        }
                    }

                    if (validSquare)
                    {
                        int iIndex = colourBlock.I + -xAdd[bestDir];
                        int jIndex = colourBlock.J + -yAdd[bestDir];

                        // Check if these indices are within limits
                        if (iIndex >= 0 && iIndex < GridSize && jIndex >= 0 && jIndex < GridSize)
                        {
                            // Get this block
                            var checkBlock = ColourBlocks[iIndex, jIndex];
                            //Check if block is the same colour as starting block
                            if (checkBlock.ColourType == colourBlock.ColourType)
                            {
                                blocksInSquareCheck.Add(checkBlock);
                            }
                            else
                            {
                                validSquare = false;
                            }
                        }
                        else
                        {
                            validSquare = false;
                        }
                    }

                    // If this square is valid then set it as the largest square found
                    if (validSquare)
                    {
                        blocksInSqaure.AddRange(blocksInSquareCheck);
                    }
                }

            }

            return blocksInSqaure;
        }

        public bool ValidMove(ColourBlock attackerColourBlock, Point newPoint)
        {
            // Check if colourblock is a blank
            if (attackerColourBlock.ColourType == ColourType.Blank)
            {
                return false;
            }

            // Check if move is within bounds of the play area
            if (newPoint.X < 0 || newPoint.X >= GridSize || newPoint.Y < 0 || newPoint.Y >= GridSize)
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

        public int GetBlockCount(ColourType colourType)
        {
            int blockCount = 0;

            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    if (ColourBlocks[i,j].ColourType == colourType)
                    {
                        blockCount++;
                    }
                }
            }

            return blockCount;
        }

        public int GetStrength(ColourType colourType)
        {
            int strength = 0;

            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    if (ColourBlocks[i,j].ColourType == colourType)
                    {
                        strength += ColourBlocks[i, j].Count;
                    }
                }
            }

            return strength;
        }
    }
}

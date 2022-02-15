using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MathsJourney.ColourWars.ColourTypeHelper;
using static MathsJourney.ColourWars.BlockMoveHelper;

namespace MathsJourney.ColourWars
{
    public class PlayerMove
    {
        public ColourType ColourType { get; set; }
        public int I { get; set; }
        public int NewI { get => NewPoint.X; }
        public int J { get; set; }
        public int NewJ { get => NewPoint.Y; }
        public Point NewPoint
        {
            get
            {
                var newPoint = GetNewPoint(I, J, BlockMove);
                if (newPoint.HasValue)
                {
                    return newPoint.Value;
                }
                return new Point();
            }
        }
        public BlockMove BlockMove { get; set; }
        public bool ValidMove { get; set; }

        public int PredictedStrength { get; set; }

        public int PredictedBlockCount { get; set; }

        public int SurroundingEnemyBlocks
        {
            get
            {
                int enemyBlocks = 0;

                var xAdd = new int[] { 0, 0, -1, 1 };
                var yAdd = new int[] { -1, 1, 0, 0 };

                for (int m = 0; m < xAdd.Length; m++)
                {
                    var iIndex = I + xAdd[m];
                    var jIndex = J + yAdd[m];

                    if (iIndex < 0 || iIndex >= ColourGrid.GridSize || jIndex < 0 || jIndex >= ColourGrid.GridSize)
                    {
                        continue;
                    }

                    if (_colourGrid.ColourBlocks[iIndex, jIndex].ColourType != ColourType)
                    {
                        enemyBlocks++;
                    }
                }

                return enemyBlocks;
            }
        }

        public double MoveScore { get; set; }

        private ColourGrid _colourGrid { get; set; }
        private ColourGrid _futureColourGrid { get; set; }

        public PlayerMove(ColourGrid colourGrid, ColourType colourType, ColourBlock colourBlock, BlockMove blockMove)
        {
            _colourGrid = colourGrid;
            ColourType = colourType;
            I = colourBlock.I;
            J = colourBlock.J;
            BlockMove = blockMove;

            PredictPlayerStateAfterMove();
        }

        //private const double thisCountWeighting = 1.0;
        //private const double otherCountWeighting = 1.0;
        //private const double predictedStrengthWeighting = 10.0;
        //private const double predictedBlockCountWeighting = 100.0;
        //private const double surroundingEnemyBlockWeighting = 1.0;
        //private const double attackWeighting = 100.0;
        //private const double attackWeakWeighting = 1.0;
        //private const double attackStrongWeighting = 1.0;
        public double CalculateMoveScore(MoveScoreWeightings moveScoreWeightings, ComputerPlayer player)
        {
            // A way over determining how good this move is
            var totalScore = 0.0;

            // Add the count of this block to the score
            totalScore += (double)_colourGrid[I, J].Count / (double)player.Strength * moveScoreWeightings.thisCountWeighting;

            // Add the count of the block moving onto if it is same type
            if (_colourGrid[NewI, NewJ].ColourType == ColourType)
            {
                totalScore += (double)_colourGrid[NewI, NewJ].Count / (double)player.Strength * moveScoreWeightings.otherCountWeighting;
            }
            else
            {
                // add a number if this is an attack move
                totalScore += moveScoreWeightings.attackWeighting;

                // add a number if this is attacking your weakness
                if (GetWeakColourType(ColourType) == _colourGrid[NewI, NewJ].ColourType)
                {
                    totalScore += moveScoreWeightings.attackWeakWeighting;
                }

                // add a number if this is attacking your strength
                if (GetStrongColourType(ColourType) == _colourGrid[NewI, NewJ].ColourType)
                {
                    totalScore += moveScoreWeightings.attackStrongWeighting;
                }
            }

            // add predicted strength after this move
            totalScore += ((double)PredictedStrength - (double)player.Strength) * moveScoreWeightings.predictedStrengthWeighting;

            // add predicted block count after this move
            totalScore += ((double)PredictedBlockCount - (double)player.BlockCount) * moveScoreWeightings.predictedBlockCountWeighting;

            // add number of surrounding enemy blocks after this move
            totalScore += ((double)PredictedBlockCount - (double)player.BlockCount) * moveScoreWeightings.surroundingEnemyBlockWeighting;

            if (EnemyBlockInMoveDirection())
            {
                totalScore += moveScoreWeightings.moveTowardEnemyWeighting;
            }

            return totalScore;
        }

        private bool EnemyBlockInMoveDirection()
        {
            // Check if moving in this direction takes you towards an enemy block
            int xAdd = 0;
            int yAdd = 0;

            switch(BlockMove)
            {
                case BlockMove.Down:
                    yAdd = 1;
                    break;
                case BlockMove.Up:
                    yAdd = -1;
                    break;
                case BlockMove.Left:
                    xAdd = -1;
                    break;
                case BlockMove.Right:
                    xAdd = 1;
                    break;
                default:
                    return false;
            }

            int iIndex = I + xAdd;
            int jIndex = J + yAdd;

            while(iIndex >= 0 && iIndex < ColourGrid.GridSize && jIndex >= 0 && jIndex < ColourGrid.GridSize)
            {
                if (_colourGrid[iIndex, jIndex].ColourType != ColourType)
                {
                    return true;
                }

                iIndex += xAdd;
                jIndex += yAdd;
            }

            return false;
        }

        private void PredictPlayerStateAfterMove()
        {
            // Create a copy of the colourgrid for prediction
            _futureColourGrid = new ColourGrid(_colourGrid, "Prediction Grid");
            var colourBlock = _futureColourGrid.ColourBlocks[I, J];

            if (_futureColourGrid.ValidMove(colourBlock, BlockMove))
            {
                ValidMove = true;

                _futureColourGrid.Game.RefreshGameField();
                _futureColourGrid.MoveBlock(colourBlock, BlockMove);
                _futureColourGrid.Game.RefreshGameField();

                PredictedStrength = _futureColourGrid.GetStrength(ColourType);
                PredictedBlockCount = _futureColourGrid.GetBlockCount(ColourType);
            }
        }
    }
}

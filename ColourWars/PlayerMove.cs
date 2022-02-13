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

        //private const double thisCountWeighting = 1.0;
        //private const double otherCountWeighting = 1.0;
        //private const double predictedStrengthWeighting = 10.0;
        //private const double predictedBlockCountWeighting = 100.0;
        //private const double surroundingEnemyBlockWeighting = 1.0;
        //private const double attackWeighting = 100.0;
        //private const double attackWeakWeighting = 1.0;
        //private const double attackStrongWeighting = 1.0;
        public int MoveScore(MoveScoreWeightings moveScoreWeightings)
        {
            // A way over determining how good this move is
            var totalScore = 0;

            // Add the count of this block to the score
            totalScore += (int)(_colourGrid[I, J].Count * moveScoreWeightings.thisCountWeighting);

            // Add the count of the block moving onto if it is same type
            if (_colourGrid[NewI, NewJ].ColourType == ColourType)
            {
                totalScore += (int)(_colourGrid[NewI, NewJ].Count * moveScoreWeightings.otherCountWeighting);
            }
            else
            {
                // add a number if this is an attack move
                totalScore += (int)moveScoreWeightings.attackWeighting;

                // add a number if this is attacking your weakness
                if (GetWeakColourType(ColourType) == _colourGrid[NewI, NewJ].ColourType)
                {
                    totalScore += (int)moveScoreWeightings.attackWeakWeighting;
                }

                // add a number if this is attacking your strength
                if (GetStrongColourType(ColourType) == _colourGrid[NewI, NewJ].ColourType)
                {
                    totalScore += (int)moveScoreWeightings.attackStrongWeighting;
                }
            }

            // add predicted strength after this move
            totalScore += (int)(PredictedStrength * moveScoreWeightings.predictedStrengthWeighting);

            // add predicted block count after this move
            totalScore += (int)(PredictedBlockCount * moveScoreWeightings.predictedBlockCountWeighting);

            // add number of surrounding enemy blocks after this move
            totalScore += (int)(PredictedBlockCount * moveScoreWeightings.surroundingEnemyBlockWeighting);

            return totalScore;
        }

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

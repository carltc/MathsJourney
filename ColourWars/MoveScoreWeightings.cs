using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathsJourney.ColourWars
{
    public class MoveScoreWeightings
    {
        private const int _initialiseMax = 100;
        private const int _initialiseMin = -100;
        private const double _mutateRatio = 0.5;
        private static Random random = new Random();

        public double thisCountWeighting { get; set; } = 1.0;
        public double otherCountWeighting { get; set; } = 1.0;
        public double predictedStrengthWeighting { get; set; } = 1.0;
        public double predictedBlockCountWeighting { get; set; } = 1.0;
        public double surroundingEnemyBlockWeighting { get; set; } = 1.0;
        public double attackWeighting { get; set; } = 1.0;
        public double attackWeakWeighting { get; set; } = 1.0;
        public double attackStrongWeighting { get; set; } = 1.0;

        public MoveScoreWeightings()
        {
            thisCountWeighting = random.Next(_initialiseMin, _initialiseMax);
            otherCountWeighting = random.Next(_initialiseMin, _initialiseMax);
            predictedStrengthWeighting = random.Next(_initialiseMin, _initialiseMax);
            predictedBlockCountWeighting = random.Next(_initialiseMin, _initialiseMax);
            surroundingEnemyBlockWeighting = random.Next(_initialiseMin, _initialiseMax);
            attackWeighting = random.Next(_initialiseMin, _initialiseMax);
            attackWeakWeighting = random.Next(_initialiseMin, _initialiseMax);
            attackStrongWeighting = random.Next(_initialiseMin, _initialiseMax);
        }

        public static MoveScoreWeightings MutateMoveScoreWeighting(MoveScoreWeightings moveScoreWeightings)
        {
            return new MoveScoreWeightings()
            {
                thisCountWeighting = moveScoreWeightings.thisCountWeighting + random.Next((int)(_initialiseMin * _mutateRatio), (int)(_initialiseMax * _mutateRatio)),
                otherCountWeighting = moveScoreWeightings.otherCountWeighting + random.Next((int)(_initialiseMin * _mutateRatio), (int)(_initialiseMax * _mutateRatio)),
                predictedStrengthWeighting = moveScoreWeightings.predictedStrengthWeighting + random.Next((int)(_initialiseMin * _mutateRatio), (int)(_initialiseMax * _mutateRatio)),
                predictedBlockCountWeighting = moveScoreWeightings.predictedBlockCountWeighting + random.Next((int)(_initialiseMin * _mutateRatio), (int)(_initialiseMax * _mutateRatio)),
                surroundingEnemyBlockWeighting = moveScoreWeightings.surroundingEnemyBlockWeighting + random.Next((int)(_initialiseMin * _mutateRatio), (int)(_initialiseMax * _mutateRatio)),
                attackWeighting = moveScoreWeightings.attackWeighting + random.Next((int)(_initialiseMin * _mutateRatio), (int)(_initialiseMax * _mutateRatio)),
                attackWeakWeighting = moveScoreWeightings.attackWeakWeighting + random.Next((int)(_initialiseMin * _mutateRatio), (int)(_initialiseMax * _mutateRatio)),
                attackStrongWeighting = moveScoreWeightings.attackStrongWeighting + random.Next((int)(_initialiseMin * _mutateRatio), (int)(_initialiseMax * _mutateRatio))
            };
        }

        public static MoveScoreWeightings BreedMoveScoreWeighting(MoveScoreWeightings moveScoreWeightings1, MoveScoreWeightings moveScoreWeightings2)
        {
            var childMoveScoreWeighting = new MoveScoreWeightings();

            childMoveScoreWeighting.thisCountWeighting = BreedParameter(moveScoreWeightings1.thisCountWeighting, moveScoreWeightings2.thisCountWeighting);
            childMoveScoreWeighting.otherCountWeighting = BreedParameter(moveScoreWeightings1.otherCountWeighting, moveScoreWeightings2.otherCountWeighting);
            childMoveScoreWeighting.predictedStrengthWeighting = BreedParameter(moveScoreWeightings1.predictedStrengthWeighting, moveScoreWeightings2.predictedStrengthWeighting);
            childMoveScoreWeighting.predictedBlockCountWeighting = BreedParameter(moveScoreWeightings1.predictedBlockCountWeighting, moveScoreWeightings2.predictedBlockCountWeighting);
            childMoveScoreWeighting.surroundingEnemyBlockWeighting = BreedParameter(moveScoreWeightings1.surroundingEnemyBlockWeighting, moveScoreWeightings2.surroundingEnemyBlockWeighting);
            childMoveScoreWeighting.attackWeighting = BreedParameter(moveScoreWeightings1.attackWeighting, moveScoreWeightings2.attackWeighting);
            childMoveScoreWeighting.attackWeakWeighting = BreedParameter(moveScoreWeightings1.attackWeakWeighting, moveScoreWeightings2.attackWeakWeighting);
            childMoveScoreWeighting.attackStrongWeighting = BreedParameter(moveScoreWeightings1.attackStrongWeighting, moveScoreWeightings2.attackStrongWeighting);

            return childMoveScoreWeighting;
        }

        public static double BreedParameter(double parameter1, double parameter2)
        {
            var i = random.Next(2);
            if (i == 0)
            {
                // Take parameter1
                return parameter1;
            }
            else if (i == 1)
            {
                // Take parameter2
                return parameter2;
            }
            else
            {
                // Take combination
                return (parameter1 + parameter2) / 2;
            }
        }
    }
}

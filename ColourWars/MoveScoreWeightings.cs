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
    }
}

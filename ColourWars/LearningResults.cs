using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathsJourney.ColourWars
{
    public class LearningResults
    {
        public List<LearningResult> BestLearningResults { get; set; } = new List<LearningResult>();
    }

    public class LearningResult
    {
        public int Score { get; set; }
        public MoveScoreWeightings MoveScoreWeightings { get; set; }
    }
}

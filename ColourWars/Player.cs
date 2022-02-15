using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathsJourney.ColourWars
{
    public class Player
    {
        public ColourType ColourType { get; set; }

        public ColourGrid ColourGrid { get; set; }

        public int Strength
        {
            get { return ColourGrid.GetStrength(ColourType); }
        }

        public int BlockCount
        {
            get { return ColourGrid.GetBlockCount(ColourType); }
        }

        public int Score
        {
            get { return Strength + BlockCount; }
        }

        public int TotalScore { get; set; }

        public int Wins { get; set; } = 0;

        public Player(ColourType colourType)
        {
            ColourType = colourType;
        }

    }
}

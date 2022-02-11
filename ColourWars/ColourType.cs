using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathsJourney.ColourWars
{
    public enum ColourType
    {
        Blank,
        Red,
        Green,
        Blue
    }

    public static class ColourTypeHelper
    {
        public static Color GetColour(ColourType colourType)
        {
            switch (colourType)
            {
                case ColourType.Red:
                    return Color.Red;
                case ColourType.Green:
                    return Color.Green;
                case ColourType.Blue:
                    return Color.Blue;
                case ColourType.Blank:
                    return Color.Transparent;
                default:
                    return Color.Black;
            }
        }
    }
}

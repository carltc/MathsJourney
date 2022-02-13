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

        public static ColourType GetWeakColourType(ColourType colourType)
        {
            switch (colourType)
            {
                case ColourType.Red:
                    return ColourType.Blue;
                case ColourType.Green:
                    return ColourType.Red;
                case ColourType.Blue:
                    return ColourType.Green;
                default:
                    return ColourType.Blank;
            }
        }

        public static ColourType GetStrongColourType(ColourType colourType)
        {
            switch (colourType)
            {
                case ColourType.Red:
                    return ColourType.Green;
                case ColourType.Green:
                    return ColourType.Blue;
                case ColourType.Blue:
                    return ColourType.Red;
                default:
                    return ColourType.Blank;
            }
        }
    }
}

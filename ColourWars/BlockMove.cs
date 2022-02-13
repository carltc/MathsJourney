using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathsJourney.ColourWars
{
    public enum BlockMove
    {
        Up,
        Down,
        Left,
        Right,
        Same
    }

    public static class BlockMoveHelper
    {
        public static Point? GetNewPoint(ColourBlock colourBlock, BlockMove blockMove)
        {
            return GetNewPoint(colourBlock.I, colourBlock.J, blockMove);
        }

        public static Point? GetNewPoint(int i, int j, BlockMove blockMove)
        {
            // Get the point of the block that wants to be overwritten
            Point oldPoint = new Point(i, j);
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
                case BlockMove.Same:
                    newPoint = new Point(oldPoint.X, oldPoint.Y);
                    break;
                default:
                    // A new blockmove which has not been implented so therefore return
                    return null;
            }

            return newPoint;
        }

    }
}

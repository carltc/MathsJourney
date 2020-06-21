using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MathsJourney
{
    public class MathBlock
    {
        public BlockLocation Location { get; set; }
        public int Value { get; set; }
        public MathFunction Function { get; set; }
        public bool Used { get; set; }
        public Color Colour { get; set; }

        public MathBlock(int value, MathFunction mathFunction, BlockLocation blockLocation)
        {
            Value = value;
            Function = mathFunction;
            Location = blockLocation;
            Used = false;
            Colour = Color.Black;
        }

    }

    public enum MathFunction
    {
        Add,
        Subtract,
        Multiply,
        Divide
    }

    public class BlockLocation
    {
        public int X { get; set; }
        public int Y { get; set; }

        public BlockLocation(int x, int y)
        {
            X = x;
            Y = y;
        }

        public BlockLocation(BlockLocation blockLocation)
        {
            X = blockLocation.X;
            Y = blockLocation.Y;
        }

        public bool Equals(BlockLocation otherLocation)
        {
            // If parameter is null, return false.
            if (Object.ReferenceEquals(otherLocation, null))
            {
                return false;
            }

            // Optimization for a common success case.
            if (Object.ReferenceEquals(this, otherLocation))
            {
                return true;
            }

            // If run-time types are not exactly the same, return false.
            if (this.GetType() != otherLocation.GetType())
            {
                return false;
            }

            // Return true if the fields match.
            // Note that the base class is not invoked because it is
            // System.Object, which defines Equals as reference equality.
            return (X == otherLocation.X) && (Y == otherLocation.Y);
        }

        public static bool operator ==(BlockLocation lhs, BlockLocation rhs)
        {
            // Check for null on left side.
            if (Object.ReferenceEquals(lhs, null))
            {
                if (Object.ReferenceEquals(rhs, null))
                {
                    // null == null = true.
                    return true;
                }

                // Only the left side is null.
                return false;
            }
            // Equals handles case of null on right side.
            return lhs.Equals(rhs);
        }
        public static bool operator !=(BlockLocation lhs, BlockLocation rhs)
        {
            return !(lhs == rhs);
        }

        public BlockLocation copy()
        {
            var blockLocation = new BlockLocation(this.X, this.Y);
            return blockLocation;
        }
    }
}

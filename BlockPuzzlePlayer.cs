using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathsJourney
{
    public static class BlockPuzzlePlayer
    {
        public static BlockLocation Location { get; set; }
        public static int Value { get; set; }
        public static int Target { get; set; }
        public static int Level { get; set; }

        public static void Initiate(BlockLocation location, int startValue)
        {
            // Set player starting values
            BlockPuzzlePlayer.Location = location;
            BlockPuzzlePlayer.Level = 1;
            BlockPuzzlePlayer.Value = startValue;
        }

        public static bool Move(int Xmove, int Ymove)
        {
            if (!AllowedMove(Xmove,Ymove))
            {
                return false;
            }

            Location.X += Xmove;
            Location.Y += Ymove;

            // Calculate new value.
            BlockPuzzlePlayer.DoMaths(BlockPuzzleGrid.Grid[Location.X, Location.Y]);
            BlockPuzzleGrid.Grid[Location.X, Location.Y].Used = true;

            return true;
        }

        public static bool AllowedMove(int Xmove, int Ymove)
        {
            // Check if move is within boundaries
            if (Location.X + Xmove < 0 || Location.Y + Ymove < 0)
            {
                return false;
            }
            if (Location.X + Xmove >= BlockPuzzleGrid.GridSize || Location.Y + Ymove >= BlockPuzzleGrid.GridSize)
            {
                return false;
            }

            // Check if maths on block is allowed
            BlockLocation newLocation = new BlockLocation(BlockPuzzlePlayer.Location.X + Xmove, BlockPuzzlePlayer.Location.Y + Ymove);
            if (!MathsAllowed(newLocation))
            {
                return false;
            }

            // Don't allow going back to used space.
            if (BlockPuzzleGrid.Grid[newLocation.X, newLocation.Y].Used == true)
            {
                return false;
            }

            return true;
        }

        public static void DoMaths(MathBlock mathBlock)
        {
            switch(mathBlock.Function)
            {
                case MathFunction.Add:
                    Value += mathBlock.Value;
                    break;
                case MathFunction.Subtract:
                    Value -= mathBlock.Value;
                    break;
                case MathFunction.Multiply:
                    Value *= mathBlock.Value;
                    break;
                case MathFunction.Divide:
                    Value /= mathBlock.Value;
                    break;
            }

            if (Value == Target)
            {
                BlockPuzzlePlayer.Level += 1;
                BlockPuzzlePlayer.Target = new Random().Next(1, 100);
            }
        }

        public static bool MathsAllowed(BlockLocation blockLocation)
        {
            // Get block at new location
            var newBlock = BlockPuzzleGrid.Grid[blockLocation.X, blockLocation.Y];

            // Only sum not allowed so far is divide
            if (!newBlock.Used)
            {
                if (newBlock.Function == MathFunction.Divide)
                {
                    // Check if division is allowed
                    if (BlockPuzzlePlayer.Value % newBlock.Value != 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}

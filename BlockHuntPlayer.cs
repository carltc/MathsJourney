using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathsJourney
{
    public static class BlockHuntPlayer
    {
        public static BlockLocation Location { get; set; }
        public static int Value { get; set; }
        public static int Target { get; set; }
        public static int Level { get; set; }

        public static void Initiate()
        {
            // Set player starting values
            BlockHuntPlayer.Location = new BlockLocation(1, 1);
            BlockHuntPlayer.Level = 1;
            BlockHuntPlayer.Value = 5;
            BlockHuntPlayer.Target = 20;
        }

        public static void Move(int Xmove, int Ymove)
        {
            // Check if move is within boundaries
            if (Location.X + Xmove < 0 || Location.Y + Ymove < 0)
            {
                return;
            }
            if(Location.X + Xmove >= BlockHuntGrid.GridSize || Location.Y + Ymove >= BlockHuntGrid.GridSize)
            {
                return;
            }

            // Check if maths on block is allowed
            BlockLocation newLocation = new BlockLocation(BlockHuntPlayer.Location.X + Xmove, BlockHuntPlayer.Location.Y + Ymove);
            if(!MathsAllowed(newLocation))
            {
                return;
            }

            Location.X += Xmove;
            Location.Y += Ymove;
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
                BlockHuntPlayer.Level += 1;
                BlockHuntPlayer.Target = new Random().Next(1, 100);
            }
        }

        public static bool MathsAllowed(BlockLocation blockLocation)
        {
            // Get block at new location
            var newBlock = BlockHuntGrid.Grid[blockLocation.X, blockLocation.Y];

            // Only sum not allowed so far is divide
            if (!newBlock.Used)
            {
                if (newBlock.Function == MathFunction.Divide)
                {
                    // Check if division is allowed
                    if (BlockHuntPlayer.Value % newBlock.Value != 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}

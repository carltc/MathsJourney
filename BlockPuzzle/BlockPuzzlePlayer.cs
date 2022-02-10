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
        public static List<BlockLocation> Locations { get; set; }
        public static List<int> Values { get; set; }
        public static List<int> Targets { get; set; }
        public static int Level { get; set; }

        public static void Initiate(List<BlockLocation> locations, List<int> startValues, List<int> targets)
        {
            // Set player starting values
            BlockPuzzlePlayer.Locations = locations.Select(item => item.copy()).ToList();
            BlockPuzzlePlayer.Level = 1;
            BlockPuzzlePlayer.Values = startValues.Select(item => item).ToList();
            BlockPuzzlePlayer.Targets = targets.Select(item => item).ToList();
        }

        public static bool Move(int puzzleID, int Xmove, int Ymove)
        {
            if (!AllowedMove(puzzleID, Xmove, Ymove))
            {
                return false;
            }

            Locations[puzzleID].X += Xmove;
            Locations[puzzleID].Y += Ymove;

            // Calculate new value.
            BlockPuzzlePlayer.DoMaths(puzzleID, BlockPuzzleGrid.Grid[Locations[puzzleID].X, Locations[puzzleID].Y]);
            BlockPuzzleGrid.Grid[Locations[puzzleID].X, Locations[puzzleID].Y].Used = true;
            BlockPuzzleGrid.Grid[Locations[puzzleID].X, Locations[puzzleID].Y].Colour = BlockPuzzleGrid.Colours[puzzleID];

            return true;
        }

        public static bool AllowedMove(int puzzleID, int Xmove, int Ymove)
        {
            // Check if puzzle completed already
            if (Values[puzzleID] == Targets[puzzleID])
            {
                return false;
            }

            // Check if move is within boundaries
            if (Locations[puzzleID].X + Xmove < 0 || Locations[puzzleID].Y + Ymove < 0)
            {
                return false;
            }
            if (Locations[puzzleID].X + Xmove >= BlockPuzzleGrid.GridSize || Locations[puzzleID].Y + Ymove >= BlockPuzzleGrid.GridSize)
            {
                return false;
            }

            // Check if maths on block is allowed
            BlockLocation newLocation = new BlockLocation(BlockPuzzlePlayer.Locations[puzzleID].X + Xmove, BlockPuzzlePlayer.Locations[puzzleID].Y + Ymove);
            if (!MathsAllowed(puzzleID, newLocation))
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

        public static void DoMaths(int puzzleID, MathBlock mathBlock)
        {
            switch(mathBlock.Function)
            {
                case MathFunction.Add:
                    Values[puzzleID] += mathBlock.Value;
                    break;
                case MathFunction.Subtract:
                    Values[puzzleID] -= mathBlock.Value;
                    break;
                case MathFunction.Multiply:
                    Values[puzzleID] *= mathBlock.Value;
                    break;
                case MathFunction.Divide:
                    Values[puzzleID] /= mathBlock.Value;
                    break;
            }

            //if (Values[puzzleID] == Targets[puzzleID])
            //{
            //    BlockPuzzlePlayer.Level += 1;
            //    BlockPuzzlePlayer.Targets[puzzleID] = new Random().Next(1, 100);
            //}
        }

        public static bool MathsAllowed(int puzzleID, BlockLocation blockLocation)
        {
            // Get block at new location
            var newBlock = BlockPuzzleGrid.Grid[blockLocation.X, blockLocation.Y];

            // Only sum not allowed so far is divide
            if (!newBlock.Used)
            {
                if (newBlock.Function == MathFunction.Divide)
                {
                    // Check if division is allowed
                    if (BlockPuzzlePlayer.Values[puzzleID] % newBlock.Value != 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}

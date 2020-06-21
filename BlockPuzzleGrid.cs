using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace MathsJourney
{
    public static class BlockPuzzleGrid
    {
        public static MathBlock[,] Grid;
        public static int GridSize { get; set; }
        public static int PuzzleCount { get; set; }
        public static Random rand = new Random();
        private static List<int> CurrentValues = new List<int>();
        private static List<BlockLocation> CurrentLocations = new List<BlockLocation>();
        public static List<int> Targets = new List<int>();
        public static List<BlockLocation> StartLocations = new List<BlockLocation>();
        public static List<int> StartValues = new List<int>();
        public static List<Color> Colours = new List<Color>();
        public static List<int> RequiredMoves { get; set; }


        public static void CalculateGrid(int size, int puzzleCount)
        {
            // Reset all lists
            CurrentValues = new List<int>();
            CurrentLocations = new List<BlockLocation>();
            Targets = new List<int>();
            StartLocations = new List<BlockLocation>();
            StartValues = new List<int>();
            Colours = new List<Color>();

            GridSize = size;
            PuzzleCount = puzzleCount;
            Grid = new MathBlock[size, size];
            int minTarget = 1;
            int maxTarget = 20;
            List<bool> PuzzlesComplete = new List<bool>();

            // Initiate each puzzle
            for (int p = 0; p < puzzleCount; p++)
            {
                //Choose target for puzzle
                Targets.Add(rand.Next(minTarget, maxTarget));
                CurrentValues.Add(Targets.Last());

                //Choose Target location
                int blockX = rand.Next(0, size);
                int blockY = rand.Next(0, size);
                while (CurrentLocations.FindIndex(a => a == new BlockLocation(blockX, blockY)) >= 0)
                {
                    blockX = rand.Next(0, size);
                    blockY = rand.Next(0, size);
                }
                CurrentLocations.Add(new BlockLocation(blockX, blockY));
                StartLocations.Add(new BlockLocation(0, 0));
                StartValues.Add(0);

                // Set puzzle colour
                switch (p)
                {
                    case 0:
                        Colours.Add(Color.Green);
                        break;
                    case 1:
                        Colours.Add(Color.Blue);
                        break;
                    case 2:
                        Colours.Add(Color.Orange);
                        break;
                    case 3:
                        Colours.Add(Color.Purple);
                        break;
                    case 4:
                        Colours.Add(Color.LightGray);
                        break;
                    case 5:
                        Colours.Add(Color.Coral);
                        break;
                    case 6:
                        Colours.Add(Color.Aquamarine);
                        break;
                    case 7:
                        Colours.Add(Color.Magenta);
                        break;
                    case 8:
                        Colours.Add(Color.Lime);
                        break;
                    case 9:
                        Colours.Add(Color.Pink);
                        break;
                    default:
                        Colours.Add(Color.Cyan);
                        break;
                }

                PuzzlesComplete.Add(false);
            }

            // Check if any starting locations are the same
            if (CurrentLocations.Count() != CurrentLocations.Distinct().Count())
            {
                return;
            }


            // Calculate each move and create block
            //for (int i = 0; i < desiredMoves; i++)
            while(PuzzlesComplete.Contains(false))
            {
                // loop through for each puzzle
                for (int i = 0; i < PuzzleCount; i++)
                {
                    // Check if puzzle has already been completed.
                    if (!PuzzlesComplete[i])
                    {
                        // Create a random block
                        Grid[CurrentLocations[i].X, CurrentLocations[i].Y] = GetRandomMathBlocks(rand, new BlockLocation(CurrentLocations[i].X, CurrentLocations[i].Y));

                        // Check if block is allowed and if not create a new one
                        while (!BlockAllowed(CurrentValues[i], Grid[CurrentLocations[i].X, CurrentLocations[i].Y], Targets[i]))
                        {
                            Grid[CurrentLocations[i].X, CurrentLocations[i].Y] = GetRandomMathBlocks(rand, new BlockLocation(CurrentLocations[i].X, CurrentLocations[i].Y));
                        }

                        // Calculate all available direction
                        List<BlockLocation> availableLocations = new List<BlockLocation>();

                        //Check up
                        if (MoveAllowed(new BlockLocation(CurrentLocations[i].X, CurrentLocations[i].Y - 1)))
                        {
                            availableLocations.Add(new BlockLocation(CurrentLocations[i].X, CurrentLocations[i].Y - 1));
                        }
                        //Check down
                        if (MoveAllowed(new BlockLocation(CurrentLocations[i].X, CurrentLocations[i].Y + 1)))
                        {
                            availableLocations.Add(new BlockLocation(CurrentLocations[i].X, CurrentLocations[i].Y + 1));
                        }
                        //Check left
                        if (MoveAllowed(new BlockLocation(CurrentLocations[i].X - 1, CurrentLocations[i].Y)))
                        {
                            availableLocations.Add(new BlockLocation(CurrentLocations[i].X - 1, CurrentLocations[i].Y));
                        }
                        //Check down
                        if (MoveAllowed(new BlockLocation(CurrentLocations[i].X + 1, CurrentLocations[i].Y)))
                        {
                            availableLocations.Add(new BlockLocation(CurrentLocations[i].X + 1, CurrentLocations[i].Y));
                        }

                        if (availableLocations.Count() > 0)
                        {
                            // Calculate new value of next location
                            CurrentValues[i] = CalculateReverseBlock(CurrentValues[i], Grid[CurrentLocations[i].X, CurrentLocations[i].Y]);

                            // Choose random next direction
                            var nextLocation = availableLocations[rand.Next(0, availableLocations.Count())];
                            CurrentLocations[i].X = nextLocation.X;
                            CurrentLocations[i].Y = nextLocation.Y;

                        }
                        else
                        {
                            // End puzzle creation
                            Grid[CurrentLocations[i].X, CurrentLocations[i].Y] = new MathBlock(0, MathFunction.Add, new BlockLocation(CurrentLocations[i].X, CurrentLocations[i].Y));
                            PuzzlesComplete[i] = true;

                            // Set starting conditions
                            StartLocations[i] = new BlockLocation(CurrentLocations[i]);
                            StartValues[i] = CurrentValues[i];

                            // Set start location as used to prevent it happening
                            Grid[CurrentLocations[i].X, CurrentLocations[i].Y].Used = true;
                            Grid[CurrentLocations[i].X, CurrentLocations[i].Y].Colour = Colours[i];
                        }
                    }
                }
            }

            // Populate remaining blocks
            for (int i = 0; i <= GridSize - 1; i++)
            {
                for (int j = 0; j <= GridSize - 1; j++)
                {
                    if (Grid[i, j] == null)
                    {
                        Grid[i, j] = GetRandomMathBlocks(rand, new BlockLocation(i, j));
                    }
                }
            }
        }

        public static bool MoveAllowed(BlockLocation newLocation)
        {
            // Check it is inside grid
            if (newLocation.X < 0 || newLocation.X >= GridSize || newLocation.Y < 0 || newLocation.Y >= GridSize)
            {
                return false;
            }

            // Check grid is currently not occupied by mathblock
            if (Grid[newLocation.X, newLocation.Y] != null)
            {
                return false;
            }

            // Check it is not location of another puzzle
            foreach (var currentLocation in CurrentLocations)
            {
                if (newLocation == currentLocation)
                {
                    return false;
                }
            }

            return true;

        }

        public static bool ResetGrid()
        {
            // Reset used status in Grid
            foreach (var block in Grid)
            {
                if (StartLocations.FindIndex(bl => bl == block.Location) >= 0)
                {
                    Grid[block.Location.X, block.Location.Y].Used = true;
                }
                else
                {
                    Grid[block.Location.X, block.Location.Y].Used = false;
                }
            }

            return true;
        }

        public static bool BlockAllowed(int value, MathBlock block, int target)
        {
            // Check if division is allowed
            switch(block.Function)
            {
                case MathFunction.Multiply:
                    if (value%block.Value != 0 || block.Value <= 1)
                    {
                        return false;
                    }
                    break;
                case MathFunction.Divide:
                    if (block.Value <= 1)
                    {
                        return false;
                    }
                    break;
            }

            // Check if next value will be over 150
            if (CalculateReverseBlock(value, block) > 150)
            {
                return false;
            }

            // Check if next value is same as target
            if (CalculateReverseBlock(value, block) == target)
            {
                return false;
            }


            return true;
        }

        public static int CalculateReverseBlock(int value, MathBlock block)
        {
            switch (block.Function)
            {
                case MathFunction.Add:
                    value = value - block.Value;
                    break;
                case MathFunction.Subtract:
                    value = value + block.Value;
                    break;
                case MathFunction.Multiply:
                    value = value / block.Value;
                    break;
                case MathFunction.Divide:
                    value = value * block.Value;
                    break;
            }

            return value;
        }

        public static MathBlock GetRandomMathBlocks(Random rand, BlockLocation location)
        {
            // Randomise maths functions
            MathFunction mathFunction = MathFunction.Add;
            switch (rand.Next(1, 5))
            {
                case 1:
                    mathFunction = MathFunction.Add;
                    break;
                case 2:
                    mathFunction = MathFunction.Subtract;
                    break;
                case 3:
                    mathFunction = MathFunction.Multiply;
                    break;
                case 4:
                    mathFunction = MathFunction.Divide;
                    break;
            }

            var mathBlock = new MathBlock(rand.Next(1, 10), mathFunction, location);
            return mathBlock;
        }

        public static void DrawGrid(PaintEventArgs e)
        {
            for (int i = 0; i <= Grid.GetLength(0) - 1; i++)
            {
                for (int j = 0; j <= Grid.GetLength(1) - 1; j++)
                {
                    // Check if math block player is on has been used and if not then do the function
                    //if (Grid[i, j].Location == BlockPuzzlePlayer.Location)
                    //{
                    //    if (!Grid[i, j].Used)
                    //    {
                    //        BlockPuzzlePlayer.DoMaths(Grid[i, j]);
                    //        Grid[i, j].Used = true;
                    //    }
                    //}

                    var mathBlock = Grid[i, j];
                    DrawBlock(e, mathBlock);
                }
            }
        }

        public static void DrawBlock(PaintEventArgs e, MathBlock mathBlock)
        {
            Pen blockPen;
            SolidBrush blockBrush = null;
            Font drawFont = new Font("Arial", 15);

            string blockText = "";
            if (BlockPuzzlePlayer.Locations.FindIndex(a => a == mathBlock.Location) >= 0)
            {
                // get puzzle index
                int puzzleID = BlockPuzzlePlayer.Locations.FindIndex(i => i == mathBlock.Location);

                // Create pen.
                blockPen = new Pen(Colours[puzzleID], 8);

                blockText = BlockPuzzlePlayer.Values[puzzleID].ToString();

                // Set font
                drawFont = new Font("Arial", 20, FontStyle.Bold);

                // Check if target reached
                if (BlockPuzzleGrid.Targets[puzzleID] == BlockPuzzlePlayer.Values[puzzleID])
                {
                    blockBrush = new SolidBrush(Colours[puzzleID]);
                }
            }
            else
            {
                if (mathBlock.Used)
                {
                    blockPen = new Pen(mathBlock.Colour, 5);
                    blockBrush = new SolidBrush(mathBlock.Colour);
                }
                else
                {
                    blockPen = new Pen(Color.Black, 3);
                }

                // Set up block text
                string valueString = mathBlock.Value.ToString();
                // Get function sign
                string functionString = "";
                switch (mathBlock.Function)
                {
                    case MathFunction.Add:
                        functionString = "+";
                        break;
                    case MathFunction.Subtract:
                        functionString = "-";
                        break;
                    case MathFunction.Multiply:
                        functionString = "x";
                        break;
                    case MathFunction.Divide:
                        functionString = "÷";
                        //if (BlockPuzzlePlayer.Value%mathBlock.Value != 0)
                        //{
                        //    blockBrush = new SolidBrush(Color.Red);
                        //}
                        break;
                }
                blockText = functionString + " " + valueString;
            }

            // Create rectangle.
            int SizeX = 50;
            int SizeY = SizeX;
            Rectangle rect = new Rectangle(mathBlock.Location.X*100, mathBlock.Location.Y*100, SizeX, SizeY);

            // Fill rectangle
            if (blockBrush != null)
            {
                e.Graphics.FillRectangle(blockBrush, rect);
            }

            // Draw rectangle to screen.
            e.Graphics.DrawRectangle(blockPen, rect);

            e.Graphics.DrawRectangle(blockPen, rect);

            SolidBrush drawBrush = new SolidBrush(Color.Black);
            StringFormat drawFormat = new StringFormat();
            e.Graphics.DrawString(blockText, drawFont, drawBrush, mathBlock.Location.X * 100 + 7, mathBlock.Location.Y * 100 + 15, drawFormat);
        }
    }
}

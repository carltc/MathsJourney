using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace MathsJourney
{
    public static class BlockPuzzleGrid
    {
        public static MathBlock[,] Grid;
        public static int GridSize;
        public static Random rand = new Random();
        public static int Target { get; set; }
        public static BlockLocation StartLocation { get; set; }
        public static int StartValue { get; set; }
        public static int RequiredMoves { get; set; }


        // Store current grid and settings so game can be restarted
        public static MathBlock[,] CurrentGrid;
        public static int CurrentTarget { get; set; }
        public static BlockLocation CurrentStartLocation { get; set; }
        public static int CurrentStartValue { get; set; }
        public static int CurrentRequiredMoves { get; set; }

        public static void CalculateGrid(int size, int desiredMoves)
        {
            GridSize = size;

            Grid = new MathBlock[size, size];

            //Choose target for puzzle
            Target = rand.Next(1, 100);
            int CurrentValue = Target;
            int moves = 0;

            //Choose Target location
            int blockX = rand.Next(0, size);
            int blockY = rand.Next(0, size);

            // Calculate each move and create block
            for (int i = 0; i < desiredMoves; i++)
            {
                // Create a random block
                Grid[blockX, blockY] = GetRandomMathBlocks(rand, new BlockLocation(blockX, blockY));

                // Check if block is allowed and if not create a new one
                while (!BlockAllowed(CurrentValue, Grid[blockX, blockY]))
                {
                    Grid[blockX, blockY] = GetRandomMathBlocks(rand, new BlockLocation(blockX, blockY));
                }

                // Calculate new value of next location
                CurrentValue = CalculateReverseBlock(CurrentValue, Grid[blockX, blockY]);
                moves++;

                // Calculate all available direction
                List<BlockLocation> availableLocations = new List<BlockLocation>();

                //Check up
                if (blockY - 1 >= 0 && Grid[blockX, blockY - 1] == null)
                {
                    availableLocations.Add(new BlockLocation(blockX, blockY - 1));
                }
                //Check down
                if (blockY + 1 < size && Grid[blockX, blockY + 1] == null)
                {
                    availableLocations.Add(new BlockLocation(blockX, blockY + 1));
                }
                //Check left
                if (blockX - 1 >= 0 && Grid[blockX - 1, blockY] == null)
                {
                    availableLocations.Add(new BlockLocation(blockX - 1, blockY));
                }
                //Check down
                if (blockX + 1 < size && Grid[blockX + 1, blockY] == null)
                {
                    availableLocations.Add(new BlockLocation(blockX + 1, blockY));
                }

                if (availableLocations.Count() > 0)
                {
                    // Choose random next direction
                    var nextLocation = availableLocations[rand.Next(0, availableLocations.Count())];
                    blockX = nextLocation.X;
                    blockY = nextLocation.Y;
                }
                else
                {
                    Grid[blockX, blockY] = new MathBlock(0, MathFunction.Add, new BlockLocation(blockX, blockY));
                    break;
                }
            }

            // Set starting criteria
            StartLocation = new BlockLocation(blockX, blockY);
            StartValue = CurrentValue;
            RequiredMoves = moves;

            Console.WriteLine($"Start location: X:{blockX} Y:{blockY}");

            // Populate remaining blocks
            for (int i = 0; i <= GridSize-1; i++)
            {
                for (int j = 0; j <= GridSize-1; j++)
                {
                    if (Grid[i, j] == null)
                    {
                        Grid[i, j] = GetRandomMathBlocks(rand, new BlockLocation(i, j));
                    }
                }
            }

            // Set start location as used to prevent it happening
            Grid[blockX, blockY].Used = true;


            // Set current variables so game can be restarted
            CurrentStartLocation = new BlockLocation(StartLocation.X,StartLocation.Y);
        }

        public static bool ResetGrid()
        {
            if (CurrentStartLocation != null)
            {
                StartLocation = new BlockLocation(CurrentStartLocation.X, CurrentStartLocation.Y);

                // Reset used status in Grid
                foreach (var block in Grid)
                {
                    if (block.Location != StartLocation)
                    {
                        Grid[block.Location.X, block.Location.Y].Used = false;
                    }
                }

                return true;
            }
            return false;
        }

        public static bool BlockAllowed(int value, MathBlock block)
        {
            // Check if division is allowed
            switch(block.Function)
            {
                case MathFunction.Multiply:
                    if (value%block.Value != 0)
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
            string blockText = "";
            if (mathBlock.Location == BlockPuzzlePlayer.Location)
            {
                // Create pen.
                blockPen = new Pen(Color.Green, 8);

                blockText = BlockPuzzlePlayer.Value.ToString();
            }
            else
            {
                if (mathBlock.Used)
                {
                    blockPen = new Pen(Color.Gray, 5);
                }
                else
                {
                    // Create pen.
                    blockPen = new Pen(Color.Black, 3);

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
                            if (BlockPuzzlePlayer.Value%mathBlock.Value != 0)
                            {
                                blockBrush = new SolidBrush(Color.Red);
                            }
                            break;
                    }
                    blockText = functionString + " " + valueString;
                }
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

            Font drawFont = new Font("Arial", 15);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            StringFormat drawFormat = new StringFormat();
            e.Graphics.DrawString(blockText, drawFont, drawBrush, mathBlock.Location.X * 100 + 7, mathBlock.Location.Y * 100 + 15, drawFormat);
        }
    }
}

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
    public static class BlockHuntGrid
    {
        public static MathBlock[,] Grid;
        public static int GridSize = 8;
        public static Random rand = new Random();

        public static void CalculateGrid()
        {
            Grid = new MathBlock[GridSize, GridSize];
            for (int i = 0; i <= GridSize-1; i++)
            {
                for (int j = 0; j <= GridSize-1; j++)
                {
                    Grid[i, j] = GetRandomMathBlocks(rand, new BlockLocation(i, j));
                }
            }
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

        public static void Repopulate()
        {
            // Find a random used block and re-populate it
            List<MathBlock> blocks = new List<MathBlock>();
            foreach (var block in Grid)
            {
                blocks.Add(block);
            }
            Random rnd = new Random();
            blocks = blocks.OrderBy(x => rnd.Next()).ToList();

            foreach(var block in blocks)
            {
                if (block.Used && block.Location != BlockHuntPlayer.Location)
                {
                    Grid[block.Location.X, block.Location.Y] = GetRandomMathBlocks(rand, block.Location);
                    return;
                }
            }
        }

        public static int GetUsedBlocks()
        {
            int usedBlockCount = 0;
            foreach (var block in Grid)
            {
                // Check if block is used and it is not under player block
                if (block.Used && block.Location != BlockHuntPlayer.Location)
                {
                    usedBlockCount += 1;
                }
            }

            return usedBlockCount;
        }

        public static void DrawGrid(PaintEventArgs e)
        {
            for (int i = 0; i <= Grid.GetLength(0) - 1; i++)
            {
                for (int j = 0; j <= Grid.GetLength(1) - 1; j++)
                {
                    // Check if math block player is on has been used and if not then do the function
                    if (Grid[i, j].Location == BlockHuntPlayer.Location)
                    {
                        if (!Grid[i, j].Used)
                        {
                            BlockHuntPlayer.DoMaths(Grid[i, j]);
                            Grid[i, j].Used = true;
                        }
                    }

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
            if (mathBlock.Location == BlockHuntPlayer.Location)
            {
                // Create pen.
                blockPen = new Pen(Color.Green, 8);

                blockText = BlockHuntPlayer.Value.ToString();
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
                            if (BlockHuntPlayer.Value%mathBlock.Value != 0)
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

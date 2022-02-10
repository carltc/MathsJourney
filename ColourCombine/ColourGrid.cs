using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathsJourney.ColourCombine
{
    public class ColourGrid
    {
        /// <summary>
        /// MUST be even
        /// </summary>
        public const int GridSize = 8;

        public ColourCombine Game { get; set; }
        public Size GameFieldSize { get; set; }

        public ColourBlock[,] ColourBlocks { get; set; }

        public ColourGrid(ColourCombine game, Size gameFieldSize)
        {
            Game = game;
            GameFieldSize = gameFieldSize;

            // Create a starting grid
            ColourBlocks = new ColourBlock[GridSize, GridSize];

            // Set the central 4 blocks to Red, Green, Blue and Blank
            int gridCentre = GridSize / 2 - 1;
            ColourBlocks[gridCentre, gridCentre] = new ColourBlock(this, ColourType.Red, gridCentre, gridCentre);
            ColourBlocks[gridCentre+1, gridCentre] = new ColourBlock(this, ColourType.Green, gridCentre+1, gridCentre);
            ColourBlocks[gridCentre+1, gridCentre+1] = new ColourBlock(this, ColourType.Blue, gridCentre+1, gridCentre+1);
            ColourBlocks[gridCentre, gridCentre+1] = new ColourBlock(this, ColourType.Blank, gridCentre, gridCentre+1);
        }
    }
}

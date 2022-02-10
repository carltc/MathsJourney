using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MathsJourney.DrawingHelper;

namespace MathsJourney.ColourCombine
{
    public class ColourBlock
    {
        private ColourGrid _parentGrid { get; set; }
        public ColourType ColourType { get; set; }

        public int X { get; set; }
        public int Y { get; set; }
        public int Count { get; set; }

        public Point BlockLocation { get => new Point(X * BlockWidth, Y * BlockHeight); }

        public int BlockWidth { get => _parentGrid.GameFieldSize.Width / ColourGrid.GridSize; }
        public int BlockHeight { get => _parentGrid.GameFieldSize.Height / ColourGrid.GridSize; }

        public bool ShouldFill { get => ColourType != ColourType.Blank; }
        public Color FillColour
        {
            get
            {
                switch (ColourType)
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
        }
        
        public Color BorderColour { get => Color.Black; }

        public ColourBlock(ColourGrid parentGrid, ColourType colourType, int x, int y)
        {
            _parentGrid = parentGrid;
            ColourType = colourType;
            X = x;
            Y = y;
        }

        public void DrawBlock(PaintEventArgs e)
        {
            DrawRectangle(e, BlockLocation, BlockWidth, BlockHeight, BorderColour, ShouldFill, FillColour);
        }
    }
}

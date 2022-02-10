using System.Drawing;
using System.Windows.Forms;
using static MathsJourney.DrawingHelper;

namespace MathsJourney.ColourCombine
{
    public class ColourBlock
    {
        private ColourGrid _parentGrid { get; set; }
        public ColourType ColourType { get; set; }

        public int I { get; set; }
        public int J { get; set; }
        public int Count { get; set; }

        public Point BlockLocation { get => new Point(I * BlockWidth, J * BlockHeight); }

        public int BlockWidth { get => _parentGrid.BlockWidth; }
        public int BlockHeight { get => _parentGrid.BlockHeight; }

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
            I = x;
            J = y;
        }

        public void DrawBlock(PaintEventArgs e)
        {
            DrawRectangle(e, BlockLocation, BlockWidth, BlockHeight, BorderColour, ShouldFill, FillColour);
        }
    }
}

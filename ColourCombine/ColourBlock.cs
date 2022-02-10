using System.Drawing;
using System.Windows.Forms;
using static MathsJourney.DrawingHelper;

namespace MathsJourney.ColourCombine
{
    public class ColourBlock
    {
        private ColourGrid _parentGrid { get; set; }
        public ColourType ColourType { get; set; }
        public ColourType ColourResidue { get; set; } = ColourType.Blank;

        public int I { get; set; }
        public int J { get; set; }

        private int _count = 1;
        public int Count
        {
            get
            {
                if (ColourType == ColourType.Blank)
                {
                    return 0;
                }
                return _count;
            }
            set => _count = value;
        }

        public Point BlockLocation { get => new Point(I * BlockWidth, J * BlockHeight); }

        public Point BlockCentre
        {
            get => new Point(BlockLocation.X + BlockWidth / 2, BlockLocation.Y + BlockHeight / 2);
        }

        public int BlockWidth { get => _parentGrid.BlockWidth; }
        public int BlockHeight { get => _parentGrid.BlockHeight; }

        public bool ShouldFill { get => ColourType != ColourType.Blank || ColourResidue != ColourType.Blank; }
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
                        switch(ColourResidue)
                        {
                            case ColourType.Red:
                                return Color.PaleVioletRed;
                            case ColourType.Green:
                                return Color.LightGreen;
                            case ColourType.Blue:
                                return Color.LightBlue;
                            default:
                                return Color.Transparent;
                        }
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
            // Draw the block
            DrawRectangle(e, BlockLocation, BlockWidth, BlockHeight, BorderColour, ShouldFill, FillColour);

            // Draw the count text if it is greater than 1
            if (Count > 1)
            {
                DrawText(e, Count.ToString(), BlockCentre);
            }
        }
    }
}

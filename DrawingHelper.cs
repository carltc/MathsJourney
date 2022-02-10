using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathsJourney
{
    public static class DrawingHelper
    {
        public static void DrawRectangle(PaintEventArgs e, Point rectangleTopLeft, int rectangleWidth, int rectangleHeight, Color borderColor, bool fill, Color fillColor, float borderWidth = 1)
        {
            Pen rectanglePen = new Pen(borderColor, borderWidth);
            SolidBrush rectangleBrush = new SolidBrush(fillColor);
            
            Rectangle rect = new Rectangle(rectangleTopLeft.X, rectangleTopLeft.Y, rectangleWidth, rectangleHeight);

            // Fill rectangle
            if (fill)
            {
                e.Graphics.FillRectangle(rectangleBrush, rect);
            }

            // Draw rectangle to screen.
            e.Graphics.DrawRectangle(rectanglePen, rect);

            e.Graphics.DrawRectangle(rectanglePen, rect);
        }
    }
}

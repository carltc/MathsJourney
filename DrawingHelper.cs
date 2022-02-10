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

        public static void DrawText(PaintEventArgs e, string text, Point location)
        {
            Font drawFont = new Font("Arial", 15);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            StringFormat drawFormat = new StringFormat();
            drawFormat.Alignment = StringAlignment.Center;
            drawFormat.LineAlignment = StringAlignment.Center;
            e.Graphics.DrawString(text, drawFont, drawBrush, location.X, location.Y, drawFormat);
        }
    }
}

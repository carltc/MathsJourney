using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathsJourney.ColourCombine
{
    public partial class ColourCombine : Form
    {
        public ColourGrid ColourGrid { get; set; }

        public ColourCombine()
        {
            InitializeComponent();
            ColourGrid = new ColourGrid(this, GameField.Size);
        }

        private void GameField_Paint(object sender, PaintEventArgs e)
        {
            DrawGrid(e);
        }

        public void DrawGrid(PaintEventArgs e)
        {
            for (int i = 0; i < ColourGrid.GridSize; i++)
            {
                for (int j = 0; j < ColourGrid.GridSize; j++)
                {
                    var colourBlock = ColourGrid.ColourBlocks[i, j];

                    if (colourBlock != null)
                    {
                        colourBlock.DrawBlock(e);
                    }
                }
            }
        }
    }
}

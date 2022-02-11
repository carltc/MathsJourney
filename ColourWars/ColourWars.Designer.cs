
namespace MathsJourney.ColourWars
{
    partial class ColourWars
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GameField = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.GameField)).BeginInit();
            this.SuspendLayout();
            // 
            // GameField
            // 
            this.GameField.Location = new System.Drawing.Point(12, 12);
            this.GameField.Name = "GameField";
            this.GameField.Size = new System.Drawing.Size(500, 500);
            this.GameField.TabIndex = 0;
            this.GameField.TabStop = false;
            this.GameField.Paint += new System.Windows.Forms.PaintEventHandler(this.GameField_Paint);
            this.GameField.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameField_MouseDown);
            this.GameField.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GameField_MouseMove);
            this.GameField.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GameField_MouseUp);
            // 
            // ColourWars
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 523);
            this.Controls.Add(this.GameField);
            this.Name = "ColourWars";
            this.Text = "ColourCombine";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ColourCombine_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.GameField)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox GameField;
    }
}
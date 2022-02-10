
namespace MathsJourney.ColourCombine
{
    partial class ColourCombine
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
            this.IncreaseLevelButton = new System.Windows.Forms.Button();
            this.ScoreLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GameField)).BeginInit();
            this.SuspendLayout();
            // 
            // GameField
            // 
            this.GameField.Location = new System.Drawing.Point(12, 43);
            this.GameField.Name = "GameField";
            this.GameField.Size = new System.Drawing.Size(500, 500);
            this.GameField.TabIndex = 0;
            this.GameField.TabStop = false;
            this.GameField.Paint += new System.Windows.Forms.PaintEventHandler(this.GameField_Paint);
            this.GameField.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameField_MouseDown);
            this.GameField.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GameField_MouseMove);
            this.GameField.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GameField_MouseUp);
            // 
            // IncreaseLevelButton
            // 
            this.IncreaseLevelButton.Location = new System.Drawing.Point(12, 549);
            this.IncreaseLevelButton.Name = "IncreaseLevelButton";
            this.IncreaseLevelButton.Size = new System.Drawing.Size(500, 50);
            this.IncreaseLevelButton.TabIndex = 1;
            this.IncreaseLevelButton.Text = "Increase Level";
            this.IncreaseLevelButton.UseVisualStyleBackColor = true;
            this.IncreaseLevelButton.Click += new System.EventHandler(this.IncreaseLevelButton_Click);
            // 
            // ScoreLabel
            // 
            this.ScoreLabel.AutoSize = true;
            this.ScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreLabel.Location = new System.Drawing.Point(12, 9);
            this.ScoreLabel.Name = "ScoreLabel";
            this.ScoreLabel.Size = new System.Drawing.Size(123, 31);
            this.ScoreLabel.TabIndex = 2;
            this.ScoreLabel.Text = "Score: 0";
            // 
            // ColourCombine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 610);
            this.Controls.Add(this.ScoreLabel);
            this.Controls.Add(this.IncreaseLevelButton);
            this.Controls.Add(this.GameField);
            this.Name = "ColourCombine";
            this.Text = "ColourCombine";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ColourCombine_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.GameField)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox GameField;
        private System.Windows.Forms.Button IncreaseLevelButton;
        private System.Windows.Forms.Label ScoreLabel;
    }
}
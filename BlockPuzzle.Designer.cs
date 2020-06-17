namespace MathsJourney
{
    partial class BlockPuzzle
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
            this.PuzzleBox = new System.Windows.Forms.PictureBox();
            this.TargetLabel = new System.Windows.Forms.Label();
            this.TargetValueLabel = new System.Windows.Forms.Label();
            this.MovesValueLabel = new System.Windows.Forms.Label();
            this.MovesLabel = new System.Windows.Forms.Label();
            this.NewGameButton = new System.Windows.Forms.Button();
            this.StartLabelValue = new System.Windows.Forms.Label();
            this.StartLabel = new System.Windows.Forms.Label();
            this.GameResultLabel = new System.Windows.Forms.Label();
            this.ResetButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PuzzleBox)).BeginInit();
            this.SuspendLayout();
            // 
            // PuzzleBox
            // 
            this.PuzzleBox.Location = new System.Drawing.Point(12, 12);
            this.PuzzleBox.Name = "PuzzleBox";
            this.PuzzleBox.Size = new System.Drawing.Size(400, 400);
            this.PuzzleBox.TabIndex = 0;
            this.PuzzleBox.TabStop = false;
            this.PuzzleBox.Paint += new System.Windows.Forms.PaintEventHandler(this.PuzzleBox_Paint);
            // 
            // TargetLabel
            // 
            this.TargetLabel.AutoSize = true;
            this.TargetLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TargetLabel.Location = new System.Drawing.Point(418, 72);
            this.TargetLabel.Name = "TargetLabel";
            this.TargetLabel.Size = new System.Drawing.Size(85, 26);
            this.TargetLabel.TabIndex = 1;
            this.TargetLabel.Text = "Target: ";
            // 
            // TargetValueLabel
            // 
            this.TargetValueLabel.AutoSize = true;
            this.TargetValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TargetValueLabel.Location = new System.Drawing.Point(509, 72);
            this.TargetValueLabel.Name = "TargetValueLabel";
            this.TargetValueLabel.Size = new System.Drawing.Size(24, 26);
            this.TargetValueLabel.TabIndex = 2;
            this.TargetValueLabel.Text = "0";
            // 
            // MovesValueLabel
            // 
            this.MovesValueLabel.AutoSize = true;
            this.MovesValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MovesValueLabel.Location = new System.Drawing.Point(509, 133);
            this.MovesValueLabel.Name = "MovesValueLabel";
            this.MovesValueLabel.Size = new System.Drawing.Size(24, 26);
            this.MovesValueLabel.TabIndex = 4;
            this.MovesValueLabel.Text = "0";
            // 
            // MovesLabel
            // 
            this.MovesLabel.AutoSize = true;
            this.MovesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MovesLabel.Location = new System.Drawing.Point(418, 133);
            this.MovesLabel.Name = "MovesLabel";
            this.MovesLabel.Size = new System.Drawing.Size(88, 26);
            this.MovesLabel.TabIndex = 3;
            this.MovesLabel.Text = "Moves: ";
            // 
            // NewGameButton
            // 
            this.NewGameButton.Location = new System.Drawing.Point(642, 374);
            this.NewGameButton.Name = "NewGameButton";
            this.NewGameButton.Size = new System.Drawing.Size(146, 40);
            this.NewGameButton.TabIndex = 5;
            this.NewGameButton.Text = "New Puzzle";
            this.NewGameButton.UseVisualStyleBackColor = true;
            this.NewGameButton.Click += new System.EventHandler(this.NewGameButton_Click);
            // 
            // StartLabelValue
            // 
            this.StartLabelValue.AutoSize = true;
            this.StartLabelValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartLabelValue.Location = new System.Drawing.Point(509, 12);
            this.StartLabelValue.Name = "StartLabelValue";
            this.StartLabelValue.Size = new System.Drawing.Size(24, 26);
            this.StartLabelValue.TabIndex = 7;
            this.StartLabelValue.Text = "0";
            // 
            // StartLabel
            // 
            this.StartLabel.AutoSize = true;
            this.StartLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartLabel.Location = new System.Drawing.Point(418, 12);
            this.StartLabel.Name = "StartLabel";
            this.StartLabel.Size = new System.Drawing.Size(70, 26);
            this.StartLabel.TabIndex = 6;
            this.StartLabel.Text = "Start: ";
            // 
            // GameResultLabel
            // 
            this.GameResultLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.GameResultLabel.AutoSize = true;
            this.GameResultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameResultLabel.Location = new System.Drawing.Point(485, 253);
            this.GameResultLabel.Name = "GameResultLabel";
            this.GameResultLabel.Size = new System.Drawing.Size(224, 46);
            this.GameResultLabel.TabIndex = 8;
            this.GameResultLabel.Text = "Completed!";
            this.GameResultLabel.Visible = false;
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(418, 372);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(146, 40);
            this.ResetButton.TabIndex = 9;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // BlockPuzzle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 426);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.GameResultLabel);
            this.Controls.Add(this.StartLabelValue);
            this.Controls.Add(this.StartLabel);
            this.Controls.Add(this.NewGameButton);
            this.Controls.Add(this.MovesValueLabel);
            this.Controls.Add(this.MovesLabel);
            this.Controls.Add(this.TargetValueLabel);
            this.Controls.Add(this.TargetLabel);
            this.Controls.Add(this.PuzzleBox);
            this.KeyPreview = true;
            this.Name = "BlockPuzzle";
            this.Text = "BlockPuzzle";
            this.Load += new System.EventHandler(this.BlockPuzzle_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BlockPuzzle_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.PuzzleBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PuzzleBox;
        private System.Windows.Forms.Label TargetLabel;
        private System.Windows.Forms.Label TargetValueLabel;
        private System.Windows.Forms.Label MovesValueLabel;
        private System.Windows.Forms.Label MovesLabel;
        private System.Windows.Forms.Button NewGameButton;
        private System.Windows.Forms.Label StartLabelValue;
        private System.Windows.Forms.Label StartLabel;
        private System.Windows.Forms.Label GameResultLabel;
        private System.Windows.Forms.Button ResetButton;
    }
}
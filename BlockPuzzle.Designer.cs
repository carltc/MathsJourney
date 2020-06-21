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
            this.NewGameButton = new System.Windows.Forms.Button();
            this.GameResultLabel = new System.Windows.Forms.Label();
            this.ResetButton = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PuzzleBox)).BeginInit();
            this.SuspendLayout();
            // 
            // PuzzleBox
            // 
            this.PuzzleBox.Location = new System.Drawing.Point(12, 12);
            this.PuzzleBox.Name = "PuzzleBox";
            this.PuzzleBox.Size = new System.Drawing.Size(500, 500);
            this.PuzzleBox.TabIndex = 0;
            this.PuzzleBox.TabStop = false;
            this.PuzzleBox.Paint += new System.Windows.Forms.PaintEventHandler(this.PuzzleBox_Paint);
            // 
            // NewGameButton
            // 
            this.NewGameButton.Enabled = false;
            this.NewGameButton.Location = new System.Drawing.Point(780, 374);
            this.NewGameButton.Name = "NewGameButton";
            this.NewGameButton.Size = new System.Drawing.Size(146, 40);
            this.NewGameButton.TabIndex = 5;
            this.NewGameButton.Text = "New Puzzle";
            this.NewGameButton.UseVisualStyleBackColor = true;
            this.NewGameButton.Click += new System.EventHandler(this.NewGameButton_Click);
            // 
            // GameResultLabel
            // 
            this.GameResultLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.GameResultLabel.AutoSize = true;
            this.GameResultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameResultLabel.Location = new System.Drawing.Point(692, 253);
            this.GameResultLabel.Name = "GameResultLabel";
            this.GameResultLabel.Size = new System.Drawing.Size(224, 46);
            this.GameResultLabel.TabIndex = 8;
            this.GameResultLabel.Text = "Completed!";
            this.GameResultLabel.Visible = false;
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(556, 372);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(146, 40);
            this.ResetButton.TabIndex = 9;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(556, 12);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(370, 147);
            this.listView1.TabIndex = 10;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(556, 165);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(370, 29);
            this.button1.TabIndex = 11;
            this.button1.Text = "Switch Puzzle";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BlockPuzzle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 537);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.GameResultLabel);
            this.Controls.Add(this.NewGameButton);
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
        private System.Windows.Forms.Button NewGameButton;
        private System.Windows.Forms.Label GameResultLabel;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button button1;
    }
}

namespace MathsJourney
{
    partial class MainMenu
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.PlayBlockHuntButton = new System.Windows.Forms.Button();
            this.PlayBlockPuzzleButton = new System.Windows.Forms.Button();
            this.PlayColourCombineButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.PlayBlockHuntButton);
            this.flowLayoutPanel1.Controls.Add(this.PlayBlockPuzzleButton);
            this.flowLayoutPanel1.Controls.Add(this.PlayColourCombineButton);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(776, 426);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // PlayBlockHuntButton
            // 
            this.PlayBlockHuntButton.Location = new System.Drawing.Point(3, 3);
            this.PlayBlockHuntButton.Name = "PlayBlockHuntButton";
            this.PlayBlockHuntButton.Size = new System.Drawing.Size(200, 100);
            this.PlayBlockHuntButton.TabIndex = 0;
            this.PlayBlockHuntButton.Text = "Play Block Hunt";
            this.PlayBlockHuntButton.UseVisualStyleBackColor = true;
            this.PlayBlockHuntButton.Click += new System.EventHandler(this.PlayBlockHuntButton_Click);
            // 
            // PlayBlockPuzzleButton
            // 
            this.PlayBlockPuzzleButton.Location = new System.Drawing.Point(209, 3);
            this.PlayBlockPuzzleButton.Name = "PlayBlockPuzzleButton";
            this.PlayBlockPuzzleButton.Size = new System.Drawing.Size(200, 100);
            this.PlayBlockPuzzleButton.TabIndex = 1;
            this.PlayBlockPuzzleButton.Text = "Play Block Puzzle";
            this.PlayBlockPuzzleButton.UseVisualStyleBackColor = true;
            this.PlayBlockPuzzleButton.Click += new System.EventHandler(this.PlayBlockPuzzleButton_Click);
            // 
            // PlayColourCombineButton
            // 
            this.PlayColourCombineButton.Location = new System.Drawing.Point(415, 3);
            this.PlayColourCombineButton.Name = "PlayColourCombineButton";
            this.PlayColourCombineButton.Size = new System.Drawing.Size(200, 100);
            this.PlayColourCombineButton.TabIndex = 2;
            this.PlayColourCombineButton.Text = "Play Colour Combine";
            this.PlayColourCombineButton.UseVisualStyleBackColor = true;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button PlayBlockHuntButton;
        private System.Windows.Forms.Button PlayBlockPuzzleButton;
        private System.Windows.Forms.Button PlayColourCombineButton;
    }
}
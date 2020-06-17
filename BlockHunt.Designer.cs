namespace MathsJourney
{
    partial class BlockHunt
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.TargetValueLabel = new System.Windows.Forms.Label();
            this.TargetProgressBar = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PlayerLevelLabel = new System.Windows.Forms.Label();
            this.GameOverLabel = new System.Windows.Forms.Label();
            this.NewGameButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 800);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint_1);
            // 
            // TargetValueLabel
            // 
            this.TargetValueLabel.AutoSize = true;
            this.TargetValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TargetValueLabel.Location = new System.Drawing.Point(725, 9);
            this.TargetValueLabel.Name = "TargetValueLabel";
            this.TargetValueLabel.Size = new System.Drawing.Size(86, 31);
            this.TargetValueLabel.TabIndex = 1;
            this.TargetValueLabel.Text = "label1";
            // 
            // TargetProgressBar
            // 
            this.TargetProgressBar.Location = new System.Drawing.Point(211, 9);
            this.TargetProgressBar.Name = "TargetProgressBar";
            this.TargetProgressBar.Size = new System.Drawing.Size(401, 31);
            this.TargetProgressBar.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(618, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 31);
            this.label2.TabIndex = 3;
            this.label2.Text = "Target:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 31);
            this.label1.TabIndex = 5;
            this.label1.Text = "Level:";
            // 
            // PlayerLevelLabel
            // 
            this.PlayerLevelLabel.AutoSize = true;
            this.PlayerLevelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerLevelLabel.Location = new System.Drawing.Point(105, 9);
            this.PlayerLevelLabel.Name = "PlayerLevelLabel";
            this.PlayerLevelLabel.Size = new System.Drawing.Size(86, 31);
            this.PlayerLevelLabel.TabIndex = 4;
            this.PlayerLevelLabel.Text = "label1";
            // 
            // GameOverLabel
            // 
            this.GameOverLabel.AutoSize = true;
            this.GameOverLabel.BackColor = System.Drawing.Color.Black;
            this.GameOverLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameOverLabel.ForeColor = System.Drawing.Color.White;
            this.GameOverLabel.Location = new System.Drawing.Point(195, 346);
            this.GameOverLabel.Name = "GameOverLabel";
            this.GameOverLabel.Size = new System.Drawing.Size(450, 91);
            this.GameOverLabel.TabIndex = 6;
            this.GameOverLabel.Text = "Game Over";
            this.GameOverLabel.Visible = false;
            // 
            // NewGameButton
            // 
            this.NewGameButton.Location = new System.Drawing.Point(195, 462);
            this.NewGameButton.Name = "NewGameButton";
            this.NewGameButton.Size = new System.Drawing.Size(450, 48);
            this.NewGameButton.TabIndex = 7;
            this.NewGameButton.Text = "Start New Game";
            this.NewGameButton.UseVisualStyleBackColor = true;
            this.NewGameButton.Visible = false;
            this.NewGameButton.Click += new System.EventHandler(this.NewGameButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 855);
            this.Controls.Add(this.NewGameButton);
            this.Controls.Add(this.GameOverLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PlayerLevelLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TargetProgressBar);
            this.Controls.Add(this.TargetValueLabel);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label TargetValueLabel;
        private System.Windows.Forms.ProgressBar TargetProgressBar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label PlayerLevelLabel;
        private System.Windows.Forms.Label GameOverLabel;
        private System.Windows.Forms.Button NewGameButton;
    }
}


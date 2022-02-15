
namespace MathsJourney.ColourWars
{
    partial class LearnColourWars
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
            this.BeginLearningButton = new System.Windows.Forms.Button();
            this.RedPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.RedPlayerLabel = new System.Windows.Forms.Label();
            this.BluePlayerLabel = new System.Windows.Forms.Label();
            this.BluePropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.GreenPlayerLabel = new System.Windows.Forms.Label();
            this.GreenPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.ResultsPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.BestResultGrid = new System.Windows.Forms.PropertyGrid();
            this.MostWinsLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BeginLearningButton
            // 
            this.BeginLearningButton.Location = new System.Drawing.Point(12, 12);
            this.BeginLearningButton.Name = "BeginLearningButton";
            this.BeginLearningButton.Size = new System.Drawing.Size(95, 23);
            this.BeginLearningButton.TabIndex = 0;
            this.BeginLearningButton.Text = "BeginLearning";
            this.BeginLearningButton.UseVisualStyleBackColor = true;
            this.BeginLearningButton.Click += new System.EventHandler(this.BeginLearningButton_Click);
            // 
            // RedPropertyGrid
            // 
            this.RedPropertyGrid.Location = new System.Drawing.Point(12, 80);
            this.RedPropertyGrid.Name = "RedPropertyGrid";
            this.RedPropertyGrid.Size = new System.Drawing.Size(236, 304);
            this.RedPropertyGrid.TabIndex = 1;
            // 
            // RedPlayerLabel
            // 
            this.RedPlayerLabel.AutoSize = true;
            this.RedPlayerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RedPlayerLabel.ForeColor = System.Drawing.Color.Red;
            this.RedPlayerLabel.Location = new System.Drawing.Point(12, 46);
            this.RedPlayerLabel.Name = "RedPlayerLabel";
            this.RedPlayerLabel.Size = new System.Drawing.Size(67, 31);
            this.RedPlayerLabel.TabIndex = 2;
            this.RedPlayerLabel.Text = "Red";
            // 
            // BluePlayerLabel
            // 
            this.BluePlayerLabel.AutoSize = true;
            this.BluePlayerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BluePlayerLabel.ForeColor = System.Drawing.Color.Blue;
            this.BluePlayerLabel.Location = new System.Drawing.Point(496, 46);
            this.BluePlayerLabel.Name = "BluePlayerLabel";
            this.BluePlayerLabel.Size = new System.Drawing.Size(72, 31);
            this.BluePlayerLabel.TabIndex = 4;
            this.BluePlayerLabel.Text = "Blue";
            // 
            // BluePropertyGrid
            // 
            this.BluePropertyGrid.Location = new System.Drawing.Point(496, 80);
            this.BluePropertyGrid.Name = "BluePropertyGrid";
            this.BluePropertyGrid.Size = new System.Drawing.Size(236, 304);
            this.BluePropertyGrid.TabIndex = 3;
            // 
            // GreenPlayerLabel
            // 
            this.GreenPlayerLabel.AutoSize = true;
            this.GreenPlayerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GreenPlayerLabel.ForeColor = System.Drawing.Color.Green;
            this.GreenPlayerLabel.Location = new System.Drawing.Point(254, 46);
            this.GreenPlayerLabel.Name = "GreenPlayerLabel";
            this.GreenPlayerLabel.Size = new System.Drawing.Size(94, 31);
            this.GreenPlayerLabel.TabIndex = 6;
            this.GreenPlayerLabel.Text = "Green";
            // 
            // GreenPropertyGrid
            // 
            this.GreenPropertyGrid.Location = new System.Drawing.Point(254, 80);
            this.GreenPropertyGrid.Name = "GreenPropertyGrid";
            this.GreenPropertyGrid.Size = new System.Drawing.Size(236, 304);
            this.GreenPropertyGrid.TabIndex = 5;
            // 
            // ResultsPropertyGrid
            // 
            this.ResultsPropertyGrid.Location = new System.Drawing.Point(1143, 12);
            this.ResultsPropertyGrid.Name = "ResultsPropertyGrid";
            this.ResultsPropertyGrid.Size = new System.Drawing.Size(319, 426);
            this.ResultsPropertyGrid.TabIndex = 7;
            // 
            // BestResultGrid
            // 
            this.BestResultGrid.Location = new System.Drawing.Point(823, 46);
            this.BestResultGrid.Name = "BestResultGrid";
            this.BestResultGrid.Size = new System.Drawing.Size(314, 392);
            this.BestResultGrid.TabIndex = 8;
            // 
            // MostWinsLabel
            // 
            this.MostWinsLabel.AutoSize = true;
            this.MostWinsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MostWinsLabel.ForeColor = System.Drawing.Color.Black;
            this.MostWinsLabel.Location = new System.Drawing.Point(817, 12);
            this.MostWinsLabel.Name = "MostWinsLabel";
            this.MostWinsLabel.Size = new System.Drawing.Size(166, 31);
            this.MostWinsLabel.TabIndex = 9;
            this.MostWinsLabel.Text = "Most Wins: ";
            // 
            // LearnColourWars
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1474, 450);
            this.Controls.Add(this.MostWinsLabel);
            this.Controls.Add(this.BestResultGrid);
            this.Controls.Add(this.ResultsPropertyGrid);
            this.Controls.Add(this.GreenPlayerLabel);
            this.Controls.Add(this.GreenPropertyGrid);
            this.Controls.Add(this.BluePlayerLabel);
            this.Controls.Add(this.BluePropertyGrid);
            this.Controls.Add(this.RedPlayerLabel);
            this.Controls.Add(this.RedPropertyGrid);
            this.Controls.Add(this.BeginLearningButton);
            this.Name = "LearnColourWars";
            this.Text = "LearnColourWars";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BeginLearningButton;
        private System.Windows.Forms.PropertyGrid RedPropertyGrid;
        private System.Windows.Forms.Label RedPlayerLabel;
        private System.Windows.Forms.Label BluePlayerLabel;
        private System.Windows.Forms.PropertyGrid BluePropertyGrid;
        private System.Windows.Forms.Label GreenPlayerLabel;
        private System.Windows.Forms.PropertyGrid GreenPropertyGrid;
        private System.Windows.Forms.PropertyGrid ResultsPropertyGrid;
        private System.Windows.Forms.PropertyGrid BestResultGrid;
        private System.Windows.Forms.Label MostWinsLabel;
    }
}
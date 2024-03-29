﻿
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
            this.RedTeamLabel = new System.Windows.Forms.Label();
            this.GreenTeamLabel = new System.Windows.Forms.Label();
            this.BlueTeamLabel = new System.Windows.Forms.Label();
            this.StrengthLabel = new System.Windows.Forms.Label();
            this.BlocksLabel = new System.Windows.Forms.Label();
            this.GoodBadLabel = new System.Windows.Forms.Label();
            this.GreenBadAgainstLabel = new System.Windows.Forms.Label();
            this.BlueBadAgainstLabel = new System.Windows.Forms.Label();
            this.RedBadAgainstLabel = new System.Windows.Forms.Label();
            this.RedStrengthLabel = new System.Windows.Forms.Label();
            this.RedBlocksLabel = new System.Windows.Forms.Label();
            this.GreenStrengthLabel = new System.Windows.Forms.Label();
            this.GreenBlocksLabel = new System.Windows.Forms.Label();
            this.BlueStrengthLabel = new System.Windows.Forms.Label();
            this.BlueBlocksLabel = new System.Windows.Forms.Label();
            this.RedGoodAgainstLabel = new System.Windows.Forms.Label();
            this.BlueGoodAgainstLabel = new System.Windows.Forms.Label();
            this.GreenGoodAgainstLabel = new System.Windows.Forms.Label();
            this.SkipTurnButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GameField)).BeginInit();
            this.SuspendLayout();
            // 
            // GameField
            // 
            this.GameField.Location = new System.Drawing.Point(12, 149);
            this.GameField.Name = "GameField";
            this.GameField.Size = new System.Drawing.Size(500, 500);
            this.GameField.TabIndex = 0;
            this.GameField.TabStop = false;
            this.GameField.Paint += new System.Windows.Forms.PaintEventHandler(this.GameField_Paint);
            this.GameField.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameField_MouseDown);
            this.GameField.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GameField_MouseMove);
            this.GameField.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GameField_MouseUp);
            // 
            // RedTeamLabel
            // 
            this.RedTeamLabel.AutoSize = true;
            this.RedTeamLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RedTeamLabel.ForeColor = System.Drawing.Color.Red;
            this.RedTeamLabel.Location = new System.Drawing.Point(99, 9);
            this.RedTeamLabel.Name = "RedTeamLabel";
            this.RedTeamLabel.Size = new System.Drawing.Size(75, 31);
            this.RedTeamLabel.TabIndex = 1;
            this.RedTeamLabel.Text = "RED";
            // 
            // GreenTeamLabel
            // 
            this.GreenTeamLabel.AutoSize = true;
            this.GreenTeamLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GreenTeamLabel.ForeColor = System.Drawing.Color.Green;
            this.GreenTeamLabel.Location = new System.Drawing.Point(230, 9);
            this.GreenTeamLabel.Name = "GreenTeamLabel";
            this.GreenTeamLabel.Size = new System.Drawing.Size(116, 31);
            this.GreenTeamLabel.TabIndex = 2;
            this.GreenTeamLabel.Text = "GREEN";
            // 
            // BlueTeamLabel
            // 
            this.BlueTeamLabel.AutoSize = true;
            this.BlueTeamLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BlueTeamLabel.ForeColor = System.Drawing.Color.Blue;
            this.BlueTeamLabel.Location = new System.Drawing.Point(398, 9);
            this.BlueTeamLabel.Name = "BlueTeamLabel";
            this.BlueTeamLabel.Size = new System.Drawing.Size(89, 31);
            this.BlueTeamLabel.TabIndex = 3;
            this.BlueTeamLabel.Text = "BLUE";
            // 
            // StrengthLabel
            // 
            this.StrengthLabel.AutoSize = true;
            this.StrengthLabel.Location = new System.Drawing.Point(29, 56);
            this.StrengthLabel.Name = "StrengthLabel";
            this.StrengthLabel.Size = new System.Drawing.Size(50, 13);
            this.StrengthLabel.TabIndex = 4;
            this.StrengthLabel.Text = "Strength:";
            // 
            // BlocksLabel
            // 
            this.BlocksLabel.AutoSize = true;
            this.BlocksLabel.Location = new System.Drawing.Point(37, 88);
            this.BlocksLabel.Name = "BlocksLabel";
            this.BlocksLabel.Size = new System.Drawing.Size(42, 13);
            this.BlocksLabel.TabIndex = 5;
            this.BlocksLabel.Text = "Blocks:";
            // 
            // GoodBadLabel
            // 
            this.GoodBadLabel.AutoSize = true;
            this.GoodBadLabel.Location = new System.Drawing.Point(12, 119);
            this.GoodBadLabel.Name = "GoodBadLabel";
            this.GoodBadLabel.Size = new System.Drawing.Size(57, 13);
            this.GoodBadLabel.TabIndex = 6;
            this.GoodBadLabel.Text = "Good/Bad";
            // 
            // GreenBadAgainstLabel
            // 
            this.GreenBadAgainstLabel.AutoSize = true;
            this.GreenBadAgainstLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GreenBadAgainstLabel.ForeColor = System.Drawing.Color.Red;
            this.GreenBadAgainstLabel.Location = new System.Drawing.Point(269, 133);
            this.GreenBadAgainstLabel.Name = "GreenBadAgainstLabel";
            this.GreenBadAgainstLabel.Size = new System.Drawing.Size(33, 13);
            this.GreenBadAgainstLabel.TabIndex = 7;
            this.GreenBadAgainstLabel.Text = "RED";
            // 
            // BlueBadAgainstLabel
            // 
            this.BlueBadAgainstLabel.AutoSize = true;
            this.BlueBadAgainstLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BlueBadAgainstLabel.ForeColor = System.Drawing.Color.Green;
            this.BlueBadAgainstLabel.Location = new System.Drawing.Point(428, 133);
            this.BlueBadAgainstLabel.Name = "BlueBadAgainstLabel";
            this.BlueBadAgainstLabel.Size = new System.Drawing.Size(50, 13);
            this.BlueBadAgainstLabel.TabIndex = 8;
            this.BlueBadAgainstLabel.Text = "GREEN";
            // 
            // RedBadAgainstLabel
            // 
            this.RedBadAgainstLabel.AutoSize = true;
            this.RedBadAgainstLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RedBadAgainstLabel.ForeColor = System.Drawing.Color.Blue;
            this.RedBadAgainstLabel.Location = new System.Drawing.Point(122, 133);
            this.RedBadAgainstLabel.Name = "RedBadAgainstLabel";
            this.RedBadAgainstLabel.Size = new System.Drawing.Size(39, 13);
            this.RedBadAgainstLabel.TabIndex = 9;
            this.RedBadAgainstLabel.Text = "BLUE";
            // 
            // RedStrengthLabel
            // 
            this.RedStrengthLabel.AutoSize = true;
            this.RedStrengthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RedStrengthLabel.ForeColor = System.Drawing.Color.Black;
            this.RedStrengthLabel.Location = new System.Drawing.Point(119, 42);
            this.RedStrengthLabel.Name = "RedStrengthLabel";
            this.RedStrengthLabel.Size = new System.Drawing.Size(30, 31);
            this.RedStrengthLabel.TabIndex = 10;
            this.RedStrengthLabel.Text = "0";
            // 
            // RedBlocksLabel
            // 
            this.RedBlocksLabel.AutoSize = true;
            this.RedBlocksLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RedBlocksLabel.ForeColor = System.Drawing.Color.Black;
            this.RedBlocksLabel.Location = new System.Drawing.Point(119, 73);
            this.RedBlocksLabel.Name = "RedBlocksLabel";
            this.RedBlocksLabel.Size = new System.Drawing.Size(30, 31);
            this.RedBlocksLabel.TabIndex = 11;
            this.RedBlocksLabel.Text = "0";
            // 
            // GreenStrengthLabel
            // 
            this.GreenStrengthLabel.AutoSize = true;
            this.GreenStrengthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GreenStrengthLabel.ForeColor = System.Drawing.Color.Black;
            this.GreenStrengthLabel.Location = new System.Drawing.Point(266, 41);
            this.GreenStrengthLabel.Name = "GreenStrengthLabel";
            this.GreenStrengthLabel.Size = new System.Drawing.Size(30, 31);
            this.GreenStrengthLabel.TabIndex = 12;
            this.GreenStrengthLabel.Text = "0";
            // 
            // GreenBlocksLabel
            // 
            this.GreenBlocksLabel.AutoSize = true;
            this.GreenBlocksLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GreenBlocksLabel.ForeColor = System.Drawing.Color.Black;
            this.GreenBlocksLabel.Location = new System.Drawing.Point(266, 70);
            this.GreenBlocksLabel.Name = "GreenBlocksLabel";
            this.GreenBlocksLabel.Size = new System.Drawing.Size(30, 31);
            this.GreenBlocksLabel.TabIndex = 13;
            this.GreenBlocksLabel.Text = "0";
            // 
            // BlueStrengthLabel
            // 
            this.BlueStrengthLabel.AutoSize = true;
            this.BlueStrengthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BlueStrengthLabel.ForeColor = System.Drawing.Color.Black;
            this.BlueStrengthLabel.Location = new System.Drawing.Point(425, 41);
            this.BlueStrengthLabel.Name = "BlueStrengthLabel";
            this.BlueStrengthLabel.Size = new System.Drawing.Size(30, 31);
            this.BlueStrengthLabel.TabIndex = 14;
            this.BlueStrengthLabel.Text = "0";
            // 
            // BlueBlocksLabel
            // 
            this.BlueBlocksLabel.AutoSize = true;
            this.BlueBlocksLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BlueBlocksLabel.ForeColor = System.Drawing.Color.Black;
            this.BlueBlocksLabel.Location = new System.Drawing.Point(425, 73);
            this.BlueBlocksLabel.Name = "BlueBlocksLabel";
            this.BlueBlocksLabel.Size = new System.Drawing.Size(30, 31);
            this.BlueBlocksLabel.TabIndex = 15;
            this.BlueBlocksLabel.Text = "0";
            // 
            // RedGoodAgainstLabel
            // 
            this.RedGoodAgainstLabel.AutoSize = true;
            this.RedGoodAgainstLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RedGoodAgainstLabel.ForeColor = System.Drawing.Color.Green;
            this.RedGoodAgainstLabel.Location = new System.Drawing.Point(101, 111);
            this.RedGoodAgainstLabel.Name = "RedGoodAgainstLabel";
            this.RedGoodAgainstLabel.Size = new System.Drawing.Size(72, 20);
            this.RedGoodAgainstLabel.TabIndex = 16;
            this.RedGoodAgainstLabel.Text = "GREEN";
            // 
            // BlueGoodAgainstLabel
            // 
            this.BlueGoodAgainstLabel.AutoSize = true;
            this.BlueGoodAgainstLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BlueGoodAgainstLabel.ForeColor = System.Drawing.Color.Red;
            this.BlueGoodAgainstLabel.Location = new System.Drawing.Point(400, 111);
            this.BlueGoodAgainstLabel.Name = "BlueGoodAgainstLabel";
            this.BlueGoodAgainstLabel.Size = new System.Drawing.Size(47, 20);
            this.BlueGoodAgainstLabel.TabIndex = 17;
            this.BlueGoodAgainstLabel.Text = "RED";
            // 
            // GreenGoodAgainstLabel
            // 
            this.GreenGoodAgainstLabel.AutoSize = true;
            this.GreenGoodAgainstLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GreenGoodAgainstLabel.ForeColor = System.Drawing.Color.Blue;
            this.GreenGoodAgainstLabel.Location = new System.Drawing.Point(232, 111);
            this.GreenGoodAgainstLabel.Name = "GreenGoodAgainstLabel";
            this.GreenGoodAgainstLabel.Size = new System.Drawing.Size(56, 20);
            this.GreenGoodAgainstLabel.TabIndex = 18;
            this.GreenGoodAgainstLabel.Text = "BLUE";
            // 
            // SkipTurnButton
            // 
            this.SkipTurnButton.Location = new System.Drawing.Point(4, 5);
            this.SkipTurnButton.Name = "SkipTurnButton";
            this.SkipTurnButton.Size = new System.Drawing.Size(75, 23);
            this.SkipTurnButton.TabIndex = 19;
            this.SkipTurnButton.Text = "Skip Turn";
            this.SkipTurnButton.UseVisualStyleBackColor = true;
            this.SkipTurnButton.Click += new System.EventHandler(this.SkipTurnButton_Click);
            // 
            // ColourWars
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 661);
            this.Controls.Add(this.SkipTurnButton);
            this.Controls.Add(this.GreenGoodAgainstLabel);
            this.Controls.Add(this.BlueGoodAgainstLabel);
            this.Controls.Add(this.RedGoodAgainstLabel);
            this.Controls.Add(this.BlueBlocksLabel);
            this.Controls.Add(this.BlueStrengthLabel);
            this.Controls.Add(this.GreenBlocksLabel);
            this.Controls.Add(this.GreenStrengthLabel);
            this.Controls.Add(this.RedBlocksLabel);
            this.Controls.Add(this.RedStrengthLabel);
            this.Controls.Add(this.RedBadAgainstLabel);
            this.Controls.Add(this.BlueBadAgainstLabel);
            this.Controls.Add(this.GreenBadAgainstLabel);
            this.Controls.Add(this.GoodBadLabel);
            this.Controls.Add(this.BlocksLabel);
            this.Controls.Add(this.StrengthLabel);
            this.Controls.Add(this.BlueTeamLabel);
            this.Controls.Add(this.GreenTeamLabel);
            this.Controls.Add(this.RedTeamLabel);
            this.Controls.Add(this.GameField);
            this.Name = "ColourWars";
            this.Text = "ColourCombine";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ColourCombine_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.GameField)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox GameField;
        private System.Windows.Forms.Label RedTeamLabel;
        private System.Windows.Forms.Label GreenTeamLabel;
        private System.Windows.Forms.Label BlueTeamLabel;
        private System.Windows.Forms.Label StrengthLabel;
        private System.Windows.Forms.Label BlocksLabel;
        private System.Windows.Forms.Label GoodBadLabel;
        private System.Windows.Forms.Label GreenBadAgainstLabel;
        private System.Windows.Forms.Label BlueBadAgainstLabel;
        private System.Windows.Forms.Label RedBadAgainstLabel;
        private System.Windows.Forms.Label RedStrengthLabel;
        private System.Windows.Forms.Label RedBlocksLabel;
        private System.Windows.Forms.Label GreenStrengthLabel;
        private System.Windows.Forms.Label GreenBlocksLabel;
        private System.Windows.Forms.Label BlueStrengthLabel;
        private System.Windows.Forms.Label BlueBlocksLabel;
        private System.Windows.Forms.Label RedGoodAgainstLabel;
        private System.Windows.Forms.Label BlueGoodAgainstLabel;
        private System.Windows.Forms.Label GreenGoodAgainstLabel;
        private System.Windows.Forms.Button SkipTurnButton;
    }
}
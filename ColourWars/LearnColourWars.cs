using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathsJourney.ColourWars
{
    public partial class LearnColourWars : Form
    {
        public MoveScoreWeightings RedPlayer { get; set; }
        public MoveScoreWeightings GreenPlayer { get; set; }
        public MoveScoreWeightings BluePlayer { get; set; }

        private ColourWars ColourWarsGame { get; set; }

        public LearnColourWars()
        {
            InitializeComponent();

            RedPlayer = new MoveScoreWeightings();
            RedPropertyGrid.SelectedObject = RedPlayer;

            GreenPlayer = new MoveScoreWeightings();
            GreenPropertyGrid.SelectedObject = GreenPlayer;

            BluePlayer = new MoveScoreWeightings();
            BluePropertyGrid.SelectedObject = BluePlayer;

            ColourWarsGame = new ColourWars(RedPlayer, GreenPlayer, BluePlayer);
        }

        private void BeginLearningButton_Click(object sender, EventArgs e)
        {
            ColourWarsGame.Show();

            ColourWarsGame.BeginGame();

            ColourWarsGame.Close();
        }
    }
}

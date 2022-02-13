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
        public ComputerPlayer RedPlayer { get; set; }
        public ComputerPlayer GreenPlayer { get; set; }
        public ComputerPlayer BluePlayer { get; set; }
        public List<ComputerPlayer> Players { get; set; }

        public LearningResults LearningResults { get; set; } = new LearningResults();

        private ColourWars ColourWarsGame { get; set; }

        public LearnColourWars()
        {
            InitializeComponent();

            RedPlayer = new ComputerPlayer(new MoveScoreWeightings(), ColourType.Red);

            GreenPlayer = new ComputerPlayer(new MoveScoreWeightings(), ColourType.Green);

            BluePlayer = new ComputerPlayer(new MoveScoreWeightings(), ColourType.Blue);

            ResultsPropertyGrid.SelectedObject = LearningResults;

            Players = new List<ComputerPlayer>() { RedPlayer, GreenPlayer, BluePlayer };

            UpdatePlayerWinsLabels();
        }

        private void UpdatePlayerWinsLabels()
        {
            RedPlayerLabel.Text = $"RED - {RedPlayer.Wins}:{RedPlayer.TotalScore}";
            RedPropertyGrid.SelectedObject = RedPlayer.MoveScoreWeightings;

            GreenPlayerLabel.Text = $"GREEN - {GreenPlayer.Wins}:{GreenPlayer.TotalScore}";
            GreenPropertyGrid.SelectedObject = GreenPlayer.MoveScoreWeightings;

            BluePlayerLabel.Text = $"BLUE - {BluePlayer.Wins}:{BluePlayer.TotalScore}";
            BluePropertyGrid.SelectedObject = BluePlayer.MoveScoreWeightings;
        }

        private void BeginLearningButton_Click(object sender, EventArgs e)
        {
            // Play 100 games
            for(int i = 0; i < 100; i++)
            {
                PlayGame();
            }

            // Save the score of the best player
            LearningResult learningResult;
            ComputerPlayer bestPlayer;
            if (RedPlayer.Wins > GreenPlayer.Wins && RedPlayer.Wins > BluePlayer.Wins)
            {
                bestPlayer = RedPlayer;
            }
            else if (GreenPlayer.Wins > BluePlayer.Wins)
            {
                bestPlayer = GreenPlayer;
            }
            else
            {
                bestPlayer = BluePlayer;
            }
            learningResult = new LearningResult()
            {
                Score = bestPlayer.TotalScore,
                MoveScoreWeightings = bestPlayer.MoveScoreWeightings
            };
            LearningResults.BestLearningResults.Add(learningResult);

            bool firstPlayer = true;
            foreach(var player in Players)
            {
                if (player != bestPlayer)
                {
                    if (firstPlayer)
                    {
                        player.MoveScoreWeightings = MoveScoreWeightings.MutateMoveScoreWeighting(bestPlayer.MoveScoreWeightings);
                        firstPlayer = false;
                    }
                    else
                    {
                        if (LearningResults.BestLearningResults.Count >= 2)
                        {
                            var bestMoveScoreWeighting = LearningResults.BestLearningResults.OrderByDescending(msw => msw.Score).Select(msw => msw.MoveScoreWeightings).ToList()[0];
                            var secondBestMoveScoreWeighting = LearningResults.BestLearningResults.OrderByDescending(msw => msw.Score).Select(msw => msw.MoveScoreWeightings).ToList()[1];

                            player.MoveScoreWeightings = MoveScoreWeightings.BreedMoveScoreWeighting(bestMoveScoreWeighting, secondBestMoveScoreWeighting);
                        }
                        else
                        {
                            player.MoveScoreWeightings = MoveScoreWeightings.MutateMoveScoreWeighting(bestPlayer.MoveScoreWeightings);
                        }
                    }
                }
                player.Wins = 0;
                player.TotalScore = 0;
            }
        }

        private void PlayGame()
        {
            ColourWarsGame = new ColourWars(RedPlayer, GreenPlayer, BluePlayer, 100);

            //ColourWarsGame.Show();
            ColourWarsGame.BeginGame();
            //ColourWarsGame.Close();

            UpdatePlayerWinsLabels();
        }
    }
}

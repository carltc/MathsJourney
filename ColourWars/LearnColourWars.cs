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
            for (int i = 0; i < 100; i++)
            {
                ComputerPlayer bestPlayer = null;
                LearningResult learningResult = null;

                if (PlayGame())
                {
                    // There was a winner. Find out who
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

                    // Save the score of the best player
                    learningResult = new LearningResult()
                    {
                        Score = bestPlayer.Wins,
                        MoveScoreWeightings = bestPlayer.MoveScoreWeightings
                    };
                    LearningResults.BestLearningResults.Add(learningResult);
                }

                foreach (var player in Players)
                {
                    if (player != bestPlayer)
                    {
                        if (bestPlayer != null && LearningResults.BestLearningResults.Count >= 2)
                        {
                            if (i % 2 == 0)
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
                        else
                        {
                            var startingScoreWeighting = new MoveScoreWeightings()
                            {
                                thisCountWeighting = 1,
                                otherCountWeighting = 2,
                                predictedStrengthWeighting = 5,
                                predictedBlockCountWeighting = 8,
                                surroundingEnemyBlockWeighting = 100,
                                attackWeighting = 200,
                                attackWeakWeighting = 500,
                                attackStrongWeighting = 300,
                                moveTowardEnemyWeighting = 500,
                                chancePickingRandomMove = 10
                            };

                            player.MoveScoreWeightings = MoveScoreWeightings.MutateMoveScoreWeighting(startingScoreWeighting);
                        }
                        player.Wins = 0;
                        player.TotalScore = 0;
                    }
                    else
                    {

                    }
                }
            }

            // At the end populate the grid with the best scoring weighting
            var bestResult = LearningResults.BestLearningResults.OrderByDescending(lr => lr.Score).FirstOrDefault();
            BestResultGrid.SelectedObject = bestResult.MoveScoreWeightings;
            MostWinsLabel.Text = $"Most Wins: {bestResult.Score}";
        }

        private bool PlayGame()
        {
            ColourWarsGame = new ColourWars(RedPlayer, GreenPlayer, BluePlayer, 100);

            //ColourWarsGame.Show();
            ColourWarsGame.BeginGame();
            //ColourWarsGame.Close();

            UpdatePlayerWinsLabels();

            // Check if anyone has won
            if (ColourWarsGame.Winner != null)
            {
                return true;
            }

            return false;
        }
    }
}

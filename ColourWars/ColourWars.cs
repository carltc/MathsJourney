using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using static MathsJourney.ColourWars.ColourTypeHelper;
using static MathsJourney.DrawingHelper;

namespace MathsJourney.ColourWars
{
    public partial class ColourWars : Form
    {
        public ColourGrid ColourGrid { get; set; }

        public int TeamsTurn = 1;

        public bool GameIsLive = true;

        private int MovesMade = 0;

        private int MaxMatchMoves = 0;

        public Player Winner { get; set; } = null;

        public Player RedPlayer { get; set; }
        public Player GreenPlayer { get; set; }
        public Player BluePlayer { get; set; }

        public List<Player> Players { get; set; }

        public ColourWars(Player redPlayer, Player greenPlayer, Player bluePlayer, int MatchMoves = 0)
        {
            InitializeComponent();
            ColourGrid = new ColourGrid("MainGrid", this, GameField.Size);

            // Create Computer players for Green and Blue teams
            RedPlayer = redPlayer; // new ComputerPlayer(redScoreWeightings, ColourGrid, ColourType.Red);
            RedPlayer.ColourGrid = ColourGrid;

            GreenPlayer = greenPlayer; // new ComputerPlayer(greenScoreWeightings, ColourGrid, ColourType.Green);
            GreenPlayer.ColourGrid = ColourGrid;

            BluePlayer = bluePlayer; // new ComputerPlayer(blueScoreWeightings, ColourGrid, ColourType.Blue);
            BluePlayer.ColourGrid = ColourGrid;

            Players = new List<Player>() { RedPlayer, GreenPlayer, BluePlayer };

            // Set the maximum match moves
            MaxMatchMoves = MatchMoves;
        }

        public void BeginGame()
        {
            // Begin the match
            NextTeamTurn();
        }

        public void RefreshGameField()
        {
            GameField.Refresh();
        }

        private void GameField_Paint(object sender, PaintEventArgs e)
        {
            // Redraw the game field
            DrawGrid(e);

            // Update the strengths and block counts
            RedStrengthLabel.Text = $"{ColourGrid.GetStrength(ColourType.Red)}";
            RedStrengthLabel.Refresh();
            GreenStrengthLabel.Text = $"{ColourGrid.GetStrength(ColourType.Green)}";
            GreenStrengthLabel.Refresh();
            BlueStrengthLabel.Text = $"{ColourGrid.GetStrength(ColourType.Blue)}";
            BlueStrengthLabel.Refresh();
            RedBlocksLabel.Text = $"{ColourGrid.GetBlockCount(ColourType.Red)}";
            RedBlocksLabel.Refresh();
            GreenBlocksLabel.Text = $"{ColourGrid.GetBlockCount(ColourType.Green)}";
            GreenBlocksLabel.Refresh();
            BlueBlocksLabel.Text = $"{ColourGrid.GetBlockCount(ColourType.Blue)}";
            BlueBlocksLabel.Refresh();
        }

        public void DrawGrid(PaintEventArgs e)
        {
            // Draw all the blocks
            for (int i = 0; i < ColourGrid.GridSize; i++)
            {
                for (int j = 0; j < ColourGrid.GridSize; j++)
                {
                    var colourBlock = ColourGrid.ColourBlocks[i, j];

                    if (colourBlock != null)
                    {
                        colourBlock.DrawBlock(e);
                    }
                }
            }

            // Draw rectangle around play area showing current team whose turn it is
            DrawTurnRectangle(e);
        }

        public void NextTeamTurn()
        {
            if (GameIsLive)
            {
                // Switch team that is to play
                TeamsTurn++;

                if (TeamsTurn > Enum.GetNames(typeof(ColourType)).Length - 1)
                {
                    TeamsTurn = 1;
                    MovesMade++;
                }

                // Check if game is finished
                CheckGameOver();

                // Perform some checks on this team to see if a it is knocked out or has only 1 move left or cannot do any moves
                if (ColourGrid.GetBlockCount((ColourType)TeamsTurn) <= 0)
                {
                    // Then this team is knocked out. Strikethrough their label to indicate this
                    StrikeOutTeamLabels(TeamsTurn);

                    // Then this team has no blocks and therefore is out
                    NextTeamTurn();
                }

                // If it is now Red team's turn
                if ((ColourType)TeamsTurn == ColourType.Red && RedPlayer is ComputerPlayer)
                {
                    if (GameIsLive) { Thread.Sleep(ComputerPlayer.ComputerPlayDelay); }
                    ((ComputerPlayer)RedPlayer).TakeTurn();
                    GameField.Refresh();
                    NextTeamTurn();
                }
                // If it is now Green team's turn
                if ((ColourType)TeamsTurn == ColourType.Green && GreenPlayer is ComputerPlayer)
                {
                    if (GameIsLive) { Thread.Sleep(ComputerPlayer.ComputerPlayDelay); }
                    ((ComputerPlayer)GreenPlayer).TakeTurn();
                    GameField.Refresh();
                    NextTeamTurn();
                }
                // If it is now Blue team's turn
                if ((ColourType)TeamsTurn == ColourType.Blue && BluePlayer is ComputerPlayer)
                {
                    if (GameIsLive) { Thread.Sleep(ComputerPlayer.ComputerPlayDelay); }
                    ((ComputerPlayer)BluePlayer).TakeTurn();
                    GameField.Refresh();
                    NextTeamTurn();
                }
            }
            
        }

        private void CheckGameOver()
        {
            // Check if this is a move counted match and if so, has the maximum been reached
            if (MaxMatchMoves > 0)
            {
                if (MovesMade >= MaxMatchMoves)
                {
                    EndMatch(null);

                    // Player with highest strength - block ratio wins
                    //if (RedPlayer.Score > GreenPlayer.Score && RedPlayer.Score > BluePlayer.Score)
                    //{
                    //    EndMatch(RedPlayer);
                    //}
                    //else if (GreenPlayer.Score > BluePlayer.Score)
                    //{
                    //    EndMatch(GreenPlayer);
                    //}
                    //else
                    //{
                    //    EndMatch(BluePlayer);
                    //}
                }
            }

            int teamsOut = 0;
            var remainingTeams = new List<Player>();

            foreach(var player in Players)
            {
                if (player.BlockCount <= 0)
                {
                    teamsOut++;
                }
                else
                {
                    remainingTeams.Add(player);
                }
            }

            if (remainingTeams.Count == 1)
            {
                EndMatch(remainingTeams[0]);
            }
        }

        private void EndMatch(Player winner)
        {
            GameIsLive = false;
            if (winner != null)
            {
                Winner = winner;
                Winner.Wins++;
                winner.TotalScore += winner.Score;
            }
        }

        private void StrikeOutTeamLabels(int teamsTurn)
        {
            switch ((ColourType)teamsTurn)
            {
                case ColourType.Red:
                    var redFont = new Font(RedTeamLabel.Font, FontStyle.Strikeout);
                    RedTeamLabel.Font = redFont;
                    RedTeamLabel.Refresh();
                    RedStrengthLabel.Text = "";
                    RedStrengthLabel.Refresh();
                    RedBlocksLabel.Text = "";
                    RedBlocksLabel.Refresh();
                    RedBadAgainstLabel.Text = "";
                    RedBadAgainstLabel.Refresh();
                    RedGoodAgainstLabel.Text = "";
                    RedGoodAgainstLabel.Refresh();
                    break;
                case ColourType.Green:
                    var greenFont = new Font(GreenTeamLabel.Font, FontStyle.Strikeout);
                    GreenTeamLabel.Font = greenFont;
                    GreenTeamLabel.Refresh();
                    GreenStrengthLabel.Text = "";
                    GreenStrengthLabel.Refresh();
                    GreenBlocksLabel.Text = "";
                    GreenBlocksLabel.Refresh();
                    GreenBadAgainstLabel.Text = "";
                    GreenBadAgainstLabel.Refresh();
                    GreenGoodAgainstLabel.Text = "";
                    GreenGoodAgainstLabel.Refresh();
                    break;
                case ColourType.Blue:
                    var blueFont = new Font(BlueTeamLabel.Font, FontStyle.Strikeout);
                    BlueTeamLabel.Font = blueFont;
                    BlueTeamLabel.Refresh();
                    BlueStrengthLabel.Text = "";
                    BlueStrengthLabel.Refresh();
                    BlueBlocksLabel.Text = "";
                    BlueBlocksLabel.Refresh();
                    BlueBadAgainstLabel.Text = "";
                    BlueBadAgainstLabel.Refresh();
                    BlueGoodAgainstLabel.Text = "";
                    BlueGoodAgainstLabel.Refresh();
                    break;
            }
        }

        private void DrawTurnRectangle(PaintEventArgs e)
        {
            DrawRectangle(e, new Point(0, 0), GameField.Width, GameField.Height, GetColour((ColourType)TeamsTurn), fill: false, Color.Transparent, 10);
        }

        private void ColourCombine_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private bool _mouseIsDown = false;
        private Point _mouseDownStartPoint, _mouseDownEndPoint;

        private void GameField_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseIsDown = true;
            _mouseDownStartPoint = e.Location;
            _mouseDownEndPoint = e.Location;
        }

        private void GameField_MouseMove(object sender, MouseEventArgs e)
        {
            if (_mouseIsDown)
            {
                _mouseDownEndPoint = e.Location;
            }
        }

        private void GameField_MouseUp(object sender, MouseEventArgs e)
        {
            _mouseIsDown = false;

            // Get the block that was clicked on
            var startColourBlock = ColourGrid.GetColourBlock(_mouseDownStartPoint.X, _mouseDownStartPoint.Y);
            var endColourBlock = ColourGrid.GetColourBlock(_mouseDownEndPoint.X, _mouseDownEndPoint.Y);

            // Check that mouse started and ended on a colour block
            if (startColourBlock == null || endColourBlock == null)
            {
                return;
            }

            // Check if this is colour block of current team
            if ((int)startColourBlock.ColourType != TeamsTurn)
            {
                return;
            }

            // Find the direction that the mouse was moved
            var deltaX =  _mouseDownEndPoint.X - _mouseDownStartPoint.X;
            var deltaY =  _mouseDownEndPoint.Y - _mouseDownStartPoint.Y;

            bool moveOccured = false;

            if (startColourBlock == endColourBlock)
            {
                // Then just add 1 to this block
                moveOccured = ColourGrid.AddToBlock(startColourBlock);
            }
            else if (Math.Abs(deltaX) > Math.Abs(deltaY))
            {
                // Then move this block in the X direction
                if (deltaX > 0)
                {
                    moveOccured = ColourGrid.MoveBlock(startColourBlock, BlockMove.Right);
                }
                else
                {
                    moveOccured = ColourGrid.MoveBlock(startColourBlock, BlockMove.Left);
                }
            }
            else
            {
                // Then move this block in the Y direction
                if (deltaY > 0)
                {
                    moveOccured = ColourGrid.MoveBlock(startColourBlock, BlockMove.Down);
                }
                else
                {
                    moveOccured = ColourGrid.MoveBlock(startColourBlock, BlockMove.Up);
                }
            }

            if (moveOccured)
            {
                GameField.Refresh();
                NextTeamTurn();
                GameField.Refresh();
            }
        }
        
        private void SkipTurnButton_Click(object sender, EventArgs e)
        {
            NextTeamTurn();
            GameField.Refresh();
        }

    }
}

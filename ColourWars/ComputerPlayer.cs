﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathsJourney.ColourWars
{
    public class ComputerPlayer : Player
    {
        public const int ComputerPlayDelay = 0;
        public static Random random = new Random();

        private PlayerMove _previousMove { get; set; }

        public MoveScoreWeightings MoveScoreWeightings { get; set; }

        public ComputerPlayer(MoveScoreWeightings moveScoreWeightings, ColourType colourType) : base(colourType)
        {
            MoveScoreWeightings = moveScoreWeightings;
        }

        public bool TakeTurn()
        {
            bool moveMade = false;
            // Get all possible moves and order them by best to worst by different factors (order applied first is the least desirable characteristic)
            var possibleMoves = ColourGrid.GetPossibleMoves(ColourType)
                //.OrderByDescending(pm => ColourGrid.ColourBlocks[pm.I, pm.J].Count) // Value of this block so that higher blocks are moved
                //.OrderByDescending(pm => pm.SurroundingEnemyBlocks) // Number of enemy blocks around so that moves near enemies are prioritised
                //.OrderByDescending(pm => pm.PredictedStrength) // Block strength so that players try to make moves which will increase their strength the most
                //.OrderByDescending(pm => pm.PredictedBlockCount) // Block count so that players always try to take a new block (increase their block count)
                //.OrderByDescending(pm => pm.CalculateMoveScore(MoveScoreWeightings, this))
                .ToList();

            foreach(var move in possibleMoves)
            {
                move.MoveScore = move.CalculateMoveScore(MoveScoreWeightings, this);
            }

            possibleMoves = possibleMoves.OrderByDescending(pm => pm.MoveScore).ToList();

            ColourGrid.Game.RefreshGameField();

            // See if the previous move exists in the list of possible moves (and if so move it to the end)
            //if (_previousMove != null)
            //{
            //    List<int> sameMoveIndices = new List<int>(); ;
            //    for (int i = 0; i < possibleMoves.Count(); i++)
            //    {
            //        if ((
            //            (_previousMove.I == possibleMoves[i].I  && _previousMove.J == possibleMoves[i].J) ||
            //            (_previousMove.NewI == possibleMoves[i].NewI  && _previousMove.NewJ == possibleMoves[i].NewJ) ||
            //            (_previousMove.NewI == possibleMoves[i].I  && _previousMove.NewJ == possibleMoves[i].J) ||
            //            (_previousMove.I == possibleMoves[i].NewI  && _previousMove.J == possibleMoves[i].NewJ) ||
            //            (_previousMove.BlockMove == possibleMoves[i].BlockMove)
            //            ))
            //            //&& _previousMove.BlockMove == possibleMoves[i].BlockMove)
            //        {
            //            sameMoveIndices.Add(i);
            //        }
            //    }

            //    foreach(var sameMoveIndex in sameMoveIndices.OrderByDescending(i => i))
            //    {
            //        var sameMove = possibleMoves[sameMoveIndex];
            //        possibleMoves.Remove(sameMove);
            //        possibleMoves.Add(sameMove);
            //    }
            //}

            // Get the move that produces the highest strength
            foreach (var move in possibleMoves)
            {
                // Check if randomly this move shouldn't be picked
                int chance = random.Next(100);
                if (chance < MoveScoreWeightings.chancePickingRandomMove)
                {
                    continue;
                }

                switch(move.BlockMove)
                {
                    case BlockMove.Up:
                    case BlockMove.Down:
                    case BlockMove.Left:
                    case BlockMove.Right:
                        if (ColourGrid.MoveBlock(move))
                        {
                            moveMade = true;
                            _previousMove = move;
                        }
                        break;
                    case BlockMove.Same:
                        if (ColourGrid.AddToBlock(move))
                        {
                            moveMade = true;
                            _previousMove = move;
                        }
                        break;
                }

                if (moveMade)
                {
                    break;
                }
            }

            return moveMade;
        }


    }
}

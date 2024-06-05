using Dame.Models;
using Dame.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace Dame.Commands
{
    public class SelectPieceCommand : BaseCommand
    {
        public override void Execute(object? parameter)
        {
            var currentPlayerColor = GameLogic.CurrentPlayerColor;
            var board = Dame.ViewModels.GameViewModel.Board;
            var moves = GameLogic.AvailableMoves;
            var crossedMoves = GameLogic.CrossedMoves;

            if (parameter is Tuple<int, int> coord) {
                //If clicked piece is not currentPlayer return
                if (board[coord.Item1][coord.Item2].Piece.Color != currentPlayerColor)
                    return;

                //Select current selected
                GameLogic.SelectedPiece = Tuple.Create(coord.Item1, coord.Item2);

                //Clear last hints(if any)
                moves.Clear();
                GameLogic.CrossedMoves.Clear();

                //Move moves (no capture)
                int[] dx, dy;
                if (board[coord.Item1][coord.Item2].Piece.Type == PieceType.NORMAL)
                {
                    dx = [-1, 1];
                    dy = [-1, -1];
                    if (currentPlayerColor == PieceColor.WHITE){
                        dy[0] *= -1;
                        dy[1] *= -1;
                    }

                }
                else {
                    dx = [-1, 1, 1, -1];
                    dy = [-1, -1, 1, 1];
                }

                for (int i = 0; i < dx.Count(); i++) {
                    if (GameLogic.isInBoard(Tuple.Create(coord.Item1 + dy[i], coord.Item2 + dx[i]))) {
                        if (board[coord.Item1 + dy[i]][coord.Item2 + dx[i]].Piece.Texture == null) {
                            moves.Add(Tuple.Create(coord.Item1 + dy[i], coord.Item2 + dx[i]), null);
                            crossedMoves.Add(Tuple.Create(coord.Item1 + dy[i], coord.Item2 + dx[i]));
                        }   
                    }
                }

                //Capture moves
                GameLogic.CheckCapture(coord, null, 0, dx, dy);

                //Display Moves
                Utility.DisplayMoves();
            }
        }
    }
}

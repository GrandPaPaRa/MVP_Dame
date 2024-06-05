using Dame.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dame.Models;
using static System.Net.Mime.MediaTypeNames;
using System.Windows;

namespace Dame.Commands
{
    public class MoveCommand : BaseCommand
    {
        public override void Execute(object? parameter)
        {
            var currentPlayerColor = GameLogic.CurrentPlayerColor;
            string pieceTexture;
            PieceType pieceType;
            
            var board = Dame.ViewModels.GameViewModel.Board;
            var moves = GameLogic.AvailableMoves;

            var selectedPiece = board[GameLogic.SelectedPiece.Item1][GameLogic.SelectedPiece.Item2].Piece;
            
            if (parameter is Tuple<int, int> coord)
            {
                pieceType = selectedPiece.Type;

                //if piece promotes
                if (coord.Item1 == 0 || coord.Item1 == GameLogic.BoardSize - 1)
                    pieceType = PieceType.KING;


                if (currentPlayerColor == PieceColor.RED && pieceType == PieceType.NORMAL)
                    pieceTexture = Utility.RedNormalPieceTex;
                else if (currentPlayerColor == PieceColor.RED && pieceType == PieceType.KING)
                    pieceTexture = Utility.RedKingPieceTex;
                else if (currentPlayerColor == PieceColor.WHITE && pieceType == PieceType.NORMAL)
                    pieceTexture = Utility.WhiteNormalPieceTex;
                else 
                    pieceTexture = Utility.WhiteKingPieceTex;

                var nextPiece = board[coord.Item1][coord.Item2].Piece;
                //Move Piece

                //remove selected piece
                selectedPiece.Texture = null;
                selectedPiece.Color = PieceColor.NONE;
                selectedPiece.Type = PieceType.NONE;

                //move the piece
                nextPiece.Texture = pieceTexture;
                nextPiece.Color = currentPlayerColor;
                nextPiece.Type = pieceType;

                //Delete Pieces(if necesary)
                if (moves?[coord] != null) {
                    foreach (var captureCoord in moves[coord]){
                        var capturePiece = board[captureCoord.Item1][captureCoord.Item2].Piece;

                        capturePiece.Texture = null;
                        capturePiece.Color = PieceColor.NONE;
                        capturePiece.Type = PieceType.NONE;
                    }
                    GameLogic.RemovePieceCountFromCurrent(moves[coord].Count());
                }


                //Check if the game is ended
                if (GameLogic.isEndGame())
                {
                    Utility.EraseAllMoves();
                    Utility.UpdateSavedStatistics();

                    //Display msg

                    string winner = "";
                    if (currentPlayerColor == PieceColor.RED)
                        winner = "Red";
                    else
                        winner = "White";
                    MessageBox.Show(winner + " Wins!", winner + " player Wins!!", MessageBoxButton.OK);

                    //Reset game
                    GameLogic.resetBoard();
                    GameLogic.CurrentPlayerColor = PieceColor.RED;
                    GameLogic.RedPieceCount = GameLogic.TotalPieceCount;
                    GameLogic.WhitePieceCount = GameLogic.TotalPieceCount;
                    return;
                }

                //Switch Player and reset some logic
                GameLogic.SwitchPlayer();
                Utility.EraseAllMoves();
                GameLogic.CrossedMoves.Clear();
                //AvailableMoves resets at the begining of SelectPieceCommand
            }
        }
    }
}

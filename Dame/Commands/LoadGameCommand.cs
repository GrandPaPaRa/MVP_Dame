using Dame.Models;
using Dame.Services;
using Dame.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace Dame.Commands
{
    public class LoadGameCommand : BaseCommand
    {
        public override void Execute(object? parameter)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Dame Save files (*.dam)|*.dam|All files (*.*)|*.*";
            if (dialog.ShowDialog() == true) { 
                string fileName = dialog.FileName;
                string jsonString = File.ReadAllText(fileName);
                SavedGame savedGame = JsonSerializer.Deserialize<SavedGame>(jsonString);
                //check if the data is ok
                if (savedGame != null && savedGame.RedPieceCount + savedGame.WhitePieceCount == savedGame.Pieces?.Count())
                {
                    GameLogic.CleanBoard();
                    foreach (var savedPiece in savedGame.Pieces) {
                        var cellPiece = GameViewModel.Board[savedPiece.Position.Item1][savedPiece.Position.Item2].Piece;
                        cellPiece.Type = savedPiece.Type;
                        cellPiece.Color = savedPiece.Color;

                        if (cellPiece.Type == PieceType.NORMAL)
                        {
                            if (cellPiece.Color == PieceColor.RED)
                                cellPiece.Texture = Utility.RedNormalPieceTex;
                            else
                                cellPiece.Texture = Utility.WhiteNormalPieceTex;
                        }
                        else {
                            if (cellPiece.Color == PieceColor.RED)
                                cellPiece.Texture = Utility.RedKingPieceTex;
                            else
                                cellPiece.Texture = Utility.WhiteKingPieceTex;
                        }
                    }
                    GameLogic.CurrentPlayerColor = savedGame.CurrentPieceColor;
                    GameLogic.RedPieceCount = savedGame.RedPieceCount;
                    GameLogic.WhitePieceCount = savedGame.WhitePieceCount;
                }
                else {
                    MessageBox.Show("Unable to load file, try again.", "Load error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}

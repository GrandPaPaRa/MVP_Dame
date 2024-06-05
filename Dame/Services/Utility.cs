using Dame.Commands;
using Dame.Events;
using Dame.Models;
using Dame.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Dame.Services
{
    public class Utility
    {
        //private static string path = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory?.ToString())?.ToString())?.ToString())?.ToString())?.ToString();
        private static string path = AppDomain.CurrentDomain.BaseDirectory?.ToString() + "\\..\\..\\..\\.."; //epic oni trik
        public static string WhiteNormalPieceTex = Path.Combine(path, "Resources\\pieceWhite.png");
        public static string WhiteKingPieceTex = Path.Combine(path, "Resources\\pieceWhiteKing.png");
        public static string RedNormalPieceTex = Path.Combine(path, "Resources\\pieceRed.png");
        public static string RedKingPieceTex = Path.Combine(path, "Resources\\pieceRedKing.png");
        public static string BlackCellTex = Path.Combine(path, "Resources\\squareBlack.png");
        public static string WhiteCellTex = Path.Combine(path, "Resources\\squareWhite.png");
        public static string HintTex = Path.Combine(path, "Resources\\squareHint.png");
        public static string HintCaptureTex = Path.Combine(path, "Resources\\squareHintCapture.png");
        public static string MultipleJumpOption = Path.Combine(path, "Dame\\Resources\\MultipleJumpOption.json");
        public static string SavedStatisticsPath = Path.Combine(path, "Dame\\Resources\\SavedStatistics.json");
        public static string AboutPath = Path.Combine(path, "Dame\\Resources\\About.json");

        public static void EraseAllMoves() {
            //Erases moves only visually
            foreach (var row in GameViewModel.Board) {
                foreach (var move in row) {
                    GameViewModel.Board[move.Row][move.Col].HintTexture = null;
                }
            }
        }
        public static void DisplayMoves() {
            EraseAllMoves();
            if (GameLogic.AvailableMoves.Count != 0) {
                
                foreach (var move in GameLogic.AvailableMoves.Keys) {
                    if (GameLogic.AvailableMoves[move] == null)
                        GameViewModel.Board[move.Item1][move.Item2].HintTexture = HintTex;
                    else
                        GameViewModel.Board[move.Item1][move.Item2].HintTexture = HintCaptureTex;
                }
            }
            
        }
        public static PieceColor OpositePlayerColor() {
            if (GameLogic.CurrentPlayerColor == PieceColor.RED)
                return PieceColor.WHITE;
            return PieceColor.RED;
        }
        public static void PlayerColorChanged(object sender, PlayerColorChangedEventArgs e) { 
            GameViewModel.PlayerTurn.Color = e.Color;
        }

        public static void PlayerCountChanged(object sender, PlayerCountChangedEventArgs e) {
            GameViewModel.PlayerCount.RedCount = e.RedCount;
            GameViewModel.PlayerCount.WhiteCount = e.WhiteCount;
        }
        public static void ExtraJumpChanged(object sender, EventArgs e) {
            GameViewModel.MultipleJump.OnState = !GameViewModel.MultipleJump.OnState;
            if (GameLogic.SelectedPiece != null) {
                ICommand selectCommand = new SelectPieceCommand();
                selectCommand.Execute(GameLogic.SelectedPiece);
            }
            SaveMultipleJumpOption();
        }
        public static void LoadMultipleJumpOption() {
            string jsonString = File.ReadAllText(MultipleJumpOption);
            GameLogic.ExtraJump = JsonSerializer.Deserialize<bool>(jsonString);
        }

        private static void SaveMultipleJumpOption() {
            string path = MultipleJumpOption;
            string jsonString = JsonSerializer.Serialize<bool>(GameLogic.ExtraJump);
            File.WriteAllText(MultipleJumpOption, jsonString);
        }
        public static SavedGame GetSavedGame() { 
            List<SavePiece> savePieces = new List<SavePiece>();
            foreach (var row in GameViewModel.Board) {
                foreach (var cell in row) {
                    if (cell.Piece.Texture != null)
                        savePieces.Add(new SavePiece(cell.Piece.Type, cell.Piece.Color, cell.Coord));
                }
            }
            return new SavedGame(savePieces, GameLogic.CurrentPlayerColor, GameLogic.RedPieceCount, GameLogic.WhitePieceCount);
        }
        public static SavedStatistics GetSavedStatistics() {
            string jsonString = File.ReadAllText(SavedStatisticsPath);
            return JsonSerializer.Deserialize<SavedStatistics>(jsonString);
        }
        public static void UpdateSavedStatistics() {
            SavedStatistics statistics = GetSavedStatistics();
            if (GameLogic.CurrentPlayerColor == PieceColor.RED)
            {
                statistics.RedWins++;
                statistics.RedMaxPieces = Math.Max(statistics.RedMaxPieces, GameLogic.RedPieceCount);
            }
            else {
                statistics.WhiteWins++;
                statistics.WhiteMaxPieces = Math.Max(statistics.WhiteMaxPieces, GameLogic.WhitePieceCount);
            }
            string jsonString = JsonSerializer.Serialize(statistics);
            File.WriteAllText(SavedStatisticsPath, jsonString);
        }
        public static About GetAbout() {
            string jsonString = File.ReadAllText(AboutPath);
            return JsonSerializer.Deserialize<About>(jsonString);
        }
    }
}

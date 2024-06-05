using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dame.Models
{
    public class SavedGame
    {
        public List<SavePiece>? Pieces { get; set; }
        public PieceColor CurrentPieceColor { get; set; }
        public int RedPieceCount {  get; set; } 
        public int WhitePieceCount { get; set; }

        public SavedGame(List<SavePiece>? pieces, PieceColor currentPieceColor, int redPieceCount, int whitePieceCount)
        {
            Pieces = pieces;
            CurrentPieceColor = currentPieceColor;
            RedPieceCount = redPieceCount;
            WhitePieceCount = whitePieceCount;
        }
    }
}

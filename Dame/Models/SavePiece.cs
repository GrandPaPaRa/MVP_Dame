using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dame.Models
{
    public class SavePiece
    {
        public PieceType Type { get; set; }
        public PieceColor Color { get; set; }
        public Tuple<int, int>? Position { get; set; }
        public SavePiece(PieceType type, PieceColor color, Tuple<int, int>? position)
        {
            Type = type;
            Color = color;
            Position = position;
        }
    }
}

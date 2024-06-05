using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dame.Models
{
    public class Piece
    {
        public PieceType type { set; get; }
        public PieceColor color { set; get; }
        public string? texture { set; get; }
        public Piece(PieceType type, PieceColor color, string? texture)
        {
            this.type = type;
            this.color = color;
            this.texture = texture;
        }
        public Piece() { }
    }
}

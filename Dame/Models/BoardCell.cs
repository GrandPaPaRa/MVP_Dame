using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dame.Models
{
    public class BoardCell
    {
        public int row { get; set; }
        public int col { get; set; }
        public CellColor cellColor { get; set; }
        public string? cellTexture { get; set; }
        public string? hintTexture { get; set; }
        public Piece? piece { get; set; }
        public BoardCell(int row, int col, CellColor cellColor, string? cellTexture, string? hintTexture, Piece? piece)
        {
            this.row = row;
            this.col = col;
            this.cellColor = cellColor;
            this.cellTexture = cellTexture;
            this.hintTexture = hintTexture;
            this.piece = piece;
        }  
    }
}

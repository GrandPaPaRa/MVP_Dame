using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dame.Models
{
    public class SavedStatistics
    {
        public int RedWins { get; set; }
        public int WhiteWins { get; set; }
        public int RedMaxPieces { get; set; }
        public int WhiteMaxPieces { get; set;}
        public SavedStatistics(int redWins, int whiteWins, int redMaxPieces, int whiteMaxPieces)
        {
            RedWins = redWins;
            WhiteWins = whiteWins;
            RedMaxPieces = redMaxPieces;
            WhiteMaxPieces = whiteMaxPieces;
        }
    }
}

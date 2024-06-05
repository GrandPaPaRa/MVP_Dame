using Dame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dame.Events
{
    public class PlayerColorChangedEventArgs : EventArgs
    {
        public PieceColor Color { get; set; }
        public PlayerColorChangedEventArgs(PieceColor color) {  Color = color; }
    }
}

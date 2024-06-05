using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dame.Events
{
    public class PlayerCountChangedEventArgs : EventArgs
    {
        public int RedCount {  get; set; }  
        public int WhiteCount {  get; set; }
        public PlayerCountChangedEventArgs(int redCount, int whiteCount)
        {
            RedCount = redCount;
            WhiteCount = whiteCount;
        }
    }
}

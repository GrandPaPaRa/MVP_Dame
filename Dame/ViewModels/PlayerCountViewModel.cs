using Dame.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dame.ViewModels
{
    public class PlayerCountViewModel : BaseViewModel
    {
        public string RedPieceTexture { get; set; } = Utility.RedNormalPieceTex;
        public string WhitePieceTexture { get; set; } = Utility.WhiteNormalPieceTex;

        private int _redCount {  get; set; }
        public int RedCount
        {
            get {
                return _redCount;
            }
            set {
                _redCount = value;
                OnPropertyChanged(nameof(RedCount));
            }
        }
        private int _whiteCount { get; set; }
        public int WhiteCount
        {
            get
            {
                return _whiteCount;
            }
            set
            {
                _whiteCount = value;
                OnPropertyChanged(nameof(WhiteCount));
            }
        }
        public PlayerCountViewModel(int redCount, int whiteCount)
        {
            RedCount = redCount;
            WhiteCount = whiteCount;
        }
    }
}

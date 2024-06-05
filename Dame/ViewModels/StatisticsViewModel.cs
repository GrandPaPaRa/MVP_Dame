using Dame.Models;
using Dame.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dame.ViewModels
{
    public class StatisticsViewModel : BaseViewModel
    {
        private SavedStatistics _savedStatis {  get; set; } 
        public int RedWins {
            get {
                return _savedStatis.RedWins;
            }
            set {
                if (_savedStatis.RedWins != value) {
                    _savedStatis.RedWins = value;
                    OnPropertyChanged(nameof(RedWins));
                }
            }
        }
        public int WhiteWins
        {
            get
            {
                return _savedStatis.WhiteWins;
            }
            set
            {
                if (_savedStatis.WhiteWins != value)
                {
                    _savedStatis.WhiteWins = value;
                    OnPropertyChanged(nameof(WhiteWins));
                }
            }
        }
        public int RedMaxPieces
        {
            get
            {
                return _savedStatis.RedMaxPieces;
            }
            set
            {
                if (_savedStatis.RedMaxPieces != value)
                {
                    _savedStatis.RedMaxPieces = value;
                    OnPropertyChanged(nameof(RedMaxPieces));
                }
            }
        }
        public int WhiteMaxPieces
        {
            get
            {
                return _savedStatis.WhiteMaxPieces;
            }
            set
            {
                if (_savedStatis.WhiteMaxPieces != value)
                {
                    _savedStatis.WhiteMaxPieces = value;
                    OnPropertyChanged(nameof(WhiteMaxPieces));
                }
            }
        }
        public string RedTexture { get { return Utility.RedNormalPieceTex; } set { } }
        public string WhiteTexture { get { return Utility.WhiteNormalPieceTex; } set { } }
        public StatisticsViewModel()
        {
            _savedStatis = Utility.GetSavedStatistics();
        }
    }
}

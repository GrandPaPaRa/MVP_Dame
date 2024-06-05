using Dame.Models;
using Dame.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dame.ViewModels
{
    public class PlayerTurnViewModel : BaseViewModel
    {
        private PieceColor _color {  get; set; }
        public PieceColor Color { 
            get { 
                return _color;
            }
            set { 
                _color = value;
                if (_color == PieceColor.RED)
                    Texture = Utility.RedNormalPieceTex;
                else
                    Texture = Utility.WhiteNormalPieceTex;
                OnPropertyChanged(nameof(Color));
            }
        
        }
        private string? _texture { get; set; }
        public string? Texture {
            get {
                return _texture;
            }
            set {
                _texture = value;
                OnPropertyChanged(nameof(Texture));
            } 
        }
        public PlayerTurnViewModel(PieceColor color = PieceColor.RED)
        {
            Color = color;
        }
    }
}

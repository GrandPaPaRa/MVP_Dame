using Dame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dame.ViewModels
{
    public class PieceViewModel : BaseViewModel
    {
        private Piece? _piece { get; set; }

        public PieceType Type
        {
            get {
                if(_piece != null)
                    return _piece.type;
                return PieceType.NONE;
            }
            set {
                if (_piece == null)
                    _piece = new Piece();
                _piece.type = value;
                OnPropertyChanged(nameof(Type));
            }
        }
        public PieceColor Color {
            get
            {
                if(_piece != null)
                    return _piece.color;
                return PieceColor.NONE;
            }
            set
            {
                if (_piece == null)
                    _piece = new Piece();
                _piece.color = value;
                OnPropertyChanged(nameof(Color));
            }
        }
        public string? Texture {
            get
            {
                if(_piece != null)
                    return _piece.texture;
                return null;
            }
            set
            {
                if(_piece == null)
                    _piece = new Piece();
                _piece.texture = value;
                OnPropertyChanged(nameof(Texture));
            }
        }
        public PieceViewModel(Piece piece) {
            _piece = piece;
        }
    }
}

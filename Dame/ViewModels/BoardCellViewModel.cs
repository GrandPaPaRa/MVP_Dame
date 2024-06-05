using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Dame.Commands;
using Dame.Models;
namespace Dame.ViewModels
{
    public class BoardCellViewModel : BaseViewModel
    {
        private BoardCell? _boardCell { get; set; }
       
        private string? _hintTexture { get; set; }
        public string? HintTexture
        {
            get {
                return _hintTexture;
            }
            set { 
                _hintTexture = value;
                OnPropertyChanged(nameof(HintTexture));
            }
        }
        private string? _cellTexture { get; set; }
        public string? CellTexture
        {
            get
            {
                return _cellTexture;
            }
            set {
                _cellTexture = value;
                OnPropertyChanged(nameof(CellTexture));
            }
        }
        private PieceViewModel _piece;
        public PieceViewModel Piece {
            get {
                return _piece;
            }
            set { 
                _piece= value;
                OnPropertyChanged(nameof(Piece));
            }
        }
        public int Row
        {
            get {
                return _boardCell.row;
            }
        }
        public int Col {
            get {
                return _boardCell.col;
            }
        }
        public Tuple<int, int> Coord
        {
            get { 
                return new Tuple<int, int>(Row, Col);
            }
        }
        public ICommand ClickPieceCommand { get; set; }
        public ICommand MovePieceCommand { get; set; }
        public BoardCellViewModel(BoardCell boardCell)
        {
            this._boardCell = boardCell;
            this._piece = new PieceViewModel(boardCell?.piece);
            _cellTexture = this._boardCell?.cellTexture?.ToString();
            _hintTexture = this._boardCell?.hintTexture?.ToString();
            ClickPieceCommand = new SelectPieceCommand();
            MovePieceCommand = new MoveCommand();
        }
    }
}

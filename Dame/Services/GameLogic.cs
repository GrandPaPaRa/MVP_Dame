using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dame.ViewModels;
using Dame.Services;
using Dame.Models;
using System.Collections.ObjectModel;
using System.Windows.Documents;
using Dame.Events;
using Dame.Commands;


namespace Dame.Services
{

    public class GameLogic
    {
        //Game Variables
        public static readonly int BoardSize = 8;
        public static readonly int TotalPieceCount = 12;


        public static event EventHandler<EventArgs>? ExtraJumpChanged;
        private static bool _extraJump { get; set; } = true;
        public static bool ExtraJump
        {
            get { 
                return _extraJump;
            }
            set {
                if (_extraJump != value) {
                    _extraJump = value;
                    ExtraJumpChanged?.Invoke(null, new EventArgs());
                }
            }
        }
        public static event EventHandler<PlayerColorChangedEventArgs>? PlayerColorChanged;
        private static PieceColor _currentPlayerColor {  get; set; } = PieceColor.RED;
        public static PieceColor CurrentPlayerColor {
            get { 
                return _currentPlayerColor;
            }
            set {
                if (_currentPlayerColor != value)
                {
                    _currentPlayerColor = value;
                    PlayerColorChanged?.Invoke(null, new PlayerColorChangedEventArgs(value));
                }
            }
        }

        public static event EventHandler<PlayerCountChangedEventArgs>? PlayerCountChanged;
        private static int _redPieceCount = TotalPieceCount;

        public static int RedPieceCount
        {
            get
            {
                return _redPieceCount;
            }
            set
            {
                if (_redPieceCount != value)
                {
                    _redPieceCount = value;
                    PlayerCountChanged?.Invoke(null, new PlayerCountChangedEventArgs(_redPieceCount, _whitePieceCount));
                }
            }
        }
        private static int _whitePieceCount = TotalPieceCount;
        public static int WhitePieceCount
        {
            get
            {
                return _whitePieceCount;
            }
            set
            {
                if (_whitePieceCount != value)
                {
                    _whitePieceCount = value;
                    PlayerCountChanged?.Invoke(null, new PlayerCountChangedEventArgs(_redPieceCount, _whitePieceCount));
                }
            }
        }

        //Game Variables used for move logic
        public static Dictionary<Tuple<int, int>, List<Tuple<int, int>>>? AvailableMoves = new Dictionary<Tuple<int, int>, List<Tuple<int, int>>>();
        public static Tuple<int, int> SelectedPiece;
        public static HashSet<Tuple<int, int>> CrossedMoves = new HashSet<Tuple<int, int>>();

        public static void initBoard() {
            Dame.ViewModels.GameViewModel.Board = new ObservableCollection<ObservableCollection<BoardCellViewModel>>();
            var board = Dame.ViewModels.GameViewModel.Board;
            for (int i = 0; i < BoardSize; i++) {
                var row = new ObservableCollection<BoardCellViewModel>();
                for (int j = 0; j < BoardSize; j++) {

                    //Cell Background
                    CellColor cellColor = new CellColor();
                    string cellTexture;
                    Piece piece = null;
                    //White cell
                    if ((i + j) % 2 == 0)
                    {
                        cellColor = CellColor.WHITE;
                        cellTexture = Utility.WhiteCellTex;
                    }
                    //Black cell
                    else {
                        cellColor = CellColor.BLACK;
                        cellTexture = Utility.BlackCellTex;

                        //Initialize Pieces
                        //White Pieces
                        if (i <= 2) {
                            piece = new Piece(PieceType.NORMAL, PieceColor.WHITE, Utility.WhiteNormalPieceTex);
                        }
                        //Red Pieces
                        if (i >= 5) {
                            piece = new Piece(PieceType.NORMAL, PieceColor.RED, Utility.RedNormalPieceTex);
                        }
                    }
                    row.Add(new BoardCellViewModel(new BoardCell(i, j, cellColor, cellTexture, null, piece)));
                }
                board.Add(row);
            }
        }
        public static void resetBoard() {
            var board = Dame.ViewModels.GameViewModel.Board;
            board.Clear();
            for (int i = 0; i < BoardSize; i++)
            {
                var row = new ObservableCollection<BoardCellViewModel>();
                for (int j = 0; j < BoardSize; j++)
                {

                    //Cell Background
                    CellColor cellColor = new CellColor();
                    string cellTexture;
                    Piece piece = null;
                    //White cell
                    if ((i + j) % 2 == 0)
                    {
                        cellColor = CellColor.WHITE;
                        cellTexture = Utility.WhiteCellTex;
                    }
                    //Black cell
                    else
                    {
                        cellColor = CellColor.BLACK;
                        cellTexture = Utility.BlackCellTex;

                        //Initialize Pieces
                        //White Pieces
                        if (i <= 2)
                        {
                            piece = new Piece(PieceType.NORMAL, PieceColor.WHITE, Utility.WhiteNormalPieceTex);
                        }
                        //Red Pieces
                        if (i >= 5)
                        {
                            piece = new Piece(PieceType.NORMAL, PieceColor.RED, Utility.RedNormalPieceTex);
                        }
                    }
                    row.Add(new BoardCellViewModel(new BoardCell(i, j, cellColor, cellTexture, null, piece)));
                }
                board.Add(row);
            }
        }
        public static void CleanBoard() {
            var board = Dame.ViewModels.GameViewModel.Board;
            foreach (var row in board) {
                foreach (var cell in row) { 
                    cell.Piece.Texture = null;
                    cell.Piece.Color = PieceColor.NONE;
                    cell.Piece.Type = PieceType.NONE;

                    cell.HintTexture = null;
                }
            }
        }
        public static bool isInBoard(Tuple<int, int> coord) { 
            return coord.Item1 >=0 && coord.Item1 < BoardSize &&
                coord.Item2 >= 0 && coord.Item2 < BoardSize;
        }
        public static void SwitchPlayer() {
            if (CurrentPlayerColor == PieceColor.RED)
                CurrentPlayerColor = PieceColor.WHITE;
            else
                CurrentPlayerColor = PieceColor.RED;

        }
        public static void CheckCapture(Tuple<int, int> currentCoord,
            List<Tuple<int,int>> currentCaptureCoord,
            int jumpNum, int[] dx, int[] dy) {

            if (jumpNum >= 1 && ExtraJump == false)
                return;
            if (CrossedMoves.Contains(currentCoord))
                return;

            var board = GameViewModel.Board;

            for (int i = 0; i < dx.Count(); i++) {
                Tuple<int, int> neighbourCoord = Tuple.Create(currentCoord.Item1 + dy[i],
                    currentCoord.Item2 + dx[i]);
                Tuple<int, int> neighbourJumpCoord = Tuple.Create(neighbourCoord.Item1 + dy[i],
                    neighbourCoord.Item2 + dx[i]);

                //check if both positions are in board
                if (isInBoard(neighbourCoord) && isInBoard(neighbourJumpCoord)) {
                    //check if neighbour is a enemy piece and jump is empty
                    if (board[neighbourCoord.Item1][neighbourCoord.Item2].Piece.Color == Utility.OpositePlayerColor() &&
                        board[neighbourJumpCoord.Item1][neighbourJumpCoord.Item2].Piece.Texture == null) { 
                        
                        if(currentCaptureCoord == null)
                            currentCaptureCoord = new List<Tuple<int, int>>();

                        var newCurrentCaptureCoord = new List<Tuple<int, int>>(currentCaptureCoord);
                        newCurrentCaptureCoord.Add(neighbourCoord);

                        CrossedMoves.Add(currentCoord);
                        if (!CrossedMoves.Contains(neighbourJumpCoord)) {
                            //GameLogic.AvailableMoves?.Add(neighbourJumpCoord, newCurrentCaptureCoord);
                            GameLogic.AvailableMoves[neighbourJumpCoord] = newCurrentCaptureCoord;
                        }
                        CheckCapture(neighbourJumpCoord, newCurrentCaptureCoord, ++jumpNum, dx, dy);
                    }
                }
            }

        }
        public static bool isEndGame() {
            return RedPieceCount == 0 || WhitePieceCount == 0 || !CheckIfOpponentHasMoves();
        }
        public static void RemovePieceCountFromCurrent(int removedCount) {
            if (GameLogic.CurrentPlayerColor == PieceColor.RED)
                WhitePieceCount -= removedCount;
            else
                RedPieceCount -= removedCount;
        }
        private static bool CheckIfOpponentHasMoves() {
            //We switch player cause selectComand.Execute looks for opositeColor of selectedColor and we check the oposite player pieces
            var board = GameViewModel.Board;
            var opponentColor = Utility.OpositePlayerColor();
            var selectCommand = new SelectPieceCommand();
            SwitchPlayer();
            foreach (var row in board) {
                foreach (var cell in row) {
                    if (cell.Piece.Color == opponentColor) {
                        selectCommand.Execute(cell.Coord);
                        if (GameLogic.AvailableMoves.Count() != 0) {
                            SwitchPlayer();
                            return true;
                        }
                            
                    }
                }
            }
            SwitchPlayer();
            return false;
        }
    }
}

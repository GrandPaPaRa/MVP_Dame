using Dame.Commands;
using Dame.Models;
using Dame.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Dame.ViewModels
{
    public class GameViewModel : BaseViewModel
    {
        public static ObservableCollection<ObservableCollection<BoardCellViewModel>> Board { get; set; }
        public static PlayerTurnViewModel? PlayerTurn { get; set; }
        public static PlayerCountViewModel? PlayerCount { get; set; }
        public static MultipleJumpViewModel? MultipleJump { get; set; }

        //Commands for menu
        public ICommand MultipleJumpOn { get; set; } = new MultipleJumpOnCommand();
        public ICommand MultipleJumpOff { get; set; } = new MultipleJumpOffCommand();
        public ICommand NewGame { get; set; } = new NewGameCommand();
        public ICommand SaveGame { get; set; } = new SaveGameCommand();
        public ICommand LoadGame { get; set; } = new LoadGameCommand();
        public ICommand Statistics { get; set; } = new StatisticsCommand();
        public ICommand About { get; set; } = new AboutCommand();
        
        public GameViewModel() {
            GameLogic.initBoard();
            Utility.LoadMultipleJumpOption();

            PlayerTurn = new PlayerTurnViewModel(GameLogic.CurrentPlayerColor);
            GameLogic.PlayerColorChanged += Utility.PlayerColorChanged;

            PlayerCount = new PlayerCountViewModel(GameLogic.RedPieceCount, GameLogic.WhitePieceCount);
            GameLogic.PlayerCountChanged += Utility.PlayerCountChanged;

            MultipleJump = new MultipleJumpViewModel(GameLogic.ExtraJump);
            GameLogic.ExtraJumpChanged += Utility.ExtraJumpChanged;
        }
    }
}

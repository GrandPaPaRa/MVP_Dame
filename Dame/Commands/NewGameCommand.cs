using Dame.Models;
using Dame.Services;
using Dame.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dame.Commands
{
    public class NewGameCommand : BaseCommand
    {
        public override void Execute(object? parameter)
        {
            GameLogic.resetBoard();
            GameLogic.CurrentPlayerColor = PieceColor.RED;
            GameLogic.RedPieceCount = GameLogic.TotalPieceCount;
            GameLogic.WhitePieceCount = GameLogic.TotalPieceCount;
        }
    }
}

using Dame.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dame.ViewModels;

namespace Dame.Commands
{
    public class StatisticsCommand : BaseCommand
    {
        public override void Execute(object? parameter)
        {
            StatisticsView statisticsView = new StatisticsView();
            statisticsView.DataContext = new StatisticsViewModel();
            statisticsView.ShowDialog();
        }
    }
}

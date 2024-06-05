using Dame.ViewModels;
using Dame.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dame.Commands
{
    public class AboutCommand : BaseCommand
    {
        public override void Execute(object? parameter)
        {
            AboutView aboutView = new AboutView();
            aboutView.DataContext = new AboutViewModel();
            aboutView.ShowDialog();
        }
    }
}

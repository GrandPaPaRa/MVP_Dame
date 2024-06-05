using Dame.Models;
using Dame.ViewModels;
using System.Configuration;
using System.Data;
using System.Windows;
using Dame.Services;

namespace Dame
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            GameViewModel gameViewModel = new GameViewModel();

            MainWindow = new MainWindow() {
                DataContext = gameViewModel
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
        
    }

}

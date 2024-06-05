using Dame.Services;
using Dame.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Dame.Commands
{
    public class SaveGameCommand : BaseCommand
    {
        public override void Execute(object? parameter)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = "SaveDameGame.dam";
            dialog.Filter = "Dame Save files (*.dam)|*.dam|All files (*.*)|*.*";
            if (dialog.ShowDialog() == true) {
                string fileName = dialog.FileName;
                if (fileName != "") {
                    string jsonString = JsonSerializer.Serialize(Utility.GetSavedGame());
                    File.WriteAllText(fileName, jsonString);
                }
                
            }
            
        }
    }
}

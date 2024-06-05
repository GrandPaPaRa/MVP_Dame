using Dame.Models;
using Dame.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dame.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        private About? _about {  get; set; }
        public string Name { get { return _about.Name; } set { } }
        public string Email { get { return _about.Email; } set { } }
        public string Group { get { return _about.Group; } set { } }
        public string Description { get { return _about.Description; } set { } }
        public AboutViewModel() {
            _about = Utility.GetAbout();
        }
    }
}

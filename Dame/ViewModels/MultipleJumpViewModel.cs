using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dame.ViewModels
{
    public class MultipleJumpViewModel : BaseViewModel
    {
        private bool _multipleJump {  get; set; }
        public bool OnState
        {
            get { 
                return _multipleJump;
            }
            set {
                if (value)
                    _multipleJump = true;
                else
                    _multipleJump = false;
                OnPropertyChanged(nameof(OnState));
                OnPropertyChanged(nameof(OffState));
            }
        }
        public bool OffState
        {
            get {
                return !_multipleJump;
            }
            set
            {
                if (value)
                    _multipleJump = false;
                else
                    _multipleJump = true;
                OnPropertyChanged(nameof(OnState));
                OnPropertyChanged(nameof(OffState));
            }
        }
        public MultipleJumpViewModel(bool multipleJump) { 
            _multipleJump=multipleJump;
        }
    }
}

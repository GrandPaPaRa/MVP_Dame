using Dame.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dame.Commands
{
    internal class MultipleJumpOffCommand : BaseCommand
    {
        public override void Execute(object? parameter)
        {
            GameLogic.ExtraJump = false;
        }
    }
}

using Dame.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dame.Commands
{
    internal class MultipleJumpOnCommand : BaseCommand
    {
        public override void Execute(object? parameter)
        {
            GameLogic.ExtraJump = true;
        }
    }
}

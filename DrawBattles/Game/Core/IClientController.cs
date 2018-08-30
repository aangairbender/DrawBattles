using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawBattles.Game.Core
{
    interface IClientController
    {
        void MoveCursorTo(int X, int Y);
        void SetDraw(bool active);
        void SetHardDraw(bool active);
    }
}

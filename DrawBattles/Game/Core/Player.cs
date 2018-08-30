using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawBattles.Game.Core
{
    class Player
    {
        public string Name { get; }
        public Color DrawColor { get; }
        public Player(string name, Color drawColor)
        {
            Name = name;
            DrawColor = drawColor;
        }
    }
}

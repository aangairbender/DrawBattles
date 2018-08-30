using ClipperLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawBattles.Game.Core
{
    class GameState
    {
        public Dictionary<Player, PlayerState> PlayerStates { get; }
        public GameState(Dictionary<Player, PlayerState> playerStates)
        {
            PlayerStates = playerStates;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClipperLib;

namespace DrawBattles.Game.Core.Client
{
    class GameClient
    {
        public IClientController Controller { get; }

        public GameState GameState { get; private set; }

        public Graphics RenderTarget { get; set; } = null;

        public void UpdateGameState(GameState newGameState)
        {
            GameState = newGameState;
            if (RenderTarget != null)
                Renderer.Render(RenderTarget, GameState);
        }

    }
}

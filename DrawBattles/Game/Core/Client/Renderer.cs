using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawBattles.Game.Core.Client
{
    class Renderer
    {
        public static Color BackgroundColor { get; set; } = Color.Gray;
        public static float PolylinesPenWidth { get; set; } = 2;
        public static float CursorRadius { get; set; } = 1.5f;

        public static void Render(Graphics g, GameState s)
        {
            g.Clear(BackgroundColor);

            foreach (var playerStateKeyValuePair in s.PlayerStates)
            {
                Player player = playerStateKeyValuePair.Key;
                PlayerState state = playerStateKeyValuePair.Value;
                RenderPlayer(g, player, state);
            }
        }

        private static void RenderPlayer(Graphics g, Player player, PlayerState state)
        {
            Pen pen = new Pen(player.DrawColor, PolylinesPenWidth);
            Brush brush = new SolidBrush(player.DrawColor);

            foreach (var polyline in state.Polylines)
            {
                g.DrawLines(pen, polyline.Select(x => new Point((int)x.X, (int)x.Y)).ToArray());
            }

            foreach (var polygon in state.Polygons)
            {
                g.DrawPolygon(pen, polygon.Select(x => new Point((int)x.X, (int)x.Y)).ToArray());
            }

            if (state.Cursor.HasValue)
            {
                g.FillEllipse(brush, new RectangleF(
                    new PointF(state.Cursor.Value.X - CursorRadius, state.Cursor.Value.Y - CursorRadius),
                    new SizeF(CursorRadius * 2, CursorRadius * 2)));
            }
        }
    }
}

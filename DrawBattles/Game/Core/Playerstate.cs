using ClipperLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawBattles.Game.Core
{
    class PlayerState
    {
        public List<List<IntPoint>> Polygons { get; }
        public List<List<IntPoint>> Polylines { get; }
        public IntPoint? Cursor { get; }
        public double? Energy { get; }
        public PlayerState(
            List<List<IntPoint>> polygons,
            List<List<IntPoint>> polylines,
            IntPoint? cursor = null,
            double? energy = null)
        {
            Polygons = polygons;
            Polylines = polylines;
            Cursor = cursor;
            Energy = energy;
        }
    }
}

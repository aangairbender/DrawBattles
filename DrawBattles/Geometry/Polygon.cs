using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawBattles.Geometry
{
    class Polygon
    {
        private ICollection<Point> _points;

        public IReadOnlyCollection<Point> Points => (IReadOnlyCollection<Point>)_points;

        public Polygon()
        {
            _points = new List<Point>();
        }
        public Polygon(params Point[] points) : this(points as IEnumerable<Point>)
        {
        }
        public Polygon(IEnumerable<Point> points) : this()
        {
            foreach (var p in points)
                _points.Add(p);
        }

        public Polygon Intersect(Polygon poly)
        {

        }



    }
}

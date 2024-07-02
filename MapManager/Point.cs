using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapManager
{
    public class Point
    {
        public string Label { get; set; }
        public string Type { get; set; }
        public float X { get; set; }
        public float Y { get; set; }

        public List<Point> ConnectedPoints { get; set; }
    }
}

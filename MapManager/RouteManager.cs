using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Text.Json;

namespace MapManager
{
    public class RouteManager
    {
        public Dictionary<string, Point> Nodes { get; private set; }

        public RouteManager(IConfiguration configuration)
        {
            var nodeFilePath = Path.Combine(Directory.GetCurrentDirectory(), configuration["NodeListFileName"]);
            var points = JsonSerializer.Deserialize<List<Point>>(File.ReadAllText(nodeFilePath));
            Nodes = points.ToDictionary(k => k.Label, k => k);
        }

        public static double CalculateDistance(Point a, Point b)
        {
            return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
        }

        public List<string> GetShortestPath(string startLabel, string endLabel)
        {
            var distances = new Dictionary<string, double>();
            var previous = new Dictionary<string, string>();
            var priorityQueue = new SortedSet<(double, string)>();

            foreach (var node in Nodes.Values)
            {
                distances[node.Label] = double.PositiveInfinity;
                previous[node.Label] = null;
                priorityQueue.Add((double.PositiveInfinity, node.Label));
            }

            distances[startLabel] = 0;
            priorityQueue.Add((0, startLabel));

            while (priorityQueue.Count > 0)
            {
                var (currentDistance, currentNodeLabel) = priorityQueue.First();
                priorityQueue.Remove(priorityQueue.First());

                if (currentNodeLabel == endLabel)
                    break;

                foreach (var connectedPoint in Nodes[currentNodeLabel].ConnectedPoints)
                {
                    double distance = CalculateDistance(Nodes[currentNodeLabel], Nodes[connectedPoint.Label]);
                    double newDist = currentDistance + distance;

                    if (newDist < distances[connectedPoint.Label])
                    {
                        priorityQueue.Remove((distances[connectedPoint.Label], connectedPoint.Label));
                        distances[connectedPoint.Label] = newDist;
                        previous[connectedPoint.Label] = currentNodeLabel;
                        priorityQueue.Add((newDist, connectedPoint.Label));
                    }
                }
            }

            var path = new List<string>();
            var current = endLabel;

            while (current != null)
            {
                path.Add(current);
                current = previous[current];
            }

            path.Reverse();
            return path;
        }
    }
}

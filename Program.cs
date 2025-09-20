var solution = new Solution();

// Test case
var points = new List<Point>
        {
            new(0, 0),
            new(5, 4),
            new(3, 1)
        };

var central = new Point(1, 2);
var k = 2;
var result = solution.FindNearestKPoints(points, central, k);
Console.WriteLine($"Nearest {k} points: {string.Join(", ", result)}"); // [(0, 0), (3, 1)]

// Additional test case
var points2 = new List<Point>
        {
            new(1, 1),
            new(2, 2),
            new(3, 3),
            new(0, 0)
        };

var central2 = new Point(2, 2);
var k2 = 3;
var result2 = solution.FindNearestKPoints(points2, central2, k2);
Console.WriteLine($"Nearest {k2} points: {string.Join(", ", result2)}"); // [(2, 2), (1, 1), (3, 3)]

public struct Point
{
    public int X { get; }
    public int Y { get; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
    public override string ToString()
    {
        return $"({X}, {Y})";
    }
}

public class Solution
{
    public List<Point> FindNearestKPoints(List<Point> points, Point central, int k)
    {
        if (points == null || points.Count == 0 || k <= 0)
            throw new ArgumentException("Invalid input: points list must be non-empty and k must be positive.");
        if (k > points.Count)
            k = points.Count;

        // Calculate squared distance and sort
        var pointsWithDistance = points.Select(p => new
        {
            Point = p,
            Distance = (p.X - central.X) * (p.X - central.X) + (p.Y - central.Y) * (p.Y - central.Y)
        })
        .OrderBy(x => x.Distance)
        .Take(k)
        .Select(x => x.Point)
        .ToList();

        return pointsWithDistance;
    }
}
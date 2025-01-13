record class Point
{
    // Notice that we assign x to the X property (and not the _x field):
    public Point(double x, double y) =>
        (X, Y, DistanceFromOrigin) = (x, y, Math.Sqrt(x * x + y * y));

    double _x;
    double _y;
    double? _distance;
    public double X
    {
        get => _x;
        init
        {
            if (double.IsNaN(value))
                throw new ArgumentException("X Cannot be NaN");
            _x = value;
            _distance = null;
        }
    }
    public double Y { get; init {  _y = value; _distance = null;} } }
    public double DistanceFromOrigin => _distance ??= Math.Sqrt(X * X + Y * Y);
}

record Point3D(double X, double Y, double Z) : Point(X, Y);

/// <summary>
/// Defines an immutable two-dimensional point with validation and efficient distance calculation.
/// </summary>
/// <remarks>
/// The <c>Point</c> record provides value-based equality, input validation for coordinates, lazy distance calculation from the origin, and deconstruction support.
/// </remarks>

record Point
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Point"/> record with the specified coordinates.
    /// </summary>
    /// <param name="x">The X coordinate.</param>
    /// <param name="y">The Y coordinate.</param>
    public Point(double x, double y) => (X, Y) = (x, y);

    private double _x;
    private double _y;
    private double? _distance;

    /// <summary>
    /// Gets the distance from the origin (0,0) to this point. Calculated lazily and cached.
    /// </summary>
    public double DistanceFromOrigin => _distance ??= Math.Sqrt(X * X + Y * Y);

    /// <summary>
    /// Gets the X coordinate.
    /// </summary>
    public double X
    {
        get => _x;
        init
        {
            if (double.IsNaN(value))
                throw new ArgumentException("X cannot be NaN.");
            _x = value;
            _distance = null;
        }
    }

    /// <summary>
    /// Gets the Y coordinate.
    /// </summary>
    public double Y
    {
        get => _y;
        init
        {
            if (double.IsNaN(value))
                throw new ArgumentException("Y cannot be NaN.");
            _y = value;
            _distance = null;
        }
    }

    /// <summary>
    /// Deconstructs the point into its X and Y coordinates.
    /// </summary>
    /// <param name="x">The X coordinate output.</param>
    /// <param name="y">The Y coordinate output.</param>
    public void Deconstruct(out double x, out double y) => (x, y) = (X, Y);
}

/// <summary>
/// Represents a three-dimensional point, derived from <see cref="Point"/>.
/// </summary>
/// <param name="X">The X coordinate.</param>
/// <param name="Y">The Y coordinate.</param>
/// <param name="Z">The Z coordinate.</param>
record Point3D(double X, double Y, double Z) : Point(X, Y);
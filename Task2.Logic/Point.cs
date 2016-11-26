namespace Task2.Logic
{
    /// <summary>
    /// Represents a point on a plane.
    /// </summary>
    public class Point
    {
        /// <summary>
        /// The x-coordinate.
        /// </summary>
        public int X { get; private set; }

        /// <summary>
        /// The y-coordinate.
        /// </summary>
        public int Y { get; private set; }

        /// <summary>
        /// Initializes a new instance of the Point class
        /// with specified x-coordinate and y-coordinate.
        /// </summary>
        /// <param name="x">The x-coordinate.</param>
        /// <param name="y">The y-coordinate.</param>
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}

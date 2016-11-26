using System.Collections.Generic;
using Task2.Logic;

namespace Task2.Tests
{
    class ComparerPoint : IComparer<Point>
    {
        public int Compare(Point x, Point y) => x.X - y.X;
    }
}

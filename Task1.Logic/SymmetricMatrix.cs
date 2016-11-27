namespace Task1.Logic
{
    /// <summary>
    /// Represents the symmetric matrix with elements 
    /// of a specified type.
    /// </summary>
    /// <typeparam name="T">The type.</typeparam>
    public class SymmetricMatrix<T> : SquareMatrix<T>
    {
        /// <summary>
        /// Initializes a new instance of the SymmetricMatrix class
        /// with a specified size.
        /// </summary>
        /// <param name="size">The size.</param>
        public SymmetricMatrix(int size) : base(size)
        {
        }

        /// <summary>
        /// Adds the element to the matrix to a specified place.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="row">The row.</param>
        /// <param name="column">The column.</param>
        public override void AddElement(T element, int row, int column)
        {
            base.AddElement(element, row, column);
            if (row != column)
                Elements[column, row] = element;
        }
    }
}

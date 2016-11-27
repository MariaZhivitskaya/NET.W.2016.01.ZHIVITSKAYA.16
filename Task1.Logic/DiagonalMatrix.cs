using System;

namespace Task1.Logic
{
    /// <summary>
    /// Represents the diagonal matrix with elements 
    /// of a specified type.
    /// </summary>
    /// <typeparam name="T">The type.</typeparam>
    public class DiagonalMatrix<T> : SquareMatrix<T>
    {
        /// <summary>
        /// Initializes a new instance of the DiagonalMatrix class
        /// with a specified size.
        /// </summary>
        /// <param name="size">The size.</param>
        public DiagonalMatrix(int size) : base(size)
        {
        }

        /// <summary>
        /// Adds the element to the matrix to a specified place.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Thrown if the palce is the nondiagonal.
        /// </exception>
        /// <param name="element">The element.</param>
        /// <param name="row">The row.</param>
        /// <param name="column">The column.</param>
        public override void AddElement(T element, int row, int column)
        {
            if (row != column)
                throw new ArgumentException("Impossible to add the element" +
                                            "to the nondiagonal place!");

            base.AddElement(element, row, column);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;

namespace Task1.Logic
{
    /// <summary>
    /// Represents the square matrix with elements 
    /// of a specified type.
    /// </summary>
    /// <typeparam name="T">The type.</typeparam>
    public class SquareMatrix<T> : IEnumerable<T>
    {
        private int _size;

        /// <summary>
        /// Elements.
        /// </summary>
        public T[,] Elements { get; } = {};

        /// <summary>
        /// Matrix size.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if the size is less or equal than 0.
        /// </exception>
        public int Size
        {
            get { return _size; }
            private set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Wrong size of the matrix!");

                _size = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the SquareMatrix class
        /// with a specified size.
        /// </summary>
        /// <param name="size">The size.</param>
        public SquareMatrix(int size)
        {
            Size = size;
            Elements = new T[Size, Size];
        }

        /// <summary>
        /// Adds the element to the matrix to a specified place.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if the row or the column
        /// is out of range.
        /// </exception>
        /// <param name="element">The element.</param>
        /// <param name="row">The row.</param>
        /// <param name="column">The column.</param>
        public virtual void AddElement(T element, int row, int column)
        {
            if (row < 0 || row >= Size)
                throw new ArgumentOutOfRangeException("Wrong row index!");

            if (column < 0 || column >= Size)
                throw new ArgumentOutOfRangeException("Wrong column index!");

            Elements[row, column] = element;
        }

        /// <summary>
        /// Represents the indexer for the matrix.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <param name="column">The column.</param>
        /// <returns>Returns the element at a specified position.</returns>
        public T this[int row, int column]
        {
            get
            {
                if (row < 0 || row >= Size)
                    throw new ArgumentOutOfRangeException("Wrong row index!");

                if (column < 0 || column >= Size)
                    throw new ArgumentOutOfRangeException("Wrong column index!");

                return Elements[row, column];
            }
            set
            {
                if (row < 0 || row >= Size)
                    throw new ArgumentOutOfRangeException("Wrong row index!");

                if (column < 0 || column >= Size)
                    throw new ArgumentOutOfRangeException("Wrong column index!");

                Elements[row, column] = value;
            }
        }

        /// <summary>
        /// Gets the enumerator for the matrix.
        /// </summary>
        /// <returns>Returns the next element.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    yield return Elements[i, j];
        }

        /// <summary>
        /// Gets the enumerator for the matrix.
        /// </summary>
        /// <returns>Returns the next element.</returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

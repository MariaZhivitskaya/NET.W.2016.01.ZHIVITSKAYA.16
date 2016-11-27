using System;

namespace Task1.Logic
{
    /// <summary>
    /// Represents the extension class for matrices.
    /// </summary>
    public static class MatrixExtension
    {
        /// <summary>
        /// Finds the sum of two matrices.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// Thrown if the second matrix is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if matrices have different sizes.
        /// </exception>
        /// <typeparam name="T">The type of matrices.</typeparam>
        /// <param name="matrix1">The first matrix.</param>
        /// <param name="matrix2">The second matrix.</param>
        /// <param name="iSum">The summing logic.</param>
        /// <returns>Returns the resulting matrix.</returns>
        public static SquareMatrix<T> Add<T>(this SquareMatrix<T> matrix1, SquareMatrix<T> matrix2,
            ISum<T> iSum)
        {
            if (matrix2 == null)
                throw new ArgumentNullException("The second matrix is null!");

            if (matrix1.Size != matrix2.Size)
                throw new ArgumentException("Sizes of matrices are different!");

            int size = matrix1.Size;
            var result = new SquareMatrix<T>(size);

            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    result[i, j] = iSum.Sum(matrix1[i, j], matrix2[i, j]);

            return result;
        }

        /// <summary>
        /// Finds the sum of two symmetric matrices.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// Thrown if the second matrix is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if matrices have different sizes.
        /// </exception>
        /// <typeparam name="T">The type of matrices.</typeparam>
        /// <param name="matrix1">The first matrix.</param>
        /// <param name="matrix2">The second matrix.</param>
        /// <param name="iSum">The summing logic.</param>
        /// <returns>Returns the resulting matrix.</returns>
        public static SymmetricMatrix<T> Add<T>(this SymmetricMatrix<T> matrix1, SymmetricMatrix<T> matrix2,
           ISum<T> iSum)
        {
            if (matrix2 == null)
                throw new ArgumentNullException("The second matrix is null!");

            if (matrix1.Size != matrix2.Size)
                throw new ArgumentException("Sizes of matrices are different!");

            int size = matrix1.Size;
            var result = new SymmetricMatrix<T>(size);

            for (int i = 0; i < size; i++)
                for (int j = 0; j < i + 1; j++)
                {
                    result[i, j] = iSum.Sum(matrix1[i, j], matrix2[i, j]);
                    result[j, i] = result[i, j];
                }

            return result;
        }

        /// <summary>
        /// Finds the sum of two diagonal matrices.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// Thrown if the second matrix is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if matrices have different sizes.
        /// </exception>
        /// <typeparam name="T">The type of matrices.</typeparam>
        /// <param name="matrix1">The first matrix.</param>
        /// <param name="matrix2">The second matrix.</param>
        /// <param name="iSum">The summing logic.</param>
        /// <returns>Returns the resulting matrix.</returns>
        public static DiagonalMatrix<T> Add<T>(this DiagonalMatrix<T> matrix1, DiagonalMatrix<T> matrix2,
           ISum<T> iSum)
        {
            if (matrix2 == null)
                throw new ArgumentNullException("The second matrix is null!");

            if (matrix1.Size != matrix2.Size)
                throw new ArgumentException("Sizes of matrices are different!");

            int size = matrix1.Size;
            var result = new DiagonalMatrix<T>(size);

            for (int i = 0; i < size; i++)
               result[i, i] = iSum.Sum(matrix1[i, i], matrix2[i, i]);

            return result;
        }
    }
}

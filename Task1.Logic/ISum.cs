namespace Task1.Logic
{
    /// <summary>
    /// Represents an interface for summing two elements
    /// of a specified type.
    /// </summary>
    /// <typeparam name="T">The type.</typeparam>
    public interface ISum<T>
    {
        /// <summary>
        /// Calculates the sum of two elements
        /// of a specified type.
        /// </summary>
        /// <param name="element1">The first element.</param>
        /// <param name="element2">The second element.</param>
        /// <returns>Returns the sum.</returns>
        T Sum(T element1, T element2);
    }
}

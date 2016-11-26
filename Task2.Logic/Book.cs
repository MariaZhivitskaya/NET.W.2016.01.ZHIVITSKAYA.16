using System;

namespace Task2.Logic
{
    /// <summary>
    /// Represents a book.
    /// </summary>
    public class Book : IComparable<Book>
    {
        private string _author;
        private string _title;
        private string _language;
        private int _pagesNumber;
        private int _edition;

        /// <summary>
        /// The author.
        /// <exception cref="ArgumentNullException">
        /// Thrown if the author is null or empty.
        /// </exception>
        /// </summary>
        public string Author
        {
            get { return _author; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Null or empty string!");

                _author = value;
            }
        }

        /// <summary>
        /// The title.
        /// <exception cref="ArgumentNullException">
        /// Thrown if the title is null or empty.
        /// </exception>
        /// </summary>
        public string Title
        {
            get { return _title; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Null or empty string!");

                _title = value;
            }
        }

        /// <summary>
        /// The language.
        /// <exception cref="ArgumentNullException">
        /// Thrown if the language is null or empty.
        /// </exception>
        /// </summary>
        public string Language
        {
            get { return _language; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Null or empty string!");

                _language = value;
            }
        }

        /// <summary>
        /// The pages number.
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if the pages number is less
        /// or equal than 0.
        /// </exception>
        /// </summary>
        public int PagesNumber
        {
            get { return _pagesNumber; }
            private set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Wrong number of pages!");

                _pagesNumber = value;
            }
        }

        /// <summary>
        /// The edition.
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if the edition is less
        /// or equal than 0.
        /// </exception>
        /// </summary>
        public int Edition
        {
            get { return _edition; }
            private set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Wrong edition!");

                _edition = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the Book class
        /// with a specified author, title, language,
        /// pages number and edition.
        /// </summary>
        /// <param name="author">The author.</param>
        /// <param name="title">The title.</param>
        /// <param name="language">The language.</param>
        /// <param name="pagesNumber">The pages number.</param>
        /// <param name="edition">The edition.</param>
        public Book(string author = "Not specified", string title = "Not specified",
            string language = "Not specified", int pagesNumber = 10, int edition = 10)
        {
            Author = author;
            Title = title;
            Language = language;
            PagesNumber = pagesNumber;
            Edition = edition;
        }
        
        /// <summary>
        /// Compares two books by the pages number.
        /// </summary>
        /// <param name="other">The book.</param>
        /// <returns>
        /// Returns 1 if the first book has more pages.
        /// Returns -1 if the first book has less pages.
        /// Returns 0 if the first book and the second book
        /// have the same number of pages.
        /// </returns>
        public int CompareTo(Book other)
        {
            if (other == null)
                return 1;

            return PagesNumber - other.PagesNumber;
        }
    }
}

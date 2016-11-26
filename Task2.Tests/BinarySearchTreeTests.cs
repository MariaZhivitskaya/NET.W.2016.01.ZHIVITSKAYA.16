using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Task2.Logic;

namespace Task2.Tests
{
    [TestFixture]
    public class BinarySearchTreeTests
    {
        private static readonly BinarySearchTree<int> Integers = 
            new BinarySearchTree<int>(Comparer<int>.Default);

        private static readonly BinarySearchTree<string> Strings =
            new BinarySearchTree<string>(Comparer<string>.Default);

        private static readonly BinarySearchTree<Book> Books = 
            new BinarySearchTree<Book>(Comparer<Book>.Default);

        private static readonly BinarySearchTree<Point> Points = 
            new BinarySearchTree<Point>(new ComparerPoint());

        private static readonly Book Book1 = new Book("J.K.Rowling", "Harry Potter and the Chamber of Secrets", 
            "english", 623, 1500);

        private static readonly Book Book2 = new Book("W.Shakespeare", "Romeo and Juliet", 
            "russian", 150, 1100);

        private static readonly Book Book3 = new Book("M.A.Bulgakov", "The master and Margarita", 
            "russian", 300, 1200);

        private static readonly Point Point1 = new Point(10, 18);
        private static readonly Point Point2 = new Point(7, -5);
        private static readonly Point Point3 = new Point(15, 3);

        private static readonly List<int> ExpectedIntegersPreorder = new List<int>();
        private static readonly List<int> ExpectedIntegersInorder = new List<int>();
        private static readonly List<int> ExpectedIntegersPostorder = new List<int>();

        private static readonly List<string> ExpectedStringsPreorder = new List<string>();
        private static readonly List<string> ExpectedStringsInorder = new List<string>();
        private static readonly List<string> ExpectedStringsPostorder = new List<string>();

        private static readonly List<Book> ExpectedBooksPreorder = new List<Book>();
        private static readonly List<Book> ExpectedBooksInorder = new List<Book>();
        private static readonly List<Book> ExpectedBooksPostorder = new List<Book>();

        private static readonly List<Point> ExpectedPointsPreorder = new List<Point>();
        private static readonly List<Point> ExpectedPointsInorder = new List<Point>();
        private static readonly List<Point> ExpectedPointsPostorder = new List<Point>();

        static BinarySearchTreeTests()
        {
            Integers.Insert(5);
            Integers.Insert(-6);
            Integers.Insert(10);
            Integers.Insert(7);
            Integers.Insert(18);

            Strings.Insert("lazy");
            Strings.Insert("honney");
            Strings.Insert("pet");
            Strings.Insert("kitchen");
            Strings.Insert("mirror");

            Books.Insert(Book1);
            Books.Insert(Book2);
            Books.Insert(Book3);

            Points.Insert(Point1);
            Points.Insert(Point2);
            Points.Insert(Point3);

            ExpectedIntegersPreorder.Add(5);
            ExpectedIntegersPreorder.Add(-6);
            ExpectedIntegersPreorder.Add(10);
            ExpectedIntegersPreorder.Add(7);
            ExpectedIntegersPreorder.Add(18);

            ExpectedIntegersInorder.Add(-6);
            ExpectedIntegersInorder.Add(5);
            ExpectedIntegersInorder.Add(7);
            ExpectedIntegersInorder.Add(10);
            ExpectedIntegersInorder.Add(18);

            ExpectedIntegersPostorder.Add(-6);
            ExpectedIntegersPostorder.Add(7);
            ExpectedIntegersPostorder.Add(18);
            ExpectedIntegersPostorder.Add(10);
            ExpectedIntegersPostorder.Add(5);

            ExpectedStringsPreorder.Add("lazy");
            ExpectedStringsPreorder.Add("honney");
            ExpectedStringsPreorder.Add("kitchen");
            ExpectedStringsPreorder.Add("pet");
            ExpectedStringsPreorder.Add("mirror");

            ExpectedStringsInorder.Add("honney");
            ExpectedStringsInorder.Add("kitchen");
            ExpectedStringsInorder.Add("lazy");
            ExpectedStringsInorder.Add("mirror");
            ExpectedStringsInorder.Add("pet");

            ExpectedStringsPostorder.Add("kitchen");
            ExpectedStringsPostorder.Add("honney");
            ExpectedStringsPostorder.Add("mirror");
            ExpectedStringsPostorder.Add("pet");
            ExpectedStringsPostorder.Add("lazy");

            ExpectedBooksPreorder.Add(Book1);
            ExpectedBooksPreorder.Add(Book2);
            ExpectedBooksPreorder.Add(Book3);

            ExpectedBooksInorder.Add(Book2);
            ExpectedBooksInorder.Add(Book3);
            ExpectedBooksInorder.Add(Book1);

            ExpectedBooksPostorder.Add(Book3);
            ExpectedBooksPostorder.Add(Book2);
            ExpectedBooksPostorder.Add(Book1);

            ExpectedPointsPreorder.Add(Point1);
            ExpectedPointsPreorder.Add(Point2);
            ExpectedPointsPreorder.Add(Point3);

            ExpectedPointsInorder.Add(Point2);
            ExpectedPointsInorder.Add(Point1);
            ExpectedPointsInorder.Add(Point3);

            ExpectedPointsPostorder.Add(Point2);
            ExpectedPointsPostorder.Add(Point3);
            ExpectedPointsPostorder.Add(Point1);
        }

        [Test, TestCaseSource(typeof(PreorderIntegersTest), 
            nameof(PreorderIntegersTest.PreorderIntegersTestCases))]
        public void PreorderIntegersTests(BinarySearchTree<int> source, 
            List<int> expected) => Assert.AreEqual(expected, source.Preorder());

        [Test, TestCaseSource(typeof(InorderIntegersTest),
            nameof(InorderIntegersTest.InorderIntegersTestCases))]
        public void InorderIntegersTests(BinarySearchTree<int> source,
            List<int> expected) => Assert.AreEqual(expected, source.Inorder());

        [Test, TestCaseSource(typeof(PostorderIntegersTest),
            nameof(PostorderIntegersTest.PostorderIntegersTestCases))]
        public void PostorderIntegersTests(BinarySearchTree<int> source,
            List<int> expected) => Assert.AreEqual(expected, source.Postorder());

        [Test, TestCaseSource(typeof(PreorderStringsTest),
           nameof(PreorderStringsTest.PreorderStringsTestCases))]
        public void PreorderStringsTests(BinarySearchTree<string> source,
           List<string> expected) => Assert.AreEqual(expected, source.Preorder());

        [Test, TestCaseSource(typeof(InorderStringsTest),
           nameof(InorderStringsTest.InorderStringsTestCases))]
        public void InorderStringsTests(BinarySearchTree<string> source,
           List<string> expected) => Assert.AreEqual(expected, source.Inorder());

        [Test, TestCaseSource(typeof(PostorderStringsTest),
           nameof(PostorderStringsTest.PostorderStringsTestCases))]
        public void PostorderStringsTests(BinarySearchTree<string> source,
           List<string> expected) => Assert.AreEqual(expected, source.Postorder());

        [Test, TestCaseSource(typeof(PreorderBooksTest),
           nameof(PreorderBooksTest.PreorderBooksTestCases))]
        public void PreorderBooksTests(BinarySearchTree<Book> source,
           List<Book> expected) => Assert.AreEqual(expected, source.Preorder());

        [Test, TestCaseSource(typeof(InorderBooksTest),
           nameof(InorderBooksTest.InorderBooksTestCases))]
        public void InorderBooksTests(BinarySearchTree<Book> source,
           List<Book> expected) => Assert.AreEqual(expected, source.Inorder());

        [Test, TestCaseSource(typeof(PostorderBooksTest),
           nameof(PostorderBooksTest.PostorderBooksTestCases))]
        public void PostorderBooksTests(BinarySearchTree<Book> source,
           List<Book> expected) => Assert.AreEqual(expected, source.Postorder());

        [Test, TestCaseSource(typeof(PreorderPointsTest),
           nameof(PreorderPointsTest.PreorderPointsTestCases))]
        public void PreorderPointsTests(BinarySearchTree<Point> source,
           List<Point> expected) => Assert.AreEqual(expected, source.Preorder());

        [Test, TestCaseSource(typeof(InorderPointsTest),
          nameof(InorderPointsTest.InorderPointsTestCases))]
        public void InorderPointsTests(BinarySearchTree<Point> source,
          List<Point> expected) => Assert.AreEqual(expected, source.Inorder());

        [Test, TestCaseSource(typeof(PostorderPointsTest),
          nameof(PostorderPointsTest.PostorderPointsTestCases))]
        public void PostorderPointsTests(BinarySearchTree<Point> source,
          List<Point> expected) => Assert.AreEqual(expected, source.Postorder());

        public class PreorderIntegersTest
        {
            public static IEnumerable PreorderIntegersTestCases
            {
                get
                {
                    yield return new TestCaseData(Integers, ExpectedIntegersPreorder);
                }
            }
        }

        public class InorderIntegersTest
        {
            public static IEnumerable InorderIntegersTestCases
            {
                get
                {
                    yield return new TestCaseData(Integers, ExpectedIntegersInorder);
                }
            }
        }

        public class PostorderIntegersTest
        {
            public static IEnumerable PostorderIntegersTestCases
            {
                get
                {
                    yield return new TestCaseData(Integers, ExpectedIntegersPostorder);
                }
            }
        }

        public class PreorderStringsTest
        {
            public static IEnumerable PreorderStringsTestCases
            {
                get
                {
                    yield return new TestCaseData(Strings, ExpectedStringsPreorder);
                }
            }
        }

        public class InorderStringsTest
        {
            public static IEnumerable InorderStringsTestCases
            {
                get
                {
                    yield return new TestCaseData(Strings, ExpectedStringsInorder);
                }
            }
        }

        public class PostorderStringsTest
        {
            public static IEnumerable PostorderStringsTestCases
            {
                get
                {
                    yield return new TestCaseData(Strings, ExpectedStringsPostorder);
                }
            }
        }

        public class PreorderBooksTest
        {
            public static IEnumerable PreorderBooksTestCases
            {
                get
                {
                    yield return new TestCaseData(Books, ExpectedBooksPreorder);
                }
            }
        }

        public class InorderBooksTest
        {
            public static IEnumerable InorderBooksTestCases
            {
                get
                {
                    yield return new TestCaseData(Books, ExpectedBooksInorder);
                }
            }
        }

        public class PostorderBooksTest
        {
            public static IEnumerable PostorderBooksTestCases
            {
                get
                {
                    yield return new TestCaseData(Books, ExpectedBooksPostorder);
                }
            }
        }

        public class PreorderPointsTest
        {
            public static IEnumerable PreorderPointsTestCases
            {
                get
                {
                    yield return new TestCaseData(Points, ExpectedPointsPreorder);
                }
            }
        }

        public class InorderPointsTest
        {
            public static IEnumerable InorderPointsTestCases
            {
                get
                {
                    yield return new TestCaseData(Points, ExpectedPointsInorder);
                }
            }
        }

        public class PostorderPointsTest
        {
            public static IEnumerable PostorderPointsTestCases
            {
                get
                {
                    yield return new TestCaseData(Points, ExpectedPointsPostorder);
                }
            }
        }
    }
}

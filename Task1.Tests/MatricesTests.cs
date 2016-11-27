using System.Collections;
using NUnit.Framework;
using Task1.Logic;

namespace Task1.Tests
{
    [TestFixture]
    public class MatricesTests
    {
        public static readonly SymmetricMatrix<int> SymmetricMatrixIntegers1 =
            new SymmetricMatrix<int>(3);

        public static readonly SymmetricMatrix<int> SymmetricMatrixIntegers2 =
            new SymmetricMatrix<int>(3);

        public static readonly SymmetricMatrix<int> SymmetricMatrixIntegersSum =
            new SymmetricMatrix<int>(3);

        public static readonly SymmetricMatrix<string> SymmetricMatrixStrings1 =
            new SymmetricMatrix<string>(2);

        public static readonly SymmetricMatrix<string> SymmetricMatrixStrings2 =
            new SymmetricMatrix<string>(2);

        public static readonly SymmetricMatrix<string> SymmetricMatrixStringsSum =
            new SymmetricMatrix<string>(2);

        public static readonly DiagonalMatrix<int> DiagonalMatrixIntegers1 =
            new DiagonalMatrix<int>(3);

        public static readonly DiagonalMatrix<int> DiagonalMatrixIntegers2 =
            new DiagonalMatrix<int>(3);

        public static readonly DiagonalMatrix<int> DiagonalMatrixIntegersSum =
            new DiagonalMatrix<int>(3);

        public static readonly DiagonalMatrix<string> DiagonalMatrixStrings1 =
           new DiagonalMatrix<string>(2);

        public static readonly DiagonalMatrix<string> DiagonalMatrixStrings2 =
          new DiagonalMatrix<string>(2);

        public static readonly DiagonalMatrix<string> DiagonalMatrixStringsSum =
          new DiagonalMatrix<string>(2);

        public static readonly SquareMatrix<int> SquareMatrixIntegersSum =
            new SquareMatrix<int>(3);

        public static readonly SquareMatrix<string> SquareMatrixStringsSum =
            new SquareMatrix<string>(2);

        static MatricesTests()
        {
            SymmetricMatrixIntegers1.AddElement(7, 0, 0);
            SymmetricMatrixIntegers1.AddElement(-5, 0, 1);
            SymmetricMatrixIntegers1.AddElement(3, 1, 1);
            SymmetricMatrixIntegers1.AddElement(8, 2, 0);
            SymmetricMatrixIntegers1.AddElement(-4, 2, 1);
            SymmetricMatrixIntegers1.AddElement(3, 2, 2);

            SymmetricMatrixIntegers2.AddElement(4, 0, 0);
            SymmetricMatrixIntegers2.AddElement(1, 0, 1);
            SymmetricMatrixIntegers2.AddElement(1, 1, 1);
            SymmetricMatrixIntegers2.AddElement(1, 2, 0);
            SymmetricMatrixIntegers2.AddElement(-6, 2, 1);
            SymmetricMatrixIntegers2.AddElement(-3, 2, 2);

            SymmetricMatrixIntegersSum.AddElement(11, 0, 0);
            SymmetricMatrixIntegersSum.AddElement(-4, 0, 1);
            SymmetricMatrixIntegersSum.AddElement(4, 1, 1);
            SymmetricMatrixIntegersSum.AddElement(9, 2, 0);
            SymmetricMatrixIntegersSum.AddElement(-10, 2, 1);
            SymmetricMatrixIntegersSum.AddElement(0, 2, 2);

            SymmetricMatrixStrings1.AddElement("Start", 0, 0);
            SymmetricMatrixStrings1.AddElement("Dark", 1, 1);
            SymmetricMatrixStrings1.AddElement("Big", 1, 0);

            SymmetricMatrixStrings2.AddElement("it", 0, 0);
            SymmetricMatrixStrings2.AddElement("room", 1, 1);
            SymmetricMatrixStrings2.AddElement("pig", 1, 0);

            SymmetricMatrixStringsSum.AddElement("Start it", 0, 0);
            SymmetricMatrixStringsSum.AddElement("Dark room", 1, 1);
            SymmetricMatrixStringsSum.AddElement("Big pig", 1, 0);

            DiagonalMatrixIntegers1.AddElement(5, 0, 0);
            DiagonalMatrixIntegers1.AddElement(-3, 1, 1);
            DiagonalMatrixIntegers1.AddElement(17, 2, 2);

            DiagonalMatrixIntegers2.AddElement(-12, 0, 0);
            DiagonalMatrixIntegers2.AddElement(8, 1, 1);
            DiagonalMatrixIntegers2.AddElement(3, 2, 2);

            DiagonalMatrixIntegersSum.AddElement(-7, 0, 0);
            DiagonalMatrixIntegersSum.AddElement(5, 1, 1);
            DiagonalMatrixIntegersSum.AddElement(20, 2, 2);

            DiagonalMatrixStrings1.AddElement("Good", 0, 0);
            DiagonalMatrixStrings1.AddElement("Hi", 1, 1);

            DiagonalMatrixStrings2.AddElement("time", 0, 0);
            DiagonalMatrixStrings2.AddElement("there!", 1, 1);

            DiagonalMatrixStringsSum.AddElement("Good time", 0, 0);
            DiagonalMatrixStringsSum.AddElement("Hi there!", 1, 1);

            SquareMatrixIntegersSum.AddElement(12, 0, 0);
            SquareMatrixIntegersSum.AddElement(-5, 0, 1);
            SquareMatrixIntegersSum.AddElement(-5, 1, 0);
            SquareMatrixIntegersSum.AddElement(0, 1, 1);
            SquareMatrixIntegersSum.AddElement(8, 2, 0);
            SquareMatrixIntegersSum.AddElement(8, 0, 2);
            SquareMatrixIntegersSum.AddElement(-4, 2, 1);
            SquareMatrixIntegersSum.AddElement(-4, 1, 2);
            SquareMatrixIntegersSum.AddElement(20, 2, 2);

            SquareMatrixStringsSum.AddElement("Start time", 0, 0);
            SquareMatrixStringsSum.AddElement("Dark there!", 1, 1);
            SquareMatrixStringsSum.AddElement("Big", 1, 0);
            SquareMatrixStringsSum.AddElement("Big", 0, 1);
        }

        public class SumIntegers : ISum<int>
        {
            public int Sum(int element1, int element2) =>
                element1 + element2;
        }

        public class SumStrings : ISum<string>
        {
            public string Sum(string element1, string element2)
            {
                if (element1 == null && element2 == null)
                    return null;

                if (element1 == null)
                    return element2;

                if (element2 == null)
                    return element1;

                return element1 + " " + element2;
            }
        }

        [Test, TestCaseSource(typeof(SymmetricMatrixIntegersTest),
            nameof(SymmetricMatrixIntegersTest.SymmetricMatrixIntegersTestCases))]
        public void SymmetricMatrixIntegersSumTests(SymmetricMatrix<int> source1,
            SymmetricMatrix<int> source2, SymmetricMatrix<int> expected) =>
                Assert.AreEqual(source1.Add(source2, new SumIntegers()), expected);

        [Test, TestCaseSource(typeof(SymmetricMatrixStringsTest),
            nameof(SymmetricMatrixStringsTest.SymmetricMatrixStringsTestCases))]
        public void MatrixStringsSumTests(SymmetricMatrix<string> source1,
            SymmetricMatrix<string> source2, SymmetricMatrix<string> expected) =>
                Assert.AreEqual(source1.Add(source2, new SumStrings()), expected);

        [Test, TestCaseSource(typeof(DiagonalMatrixIntegersTest),
            nameof(DiagonalMatrixIntegersTest.DiagonalMatrixIntegersTestCases))]
        public void DiagonalMatrixIntegersSumTests(DiagonalMatrix<int> source1,
            DiagonalMatrix<int> source2, DiagonalMatrix<int> expected) =>
                Assert.AreEqual(source1.Add(source2, new SumIntegers()), expected);

        [Test, TestCaseSource(typeof(DiagonalMatrixStringsTest),
            nameof(DiagonalMatrixStringsTest.DiagonalMatrixStringsTestCases))]
        public void DiagonalMatrixStringsSumTests(DiagonalMatrix<string> source1,
            DiagonalMatrix<string> source2, DiagonalMatrix<string> expected) =>
                Assert.AreEqual(source1.Add(source2, new SumStrings()), expected);

        [Test, TestCaseSource(typeof(SquareMatrixIntegersTest),
             nameof(SquareMatrixIntegersTest.SquareMatrixIntegersTestCases))]
        public void SquareMatrixIntegersSumTests(SquareMatrix<int> source1,
             SquareMatrix<int> source2, SquareMatrix<int> expected) =>
                 Assert.AreEqual(source1.Add(source2, new SumIntegers()), expected);

        [Test, TestCaseSource(typeof(SquareMatrixStringsTest),
             nameof(SquareMatrixStringsTest.SquareMatrixStringsTestCases))]
        public void SquareMatrixStringsSumTests(SquareMatrix<string> source1,
             SquareMatrix<string> source2, SquareMatrix<string> expected) =>
                 Assert.AreEqual(source1.Add(source2, new SumStrings()), expected);

        public class SymmetricMatrixIntegersTest
        {
            public static IEnumerable SymmetricMatrixIntegersTestCases
            {
                get
                {
                    yield return new TestCaseData(SymmetricMatrixIntegers1, SymmetricMatrixIntegers2,
                        SymmetricMatrixIntegersSum);
                }
            }
        }

        public class SymmetricMatrixStringsTest
        {
            public static IEnumerable SymmetricMatrixStringsTestCases
            {
                get
                {
                    yield return new TestCaseData(SymmetricMatrixStrings1, SymmetricMatrixStrings2,
                        SymmetricMatrixStringsSum);
                }
            }
        }

        public class DiagonalMatrixIntegersTest
        {
            public static IEnumerable DiagonalMatrixIntegersTestCases
            {
                get
                {
                    yield return new TestCaseData(DiagonalMatrixIntegers1, DiagonalMatrixIntegers2,
                         DiagonalMatrixIntegersSum);
                }
            }
        }

        public class DiagonalMatrixStringsTest
        {
            public static IEnumerable DiagonalMatrixStringsTestCases
            {
                get
                {
                    yield return new TestCaseData(DiagonalMatrixStrings1, DiagonalMatrixStrings2,
                         DiagonalMatrixStringsSum);
                }
            }
        }

        public class SquareMatrixIntegersTest
        {
            public static IEnumerable SquareMatrixIntegersTestCases
            {
                get
                {
                    yield return new TestCaseData(SymmetricMatrixIntegers1, DiagonalMatrixIntegers1,
                         SquareMatrixIntegersSum);
                }
            }
        }

        public class SquareMatrixStringsTest
        {
            public static IEnumerable SquareMatrixStringsTestCases
            {
                get
                {
                    yield return new TestCaseData(SymmetricMatrixStrings1, DiagonalMatrixStrings2,
                         SquareMatrixStringsSum);
                }
            }
        }
    }
}

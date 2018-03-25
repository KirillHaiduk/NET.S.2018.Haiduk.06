using NUnit.Framework;

namespace NET.S._2018.Haiduk._06
{
    [TestFixture]
    public class PolynomialTests
    {
        [Test]
        public void PolynomialTest1()
        {
            Polynomial p1 = new Polynomial(1.234, new int[] { 5, 6, 7, 8 });
            Polynomial p2 = new Polynomial(1.234, p1.Coefficients);
            Assert.IsTrue(p1.Equals(p2));            
        }

        [Test]
        public void PolynomialTest2()
        {
            Polynomial p1 = new Polynomial(0.544, new int[] { 5, 6, 7, 8 });
            Polynomial p2 = new Polynomial(0.544, new int[] { 5, 6, 7, 8 });
            Assert.AreEqual(p1, p2);
        }

        [Test]
        public void PolynomialTest3()
        {
            Polynomial p1 = new Polynomial(double.MaxValue, new int[] { 10, 11, 12 });
            Polynomial p2 = new Polynomial(double.MaxValue, new int[] { 10, 11, 12 });
            Assert.IsTrue(p1 == p2);
        }

        [Test]
        public void PolynomialTest4()
        {
            Polynomial p1 = new Polynomial(double.MinValue, new int[] { 10, 11, 12 });
            Polynomial p2 = new Polynomial(double.NaN, new int[] { 10, 11, 12 });
            Assert.IsTrue(p1 != p2);
        }

        [TestCase(new int[] { 2, 3, 4, 5 }, ExpectedResult = "2 + 3 * x + 4 * x ^ 2 + 5 * x ^ 3")]
        [TestCase(new int[] { 14, 22, 9, 53, 150 }, ExpectedResult = "14 + 22 * x + 9 * x ^ 2 + 53 * x ^ 3 + 150 * x ^ 4")]
        public string PolynomialToStringTest(int[] coefficients)
        {
            Polynomial p1 = new Polynomial(double.Epsilon, coefficients);
            return p1.ToString();
        }
    }
}

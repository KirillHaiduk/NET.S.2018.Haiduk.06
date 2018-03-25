using System;
using NUnit.Framework;

namespace NET.S._2018.Haiduk._06
{
    [TestFixture]
    public class BubbleSortClassTests
    {
        [TestCase(null, true)]
        public void BubbleSortTest_AcceptsEmptyArray_ThrowsException(int[][] array, bool sortByAscending)
        {
            Assert.Throws<ArgumentNullException>(() => BubbleSortClass.BubbleSortByMaxOfRowElements(array, sortByAscending));
            Assert.Throws<ArgumentNullException>(() => BubbleSortClass.BubbleSortByMinOfRowElements(array, sortByAscending));
            Assert.Throws<ArgumentNullException>(() => BubbleSortClass.BubbleSortBySumsOfElements(array, sortByAscending));
        }
          
        [Test]
        public void BubbleSortTest_AcceptsNonJaggedArray_ReturnsGivenArray()
        {
            int[][] array1 = new int[1][];
            int[][] array2 = new int[1][];
            int[][] array3 = new int[1][];
            int[][] array4 = new int[1][];
            BubbleSortClass.BubbleSortByMaxOfRowElements(array2, true);
            BubbleSortClass.BubbleSortByMinOfRowElements(array3, true);
            BubbleSortClass.BubbleSortBySumsOfElements(array4, true);
            CollectionAssert.AreEqual(array1, array2);
            CollectionAssert.AreEqual(array1, array3);
            CollectionAssert.AreEqual(array1, array4);
        }

        [Test]
        public void BubbleSortByMaxOfRowElementsTest()
        {
            int[][] array1 = new int[3][] { new int[] { 5, 12, -3 }, new int[] { 0, 3, 14 }, new int[] { 7, 8, 9 } };
            int[][] sorted = new int[3][] { new int[] { 14, 3, 0 }, new int[] { 12, 5, -3 }, new int[] { 9, 8, 7 } };
            BubbleSortClass.BubbleSortByMaxOfRowElements(array1, false);
            CollectionAssert.AreEqual(sorted, array1);
        }

        [Test]
        public void BubbleSortByMinOfRowElementsTest()
        {
            int[][] array1 = new int[3][] { new int[] { 6, 18, -10 }, new int[] { 10, 10, 12, -7 }, new int[] { 20 } };
            int[][] sorted = new int[3][] { new int[] { -10, 6, 18 }, new int[] { -7, 10, 10, 12 }, new int[] { 20 } };
            BubbleSortClass.BubbleSortByMinOfRowElements(array1, true);
            CollectionAssert.AreEqual(sorted, array1);
        }

        [Test]
        public void BubbleSortBySumsOfElementsTest()
        {
            int[][] array1 = new int[3][] { new int[] { 5, -7, 0 }, new int[] { 4 }, new int[] { 2, 3, 4, -8 } };
            int[][] sorted = new int[3][] { new int[] { 5, -7, 0 }, new int[] { 2, 3, 4, -8 }, new int[] { 4 } };
            BubbleSortClass.BubbleSortBySumsOfElements(array1, true);
            CollectionAssert.AreEqual(sorted, array1);
        }
    }
}

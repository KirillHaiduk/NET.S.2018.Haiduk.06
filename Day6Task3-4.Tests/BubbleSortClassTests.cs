using System;
using NUnit.Framework;
using static NET.S._2018.Haiduk._06.BubbleSortClass;

namespace NET.S._2018.Haiduk._06
{
    [TestFixture]
    public class BubbleSortClassTests
    {
        [TestCase(null)]
        public void BubbleSortTest_AcceptsEmptyArray_ThrowsException(int[][] array) => Assert.Throws<ArgumentNullException>(() => BubbleSort(array, new SortByMaxAscending()));

        [Test]
        public void BubbleSortTest_AcceptsNonJaggedArray_ReturnsGivenArray()
        {
            int[][] array1 = new int[1][];
            int[][] array2 = new int[1][];
            int[][] array3 = new int[1][];
            int[][] array4 = new int[1][];
            BubbleSort(array2, new SortByMaxAscending());
            BubbleSort(array3, new SortByMinAscending());
            BubbleSort(array4, new SortBySumAscending());
            CollectionAssert.AreEqual(array1, array2);
            CollectionAssert.AreEqual(array1, array3);
            CollectionAssert.AreEqual(array1, array4);
        }

        [Test]
        public void BubbleSortByMaxOfRowElementsDescendingTest()
        {
            int[][] array1 = new int[3][] { new int[] { 5, 12, -3 }, new int[] { 0, 3, 14 }, new int[] { 7, 8, 9 } };
            int[][] sorted = new int[3][] { new int[] { 0, 3, 14 }, new int[] { 5, 12, -3 }, new int[] { 7, 8, 9 } };
            BubbleSort(array1, new SortByMaxDescending());
            CollectionAssert.AreEqual(sorted, array1);
        }

        [Test]
        public void BubbleSortByMaxOfRowElementsDescendingUsingDelegateTest()
        {
            int[][] array1 = new int[3][] { new int[] { 5, 12, -3 }, new int[] { 0, 3, 14 }, new int[] { 7, 8, 9 } };
            int[][] sorted = new int[3][] { new int[] { 0, 3, 14 }, new int[] { 5, 12, -3 }, new int[] { 7, 8, 9 } };
            var comparer = new AdapterForDelegate(new SortByMaxDescending().Compare);
            BubbleSortWithDelegate(array1, comparer);
            CollectionAssert.AreEqual(sorted, array1);
        }        

        [Test]
        public void BubbleSortByMaxOfRowElementsAscendingTest()
        {
            int[][] array1 = new int[3][] { new int[] { 6, 18, -10 }, new int[] { 10, 10, 12, -7 }, new int[] { 20 } };
            int[][] sorted = new int[3][] { new int[] { 10, 10, 12, -7 }, new int[] { 6, 18, -10 }, new int[] { 20 } };
            BubbleSort(array1, new SortByMaxAscending());
            CollectionAssert.AreEqual(sorted, array1);
        }

        [Test]
        public void BubbleSortByMaxOfRowElementsAscendingUsingDelegateTest()
        {
            int[][] array1 = new int[3][] { new int[] { 6, 18, -10 }, new int[] { 10, 10, 12, -7 }, new int[] { 20 } };
            int[][] sorted = new int[3][] { new int[] { 10, 10, 12, -7 }, new int[] { 6, 18, -10 }, new int[] { 20 } };
            var comparer = new AdapterForDelegate(new SortByMaxAscending().Compare);
            BubbleSortWithDelegate(array1, comparer);
            CollectionAssert.AreEqual(sorted, array1);
        }

        [Test]
        public void BubbleSortByMinOfRowElementsDescendingTest()
        {
            int[][] array1 = new int[3][] { new int[] { -15, 26 }, new int[] { 4, 55, 8, -90 }, new int[] { 1, 3, -10, -7 } };
            int[][] sorted = new int[3][] { new int[] { 1, 3, -10, -7 }, new int[] { -15, 26 }, new int[] { 4, 55, 8, -90 } };
            BubbleSort(array1, new SortByMinDescending());
            CollectionAssert.AreEqual(sorted, array1);
        }

        [Test]
        public void BubbleSortByMinOfRowElementsDescendingUsingDelegateTest()
        {
            int[][] array1 = new int[3][] { new int[] { -15, 26 }, new int[] { 4, 55, 8, -90 }, new int[] { 1, 3, -10, -7 } };
            int[][] sorted = new int[3][] { new int[] { 1, 3, -10, -7 }, new int[] { -15, 26 }, new int[] { 4, 55, 8, -90 } };
            var comparer = new AdapterForDelegate(new SortByMinDescending().Compare);
            BubbleSortWithDelegate(array1, comparer);
            CollectionAssert.AreEqual(sorted, array1);
        }

        [Test]
        public void BubbleSortByMinOfRowElementsAscendingTest()
        {
            int[][] array1 = new int[4][] { new int[] { -4, 0 }, new int[] { 10, 10, 12, -7 }, new int[] { 0, 0, 0, 0 }, new int[] { 19, 19, 20 } };
            int[][] sorted = new int[4][] { new int[] { 10, 10, 12, -7 }, new int[] { -4, 0 }, new int[] { 0, 0, 0, 0 }, new int[] { 19, 19, 20 } };
            BubbleSort(array1, new SortByMinAscending());
            CollectionAssert.AreEqual(sorted, array1);
        }

        [Test]
        public void BubbleSortByMinOfRowElementsAscendingUsingDelegateTest()
        {
            int[][] array1 = new int[4][] { new int[] { -4, 0 }, new int[] { 10, 10, 12, -7 }, new int[] { 0, 0, 0, 0 }, new int[] { 19, 19, 20 } };
            int[][] sorted = new int[4][] { new int[] { 10, 10, 12, -7 }, new int[] { -4, 0 }, new int[] { 0, 0, 0, 0 }, new int[] { 19, 19, 20 } };
            var comparer = new AdapterForDelegate(new SortByMinAscending().Compare);
            BubbleSortWithDelegate(array1, comparer);
            CollectionAssert.AreEqual(sorted, array1);
        }

        [Test]
        public void BubbleSortBySumOfRowElementsDescendingTest()
        {
            int[][] array1 = new int[3][] { new int[] { 1, 2, 3, -8 }, new int[] { 5, -5, 12, -9 }, new int[] { 33, 22, -40, 10 } };
            int[][] sorted = new int[3][] { new int[] { 33, 22, -40, 10 }, new int[] { 5, -5, 12, -9 }, new int[] { 1, 2, 3, -8 } };
            BubbleSort(array1, new SortBySumDescending());
            CollectionAssert.AreEqual(sorted, array1);
        }

        [Test]
        public void BubbleSortBySumOfRowElementsDescendingUsingDelegateTest()
        {
            int[][] array1 = new int[3][] { new int[] { 1, 2, 3, -8 }, new int[] { 5, -5, 12, -9 }, new int[] { 33, 22, -40, 10 } };
            int[][] sorted = new int[3][] { new int[] { 33, 22, -40, 10 }, new int[] { 5, -5, 12, -9 }, new int[] { 1, 2, 3, -8 } };
            var comparer = new AdapterForDelegate(new SortBySumDescending().Compare);
            BubbleSortWithDelegate(array1, comparer);
            CollectionAssert.AreEqual(sorted, array1);
        }

        [Test]
        public void BubbleSortBySumOfRowElementsAscendingTest()
        {
            int[][] array1 = new int[4][] { new int[] { -4, 0 }, new int[] { 10, 10, 12, -7 }, new int[] { 0, 0, 0, 0 }, new int[] { 19, 19, 20 } };
            int[][] sorted = new int[4][] { new int[] { -4, 0 }, new int[] { 0, 0, 0, 0 }, new int[] { 10, 10, 12, -7 }, new int[] { 19, 19, 20 } };
            BubbleSort(array1, new SortBySumAscending());
            CollectionAssert.AreEqual(sorted, array1);
        }

        [Test]
        public void BubbleSortBySumOfRowElementsAscendingUsingDelegateTest()
        {
            int[][] array1 = new int[4][] { new int[] { -4, 0 }, new int[] { 10, 10, 12, -7 }, new int[] { 0, 0, 0, 0 }, new int[] { 19, 19, 20 } };
            int[][] sorted = new int[4][] { new int[] { -4, 0 }, new int[] { 0, 0, 0, 0 }, new int[] { 10, 10, 12, -7 }, new int[] { 19, 19, 20 } };
            var comparer = new AdapterForDelegate(new SortBySumAscending().Compare);
            BubbleSortWithDelegate(array1, comparer);
            CollectionAssert.AreEqual(sorted, array1);
        }
    }
}

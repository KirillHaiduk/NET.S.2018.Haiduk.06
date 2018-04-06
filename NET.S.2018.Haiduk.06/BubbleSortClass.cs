using System;
using System.Linq;

namespace NET.S._2018.Haiduk._06
{
    /// <summary>
    /// Class that contains methods for sorting jagged arrays using Bubble Sort algorythm
    /// </summary>
    public static class BubbleSortClass
    {
        public delegate int ArraySorter(int[] arrayA, int[] arrayB);

        #region Public Methods
        /// <summary>
        /// Method that sorts given array by ascending or descending of maximum elements of the rows using Bubble Sort algorythm
        /// </summary>
        /// <param name="array">Jagged unsorted array</param>
        /// <param name="sortByAscending">If sorting by ascending of maximum elements - true, if by descending - false</param>
        public static void BubbleSort(int[][] array, ArraySorter arraySorter)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"{nameof(array)} is empty.");
            }

            if (array.Length == 1)
            {
                return;
            }

            for (int j = 0; j < MaxRowLength(array); j++)
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (arraySorter(array[i], array[i + 1]) > 0)
                    {
                        Swap(ref array[i], ref array[i + 1]);
                    }
                }
            }
        }

        #region Sorting methods

        /// <summary>
        /// Method that compares 2 accepted arrays by their maximum row values ascending
        /// </summary>
        /// <param name="array1">First accepted array</param>
        /// <param name="array2">Second accepted array</param>
        /// <returns>Difference between 1st and 2nd array maximum</returns>
        public static int SortByMaxAscending(int[] array1, int[] array2)
        {
            if (array1 is null || array2 is null)
            {
                throw new ArgumentNullException();
            }

            return array1.Max() - array2.Max();
        }

        /// <summary>
        /// Method that compares 2 accepted arrays by their maximum row values desscending
        /// </summary>
        /// <param name="array1">First accepted array</param>
        /// <param name="array2">Second accepted array</param>
        /// <returns>Difference between 2nd and 1st array maximum</returns>
        public static int SortByMaxDescending(int[] array1, int[] array2)
        {
            if (array1 is null || array2 is null)
            {
                throw new ArgumentNullException();
            }

            return array2.Max() - array1.Max();
        }

        /// <summary>
        /// Method that compares 2 accepted arrays by their minimum row values ascending
        /// </summary>
        /// <param name="array1">First accepted array</param>
        /// <param name="array2">Second accepted array</param>
        /// <returns>Difference between 1st and 2nd array minimum</returns>
        public static int SortByMinAscending(int[] array1, int[] array2)
        {
            if (array1 is null || array2 is null)
            {
                throw new ArgumentNullException();
            }

            return array1.Min() - array2.Min();
        }

        /// <summary>
        /// Method that compares 2 accepted arrays by their minimum row values ascending
        /// </summary>
        /// <param name="array1">First accepted array</param>
        /// <param name="array2">Second accepted array</param>
        /// <returns>Difference between 2nd and 1st array minimum</returns>
        public static int SortByMinDescending(int[] array1, int[] array2)
        {
            if (array1 is null || array2 is null)
            {
                throw new ArgumentNullException();
            }

            return array2.Min() - array1.Min();
        }

        /// <summary>
        /// Method that compares 2 accepted arrays by sums of their elements ascending
        /// </summary>
        /// <param name="array1">First accepted array</param>
        /// <param name="array2">Second accepted array</param>
        /// <returns>Difference between 1st and 2nd array sums</returns>
        public static int SortBySumAscending(int[] array1, int[] array2)
        {
            if (array1 is null || array2 is null)
            {
                throw new ArgumentNullException();
            }

            return array1.Sum() - array2.Sum();
        }

        /// <summary>
        /// Method that compares 2 accepted arrays by sums of their elements descending
        /// </summary>
        /// <param name="array1">First accepted array</param>
        /// <param name="array2">Second accepted array</param>
        /// <returns>Difference between 2nd and 1st array sums</returns>
        public static int SortBySumDescending(int[] array1, int[] array2)
        {
            if (array1 is null || array2 is null)
            {
                throw new ArgumentNullException();
            }

            return array2.Sum() - array1.Sum();
        }

        #endregion
        #endregion

        #region Private Methods

        private static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
                
        private static int MaxRowLength(int[][] array)
        {
            int r = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Length > r)
                {
                    r = array[i].Length;
                }
            }

            return r;
        }        

        #endregion
    }
}

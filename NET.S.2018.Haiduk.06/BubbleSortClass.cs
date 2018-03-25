using System;

namespace NET.S._2018.Haiduk._06
{
    /// <summary>
    /// Class that contains methods for sorting jagged arrays using Bubble Sort algorythm
    /// </summary>
    public static class BubbleSortClass
    {
        #region Public Methods
        /// <summary>
        /// Method that sorts given array by ascending or descending of maximum elements of the rows using Bubble Sort algorythm
        /// </summary>
        /// <param name="array">Jagged unsorted array</param>
        /// <param name="sortByAscending">If sorting by ascending of maximum elements - true, if by descending - false</param>
        public static void BubbleSortByMaxOfRowElements(int[][] array, bool sortByAscending)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"{nameof(array)} is empty.");
            }

            if (array.Length == 1)
            {
                return;
            }
                        
            for (int i = 0; i < MaxRowLength(array); i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    for (int k = 0; k < array[j].Length - 1; k++)
                    {
                        if (array[j][k] < array[j][k + 1])
                        {
                            Swap(ref array[j][k], ref array[j][k + 1]);
                        }
                    }
                }
            }

            if (sortByAscending)
            {
                SortingByAscending(array);
            }
            else
            {
                SortingByDescending(array);
            }
        }

        /// <summary>
        /// Method that sorts given array by ascending or descending of minimum elements of the rows using Bubble Sort algorythm
        /// </summary>
        /// <param name="array">Jagged unsorted array</param>
        /// <param name="sortByAscending">If sorting by ascending of maximum elements - true, if by descending - false</param>
        public static void BubbleSortByMinOfRowElements(int[][] array, bool sortByAscending)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"{nameof(array)} is empty.");
            }

            if (array.Length == 1)
            {
                return;
            }
            
            for (int i = 0; i < MaxRowLength(array); i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    for (int k = 0; k < array[j].Length - 1; k++)
                    {
                        if (array[j][k] > array[j][k + 1])
                        {
                            Swap(ref array[j][k], ref array[j][k + 1]);
                        }
                    }
                }
            }

            if (sortByAscending)
            {
                SortingByAscending(array);
            }
            else
            {
                SortingByDescending(array);
            }
        }

        /// <summary>
        /// Method that sorts given array by ascending or descending of sums of elements of the rows using Bubble Sort algorythm
        /// </summary>
        /// <param name="array">Jagged unsorted array</param>
        /// <param name="sortByAscending">If sorting by ascending of maximum elements - true, if by descending - false</param>
        public static void BubbleSortBySumsOfElements(int[][] array, bool sortByAscending)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"{nameof(array)} is empty.");
            }

            if (array.Length == 1)
            {
                return;
            }

            int[] rowSums = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length - 1; j++)
                {
                    rowSums[i] += array[i][j];
                }
            }

            if (sortByAscending)
            {
                for (int i = 0; i < rowSums.Length - 1; i++)
                {
                    if (rowSums[i] > rowSums[i + 1])
                    {
                        Swap(ref rowSums[i], ref rowSums[i + 1]);
                        Swap(ref array[i], ref array[i + 1]);
                    }
                }
            }
            else
            {
                for (int i = 0; i < rowSums.Length - 1; i++)
                {
                    if (rowSums[i] < rowSums[i + 1])
                    {
                        Swap(ref rowSums[i], ref rowSums[i + 1]);
                        Swap(ref array[i], ref array[i + 1]);
                    }
                }
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <param name="b"></param>
        private static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        /// <summary>
        /// Method to calculate maximum length from arrays in jagged array
        /// </summary>
        /// <param name="array">Given jagged array</param>
        /// <returns>Maximum length of arrays in jagged array</returns>
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

        /// <summary>
        /// Method that sorts rows of jagged array by ascending of maximum or minimum elements of the rows
        /// </summary>
        /// <param name="array">Unsorted jagged array</param>
        private static void SortingByAscending(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j][0] > array[j + 1][0])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }
        }

        /// <summary>
        /// Method that sorts rows of jagged array by descending of maximum or minimum elements of the rows
        /// </summary>
        /// <param name="array">Unsorted jagged array</param>
        private static void SortingByDescending(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j][0] < array[j + 1][0])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }
        }
        #endregion
    }
}

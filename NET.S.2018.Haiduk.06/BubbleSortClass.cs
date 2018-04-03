﻿using System;
using System.Linq;

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
        public static void BubbleSort(int[][] array, IArrayComparer comparer)
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
                    if (comparer.Compare(array[i], array[i + 1]) > 0)
                    {
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
        #endregion
    }
}

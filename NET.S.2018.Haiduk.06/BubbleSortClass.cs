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
        /// Method that sorts given array by given criterion (instance of IArrayComparer type) using Bubble Sort algorythm
        /// </summary>
        /// <param name="array">Jagged unsorted array</param>
        /// <param name="comparer">Criterion of sorting</param>
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

        /// <summary>
        /// Method that sorts given array by given criterion (instance of AdapterForDelegate class) using Bubble Sort algorythm
        /// </summary>
        /// <param name="array">Jagged unsorted array</param>
        /// <param name="adapterForDelegate">Instance of AdapterForDelegate class that incapsulates delegate as sorting type</param>
        public static void BubbleSortWithDelegate(int[][] array, AdapterForDelegate adapterForDelegate)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"{nameof(array)} is empty.");
            }

            if (array.Length == 1)
            {
                return;
            }

            if (adapterForDelegate is null)
            {
                throw new ArgumentNullException(nameof(adapterForDelegate));
            }
                        
            BubbleSort(array, adapterForDelegate);
        }
        
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

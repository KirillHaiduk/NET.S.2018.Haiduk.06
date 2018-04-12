using System;
using System.Collections.Generic;

namespace NET.S._2018.Haiduk._06
{
    /// <summary>
    /// Class for adapting delegate to interface
    /// </summary>
    public class AdapterForDelegate : IArrayComparer
    {
        private Func<int[], int[], int> comparerDelegate;

        /// <summary>
        /// Constructor for adapter instance
        /// </summary>
        /// <param name="comparer">Accepted delegate</param>
        public AdapterForDelegate(Func<int[], int[], int> comparer)
        {
            comparerDelegate = comparer;
        }

        /// <summary>
        /// Implementation of interface <see cref="IComparer"/> 
        /// </summary>
        /// <param name="array1">1st accepted array</param>
        /// <param name="array2">2nd accepted array</param>
        /// <returns>Positive integer if 1st is more than 2nd by comparation criterion, 0 if they are equivalent; otherwise, negative integer</returns>
        public int Compare(int[] array1, int[] array2)
        {
            return comparerDelegate(array1, array2);
        }
    }
}

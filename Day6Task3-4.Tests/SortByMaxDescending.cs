using System;
using System.Linq;

namespace NET.S._2018.Haiduk._06
{
    public class SortByMaxDescending : IArrayComparer
    {
        public int Compare(int[] array1, int[] array2)
        {
            if (array1 is null || array2 is null)
            {
                throw new ArgumentNullException();
            }

            return array2.Max() - array1.Max();
        }
    }
}

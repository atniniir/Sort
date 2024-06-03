//реализация алгоритмов сортировки выбором, вставкой, Шелла
using System;
using System.Collections.Generic;

namespace SortSpace
{
    public static class SortLevel
    {
        public static void SelectionSortStep(int[] array, int i)
        {
            if (i >= 0 && i < array.Length && array != null)
            {
                int imin = i;
                for (int k = i + 1; k < array.Length; k++)
                {
                    if (array[k] < array[imin])
                    {
                        imin = k;
                    }
                }
                int temp = array[i];
                array[i] = array[imin];
                array[imin] = temp;
            }
        }

        public static void InsertionSortStep(int[] array, int step, int i)
        {
            if (i >= 0 && i < array.Length && array != null)
            {
                    int iteration = i;
                    int k = 0;
                    int[] temp = new int[(array.Length - i - 1) / step + 1];
                    while (iteration < array.Length)
                    {
                        temp[k++] = (array[iteration]);
                    
                        iteration += step;
                    }
               
                for (int n = 1; n < temp.Length; n++)
                    {
                    int ins = n;
                    for (int m = n - 1; m >= 0; m--)
                    {
                        if (temp[n] < temp[m])
                        {
                            ins = m;
                        }
                    }
                    int tempvar = temp[n];
                    for (int m = n; m > ins; m--)
                    {
                        temp[m] = temp[m - 1];
                    }
                    temp[ins] = tempvar;
                    }

                iteration = i;
                    for (int n = 0; n < temp.Length; n++)
                    {
                        array[iteration] = temp[n];
                        iteration += step;
                    } 
            }
        }

            public static List<int> KnuthSequence(int array_size)
        {
            List<int> seq = new List<int>();
            if (array_size > 0)
            {
                int n = 1;
                if (array_size == 1) { seq.Add(n); }
                while (n < array_size)
                {
                    seq.Add(n);
                    n = 3 * n + 1;
                }

                for (int i = 0; i < seq.Count / 2; i++)
                {
                    int temp = seq[i];
                    seq[i] = seq[seq.Count - 1 - i];
                    seq[seq.Count - 1 - i] = temp;
                }
            }
            return seq;
        }
        
           public static void ShellSort(int[] array)
        {
            List<int> seq = KnuthSequence(array.Length);
            for (int i = 0; i < seq.Count; i++)
            {
                for (int j = 0; j < array.Length / seq[i] + 1; j++)
                {
                    InsertionSortStep(array, seq[i], j);
                }
            }
        }
    }
}

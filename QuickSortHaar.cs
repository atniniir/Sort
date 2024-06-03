//реализация алгоритма быстрой сортировки Хаара
using System;
using System.Collections.Generic;

namespace SortSpace
{
    public static class SortLevel
    {
        public static int ArrayChunk(int[] M)
        {
            int pos = M.Length / 2;
            int N = M[pos];
            int i1 = 0;
            int i2 = M.Length - 1;

            while (i1 <= i2 )
            {
                N = M[pos];
                while (M[i1] < N) i1++;
                while (M[i2] > N) i2--;
                if (i1 == i2 - 1 && M[i1] > M[i2])
                {
                    int temp = M[i1];
                    M[i1] = M[i2];
                    M[i2] = temp;
                    ArrayChunk(M);
                }
                else if (i1 == i2 || (i1 == i2 - 1 && M[i1] < M[i2])) return pos;
                else
                {
                    if (i1 == pos) pos = i2;
                    else if (i2 == pos) pos = i1;
                    int temp1 = M[i1]; 
                    M[i1] = M[i2];
                    M[i2] = temp1;
                }
            }
            return pos;
        }
        
        public static int ArrayChunkPartition(int[] array, int start, int end)
        {
            int marker = start;
            for (int i = start; i <= end; i++)
            {
                if (array[i] <= array[end])
                {
                    int temp = array[marker]; // swap
                    array[marker] = array[i];
                    array[i] = temp;
                    marker += 1;
                }
            }
            return marker - 1;
        }
        
        public static void QuickSort(int[] array, int left, int right)
        {
            if (left >= right)
            {
                return;
            }
            else
            {
                int N = ArrayChunkPartition(array, left, right);
                QuickSort(array, left, N - 1);
                QuickSort(array, N + 1, right);
            }
        }
    }
}

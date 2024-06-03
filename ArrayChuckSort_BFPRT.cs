//реализация алгоритма разбиения массива + BFPRT-алгоритм
using System;
using System.Collections.Generic;

namespace SortSpace
{
    public static class SortLevel
    {
        public static List<int> KthOrderStatisticsStep(int[] Array, int L, int R, int k)
        {
            List<int> pair = new List<int>();
            int N = ArrayChunkTwo(Array, L, R);

            if (N == k)
            {
                pair.Add(L);
                pair.Add(R);
            }
            else if (N < k)
            {
                pair.Add(N + 1);
                pair.Add(R);
            }
            else
            {
                pair.Add(L);
                pair.Add(N - 1);
            }
            return pair;
        }

        public static int ArrayChunkTwo(int[] M, int left, int right)
        {
            int pos = (right + left) / 2;
            int N = M[pos];
            int i1 = left;
            int i2 = right;

            while (i1 <= i2)
            {
                N = M[pos];
                while (M[i1] < N && i1 <= right) i1++;
                while (M[i2] > N && i2 >= left) i2--;
                if (i1 == i2 - 1 && M[i1] > M[i2])
                {
                    int temp = M[i1];
                    M[i1] = M[i2];
                    M[i2] = temp;
                    ArrayChunkTwo(M, left, right);
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
    }
}

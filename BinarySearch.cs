//реализация алгоритма двоичного поиска
using System;
using System.Collections.Generic;

namespace SortSpace
{
    public class BinarySearch
    {
        public int Left;
        public int Right;
        int[] arr;
        public int find;
        public BinarySearch(int[] _arr)
        {
            find = 0;
            Left = 0;
            Right = _arr.Length - 1;
            arr = new int[_arr.Length];
            Array.Copy(_arr, arr, _arr.Length);
        }

 public void Step (int N)
        {
            if (find == 0)
            {
                int Center = (Left + Right) / 2;
                if (arr[Center] == N)
                {
                    find = 1;
                }
                else
                {
                    if (N < arr[Center])
                    {
                        Right = Center - 1;
                    }
                    else
                    {
                        Left = Center + 1;
                    }
                    Center = (Left + Right) / 2;
                    if (arr[Center] == N)
                    {
                        find = 1;
                    }
                    else if ( Center + 1 < arr.Length && arr[Center + 1] == N)
                    {
                        find = 1;
                    }
                    else if (Left == Right || Right < 0)
                    //else if (Left == Right || (Right - Left <= 1 && arr[Center] != N && arr[Center + 1] != N) || Right < 0)
                    {
                        find = -1;
                    }
                }
            }
        }

        public int GetResult()
        {
            return find;
        }
    }
}

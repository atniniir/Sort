//реализация алгоритма быстрой сортировки Хаара с хвостовой рекурсией
using System;
using System.Collections.Generic;

namespace SortSpace
{
    public class Stack<T>
    {
        public T[] array; //дин. массив для хранения эл-в
        public int count; //текущее кол-во эл-в в стеке
        public Stack()
        {
            // инициализация внутреннего хранилища стека
            count = 0;
            array = new T[0];
        }

        public int Size()
        {
            // размер текущего стека		  
            return count;
        }

        public T Pop()
        {
            //удаление элемента
            //если стек не пустой - пересоздаём массив без последнего эл-та, выдаём удалённый эл-т
            if (count > 0)
            {
                T val = array[count - 1];

                T[] temp = new T[count - 1];
                Array.Copy(array, temp, count - 1);
                array = new T[count - 1];
                Array.Copy(temp, array, count - 1);
                count--;
                return val;
            }
            else return default(T); // null, если стек пустой
        }

        public void Push(T val)
        {
            //вставка элемента
            //копируем массив, добавляем в конец
            T[] temp = new T[count];
            Array.Copy(array, temp, count);
            array = new T[count + 1];
            Array.Copy(temp, array, count);
            array[count] = val;
            count++;
        }

        public T Peek()
        {
            if (count > 0)
            {
                T val = array[count - 1];
                return val;
            }
            else return default(T); // null, если стек пустой
        }

    }

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

        public static int ArrayChunkTwo(int[] M, int left, int right)
        {
            int pos = (right - left) / 2;
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

        public static void QuickSortTailOptimization(int[] array, int left, int right)
        {
            Stack<int> high = new Stack<int>();
            Stack<int> low = new Stack<int>();
            high.Push(right);
            low.Push(left);
            while (high.Size() > 0 && low.Size() > 0)
            {
                int l = low.Pop();
                int r = high.Pop();
                if (l >= r) continue;
                int N = ArrayChunkPartition(array, l, r);
                    low.Push(l);
                    high.Push(N - 1);
                    low.Push(N + 1);
                    high.Push(r);
            }
        }
    }
}

//реализация алгоритма сортировки ksort
using System;
using System.Collections.Generic;

namespace SortSpace
{
    public class ksort
    {
        public string[] items;

        public ksort()
        {
            items = new string[800];
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = null;
            }
        }

        public int index(string s)
        {
            if (s.Length == 3)
            {
                int s0 = s[0];
                int s1 = (int)Char.GetNumericValue(s[1]);
                int s2 = (int)Char.GetNumericValue(s[2]);
                if (s0 > 96 && s0 < 105 && s1 != -1 && s2 != -1)
                {
                    return (s0 - 97) * 100 + s1 * 10 + s2;
                }
            }
            return -1;
        }

        public bool add(string s)
        {
            int ind = index(s);
            if (ind != -1)
            {
                items[ind] = s;
                return true;
            }
            return false;
        }

        public void showoff()
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] != null) Console.Write(items[i] + " ");
            }
        }

    }
}

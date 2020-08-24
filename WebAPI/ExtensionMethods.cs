using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
    public static class ExtensionMethods
    {
        public static List<T> Swap<T>(this List<T> list, int indexA, int indexB)
        {
            T tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
            return list;
        }

        public static List<int> BubbleSort(this List<int> input)
        {
            int limit = input.Count;
            int lastIndex;
            do
            {
                lastIndex = 0;
                for (int i = 0; i < limit; i++)
                {
                    if (i + 1 < input.Count)
                    {
                        if (input[i + 1] < input[i])
                        {
                            input = input.Swap(i, i + 1);
                            lastIndex = i;
                        }
                    }
                }
                limit = lastIndex;
            } while (limit > 0);
            return input;
        }
    }
}

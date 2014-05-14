using System;

namespace ConsoleApplication1
{
    public static class Sort
    {
        static int count = 0;
        public static void QuickSort(int[] s, int l, int r)
        {
            if (l < r)
            {
                int i = l, j = r, x = s[l];
                Console.WriteLine(string.Format("i={0}, j={1}, x={2}", i, j, x));
                while (i < j)
                {
                    while (i < j && s[j] >= x) // 从右向左找第一个小于x的数  
                        j--;
                    if (i < j)
                    {
                        s[i++] = s[j];
                        Console.WriteLine("right.i={0}, j={1}", i, j);
                        Console.WriteLine(string.Join(",", s));
                    }

                    while (i < j && s[i] < x) // 从左向右找第一个大于等于x的数  
                        i++;
                    if (i < j)
                    {
                        s[j--] = s[i];
                        Console.WriteLine("left.i={0}, j={1}", i, j);
                        Console.WriteLine(string.Join(",", s));
                    }
                }
                s[i] = x;
                Console.WriteLine(string.Join(",", s));
                Console.WriteLine(++count);
                Console.WriteLine(Environment.NewLine);
                QuickSort(s, l, i - 1);
                QuickSort(s, i + 1, r);
            }
        }
    }
}

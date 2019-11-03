using System;
using System.Collections.Generic;
using System.IO;

namespace Task6_3
{
    class Program
    {
        static bool IsSerchTree(string[][] list, int index)
        {
            if (index == -1)
                return true;
            int count = int.Parse(list[index][0]);
            int leftChildIndex = int.Parse(list[index][1]);
            int rightChildIndex = int.Parse(list[index][2]);

            if (IsSerchTree(list, int.Parse(list[index][1]) - 1) && IsSerchTree(list, int.Parse(list[index][2]) - 1))
            {
                if (leftChildIndex > 0 && rightChildIndex > 0)
                {
                    if (count > int.Parse(list[leftChildIndex - 1][0]) && count < int.Parse(list[rightChildIndex - 1][0]))
                        return true;
                    else
                        return false;
                }
                else if (leftChildIndex != 0)
                {
                    if (count > int.Parse(list[leftChildIndex - 1][0]))
                        return true;
                    else
                        return false;
                }
                else if (rightChildIndex != 0)
                {
                    if (count < int.Parse(list[rightChildIndex - 1][0]))
                        return true;
                    else
                        return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
        static void Main(string[] args)
        {
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                using (StreamWriter sw = new StreamWriter("output.txt", false))
                {
                    int n = int.Parse(sr.ReadLine());
                    if (n == 0)
                    {
                        sw.WriteLine("YES");
                    }
                    else
                    {
                        string[][] list = new string[n][];
                        for (int i = 0; i < n; i++)
                        {
                            list[i] = sr.ReadLine().Split();
                        }
                        bool flag = IsSerchTree(list, 0);
                        if (flag)
                            sw.WriteLine("YES");
                        else
                            sw.WriteLine("NO");
                    }
                }
            }
        }
    }
}

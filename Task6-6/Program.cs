using System;
using System.Collections.Generic;
using System.IO;

namespace Task6_3
{
    class Program
    {
        enum Direction
        {
            right,
            left
        }

        static bool CheckSubtree(int[,] list, int index0, Direction direction, Stack<int> stack)
        {
            int index;
            if (direction == Direction.left)
                index = list[index0, 1];
            else
                index = list[index0, 2];

            if (index != -1)
                stack.Push(index);

            while (stack.Count != 0)
            {
                index = stack.Pop();
                if (direction == Direction.left)
                {
                    if (list[index, 0] > list[index0, 0])
                        return false;
                }
                else
                {
                    if (list[index, 0] < list[index0, 0])
                        return false;
                }
                if (list[index, 2] != -1)
                    stack.Push(list[index, 2]);
                if (list[index, 1] != -1)
                    stack.Push(list[index, 1]);
            }
            return true;
        }
        static bool IsSerchTree(int[,] list)
        {
            if (list[0, 1] == -1 && list[0, 2] == -1)
            {
                return true;
            }
            int index0 = 0;
            Stack<int> stack = new Stack<int>();
            Stack<int> stackOut = new Stack<int>();
            stackOut.Push(index0);
            while (stackOut.Count != 0)
            {
                index0 = stackOut.Pop();
                if (!CheckSubtree(list, index0, Direction.left, stack) || !CheckSubtree(list, index0, Direction.right, stack))
                    return false;
                if (list[index0, 2] != -1)
                    stackOut.Push(list[index0, 2]);
                if (list[index0, 1] != -1)
                    stackOut.Push(list[index0, 1]);
            }
            return true;
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
                        int[,] list = new int[n, 3];
                        for (int i = 0; i < n; i++)
                        {
                            string[] strs = sr.ReadLine().Split();

                            for (int j = 0; j < 3; j++)
                            {
                                list[i, j] = int.Parse(strs[j]);
                                if (j == 1 || j == 2)
                                {
                                    list[i, j] -= 1;
                                }
                            }
                        }

                        if (IsSerchTree(list))
                        {
                            sw.WriteLine("YES");
                        }
                        else
                        {
                            sw.WriteLine("NO");
                        }
                    }
                }
            }
        }
    }
}

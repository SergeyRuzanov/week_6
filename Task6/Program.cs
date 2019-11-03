using System;
using System.IO;

namespace Task6
{
    class Program
    {
        static void Main(string[] args)
        {

            using (StreamReader sr = new StreamReader("input.txt"))
            {
                using (StreamWriter sw = new StreamWriter("output.txt", false))
                {
                    int n = int.Parse(sr.ReadLine());
                    string[] masStr = sr.ReadLine().Split();
                    int[] mas = new int[n];
                    for (int i = 0; i < n; i++)
                    {
                        mas[i] = int.Parse(masStr[i]);
                    }
                    int n2 = int.Parse(sr.ReadLine());
                    string[] masStr2 = sr.ReadLine().Split();
                    int[] mas2 = new int[n2];
                    for (int i = 0; i < n2; i++)
                    {
                        mas2[i] = int.Parse(masStr2[i]);
                    }

                    for (int i = 0; i < n2; i++)
                    {
                        int l = -1;
                        int r = n;
                        int firstIndex;
                        int lastIndex;
                        while (r > l + 1)
                        {
                            int m = (l + r) / 2;
                            if (mas[m] < mas2[i])
                                l = m;
                            else
                                r = m;
                        }

                        if (r < n && mas[r] == mas2[i])
                        {
                            firstIndex = r;
                        }
                        else
                        {
                            sw.WriteLine("-1 -1");
                            continue;
                        }

                        l = -1;
                        r = n;
                        while (l < r - 1)
                        {
                            int m = (l + r) / 2;
                            if (mas[m] <= mas2[i])
                                l = m;
                            else
                                r = m;
                        }

                        if (l > -1 && mas[l] == mas2[i])
                        {
                            lastIndex = l;
                        }
                        else
                        {
                            sw.WriteLine("-1 -1");
                            continue;
                        }

                        sw.WriteLine($"{firstIndex + 1} {lastIndex + 1}");

                    }
                }
            }

        }
    }
}

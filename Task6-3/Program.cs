using System.IO;
using System.Linq;

namespace Task6_3
{
    class Program
    {
        static int Hight(string[][] list, int[] hight)
        {
            hight[0] = 1;
            for (int i = 0; i < list.Length; i++)
            {
                int left = int.Parse(list[i][1]) - 1;
                int right = int.Parse(list[i][2]) - 1;
                if (left >= 0)
                    hight[left] = hight[i] + 1;
                if (right >= 0)
                    hight[right] = hight[i] + 1;
            }
            return hight.Max();
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
                        sw.WriteLine("0");
                    }
                    else
                    {
                        int[] hight = new int[n];
                        string[][] list = new string[n][];
                        for (int i = 0; i < n; i++)
                        {
                            list[i] = sr.ReadLine().Split();
                        }
                        sw.WriteLine(Hight(list, hight));
                    }
                }
            }
        }
    }
}

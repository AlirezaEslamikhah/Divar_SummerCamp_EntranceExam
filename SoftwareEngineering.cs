using System;
using System.Collections.Generic;
using System.Linq;

namespace SummerCamp
{
    class Program
    {
        static void Main212(string[] args)
        {
            int m = int.Parse(Console.ReadLine());
            int[,] matrix = new int[m, m];
            List<int> numbers = new List<int>();
            for (int i = 0; i < m; i++)
            {
                string[] input = Console.ReadLine().Split();
                for (int j = 0; j < m; j++)
                {
                    //matrix[i, j] = int.Parse(Console.ReadLine());
                    matrix[i, j] = int.Parse(input[j]);
                    if (i==j && ((matrix[i,j] - 1)% 3 == 0) || matrix[i, j] == 1)
                    {
                        numbers.Add(matrix[i, j]);
                    }
                }
            }
            int v = m - 1;
            for (int i = 0; i < m; i++)
            {
                //for (int j = m-1; j >= 0; j--)
                //{
                //    if ((((matrix[i,j] -1) % 3) == 0) && i+j == (m-1))
                //    {
                //        numbers.Add(matrix[i, j]);
                //    }
                //}
                if (((matrix[i, v] - 1) % 3) == 0)
                {
                    numbers.Add(matrix[i, v]);
                }
                v--;
            }
            Console.WriteLine(numbers.Sum());
        }
    }
}

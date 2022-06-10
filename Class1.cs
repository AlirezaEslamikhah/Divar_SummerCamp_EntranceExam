using System;
using System.Collections.Generic;
using System.Text;

namespace SummerCamp
{
    class Class1
    {
        static void Main3(string[] args)
        {
            string input = (Console.ReadLine());
            char c = ' ';
            string result = "";
            int counter = 1;
            c = input[0];
            //result += c;
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] == c)
                {
                    counter++;
                    //result += c;
                }
                else
                {
                    result += counter.ToString();
                    result += c;
                    counter = 1;
                    c = input[i];
                }
            }
            result += counter.ToString();
            result += c;

            Console.WriteLine(result);
        }

    }
}

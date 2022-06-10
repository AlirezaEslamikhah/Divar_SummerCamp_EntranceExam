using System;
using System.Collections.Generic;
using System.Text;

namespace SummerCamp
{
    class Class2
    {
        static void Main4(string[] args)
        {
            string input = Console.ReadLine();
            string twodigit = "";
            char first = ' ';
            char second = ' ';
            int counter = 0;
            List<int> result = new List<int>();
            for (int i = 0; i < input.Length-1; i++)
            {
                if (char.IsDigit(input[counter]) && char.IsDigit(input[counter+1]))
                {
                    twodigit += input[counter];
                    twodigit += input[counter+1];
                    int num = int.Parse(twodigit);
                    bool flag = true;
                    counter++;
                    for(int j = 2;j <num;j++)
                    {
                        if ((num % j) == 0)
                        {
                            flag = false;
                            break;
                        }
                    }
                    if(flag && num != 1 && num != 0)
                    {
                        result.Add( num);
                    }
                    twodigit = "";

                }
                else
                {
                    counter++;

                }
            }
            for (int i = 0; i < result.Count; i++)
            {
                Console.WriteLine(result[i]);
            }
            


        }

    }
}

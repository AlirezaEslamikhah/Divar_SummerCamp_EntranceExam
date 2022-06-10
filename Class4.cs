using System;
using System.Collections.Generic;
using System.Text;

namespace SummerCamp
{
    class capsules
    {
        public int duration;
        public int az;
        public int ta;

        public capsules(int duration, int az, int ta)
        {
            this.duration = duration;
            this.az = az;
            this.ta = ta;
        }
    }
    class sesseion
    {
        public int duaration;
        public int from;
        public int to;
        public int id;

        public sesseion(int duaration, int from, int to, int id)
        {
            this.duaration = duaration;
            this.from = from;
            this.to = to;
            this.id = id;
        }
    }
    class Class4
    {
        static void Main(string[] args)
        {
            List<capsules> capsules = new List<capsules>();
            List<sesseion> sesseions = new List<sesseion>();
            //input(capsules, sesseions);
            //question1(capsules, sesseions);
            //question2(sesseions);
            Dictionary<string, List<Tuple<int, int,bool>>> hash = new Dictionary<string, List<Tuple<int, int,bool>>>();
            Dictionary<string, bool[]> space = new Dictionary<string, bool[]>();
            hash.Add("MONDAY", new List<Tuple<int, int,bool>>());
            hash.Add("TUESDAY", new List<Tuple<int, int,bool>>());
            hash.Add("WEDNESDAY", new List<Tuple<int, int,bool>>());
            hash.Add("THURSDAY", new List<Tuple<int, int,bool>>());
            hash.Add("FRIDAY", new List<Tuple<int, int,bool>>());
            hash.Add("SATURDAY", new List<Tuple<int, int,bool>>());
            hash.Add("SUNDAY", new List<Tuple<int, int,bool>>());


            space.Add("MONDAY", new bool[32400000]);
            space.Add("TUESDAY", new bool[32400000]);
            space.Add("WEDNESDAY", new bool[32400000]);
            space.Add("THURSDAY", new bool[32400000]);
            space.Add("FRIDAY", new bool[32400000]);
            space.Add("SATURDAY", new bool[32400000]);
            space.Add("SUNDAY", new bool[32400000]);

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string id = Console.ReadLine();
                string day = Console.ReadLine();
                hash[day].Add(new Tuple<int, int, bool>(0, 0, false));

                int m = int.Parse(Console.ReadLine());
                for (int j = 0; j < m; j++)
                {
                    string[] input = Console.ReadLine().Split();
                    if (input[1] == day)
                    {
                        hash[input[1]].Add(new Tuple<int, int,bool>(int.Parse(input[2]), int.Parse(input[3]),false));

                    }
                    else
                    {
                        hash[input[1]].Add(new Tuple<int, int, bool>(int.Parse(input[2]), int.Parse(input[3]), true));

                    }
                    for (int k = int.Parse(input[2]); k < int.Parse(input[3]); k++)
                    {
                        space[input[1]][k] = true;
                    }
                }
            }
            string[] temp = Console.ReadLine().Split();
            int given_duration = int.Parse(temp[1]);
            foreach (var item in hash)
            {
                if (item.Value.Count != 0 && (item.Value[0].Item3 == true && item.Value[1].Item3 == true))
                {
                    int sum = 0;
                    int start = 0;
                    int end = 0;
                    for (int i = 0; i < 400000; i++)
                    {
                        
                        if (!space[item.Key][i])
                        {
                            sum++;
                            end++;
                            if (sum > given_duration)
                            {
                                Console.WriteLine($"{item.Key} {start} {end-1}");
                                return;
                            }
                        }
                        else
                        {
                            //start++;
                            start = end;
                            end++;
                            sum = 0;
                        }
                        
                    }
                }
            }

            
            
            



        }

        private static void question2(List<sesseion> sesseions)
        {
            int m = int.Parse(Console.ReadLine());
            int result = 0;
            for (int i = 0; i < m; i++)
            {
                string[] v = Console.ReadLine().Split();
                int f = int.Parse(v[1]);
                int t = int.Parse(v[2]);
                for (int j = 0; j < sesseions.Count; j++)
                {
                    if ((f > sesseions[j].from && f < sesseions[j].to) || (sesseions[j].from > f && sesseions[j].from < t))
                    {
                        int w = Math.Max(sesseions[j].from, f);
                        int q = Math.Min(sesseions[j].to, t);
                        result += Math.Abs(q - w);
                    }
                }

            }
            Console.WriteLine(result);
        }

        private static void input(List<capsules> capsules, List<sesseion> sesseions)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                sesseion a = new sesseion((int.Parse(input[2]) - int.Parse(input[1])), int.Parse(input[1]), int.Parse(input[2]), int.Parse(input[0]));
                sesseions.Add(a);
                if (i != 0)
                {
                    capsules b = new capsules(sesseions[i].from - sesseions[i - 1].to, sesseions[i - 1].to, sesseions[i].from);
                    capsules.Add(b);
                }
            }
        }

        private static void question1(List<capsules> capsules, List<sesseion> sesseions)
        {
            string[] input2 = Console.ReadLine().Split();
            int given_duration = int.Parse(input2[1]);
            int result1 = 0;
            int result2 = 0;
            for (int k = 0; k < capsules.Count; k++)
            {
                if (given_duration < capsules[k].duration)
                {
                    result1 = capsules[k].az + 1;
                    result2 = result1 + given_duration;
                    break;
                }
            }
            if(given_duration < sesseions[0].from)
            {
                Console.Write(0);
                Console.Write(" ");
                Console.Write(given_duration);
                return;
            }
            if (result2 == 0)
            {
                Console.Write(-1);
                return;
            }
            //Console.WriteLine($"{result1} {result2}");
            Console.Write(result1);
            Console.Write(" ");
            Console.Write(result2);
        }
    }
}

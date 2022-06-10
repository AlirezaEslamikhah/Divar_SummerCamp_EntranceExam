using System;
using System.Collections.Generic;
namespace SummerCamp
{
    class node
    {

        public string value;
        public int number;
        public bool visited;
        public int answer;
        public node(string value, int number, bool visited)
        {
            this.value = value;
            this.number = number;
            this.visited = visited;
        }
    }
    class Class3
    {
        public static int rows;
        public static int columns;
        static void Main111(string[] args)
        {
            int counter = 0;
            List<node> mm = new List<node>();
            string[] two = Console.ReadLine().Split();
            rows = int.Parse(two[0]);
            columns = rows;
            for (int i = 0; i < rows; i++)
            {
                string[] tmp = (Console.ReadLine().Split());
                for (int j = 0; j < tmp.Length; j++)
                {
                    node n = new node(tmp[j], counter, false);
                    counter++;
                    mm.Add(n);
                }
            }
            //solve(mm,0);
            for (int i = 0; i < rows * columns; i++)
            {
                if (mm[i].value == "1")
                {
                    int ans = solve(mm, i);
                    //false_visit(mm);

                    mm[i].answer = ans;
                    cnt = 0;
                }
            }
            int max = mm[0].answer;
            for (int i = 0; i < rows * columns; i++)
            {

                if (mm[i].answer > max)
                {
                    max = mm[i].answer;
                }
            }
            Console.WriteLine(max);

        }
        public static int cnt;
        private static int solve(List<node> mm, int v)
        {
            if (mm[v].visited == false)
            {
                cnt++;

            }
            mm[v].visited = true;
            List<int> neighbors = new List<int>();
            neighbors = set_neighbors(mm, v);
            if (neighbors.Count == 0)
            {
                return cnt;
            }
            for (int i = 0; i < neighbors.Count; i++)
            {
                solve(mm, neighbors[i]);
            }
            return cnt;
        }

        //private static void false_visit(List<node> mm)
        //{
        //    for (int i = 0; i < mm.Count; i++)
        //    {
        //        if (mm[i].value != '1')
        //        {
        //            mm[i].visited = false;
        //        }
        //    }
        //}

        private static List<int> set_neighbors(List<node> mm, int v)
        {
            int left;
            int right;
            int up;
            int down;
            List<int> tmp_neighbors = new List<int>();
            if ((v + 1) % columns == 0)
            {

            }
            else
            {
                right = v + 1;
                if (mm[right].visited == false && mm[right].value == "1")
                {
                    tmp_neighbors.Add(right);

                }
            }
            if ((v /*- 1*/) % columns == 0 || v == 0)
            {

            }
            else
            {
                left = v - 1;
                if (mm[left].visited == false && mm[left].value == "1")
                {
                    tmp_neighbors.Add(left);
                }
            }
            if (v < columns)
            {

            }
            else
            {
                up = v - columns;
                if (mm[up].visited == false && mm[up].value == "1")
                {
                    tmp_neighbors.Add(up);
                }
            }
            if (v >= (rows * columns) - columns)
            {

            }
            else
            {
                down = v + columns;
                if (mm[down].visited == false && mm[down].value == "1")
                {
                    tmp_neighbors.Add(down);
                }
            }
            return tmp_neighbors;
        }
    }
}

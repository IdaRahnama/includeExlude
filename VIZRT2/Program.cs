using System;

namespace Vizrt
{
    class Intervals
    {
        public int begin;
        public int end;
        public Intervals(int b, int e)
        {
            this.begin = b;
            this.end = e;
        }
        public Intervals[] Overlap(Intervals[] inc, Intervals[] ex)
        {

            Intervals[] temp = new Intervals[4];
            temp[0] = new Intervals(0, 0);
            temp[1] = new Intervals(0, 0);
            temp[2] = new Intervals(0, 0);
            temp[3] = new Intervals(0, 0);

            int k = 0;
            for (int i = 0; i < ex.Length; i++)
            {
                for (int j = 0; j < inc.Length; j++)
                {
                    Boolean t = ((ex[i].begin) > (inc[j].begin)) && ((ex[i].end) < (inc[j].end));

                    if (t)
                    {

                        temp[k].begin = inc[j].begin;
                        temp[k].end = ex[i].begin - 1;
                        k++;
                        temp[k].begin = ex[i].end + 1;
                        temp[k].end = inc[j].end;
                        k++;
                    }
                    Boolean x = ((ex[i].begin) >= (inc[j].begin)) && ((ex[i].end) >= (inc[j].end) && (ex[i].begin <= inc[j].end));

                    if (x)
                    {
                        temp[k].begin = inc[j].begin;
                        temp[k].end = ex[i].begin - 1;
                        k++;
                    }
                    Boolean y = ((ex[i].begin) <= (inc[j].begin)) && ((ex[i].end) <= (inc[j].end) && (ex[i].end >= inc[j].begin));

                    if (y)
                    {
                        temp[k].begin = ex[i].end + 1;
                        temp[k].end = inc[j].end;
                        k++;
                    }

                }
            }
            return temp;
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            Intervals[] include = new Intervals[3];
            Intervals[] exclude = new Intervals[2];
            Intervals n = new Intervals(0, 0);
            Intervals[] result = new Intervals[4];
            include[0] = new Intervals(10, 100);
            include[1] = new Intervals(200, 300);
            include[2] = new Intervals(400, 500);
            exclude[0] = new Intervals(95, 200);
            exclude[1] = new Intervals(410, 420);
            result = n.Overlap(include, exclude);
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("{0} {1}", result[i].begin, result[i].end);

            }

        }

    }
}

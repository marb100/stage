using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestStage
{
    class Program
    {
        static void Main(string[] args)
        {
            string hallo = string.Format("{0:e}", 1,2e2);
            int ha = Convert.ToInt32(hallo);
            Console.WriteLine(ha);
        }


        public void opdrachtFizzBuzz()
        {
            for (int i = 1; i < 31; i++)
            {
                if (i % 3 == 0 && i % 5 == 0) Console.WriteLine("fizzbuzz");
                else if (i % 3 == 0) Console.WriteLine("fizz");
                else if (i % 5 == 0) Console.WriteLine("buzz");
                else Console.WriteLine(i);
            }
        }

        public static void Opdracht3()
        {
            IEnumerable<int> numberEnum = RandomNumbers();
            var q = numberEnum.GroupBy(x => x)
            .Select(g => new { Value = g.Key, Count = g.Count() })
            .OrderByDescending(x => x.Value);

            foreach (var x in q)
            {
                Console.WriteLine(x.Value + " : " + x.Count);
            }
        }

        public static void Opdracht4()
        {
            IEnumerable<int> numberEnum = RandomNumbers();
            var q = numberEnum.GroupBy(x => x)
            .Select(g => new { Value = g.Key, Count = g.Count() })
            .OrderByDescending(x => x.Count);
            foreach (var x in q)
            {
                String numberJson = JsonConvert.SerializeObject(new NumberModel(x.Value, x.Count));
                Console.WriteLine(numberJson);
            }


        }

        public static void Opdracht5(int m, int n)
        {
            if (m <= 3 && n <= 9)
            {
                int value = Ackermanns(m, n);
                Console.WriteLine(value);
            }
            else
            {
                Console.WriteLine("this method wil not go further as m = 3 and n = 9. If numbers above this combination are used the program will crash");
            }

        }

        private static IEnumerable<int> RandomNumbers(int seed = 123)
        {
            var random = new System.Random(seed);
            for (int i = 0; i < 1000; i++)
            {
                yield return random.Next(25);
            }
        }

        public static int Ackermanns(int m, int n)
        {
            if (m == 0)
            {
                return n + 1;
            }
            else if (m > 0 && n == 0) return Ackermanns((m - 1), 1);
            else if (m > 0 && n > 0) return Ackermanns((m - 1), Ackermanns(m, (n - 1)));
            else
            {
                throw new System.ArgumentOutOfRangeException();
            }
        }





    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace TestStage
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
            while(running = true)
                {
                string input = Console.ReadLine();
                if (input == "1")
                {
                    opdrachtFizzBuzz();
                }
                else if(input == "2")
                {
                    Opdracht2();
                }
                else if (input == "3")
                {
                    Opdracht3();
                }
                else if (input == "4")
                {
                    Opdracht4();
                }
                else if (input == "5")
                {
                    int m = Convert.ToInt32(Console.ReadLine());
                    int n = Convert.ToInt32(Console.ReadLine());
                    Opdracht5(m, n);
                }
                else if(input == "6"){
                    break;
                }
            }
            
        }


        public static void opdrachtFizzBuzz()
        {
            for (int i = 1; i < 31; i++)
            {
                if (i % 3 == 0 && i % 5 == 0) Console.WriteLine("fizzbuzz");
                else if (i % 3 == 0) Console.WriteLine("fizz");
                else if (i % 5 == 0) Console.WriteLine("buzz");
                else Console.WriteLine(i);
            }
        }

        private static object[] InputValues()
        {
            return new[]
            {
                "5",
                "1,2e2",
                null,
                "-5555",
                "6.767"
            };
        }

        public static void Opdracht2()
        {
            string total = "";
            object[] vars = InputValues();
            foreach (var item in vars)
            {
                total += item;
            }
            string portion1 = total.Substring(0, 1);
            string portion2 = total.Substring(1, 5);
            string portion3 = total.Substring(6, 5);
            string portion4 = total.Substring(11, 5);
            int getal = int.Parse("1.2e2", System.Globalization.NumberStyles.Any);
            Console.WriteLine(getal);
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
                Console.WriteLine("value is " + value);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int min = 30000, max = 1;
            int number = int.Parse(Console.ReadLine());

            while (number != 0)
            {
                if (number < min) { min = number; }
                if (number > max) { max = number; }
                number = int.Parse(Console.ReadLine());
            }
            Console.WriteLine(min);
            Console.WriteLine(max);
            Console.ReadKey();
        }
    }
}

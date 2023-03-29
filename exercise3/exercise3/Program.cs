using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of wheels (n): ");
            int n = int.Parse(Console.ReadLine());

            if (n < 3 || n >= 50)
            {
                Console.WriteLine("Invalid input. N must be between 3 and 50.");
                return;
            }

            for (int cars = 0; cars <= n / 4; cars++)
            {
                for (int trucks = 0; trucks <= n / 6; trucks++)
                {
                    int remainingWheels = n - (4 * cars) - (6 * trucks);
                    if (remainingWheels % 3 == 0)
                    {
                        int motorcycles = remainingWheels / 3;
                        if (motorcycles >= 0)
                        {
                            Console.WriteLine($"{cars} {trucks} {motorcycles}");
                            Console.ReadKey();
                        }
                    }
                }
            }
        }
    }
}

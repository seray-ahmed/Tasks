using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> chessSymbols = new Dictionary<string, int>()
            {
                {"a", 1},
                {"b", 2},
                {"c", 3},
                {"d", 4},
                {"e", 5},
                {"f", 6},
                {"g", 7},
                {"h", 8}
            };

            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[8, 8];

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                int firstPart = chessSymbols[input[0]];
                int secondPart = int.Parse(input[1]);

                for (int j = 0; j < 8; j++)
                {

                    matrix[j, firstPart - 1] = 1;
                    matrix[secondPart - 1, j] = 1;
                }
            }

            PrintArray(matrix);
            Console.WriteLine("Броят на празните полета е "+EmptyPlacesCount(matrix));

        }
        public static void PrintArray<T>(T[,] matrix)
        {
            int rows = matrix.GetLength(0);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[rows - i - 1, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        public static int EmptyPlacesCount(int[,] matrix)
        {
            int sum = 0;
            foreach (int i in matrix)
            {
                if (i == 0)
                {
                    sum++;
                }
            }
            return sum;
        }
    }

}
  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise6._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("[number] [operation_type(+,-,)] [number]");
            Console.WriteLine("     \"exit\" to exit");
            Console.WriteLine("-----------------------");
            string input = Console.ReadLine();
            while (input != "exit")
            {
                string[] inputSplitted = input.Split(' ');
                string firstNumber = inputSplitted[0];
                string operationType = inputSplitted[1];
                string secondNumber = inputSplitted[2];
                string result = "Invalid Operation Type!";

                switch (operationType)
                {
                    case "+":
                        result = Addition(firstNumber, secondNumber);
                        break;
                    case "-":
                        result = Subtraction(firstNumber, secondNumber);
                        break;
                    case "":
                        result = Multiply(firstNumber, secondNumber);
                        break;
                }
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.WriteLine($"{firstNumber} {operationType} {secondNumber} = {result}");
                input = Console.ReadLine();
            }

        }

        static string Addition(string first, string second)
        {
            StringBuilder result = new StringBuilder();
            int carry = 0;
            int firstNumberLength = first.Length - 1;
            int secondNumberLength = second.Length - 1;

            while (firstNumberLength >= 0 || secondNumberLength >= 0 || carry > 0)
            {
                int numberOne = firstNumberLength >= 0 ? int.Parse(first[firstNumberLength].ToString()) : 0;
                int numberTwo = secondNumberLength >= 0 ? int.Parse(second[secondNumberLength].ToString()) : 0;
                int sum = numberOne + numberTwo + carry;
                carry = sum / 10;
                int digit = sum % 10;
                result.Insert(0, digit);
                firstNumberLength--;
                secondNumberLength--;
            }

            return result.ToString();
        }

        static string Subtraction(string first, string second)
        {
            StringBuilder result = new StringBuilder();
            int borrow = 0;
            int firstNumberLength = first.Length - 1;
            int secondNumberLength = second.Length - 1;

            while (firstNumberLength >= 0 || secondNumberLength >= 0)
            {
                int numberOne = firstNumberLength >= 0 ? int.Parse(first[firstNumberLength].ToString()) : 0;
                int numberTwo = secondNumberLength >= 0 ? int.Parse(second[secondNumberLength].ToString()) : 0;
                int diff = numberOne - borrow - numberTwo;

                if (diff < 0)
                {
                    diff += 10;
                    borrow = 1;
                }
                else
                {
                    borrow = 0;
                }

                result.Insert(0, diff);
                firstNumberLength--;
                secondNumberLength--;
            }

            //Remove leading zeros
            while (result.Length > 1 && result[0] == '0')
            {
                result.Remove(0, 1);
            }

            return result.ToString();
        }

        static string Multiply(string first, string second)
        {
            int firstNumberLegnth = first.Length;
            int secondNumberLength = second.Length;
            int[] result = new int[firstNumberLegnth + secondNumberLength];

            for (int i = 0; i < firstNumberLegnth; i++)
            {
                for (int j = 0; j < secondNumberLength; j++)
                {
                    int numberOne = int.Parse(first[firstNumberLegnth - i - 1].ToString());
                    int numberTwo = int.Parse(second[secondNumberLength - j - 1].ToString());
                    int multiplyResult = numberOne * numberTwo;
                    int sum = multiplyResult + result[(firstNumberLegnth - i - 1) + (secondNumberLength - j - 1) + 1];
                    result[(firstNumberLegnth - i - 1) + (secondNumberLength - j - 1) + 1] = sum % 10;
                    result[(firstNumberLegnth - i - 1) + (secondNumberLength - j - 1)] += sum / 10;
                }
            }

            StringBuilder sb = new StringBuilder();
            foreach (int digit in result)
            {
                if (!(sb.Length == 0 && digit == 0))
                {
                    sb.Append(digit);
                }
            }

            return sb.Length == 0 ? "0" : sb.ToString();
        }
    }
}
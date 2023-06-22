using System;
using System.Text;

namespace ConsoleApp1
{
    public class MyBigInt
    {
        private string myNumber;
        public string MyNumber
        {
            get => isNegative ? "-" + myNumber : myNumber;
            set => myNumber = value;
        }

        private readonly bool isNegative;

        public MyBigInt(string myNumber)
        {
            this.isNegative = false;
            if (myNumber.StartsWith("-"))
            {
                this.isNegative = true;
                myNumber = myNumber.Substring(1);
            }
            this.myNumber = myNumber;
        }

        public static MyBigInt operator +(MyBigInt a, MyBigInt b)
        {
            if (a.isNegative && b.isNegative)
            {
                return new MyBigInt("-" + Addition(a.myNumber, b.myNumber));
            }
            if (a.isNegative)
            {
                if (a.isBigger(b.MyNumber))
                {
                    return new MyBigInt("-" + Subtraction(a.myNumber, b.myNumber));
                }
                return new MyBigInt(Subtraction(b.myNumber, a.myNumber));
            }
            if (b.isNegative)
            {
                return new MyBigInt(Subtraction(a.myNumber, b.myNumber));
            }
            return new MyBigInt(Addition(a.myNumber, b.myNumber));

        }

        public static MyBigInt operator -(MyBigInt a, MyBigInt b)
        {
            if (a.isNegative && b.isNegative)
            {
                return new MyBigInt("-" + Subtraction(a.myNumber, b.myNumber));
            }
            if (a.isNegative)
            {
                return new MyBigInt("-" + Addition(a.myNumber, b.myNumber));
            }
            if (b.isNegative)
            {
                return new MyBigInt(Addition(a.myNumber, b.myNumber));
            }
            return new MyBigInt(Subtraction(a.myNumber, b.myNumber));
        }

        public static MyBigInt operator *(MyBigInt a, MyBigInt b)
        {
            if (a.isNegative || b.isNegative)
            {
                return new MyBigInt("-" + Multiply(a.myNumber, b.myNumber));
            }

            return new MyBigInt(Multiply(a.myNumber, b.myNumber));
        }

        private static string Addition(string first, string second)
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

        private static string Subtraction(string first, string second)
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

            // Remove leading zeros
            while (result.Length > 1 && result[0] == '0')
            {
                result.Remove(0, 1);
            }

            return result.ToString();
        }

        private static string Multiply(string first, string second)
        {
            int firstNumberLength = first.Length;
            int secondNumberLength = second.Length;
            int[] result = new int[firstNumberLength + secondNumberLength];

            for (int i = 0; i < firstNumberLength; i++)
            {
                for (int j = 0; j < secondNumberLength; j++)
                {
                    int numberOne = int.Parse(first[firstNumberLength - i - 1].ToString());
                    int numberTwo = int.Parse(second[secondNumberLength - j - 1].ToString());
                    int multiplyResult = numberOne * numberTwo;
                    int sum = multiplyResult + result[(firstNumberLength - i - 1) + (secondNumberLength - j - 1) + 1];
                    result[(firstNumberLength - i - 1) + (secondNumberLength - j - 1) + 1] = sum % 10;
                    result[(firstNumberLength - i - 1) + (secondNumberLength - j - 1)] += sum / 10;
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

        private bool isBigger(string one)
        {
            if (myNumber.Length > one.Length) return true;

            if (myNumber.Length < one.Length) return false;

            for (int i = 0; i < one.Length; i++)
            {
                int currentNumberMyNumber = int.Parse(myNumber[i].ToString());
                int currentNumberOne = int.Parse(one[i].ToString());
                if (currentNumberMyNumber > currentNumberOne) return true;
                if (currentNumberMyNumber < currentNumberOne) return false;
            }
            return false;
        }
    }
}

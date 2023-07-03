using System;
using System.Linq;

namespace exercise6._2
{
    public class MyBigInt
    {
        private byte[] myNumber;
        public string MyNumber
        {
            get => (isNegative ? "-" : "") + string.Join("", myNumber);
            set => myNumber = StringToByteArray(value);
        }

        private bool isNegative;

        public MyBigInt(string myNumber)
        {
            isNegative = false;
            if (myNumber.StartsWith("-"))
            {
                isNegative = true;
                myNumber = myNumber.Substring(1);
            }
            this.myNumber = StringToByteArray(myNumber);
        }

        private MyBigInt(byte[] myNumber)
        {
            this.myNumber = new byte[myNumber.Length];
            Array.Copy(myNumber, this.myNumber, myNumber.Length);
        }

        public static MyBigInt operator +(MyBigInt a, MyBigInt b)
        {
            if (a.isNegative && b.isNegative)
            {
                MyBigInt myBigInt = new MyBigInt(Addition(a.myNumber, b.myNumber));
                myBigInt.isNegative = true;
                return myBigInt;
            }
            if (a.isNegative)
            {
                return a.isBigger(StringToByteArray(b.MyNumber)) ? new MyBigInt(Subtraction(a.myNumber, b.myNumber)) { isNegative = true } :
                    new MyBigInt(Subtraction(b.myNumber, a.myNumber));
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
                MyBigInt myBigInt = new MyBigInt(Subtraction(a.myNumber, b.myNumber));
                myBigInt.isNegative = true;
                return myBigInt;
            }
            if (a.isNegative)
            {
                return new MyBigInt(Addition(a.myNumber, b.myNumber)) { isNegative = true };
            }
            if (b.isNegative)
            {
                return new MyBigInt(Addition(a.myNumber, b.myNumber));
            }
            if (b.isBigger(a.myNumber))
            {
                MyBigInt myBigInt = new MyBigInt(Subtraction(a.myNumber, b.myNumber));
                myBigInt.isNegative = true;
                return myBigInt;
            }
            return new MyBigInt(Subtraction(a.myNumber, b.myNumber));
        }

        public static MyBigInt operator *(MyBigInt a, MyBigInt b)
        {
            if (a.isNegative || b.isNegative)
            {
                MyBigInt myBigInt = new MyBigInt(Multiply(a.myNumber, b.myNumber));
                myBigInt.isNegative = true;
                return myBigInt;
            }
            return new MyBigInt(Multiply(a.myNumber, b.myNumber));
        }

        private static byte[] Addition(byte[] first, byte[] second)
        {
            int biggerNumberLength = Math.Max(first.Length, second.Length);
            byte[] result = new byte[biggerNumberLength + 1];
            byte carry = 0;

            for (int i = 0; i < biggerNumberLength || carry > 0; i++)
            {
                byte numberOne = (byte)(i < first.Length ? first[first.Length - i - 1] : 0);
                byte numberTwo = (byte)(i < second.Length ? second[second.Length - i - 1] : 0);
                byte sum = (byte)(numberOne + numberTwo + carry);
                carry = (byte)(sum / 10);
                byte digit = (byte)(sum % 10);
                result[result.Length - i - 1] = digit;
            }

            return TrimStart(result);
        }

        private static byte[] Subtraction(byte[] first, byte[] second)
        {
            int biggerNumberLength = Math.Max(first.Length, second.Length);
            byte[] result = new byte[biggerNumberLength];
            byte borrow = 0;

            for (int i = 0; i < biggerNumberLength; i++)
            {
                byte numberOne = (byte)(i < first.Length ? first[first.Length - i - 1] : 0);
                byte numberTwo = (byte)(i < second.Length ? second[second.Length - i - 1] : 0);
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

                result[result.Length - i - 1] = (byte)diff;
            }

            return TrimStart(result);
        }

        private static byte[] Multiply(byte[] first, byte[] second)
        {
            byte[] result = new byte[first.Length + second.Length];

            for (int i = 0; i < first.Length; i++)
            {
                for (int j = 0; j < second.Length; j++)
                {
                    byte numberOne = first[first.Length - i - 1];
                    byte numberTwo = second[second.Length - j - 1];
                    byte multiplyResult = (byte)(numberOne * numberTwo);
                    byte sum = (byte)(multiplyResult + result[result.Length - i - j - 1]);
                    result[result.Length - i - j - 1] = (byte)(sum % 10);
                    result[result.Length - i - j - 2] += (byte)(sum / 10);
                }
            }

            return TrimStart(result);
        }

        private bool isBigger(byte[] one)
        {
            if (myNumber.Length > one.Length) return true;
            if (myNumber.Length < one.Length) return false;

            for (int i = 0; i < one.Length; i++)
            {
                byte currentNumberMyNumber = myNumber[i];
                byte currentNumberOne = one[i];
                if (currentNumberMyNumber > currentNumberOne) return true;
                if (currentNumberMyNumber < currentNumberOne) return false;
            }

            return false;
        }

        private static byte[] StringToByteArray(string number) =>
            number.Select(x => byte.Parse(x.ToString())).ToArray();

        private static byte[] TrimStart(byte[] num)
        {
            int startIndex = 0;
            while (startIndex < num.Length - 1 && num[startIndex] == 0)
                startIndex++;

            byte[] result = new byte[num.Length - startIndex];
            Array.Copy(num, startIndex, result, 0, result.Length);
            return result;
        }
    }
}

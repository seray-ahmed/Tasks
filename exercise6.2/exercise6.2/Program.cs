
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
            MyBigInt numberOne = new MyBigInt("1234");
            MyBigInt numberTwo = new MyBigInt("4578");
            MyBigInt numberThree = numberOne + numberTwo;
            Console.WriteLine(numberThree.MyNumber);
                    



        }
    }
}
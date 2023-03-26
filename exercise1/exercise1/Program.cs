using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise1
{
    public class Date
    {
        public int year;
        public int month;
        public int day;

        public Date()
        {
            this.year = 0;
            this.month = 0;
            this.day = 0;
            
        }

        public void Input()
        {
            Console.Write("Ден:");
            this.day = int.Parse(Console.ReadLine());
            Console.Write("Месец:");
            this.month = int.Parse(Console.ReadLine());
            Console.Write("Година:");
            this.year = int.Parse(Console.ReadLine());

        }

        public void Output()
        {
            int temp = this.month ;
           
            if (this.day > 0) this.day++;
            if (this.day > Month()) this.month++;
            if (temp != this.month) this.day = 1;
            if (this.month > 12)
            {
                this.year++;
                this.month = 1;
            }
            
            Console.WriteLine("{0}.{1}.{2}", this.day, this.month, this.year);
            
        }

        public int Year()
        {
            if (this.year % 4 == 0) return 29;
            else return 28;
        }
        public int Month()
        {
            if (this.month == 1 || this.month == 3 || this.month == 5 || this.month == 7 || this.month == 8 || this.month == 10 || this.month == 12)
                return 31;
            if(this.month==2)return Year();
            else return 30;
        }
         class Program
        {
           public static void Main(string[] args)
            {
                Date date = new Date();
                date.Input();
                date.Output();
                Console.ReadLine();
            }
        }
    }
}

  
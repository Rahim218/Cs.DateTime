
using System;

namespace Cs.DateTime1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dogum tarixini daxil edin : ");
            string inputStr = Console.ReadLine();
            DateTime inputDate = Convert.ToDateTime(inputStr);

            Console.WriteLine(inputDate.DayOfWeek);


            


        }

    }
}

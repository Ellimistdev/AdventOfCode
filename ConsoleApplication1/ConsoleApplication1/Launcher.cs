using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication1
{
    class Launcher
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Run which day?");
            int day = Convert.ToInt32(Console.ReadLine());
            string filePath = $@"..\..\Input\{day}.txt";
            switch (day)
            {
                case 1:
                    DayOne.dayOne();
                    break;
                case 2:
                    DayTwo.dayTwo(filePath);
                    break;                
                default:
                    break;
            }
            Console.WriteLine("Merry Christmas!");
            Console.ReadLine();



        }
    }
}

using System;

namespace Advent
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
                    DayOne.dayOne(filePath);
                    break;
                case 2:
                    DayTwo.dayTwo(filePath);
                    break;
                case 3:
                    Console.WriteLine("How many Santas?");
                    int santaCount = Convert.ToInt32(Console.ReadLine());
                    if (santaCount == 1)
                        DayThree.oneSanta(filePath);
                    DayThree.twoSantas(filePath);                    
                    break;              
                default:
                    break;
            }
            Console.WriteLine("Merry Christmas!");
            Console.ReadLine();



        }
    }
}

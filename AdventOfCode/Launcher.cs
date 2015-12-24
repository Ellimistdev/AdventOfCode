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
                case 4:
                    DayFour.dayFour();
                    break;
                case 5:
                    Console.WriteLine("Which part?");
                    int part = Convert.ToInt32(Console.ReadLine());
                    if (part == 1)
                        DayFive.partOne(filePath);
                    DayFive.partTwo(filePath);
                    break;
                case 6:
                    DaySix.daySix(filePath);
                    break;
                default:
                    Console.WriteLine("Please enter a numberal between 1 and 6");
                    break;
            }
            Console.WriteLine("Merry Christmas!");
            Console.ReadLine();



        }
    }
}

using System;

namespace Advent
{
    class Launcher
    {
        static void Main(string[] args)
        {
            Entry();
        }
        static void Entry()
        {
            Console.WriteLine("Run which year?");
            int year = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Run which day?");
            int day = Convert.ToInt32(Console.ReadLine());
            if (year != 2016)
            {
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
                        Console.WriteLine("Please enter an integer between 1 and 6");
                        break;
                }
            }
            else
            {
                switch (day)
                {
                    case 1:
                    case 2:
                        Console.WriteLine("Days 1 and 2 not implemented, sorry!");
                        break;
                    case 3:
                        DayThree2016.Entry();
                        break;
                    case 4:
                        DayFour2016.Entry();
                        break;
                    case 5:
                        DayFive2016.Entry();
                        break;
                    case 6:
                        DaySix2016.Entry();
                        break;
                    case 7:
                        DaySeven2016.Entry();
                        break;
                    case 8:
                        DayEight2016.Entry();
                        break;
                    case 9:
                        DayNine2016.Entry();
                        break;
                    default:
                        Console.WriteLine("Please enter an integer between 1 and 9");
                        break;

                }
            }
            Console.WriteLine("Would you like to run again? y/n");
            if (Console.ReadLine() == "y")
            {
                Entry();
            }
            Console.WriteLine("Merry Christmas!");
            Console.ReadLine();
        }
    }
}

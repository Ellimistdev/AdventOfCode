using System;
using System.IO;

namespace Advent
{
    public class DayOne
    {
        public static void dayOne(string filePath)
        {
            // Problem 1 - ( = upstairs ) = downstairs, what floor given s?
            string s = File.ReadAllText(filePath);
            int f = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                    f++;
                else
                    f--;
            }
            Console.WriteLine("Santa is going to floor " + f);

            //Problem 1 part 2 - ( = upstairs ) = downstairs, after what instruction does santa enter the basement given s?
            f = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                    f++;
                else
                    f--;
                if (f == -1)
                {
                    Console.WriteLine("Santa enters the basement after instruction " + (i + 1));
                    break;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Advent
{
    class DayFive
    {
        public static void dayFive(string filePath)
        {
            string[] naughtyLetters = new string[] { "ab", "cd", "pq", "xy" };
            char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };
            List<string> niceStrings = new List<string>();
            List<string> naughtyStrings = new List<string>();

            foreach (string line in File.ReadAllLines(filePath))
            {
                int vowelCount = 0;
                bool consecutive = false;
                bool isNaughty = false;

                for (int i = 0; i < line.Length; i++)
                {
                    if (i + 1 < line.Length)
                    {
                        foreach (string letters in naughtyLetters)
                        {
                            if (string.Concat(line[i], line[i + 1]).Contains(letters))
                            {
                                isNaughty = true;
                                break;
                            }
                        }

                        if (line[i] == line[i + 1])
                            consecutive = true;
                    }
                    foreach (char vowel in vowels)
                    {
                        if (line[i] == vowel)
                            vowelCount++;
                    }
                }
                    
                if ((vowelCount > 2) && consecutive && !isNaughty)
                    niceStrings.Add(line);
                else
                    naughtyStrings.Add(line);
            }
            Console.WriteLine("There are {0} nice strings", niceStrings.Count());
            Console.WriteLine("There are {0} naughty strings", naughtyStrings.Count());
        }
    }
}

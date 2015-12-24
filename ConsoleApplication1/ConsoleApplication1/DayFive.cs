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
        public static void partOne(string filePath)
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
        public static void partTwo(string filePath)
        {
            List<string> niceStrings = new List<string>();
            List<string> naughtyStrings = new List<string>();

            foreach (string line in File.ReadAllLines(filePath))
            {
                bool sandwiched = false;
                int pairCount = 0;
                List<string> pairs = new List<string>();

                for (int i = 0; i < line.Length; i++)
                {
                    if (i + 1 < line.Length)
                    {
                        string pair = string.Concat(line[i], line[i + 1]);
                        pairs.Add(pair);
                    }
                    if (i + 2 < line.Length)
                    {
                        if (line[i] == line[i + 2])
                            sandwiched = true;
                    }
                }
                // handle three identical chars in a row
                for (int i = 0; i + 1 < pairs.Count(); i++)
                {
                    if (pairs[i] == pairs[i + 1])
                    {
                        pairs.Remove(pairs[i + 1]);
                    }
                }
                if (pairs.Distinct().Count() != pairs.Count())
                {
                    Console.WriteLine("List contains multiple pairs. {0} of them", (pairs.Count() - pairs.Distinct().Count()));
                    pairCount = 2;
                }
                if (pairCount > 1 && sandwiched)
                    niceStrings.Add(line);
                else
                    naughtyStrings.Add(line);
            }

            Console.WriteLine("There are {0} nice strings", niceStrings.Count());
            Console.WriteLine("There are {0} naughty strings", naughtyStrings.Count());
        }
    }
}

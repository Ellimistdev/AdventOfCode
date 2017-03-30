using System;
using System.Net;
using System.IO;
using System.Collections.Generic;

namespace Advent
{
    public class DayThree2016

    {
        public static int goodCount = 0;
        public static int selector = 2;

        public static void Entry()
        {
            //readfile
            WebClient client = new WebClient();
            Stream stream = client.OpenRead("https://gist.githubusercontent.com/endotnick/495fc05b32efc408144b7fd182d7fdbc/raw/3a003a87ce4dde4137b163d5ec655c1cb200bd67/AoC2016d3p1.txt");
            StreamReader reader = new StreamReader(stream);
            string content = reader.ReadToEnd();

            //convert file to lines
            string[] lines = content.Split(new string[] { "\n" }, StringSplitOptions.None);

            //parse lines as columns
            //get 3 lines
            //lines.Length is divisible by 3		
            while (selector <= (lines.Length))
            {
                Console.WriteLine("selector = {0}", selector);

                string[] lineSet = { lines[selector - 2], lines[selector - 1], lines[selector] };
                List<int> ints = new List<int>();

                foreach (string s in lineSet)
                {
                    int[] sides = getIntArray(s);

                    for (int i = 0; i < 3; i++)
                        ints.Add(sides[i]);

                }
                for (int i = 0; i < 3; i++)
                {
                    int[] testTri = new int[] { ints[i], ints[i + 3], ints[i + 6] };
                    Console.WriteLine("testTri = {0},{1},{2}", testTri[0], testTri[1], testTri[2]);
                    if (isTriangle(testTri))
                    {
                        goodCount++;
                        Console.WriteLine("Triangle Found! Count = {0}", goodCount);
                    }
                }

                selector = selector + 3;
            }


            //parse lines as rows
            /*
            foreach(string s in lines)
            {
                int[] sides = getIntArray(s);			
                //check if array is triangle	
                if (isTriangle(sides))
                {
                    goodCount++;
                    //Console.WriteLine("Triangle Found! Count = {0}", goodCount);						
                }			
            }	
            */
            Console.WriteLine("Search complete.");
        }
        public static bool isTriangle(int[] sides)
        {
            Array.Sort(sides, 0, 3);
            //Console.WriteLine("Sorted array: {0}, {1}, {2}", sides[0], sides[1], sides[2]);

            if (sides[0] + sides[1] > sides[2])
                return true;
            else
                return false;
        }

        public static int[] getIntArray(string s)
        {
            string[] values = s.Split(new string[] { "  " }, StringSplitOptions.RemoveEmptyEntries);
            int[] ints = Array.ConvertAll<string, int>(values, int.Parse);

            return ints;
        }

    }
}

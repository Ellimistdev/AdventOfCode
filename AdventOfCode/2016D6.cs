using System;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;

namespace Advent
{
    public class DaySix2016

    {
        public static void Entry()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            List<KeyValuePair<char, int>> scrambledMessage = new List<KeyValuePair<char, int>>();

            //readfile
            WebClient client = new WebClient();
            Stream stream = client.OpenRead("https://raw.githubusercontent.com/endotnick/AdventOfCode/master/AdventOfCode/Input/2017d6p1");
            StreamReader reader = new StreamReader(stream);
            string content = reader.ReadToEnd();

            //convert file to lines
            string[] lines = content.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            //get length of message
            int messageLength = lines[0].Length;

            //parse lines
            foreach (string line in lines)
            {
                int index = 0;
                foreach (char c in line)
                {
                    KeyValuePair<char, int> element = new KeyValuePair<char, int>(c, index);
                    scrambledMessage.Add(element);
                    index++;
                }
            }

            Dictionary<KeyValuePair<char, int>, int> dictionary = new Dictionary<KeyValuePair<char, int>, int>();
            foreach (KeyValuePair<char, int> pair in scrambledMessage)
            {
                if (dictionary.ContainsKey(pair))
                {
                    dictionary[pair] += 1;
                }
                else
                {
                    dictionary.Add(pair, 1);
                }
            }
            var sortedList = (from entry in dictionary
                              orderby entry.Value ascending, entry.Key.Value ascending
                              select entry).ToList();
            //find password
            int count = 0;
            string password = "";
            while (count < messageLength)
            {
                password += sortedList[count].Key.Key;
                count++;
            }

            Console.WriteLine("@ {0} - Password found: {1}", watch.Elapsed, password);
            Console.WriteLine("@ {0} - End program", watch.Elapsed);
            watch.Stop();
        }
    }
}

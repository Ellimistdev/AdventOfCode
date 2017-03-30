using System;
using System.Diagnostics;
using System.Net;
using System.IO;
using System.Collections.Generic;

namespace Advent
{
    public class DaySeven2016

    {
        public static void Entry()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            //readfile
            WebClient client = new WebClient();
            Stream stream = client.OpenRead("https://raw.githubusercontent.com/endotnick/AdventOfCode/master/AdventOfCode/Input/2017.7.1");
            StreamReader reader = new StreamReader(stream);
            string content = reader.ReadToEnd();
            //convert file to lines
            string[] lines = content.Split(new string[] { "\n" }

            , StringSplitOptions.RemoveEmptyEntries);
            List<string> supportedIPs = new List<string>();
            List<string> sslIPs = new List<string>();
            foreach (string line in lines)
            {
                Console.WriteLine("@ {0} - line is {1}", watch.Elapsed, line);
                List<string> hypernetList = new List<string>();
                List<string> segmentList = new List<string>();
                List<string> listABA = new List<string>();
                List<string> listBAB = new List<string>();

                extractElements(line, ref segmentList, ref hypernetList);

                //process hypernets in IP
                bool hypernetIsABBA = false;
                bool hypernetIsBAB = false;
                foreach (string hypernet in hypernetList)
                {
                    //used later to prevent adding invalid IPs to TLS supported List
                    if (!hypernetIsABBA)
                    {
                        hypernetIsABBA = (stringIsABBA(hypernet.ToCharArray(), watch));
                    }
                    hypernetIsBAB = (stringIsABA(hypernet.ToCharArray(), watch, ref listBAB));

                }

                Console.WriteLine("@ {0} - hypernetList.Count {1} complete, moving on", watch.Elapsed, hypernetList.Count);
                //process segments in IP
                bool segmentIsABBA = false;
                bool segmentIsABA = false;

                foreach (string segment in segmentList)
                {
                    segmentIsABBA = (stringIsABBA(segment.ToCharArray(), watch));
                    segmentIsABA = (stringIsABA(segment.ToCharArray(), watch, ref listABA));
                    if (segmentIsABBA && !hypernetIsABBA)
                    {
                        Console.WriteLine("@ {0} - segment {1} Is Abba, IP {2} supports TLS", watch.Elapsed, segment, line);
                        supportedIPs.Add(line);
                        //without this break, receive incorrect TLS, with the break, receive incorrect SSL
                        //break;
                    }
                }

                if (segmentIsABBA == false)
                {
                    Console.WriteLine("@ {0} - Reached end of Abba check, IP does not support TLS", watch.Elapsed);
                }

                Console.WriteLine("@ {0} - listABA count: {1}", watch.Elapsed, listABA.Count);
                Console.WriteLine("@ {0} - listBAB count: {1}", watch.Elapsed, listBAB.Count);
                //if both lists have entries, continue SSL detection process
                if (listABA.Count > 0 && listBAB.Count > 0)
                {
                    Console.WriteLine("@ {0} - Lists have entries, begin conversion", watch.Elapsed);
                    //convert entries in listABA
                    List<string> convertedABA = convertABA(listABA);
                    //compare entries
                    foreach (string entry in convertedABA)
                    {
                        Console.WriteLine("@ {0} - Entry: {1}, comparing", watch.Elapsed, entry);
                        if (listBAB.Contains(entry))
                        {
                            Console.WriteLine("@ {0} - Entry: {1}, comparing found", watch.Elapsed, entry);
                            sslIPs.Add(line);
                            Console.WriteLine("@ {0} - IPs supporting SSL: {1}", watch.Elapsed, sslIPs.Count);
                            break;
                        }
                    }
                }
                Console.WriteLine("@ {0} - Moving to next line", watch.Elapsed);
            }

            Console.WriteLine("@ {0} - IPs supporting SSL: {1}", watch.Elapsed, sslIPs.Count);
            Console.WriteLine("@ {0} - IPs supporting TLS: {1}", watch.Elapsed, supportedIPs.Count);
            Console.WriteLine("@ {0} - End program", watch.Elapsed);
            watch.Stop();
        }

        public static void extractElements(string line, ref List<string> segmentList, ref List<string> hypernetList)
        {
            int substringStart = 0;
            int substringEnd = 0;
            int index = 0;
            //iterate over string
            while (substringEnd != line.Length)
            {
                //when hit '[' set substring end to IndexOf('[') - 1
                if (line[index] == '[')
                {
                    substringEnd = index;
                    segmentList.Add(line.Substring(substringStart, substringEnd - substringStart));
                    substringStart = index + 1;
                    index++;
                }
                //when hit ']' set substring end to IndexOf(']') - 1
                else if (line[index] == ']')
                {
                    substringEnd = index;
                    hypernetList.Add(line.Substring(substringStart, substringEnd - substringStart));
                    substringStart = index + 1;
                    index++;
                }
                else if (index == line.Length - 1)
                {
                    //+1 to get final char
                    substringEnd = index + 1;
                    segmentList.Add(line.Substring(substringStart, substringEnd - substringStart));
                    //reached the end of the line, move on
                    break;
                }
                else
                {
                    index++;
                }
            }
        }
        public static List<string> convertABA(List<string> listABA)
        {
            List<string> convertedList = new List<string>();
            foreach (string entry in listABA)
            {
                char[] charEntry = entry.ToCharArray();
                //shift chars
                charEntry[0] = charEntry[1];
                charEntry[1] = charEntry[2];
                charEntry[2] = charEntry[0];
                //convert to string
                string convertedEntry = new string(charEntry);
                convertedList.Add(convertedEntry);
                Console.WriteLine("Entry: {0}, Converted: {1}", entry, convertedEntry);
            }

            return convertedList;
        }

        //for a 4 element char array, determine whether it is a palindrome
        public static bool charSetIsABBA(char[] chars)
        {
            //interior chars must be different
            if (chars[0] == chars[3] && chars[1] == chars[2] && chars[0] != chars[1])
            {
                return true;
            }
            else
                return false;
        }

        public static bool charSetIsABA(char[] chars)
        {
            if (chars[0] == chars[2] && chars[0] != chars[1])
            {
                return true;
            }
            else
                return false;
        }

        public static char[] getChars(char[] chars, int index, int size)
        {
            char[] charSet = new char[size];
            for (int i = 0; i < size; i++)
            {
                charSet[i] = chars[index];
                index++;
            }

            return charSet;
        }

        public static bool stringIsABA(char[] chars, Stopwatch watch, ref List<string> sslList)
        {
            bool status = false;
            int index = 0;
            while (index < chars.Length - 2)
            {
                char[] testArray = getChars(chars, index, 3);
                //Console.WriteLine("@ {0} - charSet == {1}, {2}, {3}", watch.Elapsed, testArray[0], testArray[1], testArray[2]);
                if (charSetIsABA(testArray))
                {
                    Console.WriteLine("@ {0} - {1}{2}{3} isAba - continuing", watch.Elapsed, testArray[0], testArray[1], testArray[2]);
                    status = true;
                    sslList.Add(new string(testArray));
                    Console.WriteLine("@ {0} - list.Count: {1}", watch.Elapsed, sslList.Count);
                }

                index++;
            }

            return status;
        }

        public static bool stringIsABBA(char[] chars, Stopwatch watch)
        {
            bool status = false;
            int index = 0;
            while (index < chars.Length - 3)
            {
                char[] testArray = getChars(chars, index, 4);
                if (charSetIsABBA(testArray))
                {
                    Console.WriteLine("@ {0} - {1}{2}{3}{4} isAbba - Breaking", watch.Elapsed, testArray[0], testArray[1], testArray[2], testArray[3]);
                    status = true;
                    return status;
                }
                else
                {
                    index++;
                }
            }

            return status;
        }
    }
}

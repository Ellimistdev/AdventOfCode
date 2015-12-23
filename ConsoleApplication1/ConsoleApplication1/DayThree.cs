using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Advent
{
    class DayThree
    {
        public static void oneSanta(string filePath)
        {
            //How many houses receive at least 1 present given the instructions? 
            // > delivers presents to 2 houses: one at the starting location, and one to the east.
            // ^> v < delivers presents to 4 houses in a square, including twice to the house at his starting / ending location.
            // ^ v ^ v ^ v ^ v ^ v delivers a bunch of presents to some very lucky children at only 2 houses.

            char[] instructions = File.ReadAllText(filePath).ToCharArray();
            List<Tuple<int, int>> addressess = new List<Tuple<int, int>>();
            addressess.Add(Tuple.Create(0, 0)); // only count starting location once.
            List<Tuple<int, int>> coords = ProcessInstructions(instructions, addressess);
            Console.WriteLine(coords.Count + " houses receive a present.");
        }
        public static void twoSantas(string filePath)
        {
            // How many houses receive at least 1 present if two santas alternate moves?

            Console.WriteLine("Gogo RoboSanta!");
            char[] instructions = File.ReadAllText(filePath).ToCharArray();
            char[] roboInstructions = new char[(instructions.Count() / 2)];
            char[] realInstructions = new char[(instructions.Count() / 2)];
            int roboIndex = 0;
            int realIndex = 0;

            // separate instructions
            for (int i = 0; i < instructions.Length; i++)
            {                
                if (i % 2 == 0)
                {
                    roboInstructions.SetValue((instructions.ElementAt(i)), roboIndex);
                    roboIndex++;
                }
                else
                {
                    realInstructions.SetValue((instructions.ElementAt(i)), realIndex);
                    realIndex++;
                }
            }
            List<Tuple<int, int>> addressess = new List<Tuple<int, int>>();
            addressess.Add(Tuple.Create(0, 0)); // only count starting location once.

            ProcessInstructions(roboInstructions, addressess);
            ProcessInstructions(realInstructions, addressess);

            Console.WriteLine("Presents go to {0} houses!", addressess.Count);
        }
        public static List<Tuple<int, int>> ProcessInstructions(char[] instructions, List<Tuple<int, int>> addressess)
        {
            int x = 0;
            int y = 0;
            
            foreach (char i in instructions)
            {
                if (i == '^')
                    y++;
                else if (i == '>')
                    x++;
                else if (i == '<')
                    x--;
                else
                    y--;

                Tuple<int, int> address = Tuple.Create(x, y);
                if (!addressess.Contains(address))
                {
                    addressess.Add(address);
                }
            }
            return addressess;
        }
    }
}


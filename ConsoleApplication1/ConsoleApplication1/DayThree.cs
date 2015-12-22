using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            List<Tuple<int, int>> coords = ProcessInstructions(instructions);

            List<Tuple<int, int>> uniqueAddresses = DeDupeCoords(coords);

            Console.WriteLine(uniqueAddresses.Count + " houses receive a present.");

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

            List<Tuple<int, int>> roboUnique = DeDupeCoords(ProcessInstructions(roboInstructions));
            List<Tuple<int, int>> realUnique = DeDupeCoords(ProcessInstructions(realInstructions));

            Console.WriteLine("RoboSanta goes to {0} houses!", roboUnique.Count);
            Console.WriteLine("RealSanta goes to {0} houses!", realUnique.Count);
            Console.WriteLine("That's a combined total of {0} houses!", (roboUnique.Count + realUnique.Count));

        }
        public static List<Tuple<int, int>> ProcessInstructions(char[] instructions)
        {
            List<Tuple<int, int>> coords = new List<Tuple<int, int>>();
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
                Tuple<int, int> address = new Tuple<int, int>(x, y);

                coords.Add(address);

            }
            return coords;

        }

        public static List<Tuple<int,int>> DeDupeCoords(List<Tuple<int,int>> coords)
        {           
            // with Linq
            List<Tuple<int, int>> newcoords = coords.Distinct().ToList();
            return newcoords;
        }
    }

}


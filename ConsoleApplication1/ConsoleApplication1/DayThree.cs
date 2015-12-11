using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication1
{
    class DayThree
    {
        public static void dayThree(string filePath)
        {
            //How many houses receive at least 1 present given the instructions? 
            // > delivers presents to 2 houses: one at the starting location, and one to the east.
            // ^> v < delivers presents to 4 houses in a square, including twice to the house at his starting / ending location.
            // ^ v ^ v ^ v ^ v ^ v delivers a bunch of presents to some very lucky children at only 2 houses.

            
            int x = 0;
            int y = 0;

            char[] instructions = File.ReadAllText(filePath).ToCharArray();

            List<Tuple<int, int>> coords = ProcessInstruction(instructions);

        }
        public List<Tuple<int, int>> ProcessInstructions(char [] instructions)
        {
            List<Tuple<int, int>> coords = new List<Tuple<int, int>>();

            foreach (var instruction in instructions)
            {

            }
            return coords;

        }
    }

}


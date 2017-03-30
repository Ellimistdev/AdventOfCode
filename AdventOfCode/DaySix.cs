using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Advent
{
    class DaySix
    {
        public static void daySix(string filePath)
        {
            Console.WriteLine("define x");
            int boardX = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("define y");
            int boardY = Convert.ToInt32(Console.ReadLine());

            bool[,] lightboard = SetupLights(boardX, boardY);

            processInstructions(lightboard, filePath);
            int litLights = countLitLights(lightboard);

            Console.WriteLine("There are {0} lights lit after processing instructions", litLights);
        }

        private static int countLitLights(bool[,] lightboard)
        {
            int lightCount = 0;
            foreach (bool light in lightboard)
            {
                if (light)
                    lightCount++;
            }
            return lightCount;
        }

        private static bool[,] SetupLights(int boardX, int boardY)
        {
            bool[,] lightBoard = new bool[boardX, boardY];
            for (int x = 0; x < boardX; x++)
            {
                for (int y = 0; y < boardY; y++)
                {
                    //Light light = new Light(x, y, false);
                    lightBoard.SetValue(false, x, y);
                }
            }
            return lightBoard;
        }

        private class Light
        {
            private bool lightSwitch = false;
            private int positionX = 0;
            private int positionY = 0;

            internal Light() { }
            internal Light(int positionX, int positionY, bool lightswitch)
            {
                this.positionX = positionX;
                this.positionY = positionY;
                this.lightSwitch = lightswitch;
            }
        }

        private static void processInstructions(bool[,] lightboard, string filePath)
        {
            List<string> instructions = new List<string>();

            foreach (string line in File.ReadAllLines(filePath))
            {
                instructions.Add(line);
                int operation = 0;
                int xStart = 0;
                int xEnd = 0;
                int yStart = 0;
                int yEnd = 0;


                processLine(line, ref operation, ref xStart, ref xEnd, ref yStart, ref yEnd);

                //nothing happens if xstart and xend are both 0
                for (int x = xStart; x != xEnd; x++)
                {
                    //nothing happens if ystart and yend are both 0
                    for (int y = yStart; y != yEnd; y++)
                    {
                        switch (operation)
                        {
                            case 0:
                                if (!lightboard[x, y])
                                    lightboard[x, y] = true;
                                else
                                    lightboard[x, y] = false;
                                break;
                            case 1:
                                lightboard[x, y] = false;
                                break;
                            case 2:
                                lightboard[x, y] = true;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }

        private static void processLine(string line, ref int operation, ref int xStart, ref int xEnd, ref int yStart, ref int yEnd)
        {
            if (line.StartsWith("toggle"))
                operation = 0;
            else if (line.StartsWith("turn off"))
                operation = 1;
            else
                operation = 2;

            string[] strArray = line.Split(null);
            string[] tmpStart;
            string[] tmpEnd;

            if (strArray.Length == 4)
            {
                tmpStart = strArray[1].Split(',');
                xStart = int.Parse(tmpStart[0]);
                yStart = int.Parse(tmpStart[1]);

                tmpEnd = strArray[3].Split(',');
                xEnd = int.Parse(tmpEnd[0]);
                yEnd = int.Parse(tmpEnd[1]);

            }
            if (strArray.Length == 5)
            {
                tmpStart = strArray[2].Split(',');
                xStart = int.Parse(tmpStart[0]);
                yStart = int.Parse(tmpStart[1]);

                tmpEnd = strArray[4].Split(',');
                xEnd = int.Parse(tmpEnd[0]);
                yEnd = int.Parse(tmpEnd[1]);
            }
        }
    }
}

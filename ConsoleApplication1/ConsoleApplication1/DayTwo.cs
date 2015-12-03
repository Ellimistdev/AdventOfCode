using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class DayTwo
    {
        public static void dayTwo(string filePath)
        {
            //Problem 2 | Elves need exactly total surface area + the area of the smallest side of a rectangular present to wrap, how much total given dimensions in file?
            List<Present> Presents = new List<Present>();
            foreach (string line in File.ReadLines(filePath))
            {
                string[] strArray;
                strArray = line.Split('x');
                Present currentPresent = new Present();

                currentPresent.Length = int.Parse(strArray[0]);
                currentPresent.Width = int.Parse(strArray[1]);
                currentPresent.Height = int.Parse(strArray[2]);

                int lxw = currentPresent.Length * currentPresent.Width;
                int lxh = currentPresent.Length * currentPresent.Height;
                int wxh = currentPresent.Width * currentPresent.Height;

                currentPresent.SurfaceArea = ((2 * lxw) + (2 * wxh) + (2 * lxh));             
                currentPresent.SmallestArea = (Math.Min(Math.Min(lxw, wxh), lxh));
                currentPresent.Volume = (lxw * currentPresent.Height);

                int p1 = ((2 * currentPresent.Length ) + (2 * currentPresent.Width));
                int p2 = ((2 * currentPresent.Length) + (2 * currentPresent.Height));
                int p3 = ((2 * currentPresent.Width) + (2 * currentPresent.Height));

                currentPresent.ShortestPerim = (Math.Min(Math.Min(p1, p2), p3));
                
                Presents.Add(currentPresent);
            }
            int sqft = 0;
            int ribbon = 0;
            for (int i = 0; i < Presents.Count; i++)
            {
                sqft += Presents[i].SmallestArea + Presents[i].SurfaceArea;
                ribbon += Presents[i].ShortestPerim + Presents[i].Volume;
            }
            Console.WriteLine($"To wrap all {Presents.Count} presents, the elves will need exactly {sqft} sqft of wrapping paper!");
            Console.WriteLine($"To wrap all {Presents.Count} presents, the elves will need exactly {ribbon} ft of ribbon!");

            Console.ReadLine();
        }  
    }
    internal class Present
    {
        public int Length { set; get; }
        public int Width  { set; get; }
        public int Height { set; get; }
        public int SurfaceArea { set; get; }
        public int SmallestArea { set; get; }
        public int ShortestPerim { set; get; }
        public int Volume { set; get; }
    }
}

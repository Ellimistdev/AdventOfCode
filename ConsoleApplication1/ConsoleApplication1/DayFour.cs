using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Advent
{
    class DayFour
    {
        //currently takes between 5.8 and 6.7 sec to find the first instance w/ 6 leading zeroes, WE CAN DO BETTER
        public static void dayFour()
        {
            string input = "bgvyzdsv";
            int max = 10000000;
            string adventAddress = null;
            MD5 md5 = MD5.Create();

            for (int i = 0; i < max; i++)
            {
                // hash input with i appended
                string address = input + i;  //"abcdef609043"; 
                string hash = getMD5Hash(address, md5);

                // check if output has 5 leading zeros
                adventAddress = checkHash(hash);

                if (adventAddress == null)
                    continue;
                else
                    Console.WriteLine("Input was {0}", address);
                    break;
            }
            md5.Dispose();
            Console.WriteLine("AdventCoin address is {0}", adventAddress);
        }

        private static string checkHash(string hash)
        {
            for (int x = 0; x < 6; x++)
            {
                if (!(hash[x] == '0'))
                    break;
                else if (x != 5)
                    continue;
                else
                {
                    Console.WriteLine("Found AdventCoin at {0}!", hash);
                    return hash;
                }
            }
            return null;
        }

        private static string getMD5Hash(string input, MD5 md5)
        {            
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}

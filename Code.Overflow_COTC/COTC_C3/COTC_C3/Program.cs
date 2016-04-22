using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace COTC_C3
{
    class Program
    {
        static void Main(string[] args)
        {
            //myFunc(new string[] { "4", "a,w,e,L,K,2,3,D,r,9,N,P,z,u" });
            myFunc(args);
        }

        private static char[] shuffle(char[] charArray)
        {
            char[] shuffledArray = new char[charArray.Length];
            int rndNo;

            Random rnd = new Random();
            for (int i = charArray.Length; i >= 1; i--)
            {
                rndNo = rnd.Next(1, i + 1) - 1;
                shuffledArray[i - 1] = charArray[rndNo];
                charArray[rndNo] = charArray[i - 1];
            }
            return shuffledArray;
        }

        public static void myFunc(string[] args)
        {
            int myStringLen = Convert.ToInt32(args[0]);
            char[] myExcludeChar = args[1].ToCharArray();

            string upperAlphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string numberString = "0123456789";
            List<char> originalCharSet = new List<char>(upperAlphabets.ToCharArray());
            originalCharSet.AddRange(upperAlphabets.ToLower().ToCharArray());
            originalCharSet.AddRange(numberString.ToCharArray());

            foreach(char cExclude in myExcludeChar)
            {
                originalCharSet.Remove(cExclude);
            }

            List<char> workingCharSet = new List<char>();
            string myOutputStr = "";
            if (originalCharSet.Count <= 50)
            {
                workingCharSet.AddRange(originalCharSet);
                workingCharSet.AddRange(originalCharSet);
                myOutputStr = new string(shuffle(workingCharSet.ToArray<char>()));                
            }
            else
            {
                myOutputStr = new string(shuffle(originalCharSet.ToArray<char>()));                
            }

            string myOutputData = "";
            if(myStringLen<=3)
            {
                Random rnd = new Random();
                int rndNo = rnd.Next(1, myOutputStr.Length - myStringLen) - 1;
                //Console.WriteLine(myOutputStr.Substring(rndNo, myStringLen));
                myOutputData = myOutputStr.Substring(rndNo, myStringLen);
            }
            else
            {
                //Console.WriteLine(myOutputStr.Substring(0, myStringLen));
                myOutputData = myOutputStr.Substring(0, myStringLen);
            }

            StreamWriter sw = new StreamWriter("output.txt",true);
            sw.WriteLine(myOutputData);
            sw.Close();
        }
    }
}

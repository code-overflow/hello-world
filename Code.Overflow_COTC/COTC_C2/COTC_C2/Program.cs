using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace COTC_C2
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] inputFileBytes = File.ReadAllBytes(args[0]);
            byte[] outputFileBytes = new byte[inputFileBytes.Length];

            int nHeight = 4000;
            int nWidth = 6000;

            int i=0,j=0,z=0;
            for (j = 0; j < nWidth; j++)
            {
                for (i = 0; i < nHeight; i++)
                {
                    //Console.Write((6000 * i) + j + " : ");
                    outputFileBytes[z] = inputFileBytes[(nWidth * i) + j];
                    z++;
                }
                //Console.WriteLine();
            }

            File.WriteAllBytes(args[1], outputFileBytes);

            Console.WriteLine("Created the transpose of input File Buffer.");
        }
    }
}

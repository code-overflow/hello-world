using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
//using System.Threading.Tasks;

namespace COTC_C1
{
    class Program
    {
        /// <summary>
        /// Mains the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            //string myString = "AshQYy##h#y1543";
            if (args.Length < 2)
            {
                Console.WriteLine("Please provide the PASSWORD and DB File as parameters.");
                Environment.Exit(1);
            }

            //VerifyPasswords("Input.txt");
            //VerifyPassword("2N4iKiPi^", "password-list.txt");
            Console.WriteLine(VerifyPassword(args[0], args[1]));
        }

        /// <summary>
        /// Verifies the password.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <param name="fileName">Name of the file.</param>
        private static String VerifyPassword(string password, string fileName)
        {
            byte[] myAscii = Encoding.ASCII.GetBytes(password);

            //Console.WriteLine("Password:" + password);
            //Console.WriteLine("FileName:"+ fileName);

            int specialStart = 33;
            int specialEnd = 126;
            int capStart = 65;
            int capEnd = 90;
            int smallStart = 97;
            int smallEnd = 122;
            int numStart = 48;
            int numEnd = 57;

            int specialCount = 0;
            int capCount = 0;
            int smallCount = 0;
            int numCount = 0;
            //int charSetCount=0;

            string myResult = "";

            //short[] consecutiveCount = new short[3];
            List<short> specialList = new List<short>();
            short[] specialArray = new short[password.Length];

            if (myAscii.Length >= 8 && myAscii.Length <= 16)
            {
                foreach (byte bChar in myAscii)
                {
                    if (bChar >= specialStart && bChar <= specialEnd)
                    {
                        if (bChar >= capStart && bChar <= capEnd)
                        {
                            capCount++;
                        }
                        else if (bChar >= smallStart && bChar <= smallEnd)
                        {
                            smallCount++;
                        }
                        else if (bChar >= numStart && bChar <= numEnd)
                        {
                            numCount++;
                        }
                        else
                        {
                            specialList.Add(bChar);
                            specialCount++;
                        }
                    }
                    else
                    {
                        myResult = "Result : Non-Compliant.\nReason : Password contains invalid characters.";
                        Console.WriteLine(myResult);
                        Environment.Exit(2);
                    }
                }

                if (specialCount >= 1 && capCount >= 1 && smallCount >= 1 && numCount >= 1)
                {
                    myResult = "Result : Compliant, Password strength: NORMAL.";
                    if (myAscii.Length >= 10 && specialCount >= 1 && capCount >= 2 && smallCount >= 2 && numCount >= 2)
                    {
                        if (!Regex.Match(password, "([a-z]{4,}|[0-9]{4,}|[A-Z]{4,})").Success)
                        {
                            myResult = "Result : Compliant, Password strength: HIGH.";

                            if (myAscii.Length >= 12 && specialCount >= 2)
                            {
                                if (!Regex.Match(password, "([a-z]{3,}|[0-9]{3,}|[A-Z]{3,})").Success)
                                {
                                    List<short> test_list = specialList.Distinct().ToList();
                                    if (test_list.Count > 1)
                                    {
                                        myResult = "Result : Compliant, Password strength: STRONG.";
                                    }
                                }
                            }
                        }
                    }
                }
                else if (specialCount < 1)
                {
                    myResult = "Result : Non-Compliant.";
                    myResult += "\nReason : Password should have atleast one special character.";
                }
                else if(capCount < 1)
                {
                    myResult = "Result : Non-Compliant.";
                    myResult += "\nReason : Password should have atleast one capital letter.";
                }
                else if(smallCount < 1)
                {
                    myResult = "Result : Non-Compliant.";
                    myResult += "\nReason : Password should have atleast one small letter.";                    
                }
                else if(numCount < 1)
                {
                    myResult = "Result : Non-Compliant.";
                    myResult += "\nReason : Password should have atleast one number.";
                }
                else
                {
                    myResult = "Result : Non-Compliant.\nReason : Incorrect Password.";
                }
            }
            else
            {

                myResult = "Result : Non-Compliant.\nReason : Password Length Incorrect.";
                //Console.WriteLine(myResult);
            }

            // Read the whole file and create dictionary and validate if the given password is part of it.
            try
            {
                Boolean matchFound = IsMatchFoundInPasswordList(password, fileName);

                if (matchFound)
                {
                    myResult = "Result : Non-Compliant\n. Matches password in Dictionary.";
                }
            }
            catch
            {
                myResult = "Exception : The DB File could not be read...";
            }
            return myResult;
        }

        /// <summary>
        /// Determines whether [is match found in password list] [the specified arguments].
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <param name="password">My string.</param>
        /// <returns></returns>
        private static Boolean IsMatchFoundInPasswordList(string password, string passwordFileName)
        {
            using (FileStream fs = File.Open(passwordFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    // Do not add any string from file into Dictionary which is of different size than input Password length.
                    if (line == password)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Verifies the passwords. Test to verify the password from the dictionary
        /// This is test code and not required as part of the program
        /// </summary>
        /// <param name="passwordFileName">Name of the password file.</param>
        private static void VerifyPasswords(string passwordFileName)
        {
            using (StreamWriter fsOut = new StreamWriter("PasswordVerificationOutput.txt"))
            {
                using (StreamReader fs = new StreamReader(passwordFileName))
                {
                    string pwd = string.Empty;
                    while ((pwd = fs.ReadLine()) != null)
                    {
                        fsOut.Write(pwd);
                        fsOut.WriteLine(" " + VerifyPassword(pwd, "password-list.txt"));
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SantaSecretHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            int numKey = int.Parse(Console.ReadLine());

            List<string> goodKids = new List<string>();

            string pattern = @"@([A-Za-z]+)[^@\-!:>]*(!)([G])\2";
            Regex regex = new Regex(pattern);

            while (true)
            {
                string encrypted = Console.ReadLine();

                if (encrypted == "end" )
                {
                    //ToDo
                    break;
                }

                StringBuilder sbMessage = new StringBuilder();

                foreach (var letter in encrypted)
                {
                    sbMessage.Append((char)(letter - numKey));  //reducing the currLetter and adding it to string
                }

                string currDecryptedMessage = sbMessage.ToString();  //look for @name onlyletters, !G1 or !N!

                Match match = regex.Match(currDecryptedMessage);  
                //We pick up only string with G-> good-> becasue we create List later only with Good ones

                if (match.Success)
                {                   
                    string takenName = match.Groups[1].Value;
                    goodKids.Add(takenName);                                     
                }
            }

            if (goodKids.Count != 0)
            {
                Console.Write(string.Join('\n',goodKids));
            }
        }
    }
}

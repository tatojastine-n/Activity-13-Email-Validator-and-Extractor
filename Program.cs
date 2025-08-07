using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email_Validator_and_Extractor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] emails = new string[5];
            string[] usernames = new string[5];
            bool[] isValid = new bool[5];

            Console.WriteLine("Enter 5 email addresses:");

            for (int i = 0; i < emails.Length; i++)
            {
                Console.Write($"Email {i + 1}: ");
                string email = Console.ReadLine();
                emails[i] = email;

                isValid[i] = ValidateEmail(email);

                if (isValid[i])
                {
                    int atIndex = email.IndexOf('@');
                    usernames[i] = email.Substring(0, atIndex);
                }
            }
            
            Console.WriteLine("\nValidation Results:");
            
            for (int i = 0; i < emails.Length; i++)
            {
                string result = isValid[i] ? "Valid" : "Invalid";
                Console.WriteLine($"{emails[i]} - {result} {(isValid[i] ? $"(Username: {usernames[i]})" : "")}");
            }
        }
        static bool ValidateEmail(string email)
        {
            if (!email.Contains("@"))
                return false;

            if (!email.EndsWith(".com") && !email.EndsWith(".edu"))
                return false;

            int atIndex = email.IndexOf('@');
            if (atIndex == 0 || atIndex == email.Length - 1) 
                return false;

            return true;
        }
    }
}

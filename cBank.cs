using System;
using System.IO;

namespace cBank
{
    class cBank
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the C# Banking");
            Console.WriteLine("---------------------------");
            
            while (true)
            {
                Console.WriteLine("Please enter your login information, if you dont have a login enter 2 to create a new account");
                Console.WriteLine("If you wish to exit enter 3");
                Console.Write("Username: ");
                string username = Console.ReadLine();
            
                if (username == "2")
                {
                    CreateAccount();
                }

                else if (username == "3")
                {
                    break;
                }

                else
                {
                    Login(username);
                }
            }    
        }

        static void CreateAccount()
        {
            Console.Write("Enter new username: ");
            string newUsername = Console.ReadLine();

            Console.Write("Enter new password: ");
            string newPassword = Console.ReadLine();

            using (StreamWriter sw = new StreamWriter("logins.txt", true))
            {
                sw.WriteLine($"{newUsername},{newPassword}");
            }
            Console.WriteLine("Account created successfully");
        }

        static void Login(string username)
        {
            Console.Write("Password: ");
            string password = Console.ReadLine();

            if (ValidateLogin(username, password))
            {
                Console.WriteLine("Login successful!");
            }

            else
            {
                Console.WriteLine("Invalid username or password");
            }

        }

        static bool ValidateLogin(string username, string password)
        {
            if (File.Exists("logins.txt"))
            {
                string[] lines = File.ReadAllLines("logins.txt");

                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');

                    if (parts.Length == 2)
                    {
                        string storedUsername = parts[0];
                        string storedPassword = parts[1];

                        if (storedUsername == username && storedPassword == password)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
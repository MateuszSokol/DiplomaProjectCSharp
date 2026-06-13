using System;
using System.IO;

namespace DiplomaProjects
{
    internal class UserLogin
    {
        public void Authenticate()
        {
            string filePath = "users.txt";

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Plik users.txt nie istnieje.");
                return;
            }

            string[] lines = File.ReadAllLines(filePath);

            if (lines.Length < 2)
            {
                Console.WriteLine("Nieprawidłowy format pliku users.txt.");
                return;
            }

            string storedUser = lines[0];
            string storedHashedPass = lines[1];

            Console.Write("Login: ");
            string inputUser = Console.ReadLine();

            Console.Write("Password: ");
            string inputPass = Console.ReadLine();

            string inputHashedPass =
                PasswordUtils.HashPassword(inputPass);

            if (inputUser == storedUser &&
                inputHashedPass == storedHashedPass)
            {
                Console.WriteLine("Password and login match");
            }
            else
            {
                Console.WriteLine("Invalid password or login");
            }
        }
    }
}
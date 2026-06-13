using DiplomaProjects.Library;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace DiplomaProjects.login
{
    public class UserLogin
    {
        private readonly ILogger<UserLogin> _logger;

        public UserLogin(ILogger<UserLogin> logger)
        {
            _logger = logger;
        }

        public static void Authenticate()
        {
            string filePath = "users.txt";

            if (!File.Exists(filePath))
            {
                _logger.LogInformation("Plik users.txt nie istnieje.");
                return;
            }

            string[] lines = File.ReadAllLines(filePath);

            if (lines.Length < 2)
            {
                _logger.LogInformation("Nieprawidłowy format pliku users.txt.");
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
                _logger.LogInformation("Password and login match");
            }
            else
            {
                _logger.LogInformation("Invalid password or login");
            }
        }
    }
}
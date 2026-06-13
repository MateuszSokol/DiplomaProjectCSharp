using DiplomaProjects.login;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaProjects.bankingAccount
{
    internal class BankingAccount
    {
        private string ownerFullName { get; set; }
        private string accountNumber { get; set; }
        private double balance { get; set; }
        private readonly ILogger<UserLogin> _logger;

        public BankingAccount(string ownerFullName, string accountNumber, double balance, ILogger<UserLogin> logger)
        {
            this.ownerFullName = ownerFullName;
            this.accountNumber = accountNumber;
            this.balance = balance;
            _logger = logger;
        }
        public void deposit(double amount)
        {
            if (amount > 0)
            {
                balance += amount;
                _logger.LogInformation("Deposit successful!");
            }
            else
            {
                _logger.LogInformation("Amount must be positive.");
            }
        }
        public double getBalance()
        {
            return balance;
        }

        public void withdraw(double amount)
        {
            if (amount > 0 && amount <= balance)
            {
                balance -= amount;
                _logger.LogInformation("Withdraw successful!");
            }
            else if (amount > balance)
            {
                _logger.LogInformation("Insufficient funds.");
            }
            else
            {
                _logger.LogInformation("Only positive amount acceptable.");
            }
        }


        public void displayInfo()
        {
            _logger.LogInformation("Account Holder: " + ownerFullName);
            _logger.LogInformation("Account Number: " + accountNumber);
            _logger.LogInformation($"Balance: {balance:F2}");
        }

   
    }
}

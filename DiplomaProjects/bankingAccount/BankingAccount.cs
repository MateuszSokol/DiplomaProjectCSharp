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

        public BankingAccount(string ownerFullName, string accountNumber, double balance)
        {
            this.ownerFullName = ownerFullName;
            this.accountNumber = accountNumber;
            this.balance = balance;
        }
        public void deposit(double amount)
        {
            if (amount > 0)
            {
                balance += amount;
                Console.WriteLine("Deposit successful!");
            }
            else
            {
                Console.WriteLine("Amount must be positive.");
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
                Console.WriteLine("Withdraw successful!");
            }
            else if (amount > balance)
            {
                Console.WriteLine("Insufficient funds.");
            }
            else
            {
                Console.WriteLine("Only positive amount acceptable.");
            }
        }


        public void displayInfo()
        {
            Console.WriteLine("Account Holder: " + ownerFullName);
            Console.WriteLine("Account Number: " + accountNumber);
            Console.WriteLine($"Balance: {balance:F2}");
        }

   
    }
}

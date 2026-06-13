using Microsoft.Extensions.Logging;

public class BankingAccount
{
    private readonly ILogger<BankingAccount> _logger;

    private string ownerFullName { get; set; }
    private string accountNumber { get; set; }
    private double balance { get; set; }

    public BankingAccount(
        string ownerFullName,
        string accountNumber,
        double balance,
        ILogger<BankingAccount> logger)
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

    public double getBalance() => balance;

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
        _logger.LogInformation(
            "Account Holder: {Holder}, Account Number: {Number}",
            ownerFullName,
            accountNumber);

        _logger.LogInformation("Balance: {Balance}", balance);
    }
}

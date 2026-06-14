using DiplomaProjects.bankingAccount;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

public class BankingAccountTests
{
    private readonly Mock<ILogger<BankingAccount>> _loggerMock;

    public BankingAccountTests()
    {
        _loggerMock = new Mock<ILogger<BankingAccount>>();
    }

    private BankingAccount CreateAccount(
        double initialBalance = 100,
        string owner = "Jan Kowalski",
        string number = "1234567890")
    {
        return new BankingAccount(owner, number, initialBalance, _loggerMock.Object);
    }

    [Fact]
    public void Deposit_PositiveAmount_IncreasesBalance()
    {
        var account = CreateAccount(100);

        account.deposit(50);

        Assert.Equal(150, account.getBalance());
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-10)]
    public void Deposit_NonPositiveAmount_DoesNotChangeBalance(double amount)
    {
        var account = CreateAccount(100);

        account.deposit(amount);

        Assert.Equal(100, account.getBalance());
    }

    [Fact]
    public void Withdraw_ValidAmount_DecreasesBalance()
    {
        var account = CreateAccount(200);

        account.withdraw(50);

        Assert.Equal(150, account.getBalance());
    }

    [Fact]
    public void Withdraw_TooLargeAmount_DoesNotChangeBalance()
    {
        var account = CreateAccount(100);

        account.withdraw(200);

        Assert.Equal(100, account.getBalance());
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-20)]
    public void Withdraw_NonPositiveAmount_DoesNotChangeBalance(double amount)
    {
        var account = CreateAccount(100);

        account.withdraw(amount);

        Assert.Equal(100, account.getBalance());
    }
}

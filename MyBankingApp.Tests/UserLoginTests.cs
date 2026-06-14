using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using DiplomaProjects.login;
using System;
using System.IO;

public class UserLoginTests
{
    private readonly Mock<ILogger<UserLogin>> _loggerMock;

    public UserLoginTests()
    {
        _loggerMock = new Mock<ILogger<UserLogin>>();
    }

    private void WriteUsersFile(string user, string hashedPass)
    {
        File.WriteAllLines("users.txt", new[] { user, hashedPass });
    }

    [Fact]
    public void Authenticate_FileDoesNotExist_LogsMessage()
    {
        if (File.Exists("users.txt"))
            File.Delete("users.txt");

        var login = new UserLogin(_loggerMock.Object);

        login.Authenticate();

        _loggerMock.Verify(
            x => x.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) =>
                    v.ToString()!.Contains("Plik users.txt nie istnieje.")
                ),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    [Fact]
    public void Authenticate_InvalidFileFormat_LogsMessage()
    {
        File.WriteAllLines("users.txt", new[] { "OnlyOneLine" });

        var login = new UserLogin(_loggerMock.Object);

        login.Authenticate();

        _loggerMock.Verify(
            x => x.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) =>
                    v.ToString()!.Contains("Nieprawidłowy format pliku users.txt.")
                ),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    [Fact]
    public void Authenticate_CorrectCredentials_LogsSuccess()
    {
        string user = "Mateusz";
        string pass = "tajnehaslo";
        string hashed = DiplomaProjects.PasswordUtils.HashPassword(pass);

        WriteUsersFile(user, hashed);

        var input = new StringReader($"{user}\n{pass}\n");
        Console.SetIn(input);

        var login = new UserLogin(_loggerMock.Object);

        login.Authenticate();

        _loggerMock.Verify(
            x => x.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) =>
                    v.ToString()!.Contains("Password and login match")
                ),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    [Fact]
    public void Authenticate_InvalidCredentials_LogsFailure()
    {
        string user = "Mateusz";
        string pass = "tajnehaslo";
        string hashed = DiplomaProjects.PasswordUtils.HashPassword(pass);

        WriteUsersFile(user, hashed);

        var input = new StringReader("ZlyUser\nZleHaslo\n");
        Console.SetIn(input);

        var login = new UserLogin(_loggerMock.Object);

        login.Authenticate();

        _loggerMock.Verify(
            x => x.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) =>
                    v.ToString()!.Contains("Invalid password or login")
                ),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }
}
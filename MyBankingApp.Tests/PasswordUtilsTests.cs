using Xunit;
using DiplomaProjects;

public class PasswordUtilsTests
{
    
    [Fact]
    public void HashPassword_ReturnsCorrectSha256Hash()
    {
        string password = "test123";

        string result = PasswordUtils.HashPassword(password);

        string expected =
            "ecd71870d1963316a97e3ac3408c9835ad8cf0f3c1bc703527c30265534f75ae";

        Assert.Equal(expected, result);
    }


    [Fact]
    public void HashPassword_DifferentPasswords_ProduceDifferentHashes()
    {
        string hash1 = PasswordUtils.HashPassword("abc");
        string hash2 = PasswordUtils.HashPassword("xyz");

        Assert.NotEqual(hash1, hash2);
    }

    [Fact]
    public void HashPassword_SamePassword_ProducesSameHash()
    {
        string hash1 = PasswordUtils.HashPassword("hello");
        string hash2 = PasswordUtils.HashPassword("hello");

        Assert.Equal(hash1, hash2);
    }
}

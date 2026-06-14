using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using DiplomaProjects.Library;
using System.Collections.Generic;

public class LibraryTests
{
    private readonly Mock<ILogger<Library>> _loggerMock;

    public LibraryTests()
    {
        _loggerMock = new Mock<ILogger<Library>>();
    }

    private Library CreateLibrary()
    {
        return new Library(_loggerMock.Object);
    }

    private Book CreateBook(
        string title = "Test Book",
        string author = "John Doe",
        string isbn = "12345")
    {
        return new Book(title, author, isbn);
    }

    [Fact]
    public void AddBook_ShouldAddBookToList()
    {
        var library = CreateLibrary();
        var book = CreateBook();

        library.AddBook(book);

        Assert.Single(library.GetBooks());
        Assert.Equal(book, library.GetBooks()[0]);
    }

    [Fact]
    public void RemoveBook_ShouldRemoveBook_WhenIsbnExists()
    {
        var library = CreateLibrary();
        var book = CreateBook(isbn: "ABC123");

        library.AddBook(book);

        var result = library.RemoveBook("ABC123");

        Assert.True(result);
        Assert.Empty(library.GetBooks());
    }

    [Fact]
    public void RemoveBook_ShouldReturnFalse_WhenIsbnDoesNotExist()
    {
        var library = CreateLibrary();
        library.AddBook(CreateBook(isbn: "111"));

        var result = library.RemoveBook("999");

        Assert.False(result);
        Assert.Single(library.GetBooks());
    }

    [Fact]
    public void FindByTitle_ShouldReturnCorrectBook_IgnoringCase()
    {
        var library = CreateLibrary();
        library.AddBook(CreateBook(title: "Harry Potter"));

        var result = library.FindByTitle("harry potter");

        Assert.NotNull(result);
        Assert.Equal("Harry Potter", result.bookTitle);
    }

    [Fact]
    public void FindByTitle_ShouldReturnUnknownBook_WhenNotFound()
    {
        var library = CreateLibrary();

        var result = library.FindByTitle("Nonexistent");

        Assert.Equal("Unknown", result.bookTitle);
        Assert.Equal("Unknown", result.author);
        Assert.Equal("Unknown", result.ISBN);
    }

    [Fact]
    public void DisplayLibraryStorage_ShouldLogEachBook()
    {
        var library = CreateLibrary();
        library.AddBook(CreateBook("Book1", "A", "1"));
        library.AddBook(CreateBook("Book2", "B", "2"));

        library.DisplayLibraryStorage();

        _loggerMock.Verify(
            x => x.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString()!.Contains("Book title:")),
                It.IsAny<System.Exception>(),
                It.IsAny<System.Func<It.IsAnyType, System.Exception?, string>>()),
            Times.Exactly(2));
    }
}

using System.Collections.Generic;
using Xunit;
using DiplomaProjects.dataOperation;

public class DataOperationsTests
{
    private List<Student> CreateStudents()
    {
        return new List<Student>
        {
            new Student(1, "Adam", "Male"),
            new Student(2, "Ewa", "Female"),
            new Student(3, "Kamil", "Male")
        };
    }

    [Fact]
    public void FindStudent_ReturnsCorrectStudent_WhenIdExists()
    {
        var students = CreateStudents();

        var result = DataOperations.FindStudent(students, 1);

        Assert.NotNull(result);
        Assert.Equal("Adam", result.studentName);
    }

    [Fact]
    public void FindStudent_ReturnsNull_WhenIdDoesNotExist()
    {
        var students = CreateStudents();

        var result = DataOperations.FindStudent(students, 999);

        Assert.Null(result);
    }

    [Fact]
    public void FindOnlyMaleStudents_ReturnsOnlyMales()
    {
        var students = CreateStudents();

        var result = DataOperations.FindOnlyMaleStudents(students);

        Assert.Equal(2, result.Count);
        Assert.All(result, s => Assert.Equal("Male", s.gender));
    }

    [Fact]
    public void SortedStudentByName_ReturnsStudentsSortedAlphabetically()
    {
        var students = CreateStudents();

        var result = DataOperations.SortedStudentByName(students);

        Assert.Equal("Adam", result[0].studentName);
        Assert.Equal("Ewa", result[1].studentName);
        Assert.Equal("Kamil", result[2].studentName);
    }
}

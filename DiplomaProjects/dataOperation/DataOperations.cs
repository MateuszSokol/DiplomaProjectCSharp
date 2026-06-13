using System.Collections.Generic;
using System.Linq;

namespace DiplomaProjects.dataOperation
{
    public static class DataOperations
    {
        public static Student? FindStudent(List<Student> students, int id)
        {
            return students.FirstOrDefault(s => s.studentId == id);
        }

        public static List<Student> FindOnlyMaleStudents(List<Student> students)
        {
            string gender = "Male";

            return students
                .Where(s => s.gender == gender)
                .ToList();
        }

        public static List<Student> SortedStudentByName(List<Student> students)
        {
            return students
                .OrderBy(s => s.studentName)
                .ToList();
        }
    }
}
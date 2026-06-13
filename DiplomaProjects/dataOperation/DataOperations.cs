using System.Collections.Generic;
using System.Linq;

namespace DiplomaProjects.dataOperation
{
    public class DataOperations
    {
        public Student? FindStudent(List<Student> students, int id)
        {
            return students.FirstOrDefault(s => s.studentId == id);
        }

        public List<Student> FindOnlyMaleStudents(List<Student> students)
        {
            string gender = "Male";

            return students
                .Where(s => s.gender == gender)
                .ToList();
        }

        public List<Student> SortedStudentByName(List<Student> students)
        {
            return students
                .OrderBy(s => s.studentName)
                .ToList();
        }
    }
}
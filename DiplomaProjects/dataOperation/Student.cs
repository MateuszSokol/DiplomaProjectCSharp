using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaProjects.dataOperation
{
    public class Student
    {
        public int studentId { get; set; }
        public string studentName { get; set; }
        public string gender { get; set; }
        ArrayList students = new ArrayList();

        public Student(int studentId, string studentName, string gender)
        {
            this.studentId = studentId;
            this.studentName = studentName;
            this.gender = gender;
        }
    }
}

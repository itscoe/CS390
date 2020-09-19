using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS390
{
    class Course
    {
        string courseID;
        string courseName;
        string courseDescription;
        Faculty faculty;
        SortedDictionary<string ,Student> enrolledStudents;

        public Course(string courseID, string courseName, string courseDescription, Faculty faculty)
        {
            this.courseID = courseID;
            this.courseName = courseName;
            this.courseDescription = courseDescription;
            this.faculty = faculty;
            enrolledStudents = new SortedDictionary<string, Student>();
        }

        public void EnrollStudent(Student student)
        {
            enrolledStudents.Add(student.GetUserName(), student);
        }

        public void WithdrawStudent(Student student)
        {
            enrolledStudents.Remove(student.GetUserName());
        }
    }
}

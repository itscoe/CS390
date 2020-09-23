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
        Faculty faculty;
        string courseCredit;
        int numSeats;
        List<string> dayBlocks;
        List<string> timeBlocks;

        SortedDictionary<string ,Student> enrolledStudents;
        
        public Course(string courseID, string courseName, Faculty faculty, string courseCredit, int numSeats, List<string> days, List<string> times)
        {
            this.courseID = courseID;
            this.courseName = courseName;
            this.faculty = faculty;
            this.courseCredit = courseCredit;
            this.numSeats = numSeats;
            this.dayBlocks = days;
            this.timeBlocks = times;

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

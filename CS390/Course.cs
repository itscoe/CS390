using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS390
{
    class Course
    {
        public string courseID;
        public string courseName;
        public Faculty faculty;
        public string courseCredit;
        public int numSeats;
        public List<string> dayBlocks;
        public List<string> timeBlocks;

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
        public string GetCourseID()
        {
            return courseID;
        }
        public string GetCourseName()
        {
            return courseName;
        }
        public Faculty GetFaculty()
        {
            return faculty;
        }
        public string GetCourseCredit()
        {
            return courseCredit;
        }
        public int GetNumSeats()
        {
            return numSeats;
        }
        public void SetCourseID(string newCourseid)
        {
            courseID = newCourseid;
        }
        public void SetCourseName(string newCourseName)
        {
            courseName = newCourseName;
        }
        public void SetFaculty(Faculty newFaculty)
        {
            faculty = newFaculty;
        }
        public void SetCourseCredit(string newCourseCredit)
        {
            courseCredit = newCourseCredit;
        }

        public List<string> GetTimeBlocks()
        {
            return timeBlocks;
        }

        public List<string> GetDayBlocks()
        {
            return dayBlocks;
        }

    }

}

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

        Student student;
        int numCourses;
        List<string> courseIDs;
        List<string> courseCredits;
        List<string> terms;
        List<string> grades;

        SortedDictionary<string ,Student> enrolledStudents;
        
        /// <summary>
        /// Used for CourseDatabase Creation
        /// </summary>
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

        /// <summary>
        /// Used for CourseHistoryDatabase Creation
        /// </summary>
        public Course(Student student, int numCourses, List<string> courseIDs, List<string> terms, List<string> courseCredits, List<string> grades)
        {
            this.student = student;
            this.numCourses = numCourses;
            this.courseIDs = courseIDs;
            this.terms = terms;
            this.courseCredits = courseCredits;
            this.grades = grades;
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

        public int GetHistoryNumCourses() { return numCourses; }
        public List<string> GetHistoryCourseIDs() { return courseIDs; }
        public List<string> GetHistoryCourseCredits() { return courseCredits; }
        public List<string> GetHistoryTerms() { return terms; }
        public List<string> GetHistoryGrades() { return grades; }

    }

}

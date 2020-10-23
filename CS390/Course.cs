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
        string term;
        string grade;

        SortedDictionary<string ,Student> enrolledStudents = new SortedDictionary<string, Student>();
        
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
        public Course(Student student, string courseID, string term, string courseCredit, string grade)
        {
            this.student = student;
            this.courseID = courseID;
            this.term = term;
            this.courseCredit = courseCredit;
            this.grade = grade;
        }
       
        public Course ConvertToCourseHistory(Student student, string term = "S15", string grade = "N")
        {
            return new Course(student, courseID, term, courseCredit, grade);
        }
        
        public void EnrollStudent(Student student)
        {
            enrolledStudents.Add(student.GetUserName(), student);
            numSeats--;
        }
        public void WithdrawStudent(Student student)
        {
            enrolledStudents.Remove(student.GetUserName());
            numSeats++;
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

        public SortedDictionary<string, Student> GetEnrolledStudents()
        {
            return enrolledStudents;
        }

        public string GetCourseTerm() { return term; }

        public string GetGrade() { return grade; }

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

        public bool IsCreditGrade()
        {
            switch (grade)
            {
                case "U":
                    return false;
                case "W":
                    return false;
                case "O":
                    return false;
                case "I":
                    return false;
                case "EQ":
                    return false;
            }
            return true;
        }

    }

}

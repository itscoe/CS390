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
        List<string> dayBlocks = new List<string>();
        List<string> timeBlocks = new List<string>();
        List<int> dayTimeBlocks;

        Student student;
        string term;
        string grade;

        SortedDictionary<string ,Student> enrolledStudents = new SortedDictionary<string, Student>();
        
        /// <summary>
        /// Used for CourseDatabase Creation
        /// </summary>
        public Course(string courseID, string courseName, Faculty faculty, string courseCredit, int numSeats, List<int> dayTime)
        {
            this.courseID = courseID;
            this.courseName = courseName;
            this.faculty = faculty;
            this.courseCredit = courseCredit;
            this.numSeats = numSeats;
            this.dayTimeBlocks = dayTime;

            enrolledStudents = new SortedDictionary<string, Student>();
            ConvertDayTimeBlocks();
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

        public List<int> GetDayTimeBlocks()
        {
            return dayTimeBlocks;
        }

        public void AddDayTimeBlock(int dayTime)
        {
            dayTimeBlocks.Add(dayTime);
            ConvertDayTimeBlocks();
        }

        public void ChangeDayTimeBlock(int index, int newDayTime)
        {
            dayTimeBlocks[index] = newDayTime;
            ConvertDayTimeBlocks();
        }

        public void RemoveDayTimeBlock(int dayTime)
        {
            dayTimeBlocks.Remove(dayTime);
            ConvertDayTimeBlocks();
        }

        public void ConvertDayTimeBlocks()
        {
            dayBlocks.Clear();
            timeBlocks.Clear();

            foreach(int x in dayTimeBlocks)
            {
                string days = "";
                string times = "";

                int day = x / 1000;

                if (day >= 16)
                {
                    day -= 16;
                    days += "F";
                }
                if (day >= 8)
                {
                    day -= 8;
                    days += "R";
                }
                if (day >= 4)
                {
                    day -= 4;
                    days += "W";
                }
                if (day >= 2)
                {
                    day -= 2;
                    days += "T";
                }
                if (day == 1)
                {
                    day -= 1;
                    days += "M";
                }

                dayBlocks.Add(ReverseString(days));

                float time = (((x / 10) % 100) / 2);

                if (time >= 12)
                {
                    if (time > 12)
                        time -= 12;
                    int minute = (int)(((decimal)time % 1) * 10);
                    minute = (60 / 10) * minute;
                    times += time + ":" + minute + "0" + " PM";
                }
                else
                {
                    int minute = (int)(((decimal)time % 1) * 10);
                    minute = (60 / 10) * minute;
                    times += time + ":" + minute + "0" + " AM";

                }

                timeBlocks.Add(times);
            }
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

        static string ReverseString(string x)
        {
            char[] y = x.ToCharArray();
            Array.Reverse(y);
            return new string(y);
        }
    }
}

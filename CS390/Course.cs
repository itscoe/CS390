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
        // start of prerequisite extra-credit
        List<string> coursePrerequisites = new List<string>();

        Student student;
        string term;
        string grade;

        // Dictionary that holds all currently enrolled students of this course
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

        public Course(string courseID, string courseName, Faculty faculty, string courseCredit, int numSeats, List<string> dayBlocks, List<string> timeBlocks)
        {
            this.courseID = courseID;
            this.courseName = courseName;
            this.faculty = faculty;
            this.courseCredit = courseCredit;
            this.numSeats = numSeats;
            this.dayBlocks = dayBlocks;
            this.timeBlocks = timeBlocks;
            this.dayTimeBlocks = new List<int>();

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
       
        /// <summary>
        /// Converts a Course into a CourseHisory course.
        /// </summary>
        /// <param name="student">Student Object for this course to be assigned to.</param>
        /// <param name="term">Defaults to the next term.</param>
        /// <param name="grade">Defaults to "N"</param>
        /// <returns>A Course History Object</returns>
        public Course ConvertToCourseHistory(Student student, string term = "S15", string grade = "N")
        {
            return new Course(student, courseID, term, courseCredit, grade);
        }
        
        /// <summary>
        /// Adds Student to enrolled students dictionary and removes a seat.
        /// </summary>
        /// <param name="student">Student to be added to enrolled students.</param>
        public void EnrollStudent(Student student)
        {
            enrolledStudents.Add(student.GetUserName(), student);
            numSeats--;
        }

        /// <summary>
        /// Removes Student from enrolled students dictionary and adds a seat.
        /// </summary>
        /// <param name="student">Student to be removed from enrolled students.</param>
        public void WithdrawStudent(Student student)
        {
            enrolledStudents.Remove(student.GetUserName());
            numSeats++;
        }

        // Regular Get Functions
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

        public string GetCourseTerm() { return term; }

        public string GetGrade() { return grade; }

        /// <summary>
        /// Returns entire enrolledStudents dictionary.
        /// </summary>
        public SortedDictionary<string, Student> GetEnrolledStudents()
        {
            return enrolledStudents;
        }

        // Regular Set Functions
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

        public void SetDayBlocks(List<string> newDayBlocks)
        {
            dayBlocks = newDayBlocks;
        }

        public void SetTimeBlocks(List<string> newTimeBlocks)
        {
            timeBlocks = newTimeBlocks;
        }

        public void SetCourseCredit(string newCourseCredit)
        {
            courseCredit = newCourseCredit;
        }

        // Weird DayTime Block Functions
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

        /// <summary>
        /// Adds a dayTimeBlock and starts conversion proess.
        /// </summary>
        /// <param name="dayTime">##### of a timeblock</param>
        public void AddDayTimeBlock(int dayTime)
        {
            dayTimeBlocks.Add(dayTime);
            ConvertDayTimeBlocks();
        }

        /// <summary>
        /// Adds a dayTimeBlock and starts conversion proess.
        /// </summary>
        /// <param name="newDayTime">##### of a timeblock</param>
        public void ChangeDayTimeBlock(int index, int newDayTime)
        {
            dayTimeBlocks[index] = newDayTime;
            ConvertDayTimeBlocks();
        }

        /// <summary>
        /// Removes a dayTimeBlock and starts conversion proess.
        /// </summary>
        /// <param name="dayTime">##### code of a timeblock</param>
        public void RemoveDayTimeBlock(int dayTime)
        {
            dayTimeBlocks.Remove(dayTime);
            ConvertDayTimeBlocks();
        }

        /// <summary>
        /// Used to be in RegistrationDatabase class, but was moved to Course to make changing dayTime blocks much easier.
        /// </summary>
        public void ConvertDayTimeBlocks()
        {
            // Removes everything from both day and timeBlock lists
            dayBlocks.Clear();
            timeBlocks.Clear();

            foreach(int x in dayTimeBlocks)
            {
                string days = "";
                string times = "";

                // first finds the days of the class
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

                // reverses string because it was made backwards
                dayBlocks.Add(ReverseString(days));

                // honestly, just trust that this whole time making thing works.
                // lots of casting goes on, converting floats to decimal to ints for the minutes.
                float time = (((x / 10) % 100) / 2);

                //If time is over 12, convert it out of military time and smack a PM on the end of it
                if (time >= 12)
                {
                    if (time > 12)
                        time -= 12;
                    int minute = (int)(((decimal)time % 1) * 10);
                    minute = (60 / 10) * minute;
                    times += time + ":" + minute + "0" + " PM";
                }
                // otherwise, leave time as-is and put an AM on it
                else
                {
                    int minute = (int)(((decimal)time % 1) * 10);
                    minute = (60 / 10) * minute;
                    times += time + ":" + minute + "0" + " AM";

                }

                timeBlocks.Add(times);
            }
        }

        /// <summary>
        /// Bool function to check if a given course counts towards credits earned.
        /// </summary>
        /// <returns>True if anything but U, W, O, I, or EQ</returns>
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


        /// <summary>
        /// Helper function to reverse arrays of chars. Used by ConvertDayTimeBlocks.
        /// </summary>
        static string ReverseString(string x)
        {
            char[] y = x.ToCharArray();
            Array.Reverse(y);
            return new string(y);
        }
    }
}

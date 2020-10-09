using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS390
{
    class RegistrationDatabase
    {
        public enum DatabaseType
        {
            user,
            course,
            courseHistory
        }

        static SortedDictionary<string, User> userDatabase = new SortedDictionary<string, User>();
        static SortedDictionary<string, Course> courseDatabase = new SortedDictionary<string, Course>();

        public static void Read(StreamReader file, DatabaseType databaseType)
        {
            switch (databaseType)
            {
                case DatabaseType.user:
                    while(!file.EndOfStream)
                    {
                        string userInfo = file.ReadLine();
                        string user = userInfo.Substring(0,11).TrimEnd(' '); userInfo = userInfo.Remove(0, 11);
                        string pass = userInfo.Substring(0,11).TrimEnd(' '); userInfo = userInfo.Remove(0, 11);
                        string first = userInfo.Substring(0, 16).TrimEnd(' '); userInfo = userInfo.Remove(0, 16);
                        string middle = userInfo.Substring(0, 16).TrimEnd(' '); userInfo = userInfo.Remove(0, 16);
                        string last = userInfo.Substring(0, 16).TrimEnd(' '); userInfo = userInfo.Remove(0, 16);
                        string stat = userInfo.Substring(0, userInfo.Length).TrimEnd(' ');

                        CreateUser(user, pass, first, middle, last, stat);
                    }
                    break;
                case DatabaseType.course:
                    while(!file.EndOfStream)
                    {
                        string courseInfo = file.ReadLine();
                        string courseName = courseInfo.Substring(0, 11).TrimEnd(' '); courseInfo = courseInfo.Remove(0, 11);
                        string courseTitle = courseInfo.Substring(0, 16).TrimEnd(' '); courseInfo = courseInfo.Remove(0, 16);
                        Faculty faculty = (Faculty)GetUser(courseInfo.Substring(0,11).TrimEnd(' ')); courseInfo = courseInfo.Remove(0, 11);
                        string courseCredit = courseInfo.Substring(0, 5).TrimEnd(' '); courseInfo = courseInfo.Remove(0, 5);
                        int seatCount = Convert.ToInt16(courseInfo.Substring(0,4).TrimEnd(' ')); courseInfo = courseInfo.Remove(0, 4);
                        int blocks = Convert.ToInt16(courseInfo.Substring(0,2).TrimEnd(' ')); courseInfo = courseInfo.Remove(0, 2);
                   
                        List<string> dayBlocks = new List<string>();
                        List<string> timeBlocks = new List<string>();

                        for(int x = 1; x <= blocks; x++)
                        {
                            int timeBlock = Convert.ToInt16(courseInfo.Substring(0,6).TrimEnd(' ')); courseInfo = courseInfo.Remove(0, 6);
                            string days = "";
                            string times = "";
                            int day = timeBlock / 1000;

                            if (day >= 16) {
                                day -= 16;
                                days += "F";
                            }
                            if(day >= 8) {
                                day -= 8;
                                days += "R";
                            }
                            if(day >= 4) {
                                day -= 4;
                                days += "W";
                            }
                            if(day >= 2) {
                                day -= 2;
                                days += "T";
                            }
                            if(day == 1) {
                                day -= 1;
                                days += "M";
                            }

                            dayBlocks.Add(ReverseString(days));

                            float time = (((timeBlock / 10) % 100) / 2);

                            if (time >= 12)
                            {    
                                if(time > 12)
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

                        CreateCourse(courseName, courseTitle, faculty, courseCredit, seatCount, dayBlocks, timeBlocks);
                    }
                    break;
                case DatabaseType.courseHistory:
                    while(!file.EndOfStream)
                    {
                        string historyInfo = file.ReadLine();
                        string user = historyInfo.Substring(0, 11).TrimEnd(' '); historyInfo = historyInfo.Remove(0, 11);
                        int numCourses = Convert.ToInt16(historyInfo.Substring(0, 3).TrimEnd(' ')); historyInfo = historyInfo.Remove(0, 3);
                        Console.WriteLine(numCourses);
                        string courseID;
                        string term;
                        string credit;
                        string grade;

                        for(int i = 0; i < numCourses; i++)
                        {
                            courseID = historyInfo.Substring(0, 11).TrimEnd(' '); historyInfo = historyInfo.Remove(0, 11);
                            term = historyInfo.Substring(0, 4).TrimEnd(' '); historyInfo = historyInfo.Remove(0, 4);
                            credit = historyInfo.Substring(0, 5).TrimEnd(' '); historyInfo = historyInfo.Remove(0, 5);
                            grade = historyInfo.Substring(0, 4).TrimEnd(' '); historyInfo = historyInfo.Remove(0, 4);

                            CreateHistory(user, numCourses, courseID, term, credit, grade);
                        }
                    }
                break;
            }
        }

        static void CreateCourse(string courseID, string courseName, Faculty faculty, string courseCredit,
            int numSeats, List<string> days, List<string> times)
        {
            Course course;
            course = new Course(courseID, courseName, faculty, courseCredit, numSeats, days, times);

            courseDatabase.Add(courseID, course);
        }

        static void CreateUser(string userName, string password, string firstName,
                string middleName, string lastName, string status)
        {
            User user;

            if (status.Equals("admin")) {
                user = new Admin(userName, password, firstName, middleName, lastName, status);
            }
            else if (status.Equals("faculty")) {
                user = new Faculty(userName, password, firstName, middleName, lastName, status);
            }
            else {
                user = new Student(userName, password, firstName, middleName, lastName, status);
            }

            userDatabase.Add(userName, user);
        }

        static void CreateHistory(string userName, int numCourses, string courseName, string term, string courseCredit, string grade)
        {
            Student student = (Student)GetUser(userName);
            Course course = new Course(student, numCourses, courseName, term, courseCredit, grade);
            student.AddCourseHistory(course);
        }

        public static Course GetCourse(string courseID)
        {
            try
            {
                return courseDatabase[courseID];
            }
            catch
            {
                return null;
            }
        }

        public static SortedDictionary<string, Course> GetCourses()
        {
            return courseDatabase;
        }

        /// <summary>
        /// Helper method used to bypass verification, only used by RegistrationDatabase methods.
        /// </summary>
        /// <param name="userName">Username of the User</param>
        /// <returns>User from User Database</returns>
        static User GetUser(string userName)
        {
            try
            {
                return userDatabase[userName];
            }
            catch
            {
                return null;
            }
        }

        public static User GetUser(string userName, string password)
        {
            if (VerifyUser(userName, password))
                return userDatabase[userName];
            else
                return null;
        }

        static bool VerifyUser(string userName, string password)
        {
            // try-catch statement verifies that the user exists inside the dictionary
            try
            {
                // assigns new user object to element <userName> in userDatabase
                User user = userDatabase[userName];

                // tests if the user object's password is the same as password passed.
                if (user.GetPassword().Equals(password))
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }


        void GetTransaction()
        {

        }

        static string ReverseString(string x)
        {
            char[] y = x.ToCharArray();
            Array.Reverse(y);
            return new string(y);
        }
    }
}

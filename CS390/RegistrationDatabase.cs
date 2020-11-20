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
        // use of enums to determine which database is being read
        public enum DatabaseType
        {
            user,
            course,
            courseHistory,
            // start of prerequisite extra-credit
            coursePrerequisite
        }

        // both static to retain same memory throughout life of the program.
        // basically, this whole class either IS or SHOULD be static. RegistrationDatabase is never created as an object, just used as a helper class.
        public static SortedDictionary<string, User> userDatabase = new SortedDictionary<string, User>();
        static SortedDictionary<string, Course> courseDatabase = new SortedDictionary<string, Course>();

        // The main performance of the class is this, the read function.
        /// <summary>
        /// Reads in information from File, assigning the info to proper database using DatabaseType
        /// </summary>
        /// <param name="file">File to be Read into Database</param>
        /// <param name="databaseType">Enum Type of Database to Read</param>
        public static void Read(StreamReader file, DatabaseType databaseType)
        {
            // switch statement on databaseType
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

                        // takes gathered information and pushes it into a helper function to create User object
                        CreateUser(user, pass, first, middle, last, stat);
                    }
                    // builds a list of advisee students for each faculty user object 
                    BuildStudentAdviseeList();
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

                        // We used to do the conversion of the ##### code here, but we moved it into
                        // the course class to more easily change, add, or remove dayTime blocks.
                        List<int> dayTimeBlocks = new List<int>();

                        for (int x = 1; x <= blocks; x++)
                        {
                            int timeBlock = 0;

                            // this if statement just ensures that we don't get an out of bounds error
                            if (x < blocks)
                            {
                                timeBlock = Convert.ToInt16(courseInfo.Substring(0, 6).TrimEnd(' ')); courseInfo = courseInfo.Remove(0, 6);
                            }
                            else
                                timeBlock = Convert.ToInt16(courseInfo.Substring(0, courseInfo.Length).TrimEnd(' '));

                            dayTimeBlocks.Add(timeBlock);
                        }
                        
                        // gathered information is pushed to helper function to create a course object
                        CreateCourse(courseName, courseTitle, faculty, courseCredit, seatCount, dayTimeBlocks);
                    }
                    // Takes built course database and adds it to the correct faculty User object
                    AddCoursesToFaculty();
                break;
                case DatabaseType.courseHistory:
                    while(!file.EndOfStream)
                    {
                        string historyInfo = file.ReadLine();
                        string user = historyInfo.Substring(0, 11).TrimEnd(' '); historyInfo = historyInfo.Remove(0, 11);
                        int numCourses = Convert.ToInt16(historyInfo.Substring(0, 3).TrimEnd(' ')); historyInfo = historyInfo.Remove(0, 3);
                        string courseID;
                        string term;
                        string credit;
                        string grade;

                        // for loop goes through all the courses per user for a given User
                        for(int i = 0; i < numCourses; i++)
                        {
                            courseID = historyInfo.Substring(0, 11).TrimEnd(' '); historyInfo = historyInfo.Remove(0, 11);
                            term = historyInfo.Substring(0, 4).TrimEnd(' '); historyInfo = historyInfo.Remove(0, 4);
                            credit = historyInfo.Substring(0, 5).TrimEnd(' '); historyInfo = historyInfo.Remove(0, 5);
                            if (i < numCourses - 1) {
                                grade = historyInfo.Substring(0, 4).TrimEnd(' '); historyInfo = historyInfo.Remove(0, 4);
                            }
                            else
                                grade = historyInfo.Substring(0, historyInfo.Length).TrimEnd(' ');
                            CreateHistory(user, courseID, term, credit, grade);
                        }
                    }
                    // Same as the previous two functions like this, but adds student objects to a course list.
                    AddStudentsToCourses();
                break;
            }
        }

        /// <summary>
        /// Helper function for Read, creates a course object and adds it to the course database.
        /// </summary>
        static void CreateCourse(string courseID, string courseName, Faculty faculty, string courseCredit,
            int numSeats, List<int> dayTime)
        {
            Course course;
            course = new Course(courseID, courseName, faculty, courseCredit, numSeats, dayTime);

            courseDatabase.Add(courseID, course);
        }

        public static void CreateCourse(Course course, string courseID)
        {
            courseDatabase.Add(courseID, course);
        }

        /// <summary>
        /// Helper function for Read, creates a user object and adds it to the user database.
        /// </summary>
        public static void CreateUser(string userName, string password, string firstName,
                string middleName, string lastName, string status)
        {
            User user;

            if (status.Equals("admin") || status.Equals("manager")) {
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

        /// <summary>
        /// Helper function for Read, creates a polymorphisized course object and adds it to the course history list in a student object.
        /// </summary>
        static void CreateHistory(string userName, string courseName, string term, string courseCredit, string grade)
        {
            Student student = (Student)GetUser(userName);
            Course course = new Course(student, courseName, term, courseCredit, grade);
            student.AddCourseHistory(course);
        }

        /// <summary>
        /// Builds the list inside faculty objects that holds student advisees.
        /// </summary>
        static void BuildStudentAdviseeList()
        {
            // runs through every key and user object inside user database
            foreach(KeyValuePair<string, User> user in userDatabase)
            {
                if(!user.Value.GetStatus().Equals("admin") && !user.Value.GetStatus().Equals("manager") && !user.Value.GetStatus().Equals("faculty"))
                {
                    Faculty faculty = (Faculty)GetUser(user.Value.GetStatus());
                    faculty.AddStudentAdvisee((Student)user.Value);
                }
            }
        }

        /// <summary>
        /// Builds the list inside faculty objects that holds courses taught.
        /// </summary>
        static void AddCoursesToFaculty()
        {
            foreach(KeyValuePair<string, Course> course in courseDatabase)
            {
                Faculty faculty = course.Value.GetFaculty();
                faculty.AddCourse(course.Value.GetCourseID());
            }
        }

        /// <summary>
        /// Builds the list inside course objects that holds current students.
        /// </summary>
        static void AddStudentsToCourses()
        {
            foreach(KeyValuePair<string, User> user in userDatabase)
            {
                if(!user.Value.GetStatus().Equals("admin") && !user.Value.GetStatus().Equals("manager") && !user.Value.GetStatus().Equals("faculty"))
                {
                    Student student = (Student)user.Value;
                    List<Course> courses = student.GetCourseHistory();
                    foreach(Course course in courses)
                    {
                        // this ensures that the course is valid and that it is in progress
                        if (course.GetGrade() != null && course.GetGrade() == "N")
                        {
                            GetCourse(course.GetCourseID()).EnrollStudent(student);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets a course of courseID from courseDatabase
        /// </summary>
        /// <param name="courseID">Valid ID of a course inside courseDatabase</param>
        /// <returns>Returns Course of courseID if valid, returns null if not.</returns>
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

        /// <summary>
        /// Returns the Course Database
        /// </summary>
        /// <returns>Course Database</returns>
        public static SortedDictionary<string, Course> GetCourses()
        {
            return courseDatabase;
        }

        /// <summary>
        /// Returns the User Database.
        /// </summary>
        /// <returns>User Database</returns>
        public static SortedDictionary<string, User> GetUserDatabase()
        {
            return userDatabase;
        }

        /// <summary>
        /// Helper method used to bypass verification, only used by RegistrationDatabase methods and a few other cases.
        /// </summary>
        /// <param name="userName">Username of the User</param>
        /// <returns>User from User Database</returns>
        public static User GetUser(string userName)
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

        /// <summary>
        /// Gets User after authenticating username and password.
        /// </summary>
        /// <param name="userName">Username of the user.</param>
        /// <param name="password">Password of the user.</param>
        /// <returns>Authenticated User</returns>
        public static User GetUser(string userName, string password)
        {
            if (VerifyUser(userName, password))
                return userDatabase[userName];
            else
                return null;
        }

        /// <summary>
        /// Verifies that the user exists within User Database.
        /// </summary>
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

        /// <summary>
        /// Removes a user from the User Database
        /// </summary>
        /// <param name="userName">Username of a Faculty or Student</param>
        public static void RemoveUser(string userName)
        {
            try
            {
                if(userDatabase[userName].GetStatus().Equals("faculty"))
                {
                    Faculty faculty = (Faculty)userDatabase[userName];

                    foreach(KeyValuePair<string, Course> course in faculty.GetCourses())
                    {
                        course.Value.SetFaculty((Faculty)RegistrationDatabase.GetUser("Staff"));
                    }

                    foreach(Student student in faculty.GetStudentAdvisees())
                    {
                        student.ChangeAdvisor("Staff");
                    }

                    userDatabase.Remove(userName);
                }
                else // if (userDatabase[userName].GetStatus().Equals("student"))
                {
                    Student student = (Student)userDatabase[userName];

                    foreach(KeyValuePair<string, Course> course in student.GetCourses())
                    {
                        course.Value.WithdrawStudent(student);
                        student.DropCourse(course.Value.GetCourseID());
                    }

                    Faculty faculty = (Faculty)userDatabase[student.GetStatus()];         
                    userDatabase.Remove(userName);
                    faculty.RemoveStudentAdvisee((Student)RegistrationDatabase.GetUser("PRyan"));
                    //student.ChangeAdvisor("Staff");
                }

            }
            catch
            {
                Console.WriteLine(String.Format("User \"{0}\" Not Found!", userName));
            }
        }

        /// <summary>
        /// Removes a course from the Course Database
        /// </summary>
        /// <param name="courseID">Course ID of a Course</param>
        public static void RemoveCourse(string courseID)
        {
            try
            {
                Course course = courseDatabase[courseID];

                course.GetFaculty().DropCourse(courseID);

                foreach(KeyValuePair<string, Student> student in course.GetEnrolledStudents() )
                {
                    foreach (KeyValuePair<string, Course> courseS in student.Value.GetCourses())
                    {
                        if (courseS.Value.GetCourseTerm() != null && courseS.Value.GetCourseTerm().Equals("S15"))
                        {
                            if (courseS.Value.GetCourseID() == courseID)
                                student.Value.DropCourse(courseID);
                        }
                    }
                }

                courseDatabase.Remove(courseID);
            }
            catch
            {
                Console.WriteLine(String.Format("Course \"{0}\" Not Found!", courseID));
            }
        }
    }
}

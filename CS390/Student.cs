using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS390
{
    class Student : User
    {
        SortedDictionary<string, Course> enrolledCourses = new SortedDictionary<string, Course>();
        List<Course> courseHistory = new List<Course>();

        public Student(string userName = "", string password = "", string firstName = "", string middleName = "", string lastName = "", string status = "")
            : base(userName, password, firstName, middleName, lastName, status) { }
 
        /// <summary>
        /// Accesses user's transaction history with the database.
        /// </summary>
        public override void ViewTransactionHistory()
        {

        }
        public void AddCourse(string courseID)
        //adds courseName to enrolledCourses
        {
            enrolledCourses.Add(courseID, RegistrationDatabase.GetCourse(courseID));
        }
        public void DropCourse(string courseID)
        //verify if courseName is in enrolledCourses
        //remove courseName from enrolledCourses
        {
            try
            {
                enrolledCourses.Remove(courseID);
            }
            catch(Exception e)
            {
                return;
            }
        }
        void ViewSchedule()
        //print out enrolledCourses
        {

        }
        public void AddCourseHistory(Course course)
        //access registrationDataBase
        {
            courseHistory.Add(course);
        }

        public List<Course> GetCourseHistory()
        {
            return courseHistory;
        }
        public SortedDictionary<string, Course> GetCourses()
        {
            return enrolledCourses;
        }
    }
}

//implement later
// void Petition;
// void checkGraduation;
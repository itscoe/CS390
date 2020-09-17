using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS390
{
    class Student : User
    {
        // SortedDictionary<Course> enrolledCourses;
        string userName;
        string password;
        string firstName;
        string middleName;
        string lastName;
        string status;

        public Student(string userName = "", string password = "", string firstName = "", string middleName = "", string lastName = "", string status = "")
            : base(userName, password, firstName, middleName, lastName, status)
        {
            this.userName = userName;
            this.password = password;
            this.firstName = firstName;
            this.middleName = middleName;
            this.lastName = lastName;
            this.status = status;
        }
 
        /// <summary>
        /// Accesses user's transaction history with the database.
        /// </summary>
        public override void ViewTransactionHistory()
        {

        }
        void AddCourse(string courseName)
        //adds courseName to enrolledCourses
        {

        }
        void DropCourse(string courseName)
        //verify if courseName is in enrolledCourses
        //remove courseName from enrolledCourses
        {

        }
        void ViewSchedule()
        //print out enrolledCourses
        {

        }
        void SearchCourses()
        //access registrationDataBase
        {

        }
    }
}

//implement later
// void Petition;
// void checkGraduation;
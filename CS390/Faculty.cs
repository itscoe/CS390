using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS390
{
    class Faculty : User
    {
        // SortedDictionary<Course> enrolledCourses;
        string userName;
        string password;
        string firstName;
        string middleName;
        string lastName;
        string status;

        public Faculty(string userName = "", string password = "", string firstName = "", string middleName = "", string lastName = "", string status = "")
    : base(userName, password, firstName, middleName, lastName, status)
        {
            this.userName = userName;
            this.password = password;
            this.firstName = firstName;
            this.middleName = middleName;
            this.lastName = lastName;
            this.status = status;
        }


        public override void ViewTransactionHistory()
        {

        }


        //adds courseName to enrolledCourses
        void AddCourse(string courseName)
        {

        }

        //verify if courseName is in enrolledCourses
        //remove courseName from enrolledCourses
        void DropCourse(string courseName)
        {

        }

        //print out enrolledCourses
        void ViewSchedule()

        {

        }

        //access registrationDataBase
        void SearchCourses()
        {

        }

        void SubmitGrades()
        {

        }
    }

}
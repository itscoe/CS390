using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS390
{
    class Admin : User
    {

        public Admin(string userName = "", string password = "", string firstName = "", string middleName = "", string lastName = "", string status = "")
            : base(userName, password, firstName, middleName, lastName, status)
        {
            
        }

        public override void ViewTransactionHistory()
        {

        }

        //adds courseName to enrolledCourses of the given professor
        void AddProfessorCourse(string courseName, Faculty professorName)
        {

        }

        //adds courseName to enrolledCourses of the given professor
        void AddStudentCourse(string courseName, Student studnetName)
        {

        }

        //verify if courseName is in enrolledCourses of the given professor
        //remove courseName from enrolledCourses of the given professor
        void DropProfessorCourse(string courseName, Faculty professorName)
        {

        }

        //verify if courseName is in enrolledCourses of the given student
        //remove courseName from enrolledCourses of the given student
        void DropStudentCourse(string courseName, Student studentName)
        {

        }

        //print out enrolledCourses of given professor
        void ViewStudentSchedule(Faculty professorName)
        {

        }

        //print out enrolledCourses of given student
        void ViewStudentSchedule(Student studentName)
        {

        }

        //access registrationDataBase
        void SearchCourses()
        {

        }

        /*
        //implement later
        void reviewPetitions();
        void updateLog();
        void submitGrades();
        void checkGraduation();
        */
    }

}
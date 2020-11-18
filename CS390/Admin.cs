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

        //adds courseName to enrolledCourses of the given professor
        void AddProfessorCourse(string courseName, Faculty professorName)
        {
            professorName.AddCourse(courseName);
        }

        //adds courseName to enrolledCourses of the given professor
        void AddStudentCourse(string courseName, Student studentName)
        {
            studentName.AddCourse(courseName);
        }

        //verify if courseName is in enrolledCourses of the given professor
        //remove courseName from enrolledCourses of the given professor
        void DropProfessorCourse(string courseName, Faculty professorName)
        {
            professorName.DropCourse(courseName);
        }

        //verify if courseName is in enrolledCourses of the given student
        //remove courseName from enrolledCourses of the given student
        void DropStudentCourse(string courseName, Student studentName)
        {
            studentName.DropCourse(courseName);
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
    }

}
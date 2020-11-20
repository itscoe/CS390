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
        public void AddProfessorCourse(string courseName, Faculty professorName)
        {
            professorName.AddCourse(courseName);
        }

        //adds courseName to enrolledCourses of the given professor
        public void AddStudentCourse(string courseName, Student studentName)
        {
            studentName.AddCourse(courseName);
        }

        //verify if courseName is in enrolledCourses of the given professor
        //remove courseName from enrolledCourses of the given professor
        public void DropProfessorCourse(string courseName, Faculty professorName)
        {
            professorName.DropCourse(courseName);
        }

        //verify if courseName is in enrolledCourses of the given student
        //remove courseName from enrolledCourses of the given student
        public void DropStudentCourse(string courseName, Student studentName)
        {
            studentName.DropCourse(courseName);
        }

        /// <summary>
        /// Removes course from RegistrationDatabase
        /// </summary>
        /// <param name="courseID">Valid Course ID of a Course</param>
        public void RemoveCourse(string courseID)
        {
            if(this.GetStatus().Equals("manager"))
            {
                RegistrationDatabase.RemoveCourse(courseID);
            }
        }

        public void RemoveUser(string userName)
        {
            if(this.GetStatus().Equals("manager"))
            {
                RegistrationDatabase.RemoveUser(userName);
            }
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
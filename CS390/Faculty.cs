using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS390
{
    class Faculty : User
    {
        SortedDictionary<string, Course> coursesTaught = new SortedDictionary<string, Course>();
        List<Student> advisees = new List<Student>();


        public Faculty(string userName = "", string password = "", string firstName = "", string middleName = "", string lastName = "", string status = "")
    : base(userName, password, firstName, middleName, lastName, status) { }

        public override void ViewTransactionHistory()
        {

        }
        public void AddCourse(string courseID)
        //adds courseName to enrolledCourses
        {
            coursesTaught.Add(courseID, RegistrationDatabase.GetCourse(courseID));
        }
        public void DropCourse(string courseID)
        //verify if courseName is in enrolledCourses
        //remove courseName from enrolledCourses
        {
            try
            {
                coursesTaught.Remove(courseID);
            }
            catch (Exception e)
            {
                return;
            }
        }
        public List<Student> GetAdvisees() 
        {
            return advisees;

        }
        public SortedDictionary<string, Course> GetCourses()
        {
            return coursesTaught;
        }
        
        public List<Student> GetStudentAdvisees()
        {
            return advisees;
        }

        public void AddStudentAdvisee(Student student)
        {
            advisees.Add(student);
        }

        public void RemoveStudentAdvisee(Student student)
        {
            advisees.Remove(student);
        }
        
    }
    /*
        void SubmitGrades()
        {

        }*/
    }

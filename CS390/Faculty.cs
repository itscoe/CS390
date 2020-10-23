using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS390
{
    class Faculty : User
    {
        SortedDictionary<string, Course> enrolledCourses = new SortedDictionary<string, Course>();
        List<Course> courseHistory = new List<Course>();
        List<Student> advisees = new List<Student>();


        public Faculty(string userName = "", string password = "", string firstName = "", string middleName = "", string lastName = "", string status = "")
    : base(userName, password, firstName, middleName, lastName, status) { }

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
            catch (Exception e)
            {
                return;
            }
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
        public List<Student> GetAdvisees() 
        {
            return advisees;

        }
        public SortedDictionary<string, Course> GetCourses()
        {
            return enrolledCourses;
        }
        public float GetCourseCredits()
        {
            float x = 0.0f;
            foreach (Course course in courseHistory)
            {
                x += Convert.ToSingle(course.GetCourseCredit());
            }
            return x;
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


    //print out enrolledCourses
       /* public void ViewSchedule()

        {

        }

        //access registrationDataBase
        void SearchCourses()
        {

        }

        void SubmitGrades()
        {

        }*/
    }

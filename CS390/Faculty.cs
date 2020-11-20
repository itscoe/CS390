using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS390
{
    // a child class of user
    class Faculty : User
    {

        // dictionary and list to hold courses taught and advisees of faculty object.
        SortedDictionary<string, Course> coursesTaught = new SortedDictionary<string, Course>();
        List<Student> advisees = new List<Student>();

        /// <summary>
        /// All of the variables default to blank strings and then get passed to the base User class.
        /// </summary>
        public Faculty(string userName = "", string password = "", string firstName = "", string middleName = "", string lastName = "", string status = "")
    : base(userName, password, firstName, middleName, lastName, status) { }

        /// <summary>
        /// Adds course into courses taught dictionary.
        /// </summary>
        /// <param name="courseID">Valid Course ID of a Course</param>
        public void AddCourse(string courseID)
        {
            coursesTaught.Add(courseID, RegistrationDatabase.GetCourse(courseID));
        }

        /// <summary>
        /// Removes course from courses taught.
        /// </summary>
        /// <param name="courseID">Valid Course ID of a Course</param>
        public void DropCourse(string courseID)
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

        /// <summary>
        /// Returns entire dictionary of courses taught
        /// </summary>
        public SortedDictionary<string, Course> GetCourses()
        {
            return coursesTaught;
        }
        
        /// <summary>
        /// Returns entire list of student advisees
        /// </summary>
        public List<Student> GetStudentAdvisees()
        {
            return advisees;
        }

        /// <summary>
        /// Adds a student into student advisees list.
        /// </summary>
        /// <param name="student">Valid student object</param>
        public void AddStudentAdvisee(Student student)
        {
            advisees.Add(student);
        }

        /// <summary>
        /// Removes a student from student advisees list.
        /// </summary>
        /// <param name="student">Valid student object.</param>
        public void RemoveStudentAdvisee(Student student)
        {
            advisees.Remove(student);
        }
        
    }
}

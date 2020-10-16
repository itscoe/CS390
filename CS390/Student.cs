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
            courseHistory.Add(RegistrationDatabase.GetCourse(courseID).ConvertToCourseHistory(this));
        }
        public void DropCourse(string courseID)
        //verify if courseName is in enrolledCourses
        //remove courseName from enrolledCourses
        {
            try
            {
                enrolledCourses.Remove(courseID);
                foreach (Course course in courseHistory)
                    if (course.GetCourseID().Equals(courseID))
                        if(course.GetCourseTerm().Equals("F14"))
                            courseHistory.Remove(course);
            }
            catch(Exception e)
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
        public SortedDictionary<string, Course> GetCourses()
        {
            return enrolledCourses;
        }

        public float GetCourseCredits()
        {
            float x = 0.0f;
            foreach(Course course in courseHistory)
            {
                x += Convert.ToSingle(course.GetCourseCredit());
            }
            return x;
        }

        public float GetGradePointAverage()
        {
            float x = 0.0f;
            int courseCount = 0;
            foreach(Course course in courseHistory)
            {
                switch(course.GetGrade())
                {
                    case "A":
                        x += 4f;
                        courseCount++;
                        break;
                    case "A-":
                        x += 3.7f;
                        courseCount++;
                        break;
                    case "B+":
                        x += 3.3f; courseCount++;
                        break;
                    case "B":
                        x += 3f; courseCount++;
                        break;
                    case "B-":
                        x += 2.7f; courseCount++;
                        break;
                    case "C+":
                        x += 2.3f; courseCount++;
                        break;
                    case "C":
                        x += 2f; courseCount++;
                        break;
                    case "C-":
                        x += 1.7f; courseCount++;
                        break;
                    case "D+":
                        x += 1.3f; courseCount++;
                        break;
                    case "D":
                        x += 1f; courseCount++;
                        break;
                    case "D-":
                        x += 0.7f; courseCount++;
                        break;
                    case "F":
                        x += 0; courseCount++;
                        break;
                    case "WF":
                        x += 0; courseCount++;
                        break;
                }
            }
            return (x / courseCount);
        }
    }
}

//implement later
// void Petition;
// void checkGraduation;
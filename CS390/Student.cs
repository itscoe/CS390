using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Student
    {
        // SortedDictionary<Course> enrolledCourses;
        string userName;
        string password;
        string firstName;
        string middleName;
        string lastName;
        string status;
    }
    void addCourse(string courseName);
    //adds courseName to enrolledCourses
    void dropCourse(string courseName);
    //verify if courseName is in enrolledCourses
    //remove courseName from enrolledCourses
    void viewSchedule();
    //print out enrolledCourses
    void searchCourses();
    //access registrationDataBase

//implement later
// void Petition;
// void checkGraduation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Adminstrator
    {
        string userName;
        string password;
        string firstName;
        string middleName;
        string lastName;
        string status;
    }
    void addProfessorCourse(string courseName, Professor professorName);
    //adds courseName to enrolledCourses of the given professor
    void addStudentCourse(string courseName, Student studnetName);
    //adds courseName to enrolledCourses of the given professor
    void dropProfessorCourse(string courseName, Professor professorName);
    //verify if courseName is in enrolledCourses of the given professor
    //remove courseName from enrolledCourses of the given professor
    void dropStudentCourse(string courseName, Student studentName);
    //verify if courseName is in enrolledCourses of the given student
    //remove courseName from enrolledCourses of the given student
    void viewStudentSchedule(Professor professorName);
    //print out enrolledCourses of given professor
    void viewStudentSchedule(Student studnetName);
    //print out enrolledCourses of given student
    void searchCourses();
    //access registrationDataBase

    //implement later
    void reviewPetitions();
    void updateLog();
    void submitGrades();
    void checkGraduation();
}
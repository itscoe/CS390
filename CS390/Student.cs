using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CS390
{
    // A child class of User
    class Student : User
    {
        // Sorted dictionary to store courses that a given student is enrolled in
        SortedDictionary<string, Course> enrolledCourses = new SortedDictionary<string, Course>();
        List<Course> courseHistory = new List<Course>();

        /// <summary>
        /// All of the variables default to blank strings and then get passed to the base User class.
        /// </summary>
        public Student(string userName = "", string password = "", string firstName = "", string middleName = "", string lastName = "", string status = "")
            : base(userName, password, firstName, middleName, lastName, status) { }
 

        /// <summary>
        /// Adds a course to both enrolled courses and course history.
        /// </summary>
        /// <param name="courseID">Valid Course ID of a Course</param>
        public void AddCourse(string courseID)
        {
            enrolledCourses.Add(courseID, RegistrationDatabase.GetCourse(courseID));
            RegistrationDatabase.GetCourse(courseID).EnrollStudent(this);
            courseHistory.Add(RegistrationDatabase.GetCourse(courseID).ConvertToCourseHistory(this));
        }

        /// <summary>
        /// Drops a course from both enrolled courses and course history.
        /// </summary>
        /// <param name="courseID">Valid Course ID of a Course</param>
        public void DropCourse(string courseID)
        {
            // try-catch to ensure dictionary contains courseID
            try
            {
                enrolledCourses.Remove(courseID);
                // I love the "this" keyword if you couldn't tell
                RegistrationDatabase.GetCourse(courseID).WithdrawStudent(this);

                // this foreach loop is to make sure that we are removing courses from next term and not this term.
                foreach (Course course in courseHistory)
                    if (course.GetCourseID().Equals(courseID))
                        if(course.GetCourseTerm().Equals("S15"))
                            courseHistory.Remove(course);
            }
            catch(Exception e)
            {
                return;
            }
        }

        /// <summary>
        /// Changes status of student to new Username.
        /// </summary>
        /// <param name="userName">Username of a Faculty member.</param>
        public void ChangeAdvisor(string userName) {  SetStatus(userName); }

        /// <summary>
        /// Adds a course directly into course history.
        /// </summary>
        /// <param name="course">Course Object</param>
        public void AddCourseHistory(Course course)
        {
            courseHistory.Add(course);
            if (RegistrationDatabase.GetCourse(course.GetCourseID()) != null && course.GetGrade() == "N")
                if (!enrolledCourses.ContainsKey(course.GetCourseID()))
                    enrolledCourses.Add(course.GetCourseID(), RegistrationDatabase.GetCourse(course.GetCourseID()));
        }

        /// <summary>
        /// Returns entire courseHistory list.
        /// </summary>
        public List<Course> GetCourseHistory()
        {
            return courseHistory;
        }

        /// <summary>
        /// Returns entire courseHistory dictionary.
        /// </summary>
        public SortedDictionary<string, Course> GetCourses()
        {
            return enrolledCourses;
        }

        /// <summary>
        /// Gets current amount of credits obtained by a student.
        /// </summary>
        public float GetCurrentCourseCredits()
        {
            float x = 0.0f;
            // parses through all kvps in course history and then checks if it has a valid grade to be considered a course credit grade.
            foreach(KeyValuePair<string, Course> course in enrolledCourses)
            {
                if(course.Value.IsCreditGrade())
                    x += Convert.ToSingle(course.Value.GetCourseCredit());
            }
            return x;
        }

        /// <summary>
        /// Gets amount of credits obtained in the history of the student.
        /// </summary>
        public float GetHistoryCourseCredits()
        {
            float x = 0.0f;
            foreach(Course course in courseHistory)
            {
                if (course.IsCreditGrade())
                    x += Convert.ToSingle(course.GetCourseCredit());
            }
            return x;
        }

        /// <summary>
        /// Gets grade point average of a given student.
        /// </summary>
        public float GetGradePointAverage()
        {
            float x = 0.0f;
            int courseCount = 0; 
            // uses a foreach loop and switch statement to determine a GPA
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

        /// <summary>
        /// Verifies validity of next semester's schedule.
        /// </summary>
        public void VerifyNextSchedule()
        {
            var course_keys = enrolledCourses.Keys;
            for(int index1 = 0; index1 < course_keys.Count; index1++)
            {
                for (int index2 = index1 + 1; index2 < course_keys.Count; index2++)
                {
                    List<string> new_time_slots = new List<string>();
                    string new_days_string = String.Join(", ", enrolledCourses[course_keys.ElementAt(index1)].GetDayBlocks());
                    string[] new_days_split = new_days_string.Split(',');
                    string new_times_string = String.Join(", ", enrolledCourses[course_keys.ElementAt(index1)].GetTimeBlocks());
                    string[] new_times_split = new_times_string.Split(',');
                    int i = 0;
                    foreach (string days in new_days_split)
                    {
                        string[] individual_days = Regex.Split(days.Trim(), string.Empty);
                        foreach (string day in individual_days)
                        {
                            string[] possible_days = { "M", "T", "W", "R", "F" };
                            if (Array.Exists(possible_days, element => element == day))
                            {
                                new_time_slots.Add(day + new_times_split[i].Trim());
                            }
                        }
                        i += 1;
                    }

                    List<string> old_time_slots = new List<string>();
                    string old_days_string = String.Join(", ", enrolledCourses[course_keys.ElementAt(index2)].GetDayBlocks());
                    Console.WriteLine(old_days_string);
                    string[] old_days_split = old_days_string.Split(',');
                    string old_times_string = String.Join(", ", enrolledCourses[course_keys.ElementAt(index2)].GetTimeBlocks());
                    Console.WriteLine(old_times_string);
                    string[] old_times_split = old_times_string.Split(',');
                    int j = 0;
                    foreach (string days in old_days_split)
                    {
                        string[] individual_days = Regex.Split(days.Trim(), string.Empty);
                        foreach (string day in individual_days)
                        {
                            string[] possible_days = { "M", "T", "W", "R", "F" };
                            if (Array.Exists(possible_days, element => element == day))
                            {
                                old_time_slots.Add(day + old_times_split[j].Trim());
                            }
                        }
                        j += 1;
                    }
                    //Console.WriteLine(new_time_slots.ToString());
                    //Console.WriteLine(old_time_slots.ToString());
                    if (new_time_slots.Intersect(old_time_slots).Any())
                    {
                        Console.WriteLine("Tried To Warn");
                        System.Windows.Forms.MessageBox.Show("Warning! Scheduling conflict: " + course_keys.ElementAt(index1) + " and " + course_keys.ElementAt(index2));
                    }
                }
            }
        }

        /// <summary>
        /// Verifies validity of this semester's schedule.
        /// </summary>
        public void VerifyCurrentSchedule()
        {
            for (int index1 = 0; index1 < courseHistory.Count; index1++)
            {
                for (int index2 = index1 + 1; index2 < courseHistory.Count; index2++)
                {
                    if(courseHistory.ElementAt(index1).GetCourseTerm() == "F14" && courseHistory.ElementAt(index2).GetCourseTerm() == "F14")
                    {
                        List<string> new_time_slots = new List<string>();
                        string new_days_string = String.Join(", ", courseHistory.ElementAt(index1).GetDayBlocks());
                        string[] new_days_split = new_days_string.Split(',');
                        string new_times_string = String.Join(", ", courseHistory.ElementAt(index1).GetTimeBlocks());
                        string[] new_times_split = new_times_string.Split(',');
                        int i = 0;
                        foreach (string days in new_days_split)
                        {
                            string[] individual_days = Regex.Split(days.Trim(), string.Empty);
                            foreach (string day in individual_days)
                            {
                                string[] possible_days = { "M", "T", "W", "R", "F" };
                                if (Array.Exists(possible_days, element => element == day))
                                {
                                    new_time_slots.Add(day + new_times_split[i].Trim());
                                }
                            }
                            i += 1;
                        }

                        List<string> old_time_slots = new List<string>();
                        string old_days_string = String.Join(", ", courseHistory.ElementAt(index2).GetDayBlocks());
                        Console.WriteLine(old_days_string);
                        string[] old_days_split = old_days_string.Split(',');
                        string old_times_string = String.Join(", ", courseHistory.ElementAt(index2).GetTimeBlocks());
                        Console.WriteLine(old_times_string);
                        string[] old_times_split = old_times_string.Split(',');
                        int j = 0;
                        foreach (string days in old_days_split)
                        {
                            string[] individual_days = Regex.Split(days.Trim(), string.Empty);
                            foreach (string day in individual_days)
                            {
                                string[] possible_days = { "M", "T", "W", "R", "F" };
                                if (Array.Exists(possible_days, element => element == day))
                                {
                                    old_time_slots.Add(day + old_times_split[j].Trim());
                                }
                            }
                            j += 1;
                        }
                        //Console.WriteLine(new_time_slots.ToString());
                        //Console.WriteLine(old_time_slots.ToString());
                        if (new_time_slots.Intersect(old_time_slots).Any())
                        {
                            Console.WriteLine("Tried To Warn");
                            System.Windows.Forms.MessageBox.Show("Warning! Scheduling conflict: " + courseHistory.ElementAt(index1).GetCourseID() + " and " + courseHistory.ElementAt(index2).GetCourseID());
                        }
                    }
                }
            }
        }
    }
}
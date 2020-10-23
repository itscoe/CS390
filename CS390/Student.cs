using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            RegistrationDatabase.GetCourse(courseID).EnrollStudent(this);
            courseHistory.Add(RegistrationDatabase.GetCourse(courseID).ConvertToCourseHistory(this));
        }
        public void DropCourse(string courseID)
        //verify if courseName is in enrolledCourses
        //remove courseName from enrolledCourses
        {
            try
            {
                enrolledCourses.Remove(courseID);
                RegistrationDatabase.GetCourse(courseID).WithdrawStudent(this);
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

        public void AddCourseHistory(Course course)
        //access registrationDataBase
        {
            courseHistory.Add(course);
            if (RegistrationDatabase.GetCourse(course.GetCourseID()) != null && course.GetGrade() == "N")
                if (!enrolledCourses.ContainsKey(course.GetCourseID()))
                    enrolledCourses.Add(course.GetCourseID(), RegistrationDatabase.GetCourse(course.GetCourseID()));
        }

        public List<Course> GetCourseHistory()
        {
            return courseHistory;
        }
        public SortedDictionary<string, Course> GetCourses()
        {
            return enrolledCourses;
        }

        public float GetCurrentCourseCredits()
        {
            float x = 0.0f;
            foreach(KeyValuePair<string, Course> course in enrolledCourses)
            {
                if(course.Value.IsCreditGrade())
                    x += Convert.ToSingle(course.Value.GetCourseCredit());
            }
            return x;
        }

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

//implement later
// void Petition;
// void checkGraduation;
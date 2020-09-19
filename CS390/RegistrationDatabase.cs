using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS390
{
    class RegistrationDatabase
    {
        public enum DatabaseType
        {
            user,
            course
        }

        static SortedDictionary<string, User> userDatabase = new SortedDictionary<string, User>();

        public static void Read(StreamReader file, DatabaseType databaseType)
        {
            switch (databaseType)
            {
                case DatabaseType.user:
                    while(!file.EndOfStream)
                    {
                        string[] userInfo = file.ReadLine().Split(' ');

                        CreateUser(userInfo[0], userInfo[1], userInfo[2], userInfo[3], userInfo[4], userInfo[5]);
                    }
                    break;
                case DatabaseType.course:
                    while(!file.EndOfStream)
                    {

                    }
                    break;
            }
        }

        static void CreateUser(string userName, string password, string firstName,
                string middleName, string lastName, string status)
        {
            User user;

            if (status.Equals("admin")) {
                user = new Admin(userName, password, firstName, middleName, lastName, status);
            }
            else if (status.Equals("faculty")) {
                user = new Faculty(userName, password, firstName, middleName, lastName, status);
            }
            else {
                user = new Student(userName, password, firstName, middleName, lastName, status);
            }

            userDatabase.Add(userName, user);
        }

        public static User GetUser(string userName, string password)
        {
            if (VerifyUser(userName, password))
                return userDatabase[userName];
            else
                return null;
        }

        static bool VerifyUser(string userName, string password)
        {
            // try-catch statement verifies that the user exists inside the dictionary
            try
            {
                // assigns new user object to element <userName> in userDatabase
                User user = userDatabase[userName];

                // tests if the user object's password is the same as password passed.
                if (user.GetPassword().Equals(password))
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }

        void CreateCourse() { }
        void GetCourse() { }
        void GetTransaction()
        {

        }
    }
}

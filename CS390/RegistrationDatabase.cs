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
        enum DatabaseType
        {
            user,
            course
        }

        SortedDictionary<string, User> userDatabase = new SortedDictionary<string, User>();

        void Read(StreamReader file, DatabaseType databaseType)
        {
            string fileLine = "";

            switch (databaseType)
            {
                case DatabaseType.user:
                    while(!file.EndOfStream)
                    {
                        fileLine = file.ReadLine();
                    }
                    break;
                case DatabaseType.course:
                    while(!file.EndOfStream)
                    {

                    }
                    break;
            }
        }

        void CreateUser(string userName, string password, string firstName,
                string middleName, string lastName, string status)
        {
            User user;

            if (status.Equals("admin"))
            { }
            else if (status.Equals("faculty"))
            { }
            else
            { }

            //userDatabase.Add(userName, user);
        }
        void CreateCourse() { }
        void GetUser() { }
        void GetCourse() { }
        void GetTransaction()
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS390
{
    abstract class User
    {
        string userName;
        string password;
        string firstName;
        string middleName;
        string lastName;
        string status;

        public User() { }
        public User(string userName = "", string password = "", string firstName = "",
                string middleName = "", string lastName = "", string status = "")
        {
            this.userName = userName;
            this.password = password;
            this.firstName = firstName;
            this.middleName = middleName;
            this.lastName = lastName;
            this.status = status;
        }

        SortedDictionary<Transaction, int> userTransactions;

        /// <summary>Accesses database with string userName and string password. </summary>
        /// <param name="userName">The user's username.</param>
        /// <param name="password">The user's password.</param>
        public void LogIn(string userName, string password)
        {
            try
            {
                RegistrationDatabase.GetUser(userName, password);
            }
            catch(Exception e)
            {
                throw new ArgumentNullException("Invalid Username/Password.");
            }
        }
        // Check log in information against RegistrationDatabase
        // (Student) if successful student login, redirect form to student dash
        // (Faculty) if successful faculty login, redirect form to faculty dash
        // (Admin) if successful admin login, redirect form to admin dash

        /// <summary>
        /// Accesses user's transaction history with the database.
        /// </summary>
        abstract public void ViewTransactionHistory();
        // Prints out list of transaction data.

        public string GetUserName() { return userName; }
        public string GetPassword() { return password; }
        public string GetFirstName() { return firstName; }
        public string GetMiddleName() { return middleName; }
        public string GetLastName() { return lastName; }
        public string GetStatus() { return status; }
        //added the sets/RDiaz
        public void SetUserName(String newUserName) { userName = newUserName; }
        public void SetPassword(String newPassword) { password = newPassword; }
        public void SetFirstName(String newFirstName) { firstName = newFirstName; }
        public void SetMiddleName(String newMiddleName) { middleName = newMiddleName; }
        public void SetLastName(String newLastName) { lastName = newLastName; }
        public void SetStatus(String newStatus) { status = newStatus; }


    }
}

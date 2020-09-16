using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS390
{
    abstract class User
    {
        string UserName { get; }
        string password;
        string firstName;
        string middleName;
        string lastName;
        string status;

        User() { }
        User(string userName = "", string password = "", string firstName = "",
                string middleName = "", string lastName = "", string status = "")
        {
            this.UserName = userName;
            this.password = password;
            this.firstName = firstName;
            this.middleName = middleName;
            this.lastName = lastName;
            this.status = status;
        }

        SortedDictionary<Transaction, int> userTransactions;

        /// <summary>Accesses database with string email and string password. </summary>
        /// <param name="email">The user's email address.</param>
        /// <param name="password">The user's password.</param>
        abstract protected void LogIn(string userName, string password);
        // Check log in information against RegistrationDatabase
        // (Student) if successful student login, redirect form to student dash
        // (Faculty) if successful faculty login, redirect form to faculty dash
        // (Admin) if successful admin login, redirect form to admin dash

        /// <summary>
        /// Accesses user's transaction history with the database.
        /// </summary>
        abstract protected void ViewTransactionHistory();
        // Prints out list of transaction data.

        // Get / Set functions to be added later.

    }
}

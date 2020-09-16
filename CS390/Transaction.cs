using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS390
{
    class Transaction
    {

        enum TransactionType
        {
            LogIn,
            AddCourse,
            DropCourse,
            // should be implemented later
            Petition,
            GradeSubmission
        }

        string parameters;
        DateTime time;
        User user;
        //Form form;

    }
}

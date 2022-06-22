using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryBuilder.Models
{
    internal class BooksOutOnLoan: IClassModel
    {
        public int ID { get; init; }
        public string DateIssued { get; init; } = String.Empty;
        public string DueDate { get; init; } = String.Empty;
        public string DateReturned { get; init; } = String.Empty;
        public int UserID { get; init; }
        public int BookID { get; init; }

        public BooksOutOnLoan() { }

        public BooksOutOnLoan(int iD, string dateIssued, string dueDate, string dateReturned, int userID, int bookID)
        {
            ID = iD;
            DateIssued = dateIssued;
            DueDate = dueDate;
            DateReturned = dateReturned;
            UserID = userID;
            BookID = bookID;
        }

        public override string ToString()
        {
            return
                $"ID:\t\t{ID} \n" +
                $"Date Issued:\t\t{DateIssued} \n" +
                $"Due Date:\t\t{DueDate} \n" +
                $"Date Returned:\t\t{DateReturned} \n" +
                $"User ID:\t\t{UserID} \n" +
                $"Book ID:\t\t{BookID} \n";
                
        }
    }
}

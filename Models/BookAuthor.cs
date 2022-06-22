using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryBuilder.Models
{
    internal class BookAuthor
    {
        public int BookID { get; init; }
        public int AuthorID { get; init; }

        public BookAuthor() { }

        public BookAuthor(int bookID, int authorID)
        {
            BookID = bookID;
            AuthorID = authorID;
        }

        public override string ToString()
        {
            return 
                $"Book ID: \t\t{BookID} \n" +
                $"Author ID: \t\t{AuthorID} \n";
        }
    }
}

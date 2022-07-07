using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryBuilder.Models
{
    internal class BooksCatagorey 
    {
        public int BookID { get; init; }
        public int CatagoreyID { get; init; }

        public BooksCatagorey() { }
        public BooksCatagorey(int bookID, int catagoreyID)
        {
            BookID = bookID;
            CatagoreyID = catagoreyID;
        }

        public override string ToString()
        {
            return 
                $"Book ID:\t\t {BookID} \n " +
                $"Catagorey ID: \t\t {CatagoreyID} \n";
        }
    }
}

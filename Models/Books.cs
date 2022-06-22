using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryBuilder.Models
{
    internal class Books: IClassModel
    {
        public int ID { get; init; }
        public string Title { get; init; } = String.Empty;
        public int ISBN { get; init; }
        public string DateOfPublication { get; init; } = String.Empty;

        public Books() { }

        public Books (int iD, string title, int iSBN, string dateOfPublication)
        {
            ID = iD;
            Title = title;
            ISBN = iSBN;
            DateOfPublication = dateOfPublication;
        }

        public override string ToString()
        {
            return
                $"ID:\t\t{ID} \n" +
                $"Title:\t\t{Title} \n" +
                $"ISBN:\t\t{ISBN} \n" +
                $"Date of Publication:\t\t{DateOfPublication} \n";
        }
    }
}

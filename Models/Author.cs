using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryBuilder.Models
{
    internal class Author : IClassModel
    {
        public int ID { get; init; }
        public string FirstName { get; init; } = String.Empty;
        public string Surname { get; init; } = String.Empty;
        
        //no arg constructor for reading from DB
        public Author() { }
        public Author(int iD, string firstName, string surname)
        {
            ID = iD;
            FirstName = firstName;
            Surname = surname;
        }

        public override string ToString()
        {
            return 
                $"ID: \t\t{ID} \n" +
                $"First Name: \t\t{FirstName} \n" +
                $"Last Name: \t\t{Surname} \n";
        }

        public 
    }
}

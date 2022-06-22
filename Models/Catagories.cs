using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryBuilder.Models
{
    internal class Catagories: IClassModel
    {
        public int ID { get; init; }
        public string Name { get; init; } = String.Empty;

        public Catagories() { }

        public Catagories(int id, String name)
        {
            ID = id;
            Name = name;
        }

        public override string ToString()
        {
            return
                $"ID:\t\t {ID} \n" +
                $"Name:\t\t {Name} \n";
        }
    }
}

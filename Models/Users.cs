using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryBuilder.Models
{
    internal class Users: IClassModel
    {
        public int ID { get; init; }
        public string UserName { get; init; } = String.Empty;

        public string UserAddress { get; init; } = String.Empty;
        public string OtherUserDetails { get; init; } = String.Empty;
        public double AmountOfFine { get; init; }
        public string Email { get; init; } = String.Empty;
        public int PhoneNumber { get; init; }

        public Users() { }

        public Users (int id, string userName, string userAddress, string otherUserDetails, double amountOfFine, string email, int phoneNumber)
        {
            ID = id;
            UserName = userName;
            UserAddress = userAddress;
            OtherUserDetails = otherUserDetails;
            AmountOfFine = amountOfFine;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            return
                $"ID:\t\t{ID} \n" +
                $"Name:\t\t{UserName} \n" +
                $"Address:\t\t{UserAddress} \n" +
                $"Details:\t\t{OtherUserDetails} \n" +
                $"Fine's Due:\t\t{AmountOfFine} \n" +
                $"Email:\t\t{Email} \n" +
                $"Phone Number:\t\t{PhoneNumber} \n";
        }
    }
}

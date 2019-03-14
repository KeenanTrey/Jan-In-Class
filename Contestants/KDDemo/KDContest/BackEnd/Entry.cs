using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KDContest.BackEnd
{
    public class Entry
    {
       public string EntryCode { get; set; }
       public string Email { get; set; }

        //Greedy Constructor
        public Entry(string code, string email)
        {
            EntryCode = code;
            Email = email;
        }
    }//eoc

    public class Entrant
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Province{ get; set; }
        public string PostalCode{ get; set; }
        public int Age{ get; set; }

        public Entrant(string firstName, string lastName, string email, string city, string province, string postalCode, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            City = city;
            Province = province;
            PostalCode = postalCode;
            Age = age;
        }
    }//eoc
}//eon
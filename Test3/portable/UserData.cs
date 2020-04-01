using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portable
{
    public  class UserData
    {
        public UserData(string firstName, string lastName, string country, string phone, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Country = country;
            Phone = phone;
            Email = email;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Test3
{
    class UserData 
    {
        public UserData(string firstName, string lastName, string country, string phone, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Country = country;
            Phone = phone;
            Email = email;
        }
        public static string FirstName { get; set; }
        public static string LastName { get; set; }
        public static string Country { get; set; }
        public static string Phone { get; set; }
        public static string Email { get; set; }
    }
}
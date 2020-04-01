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
using System.Text.RegularExpressions;

namespace Test3
{
    class Validation
    {
        public Validation(){}
        public bool IsValidForm(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrEmpty(name))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool IsValidEmail(string email)
        {
            const string cond = @"(\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)";
            if (Regex.IsMatch(email, cond))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
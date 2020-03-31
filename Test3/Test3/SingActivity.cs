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
    [Activity(Label = "SingActivity")]
    public class SingActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.singlayout);

            var firstName = FindViewById<TextView>(Resource.Id.firstNameBox);
            var lastName = FindViewById<TextView>(Resource.Id.lastNameBox);
            var country = FindViewById<TextView>(Resource.Id.countryBox);
            var phone = FindViewById<TextView>(Resource.Id.phoneBox);
            var email = FindViewById<TextView>(Resource.Id.emailBox);
            //product = (Product)arguments.getSerializable(Product.class.getSimpleName());

            //textView.setText("Name: " + product.getName() + "\nCompany: " + product.getCompany() +
            //"\nPrice: " + String.valueOf(product.getPrice()));
            firstName.Text = UserData.FirstName;
            lastName.Text = UserData.LastName;
            country.Text = UserData.Country;
            phone.Text = UserData.Phone;
            email.Text = UserData.Email;
        }
    }
}
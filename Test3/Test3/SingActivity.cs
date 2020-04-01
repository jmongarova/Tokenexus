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
using Newtonsoft.Json;
using portable;

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
            UserData desuserData = JsonConvert.DeserializeObject<UserData>(Intent.GetStringExtra("userData"));
            firstName.Text = desuserData.FirstName;
            lastName.Text = desuserData.LastName;
            country.Text = desuserData.Country;
            phone.Text = desuserData.Phone;
            email.Text = desuserData.Email;
        }
    }
}
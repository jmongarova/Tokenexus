using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using Android.Content;
using Newtonsoft.Json;
using portable;

namespace Test3
{

    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity 
    {
        private EditText _editTextFirstName;
        private EditText _editTextLastName;
        private EditText _editTextCountry;
        private EditText _editTextPhone;
        private EditText _editTextEmail;
        private TextView errForFirstName;
        private TextView errForLastName;
        private TextView errForCountry;
        private TextView errForPhone;
        private TextView errForEmail;
        UserData userData;
        Validation validation;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);


            var logo = FindViewById<ImageView>(Resource.Id.cryptoLogo);
            _editTextFirstName = FindViewById<EditText>(Resource.Id.first);
            _editTextLastName = FindViewById<EditText>(Resource.Id.last);
            _editTextCountry = FindViewById<EditText>(Resource.Id.country);
            _editTextPhone = FindViewById<EditText>(Resource.Id.phone);
            _editTextEmail = FindViewById<EditText>(Resource.Id.email);
            errForFirstName = FindViewById<TextView>(Resource.Id.errorfirst);
            errForLastName = FindViewById<TextView>(Resource.Id.errorlast);
            errForCountry = FindViewById<TextView>(Resource.Id.errorcountry);
            errForPhone = FindViewById<TextView>(Resource.Id.errorphone);
            errForEmail = FindViewById<TextView>(Resource.Id.erroremail);
            var reg = FindViewById<Button>(Resource.Id.sing);
            reg.Click += RegOnClick;
            validation = new Validation();

        }
        protected override void OnResume()
        {
            base.OnResume();
            _editTextFirstName.FocusChange += FocusChangeFirstName;
            _editTextLastName.FocusChange += FocusChangeLastName;
            _editTextCountry.FocusChange += FocusChangeCountry;
            _editTextPhone.FocusChange += FocusChangePhone;
            _editTextEmail.FocusChange += FocusChangeEmail;
        }
        private void RegOnClick(object sender, EventArgs eventArgs)
        {
            var intent = new Intent(this, typeof(SingActivity));
            string firstName = String.Format(_editTextFirstName.Text);
            string lastName = String.Format(_editTextLastName.Text);
            string country = String.Format(_editTextCountry.Text);
            string phone = String.Format(_editTextPhone.Text);
            string email = String.Format(_editTextEmail.Text);
            var checkSwitch = FindViewById<Switch>(Resource.Id.switchName);
            
            if (validation.IsValidForm(firstName) == true && validation.IsValidForm(lastName) == true && validation.IsValidForm(country) == true && validation.IsValidForm(phone) == true && validation.IsValidEmail(email) == true)
            {
                userData = new UserData(firstName.ToString(), lastName.ToString(), country.ToString(), phone.ToString(), email.ToString());
                //UserData.FirstName = firstName.ToString();
                //UserData.LastName = lastName.ToString();
                //UserData.Country = country.ToString();
                //UserData.Phone = phone.ToString();
                //UserData.Email = email.ToString();
                errForFirstName.Visibility = ViewStates.Gone;
                errForLastName.Visibility = ViewStates.Gone;
                errForCountry.Visibility = ViewStates.Gone;
                errForPhone.Visibility = ViewStates.Gone;
                errForEmail.Visibility = ViewStates.Gone;

                if (checkSwitch.Checked == true)
                {
                    intent.PutExtra("userData", JsonConvert.SerializeObject(userData));
                    StartActivity(intent);
                }
                else
                {
                    Toast toast = Toast.MakeText(ApplicationContext, "To continue click to <i agree> ", ToastLength.Long);
                    toast.Show();
                }

            }
        }
        private void FocusChangeFirstName(object sender, View.FocusChangeEventArgs e)
        {
            bool flag=true;
            if (!e.HasFocus)
            {
                flag = validation.IsValidForm(_editTextFirstName.Text);

            }
            if(!flag)
            {
                VisibleTextView(errForFirstName);
                errForFirstName.Text = "Fields can't be empty";
            }
            else
            {
                InvisibleTextView(errForFirstName);
            }
        }
        private void FocusChangeLastName(object sender, View.FocusChangeEventArgs e)
        { 
            bool flag = true;
            if (!e.HasFocus)
            {
                flag = validation.IsValidForm(_editTextLastName.Text);

            }
            if (!flag)
            {
                VisibleTextView(errForLastName);
                errForLastName.Text = "Fields can't be empty";
            }
            else
            {
                InvisibleTextView(errForLastName);
            }
        }
        private void FocusChangeCountry(object sender, View.FocusChangeEventArgs e)
        {
            bool flag = true;
            if (!e.HasFocus)
            {
                flag = validation.IsValidForm(_editTextCountry.Text);

            }
            if (!flag)
            {
                VisibleTextView(errForCountry);
                errForCountry.Text = "Fields can't be empty";
            }
            else
            {
                InvisibleTextView(errForCountry);
            }

        }
        private void FocusChangePhone(object sender, View.FocusChangeEventArgs e)
        {
            bool flag = true;
            if (!e.HasFocus)
            {
                flag = validation.IsValidForm(_editTextPhone.Text);

            }
            if (!flag)
            {
                VisibleTextView(errForPhone);
                errForPhone.Text = "Fields can't be empty";
            }
            else
            {
                InvisibleTextView(errForPhone);
            }
        }
        private void FocusChangeEmail(object sender, View.FocusChangeEventArgs e)
        {
            bool flag = true;
            if (!e.HasFocus)
            {
                flag = validation.IsValidForm(_editTextEmail.Text);

            }
            if (!flag)
            {
                VisibleTextView(errForEmail);
                errForEmail.Text = "Fields can't be empty";
            }
            else
            {
                InvisibleTextView(errForEmail);
            }
        }
        private void VisibleTextView(TextView err)
        {
            err.Visibility = ViewStates.Visible;
            //err.BackgroundTint edit.SetBackgroundColor(Android.Graphics.Color.ParseColor("#ff0000"));
        }
        private void InvisibleTextView(TextView err)
        {
            err.Visibility = ViewStates.Gone;
            //err.BackgroundTint
        }
        
    }
}
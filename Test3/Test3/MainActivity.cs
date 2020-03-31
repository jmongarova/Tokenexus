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
using System.Text.RegularExpressions;


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

            //if (!IsValidForm(_editTextFirstName.Text))
            //{
            //    VisibleTextView(errForFirstName);
            //    errForFirstName.Text = "Fields can't be empty";
            //}
            ////if (_classMy.IsValidForm(_editTextLastName) == false)
            ////{
            ////    VisibleTextView(errForLastName);
            ////    errForLastName.Text = "Fields can't be empty";
            ////}
            //if (!IsValidForm(_editTextCountry.Text))
            //{
            //    VisibleTextView(errForCountry);
            //    errForCountry.Text = "Fields can't be empty";
            //}
            //if (!IsValidForm(_editTextPhone.Text))
            //{
            //    VisibleTextView(errForPhone);
            //    errForPhone.Text = "Fields can't be empty";
            //}
            //if (!IsValidEmail(_editTextEmail.Text))
            //{
            //    VisibleTextView(errForEmail);
            //    errForEmail.Text = "Email entered incorrectly";
            //}


            if (IsValidForm(firstName) == true && IsValidForm(lastName) == true && IsValidForm(country) == true && IsValidForm(phone) == true && IsValidEmail(email) == true)
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
            bool validation=true;
            if (!e.HasFocus)
            {
                validation = IsValidForm(_editTextFirstName.Text);

            }
            if(!validation)
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
            bool validation = true;
            if (!e.HasFocus)
            {
                validation = IsValidForm(_editTextLastName.Text);

            }
            if (!validation)
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
            bool validation = true;
            if (!e.HasFocus)
            {
                validation = IsValidForm(_editTextCountry.Text);

            }
            if (!validation)
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
            bool validation = true;
            if (!e.HasFocus)
            {
                validation = IsValidForm(_editTextPhone.Text);

            }
            if (!validation)
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
            bool validation = true;
            if (!e.HasFocus)
            {
                validation = IsValidForm(_editTextEmail.Text);

            }
            if (!validation)
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
            //err.BackgroundTint
        }
        private void InvisibleTextView(TextView err)
        {
            err.Visibility = ViewStates.Gone;
            //err.BackgroundTint
        }
        private bool IsValidForm(string name)
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
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
using Medici.Extensions;
using Medici.Repository;

namespace Medici
{
    [Activity(Label = "MedicLog", Theme = "@style/AppTheme.NoActionBar")]
    public class MedicLog : Activity
    {
        public TextView LogIn;
        public TextView Register;
        public EditText LoginText;
        public EditText PaswordText;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.login);

            // Create your application here
            FindViews();
            HandleEvents();
        }

        private void FindViews()
        {
            LogIn = FindViewById<TextView>(Resource.Id.sign_in);
            Register = FindViewById<TextView>(Resource.Id.register);
            LoginText = FindViewById<EditText>(Resource.Id.login_content);
            PaswordText = FindViewById<EditText>(Resource.Id.pass_content);
        }
        private void HandleEvents()
        {
            Register.Click -= Register_doctor;
            Register.Click += Register_doctor;
            LogIn.Click -= Login_Doc;
            LogIn.Click += Login_Doc;

        }

        private void Register_doctor(object s, EventArgs e)
        {
            this.GoPage(typeof(RegisterDoctor));
        }

        private void Login_Doc(object s, EventArgs e)
        {

            if (LoginText.Text != "" & PaswordText.Text != "")
            {
                if (InternetConnection.IsNetConnected())
                {
                    Services.LogDoctor(LoginText.Text, PaswordText.Text);
                    if (Services.LoggedDoctor != null)
                    {
                        this.GoPage(typeof(HomeDoctor));
                    }
                    else
                    {
                        Toast.MakeText(this, "Login or password is incorect", ToastLength.Short).Show();
                    }
                }
                else
                {
                    Toast.MakeText(this, "No internet connection", ToastLength.Short).Show();
                }
            }
            else
            {
                Toast.MakeText(this, "Wrong login or password", ToastLength.Short).Show();
            }
        }

    }
}
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
using Medici.Models;
using Medici.Repository;
using Medici.Extensions;

namespace Medici
{
    [Activity(Label = "UserLog", Theme = "@style/AppTheme.NoActionBar")]
    public class UserLog : BasePage
    {
        public TextView LogIn;
        public TextView Register;
        public EditText LoginText;
        public EditText PaswordText;

        private User CurentUser;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.login);
            // Create your application here
            FindViews();
            EventHanedlers();
        }

        public override void OnBackPressed()
        {
            base.OnBackPressed();
        }

        public void EventHanedlers()
        {
            LogIn.Click -= Login_Licked;
            LogIn.Click += Login_Licked;
            Register.Click -= Register_Click;
            Register.Click += Register_Click;

        }

        private void Register_Click(object s, EventArgs e)
        {
            this.GoPage(typeof(RegisterUser));
        }

        private void Login_Licked(object s, EventArgs e)
        {
            if (LoginText.Text != "" & PaswordText.Text != "")
            {
                if (InternetConnection.IsNetConnected())
                {
                    Services.LogUser(LoginText.Text, PaswordText.Text);
                    if (Services.LoggedUser != null)
                    {
                        this.GoPage(typeof(HomeUser));
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


        private void FindViews()
        {
            LogIn = FindViewById<TextView>(Resource.Id.sign_in);
            Register = FindViewById<TextView>(Resource.Id.register);
            LoginText = FindViewById<EditText>(Resource.Id.login_content);
            PaswordText = FindViewById<EditText>(Resource.Id.pass_content);
        }
    }
}
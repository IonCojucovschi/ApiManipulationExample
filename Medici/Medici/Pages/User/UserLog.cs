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

namespace Medici
{
    [Activity(Label = "UserLog", Theme = "@style/AppTheme.NoActionBar")]
    public class UserLog : Activity
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
            LogIn.Click -= Login_Licked;
            LogIn.Click += Login_Licked;
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
                        var intent = new Intent();
                        intent.SetClass(this, typeof(HomeUser));
                        StartActivity(intent);
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
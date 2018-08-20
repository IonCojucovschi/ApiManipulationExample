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
using Medici.Repository;
using Medici.Models;
using Medici.Extensions;

namespace Medici
{
    [Activity(Label = "RegisterUser")]
    public class RegisterUser : BasePage
    {
        private EditText login;
        private EditText password;
        private EditText repeat_pasword;
        private EditText name;
        private EditText surname;
        private EditText phone;
        private TextView register;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.create_user);
            // Create your application here
            FindViews();
            HandleEvents();
        }

        public void FindViews()
        {
            login = FindViewById<EditText>(Resource.Id.user_login);
            password = FindViewById<EditText>(Resource.Id.user_password);
            repeat_pasword = FindViewById<EditText>(Resource.Id.user_password_repeat);
            name = FindViewById<EditText>(Resource.Id.user_name);
            surname = FindViewById<EditText>(Resource.Id.user_surname);
            phone = FindViewById<EditText>(Resource.Id.user_phone);
            register = FindViewById<TextView>(Resource.Id.register_user);
            register.SetBackgroundResource(Resource.Drawable.rounded_corner);
        }
        private void HandleEvents()
        {
            register.Click -= register_user;
            register.Click += register_user;
        }

        private void register_user(object s, EventArgs e)
        {
            if (login.Text != "" & password.Text != "" & password.Text == repeat_pasword.Text & name.Text != "" & surname.Text != "" & phone.Text != "")
            {
                User newuser = new User { name = name.Text, surname = surname.Text, login = login.Text, pasword = password.Text, cellphone = phone.Text };
                if (InternetConnection.IsNetConnected())
                {
                    Services.RegisterUser(newuser);
                    this.GoPage(typeof(UserLog));
                }
                else
                {
                    Toast.MakeText(this, "No internet connection", ToastLength.Short).Show();
                }

            }
            else
            {
                Toast.MakeText(this, "Complete all fields", ToastLength.Short).Show();
            }
        }
    }
}
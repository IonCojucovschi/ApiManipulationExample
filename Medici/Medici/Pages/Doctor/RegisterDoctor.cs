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
using Medici.Models;
using Medici.Repository;

namespace Medici
{
    [Activity(Label = "RegisterDoctor")]
    public class RegisterDoctor : Activity
    {
        private EditText login;
        private EditText password;
        private EditText repeat_pasword;
        private EditText name;
        private EditText surname;

        private TextView registerText;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.create_doctor);
            // Create your application here
            FindViews();
            HandleViews();
        }

        private void FindViews()
        {
            login = FindViewById<EditText>(Resource.Id.doc_login);
            password = FindViewById<EditText>(Resource.Id.doc_password);
            name = FindViewById<EditText>(Resource.Id.doc_name);
            surname = FindViewById<EditText>(Resource.Id.doc_surname);
            repeat_pasword = FindViewById<EditText>(Resource.Id.doc_password_repeat);
            registerText = FindViewById<TextView>(Resource.Id.register_doc);
        }
        private void HandleViews()
        {
            registerText.Click -= Redister_Doc;
            registerText.Click += Redister_Doc;

            registerText.SetBackgroundResource(Resource.Drawable.rounded_corner);
        }
        private void Redister_Doc(object s, EventArgs e)
        {
            Doctor newDoc = new Doctor();

            if (login.Text != "" & password.Text != "" & password.Text == repeat_pasword.Text & name.Text != "" & surname.Text != "")
            {
                newDoc.name = name.Text;
                newDoc.surname = surname.Text;
                newDoc.login = login.Text;
                newDoc.password = password.Text;

                if (InternetConnection.IsNetConnected())
                {
                    Services.RegisterDoctor(newDoc, new Procedura() { name="procedura_13"});
                    this.GoPage(typeof(MedicLog));
                }
                else
                {
                    Toast.MakeText(this, "No internet connection", ToastLength.Short).Show();
                }

            }
            else {
                Toast.MakeText(this, "Complete all input", ToastLength.Short).Show();

            }
        }

    }
}
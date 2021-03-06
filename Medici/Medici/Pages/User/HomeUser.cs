﻿
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
    [Activity(Label = "HomeUser")]
    public class HomeUser : BasePage
    {

        TextView HelloContent;
        TextView Doctors;
        TextView Programation;
        TextView CreateProgramation;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.home_user);
            // Create your application here
            FindViews();
            HandleViews();
        }

        private void FindViews()
        {
            Doctors = FindViewById<TextView>(Resource.Id.doctors_view);
            HelloContent = FindViewById<TextView>(Resource.Id.hello_text);
            Programation = FindViewById<TextView>(Resource.Id.programation_view);
            CreateProgramation = FindViewById<TextView>(Resource.Id.clear_data);

            Doctors.SetBackgroundResource(Resource.Drawable.rounded_corner);
            Programation.SetBackgroundResource(Resource.Drawable.rounded_corner);
            CreateProgramation.SetBackgroundResource(Resource.Drawable.rounded_corner);
            HelloContent.Text = "Hello, " + Services.LoggedUser.name + " !";
        }
        private void HandleViews()
        {
            CreateProgramation.Click -= CreateClick;
            CreateProgramation.Click += CreateClick;
            Programation.Click -= Programation_Click;
            Programation.Click += Programation_Click;
            Doctors.Click -= Doctor_ButtonClick;
            Doctors.Click += Doctor_ButtonClick;

        }
        private void Doctor_ButtonClick(object s, EventArgs  e)
        {
            this.GoPage(typeof(DoctorsListView));
        }
        private void CreateClick(object s, EventArgs e)
        {
            this.GoPage(typeof(AddProgramation));
        }
        void Programation_Click(object sender, EventArgs e)
        {
            this.GoPage(typeof(ProgramationUser));
        }

        public override void OnBackPressed()
        {
            base.OnBackPressed();
        }

    }
}

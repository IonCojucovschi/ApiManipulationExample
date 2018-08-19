
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
    [Activity(Label = "HomeDoctor")]
    public class HomeDoctor : Activity
    {
        TextView DoctorView;
        TextView ProgramationView;
        TextView HelloText;
        TextView AddProcedure;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.home_doctor);
            // Create your application here
            FindViews();
            HandeEvents();
            HelloText.Text ="Hello "+Services.LoggedDoctor.name+"!";
        }
        private void FindViews()
        {
            HelloText = FindViewById<TextView>(Resource.Id.hello_text);
            DoctorView = FindViewById<TextView>(Resource.Id.doctor_view);
            ProgramationView = FindViewById<TextView>(Resource.Id.programation_view);
            AddProcedure = FindViewById<TextView>(Resource.Id.add_procedure);

            DoctorView.SetBackgroundResource(Resource.Drawable.rounded_corner);
            ProgramationView.SetBackgroundResource(Resource.Drawable.rounded_corner);
            AddProcedure.SetBackgroundResource(Resource.Drawable.rounded_corner);
        }
        private void HandeEvents()
        {
            DoctorView.Click -= DoctorView_Clicked;
            DoctorView.Click += DoctorView_Clicked;
            ProgramationView.Click -= ProgramationView_Click;
            ProgramationView.Click += ProgramationView_Click;
            AddProcedure.Click -= AddProcedure_clicked;
            AddProcedure.Click += AddProcedure_clicked;
        }
        private void AddProcedure_clicked(object s,EventArgs e)
        {
            this.GoPage(typeof(AddProcedure));
        }
        private void ProgramationView_Click(object s, EventArgs e)
        {
            this.GoPage(typeof(ProgramationDoctor));
        }
        private void DoctorView_Clicked(object s, EventArgs e)
        {
            this.GoPage(typeof(DoctorsListView));
        }

    }
}

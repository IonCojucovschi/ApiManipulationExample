
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

namespace Medici
{
    [Activity(Label = "HomeUser")]
    public class HomeUser : Activity
    {

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
            Programation = FindViewById<TextView>(Resource.Id.programation_view);
            CreateProgramation = FindViewById<TextView>(Resource.Id.clear_data);
        }
        private void HandleViews()
        {
            CreateProgramation.Click -= CreateClick;
            CreateProgramation.Click += CreateClick;
        }

        private void CreateClick(object s, EventArgs e)
        {
            this.GoPage(typeof(AddProgramation));
        }
    }
}

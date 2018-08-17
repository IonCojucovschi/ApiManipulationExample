
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

namespace Medici
{
    [Activity(Label = "HomeDoctor")]
    public class HomeDoctor : Activity
    {
        TextView ProgramationButton;
        TextView DoctorsButton;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.home_doctor);
            // Create your application here
        }
    }
}

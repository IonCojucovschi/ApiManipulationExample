
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
    [Activity(Label = "ProgramationDoctor")]
    public class ProgramationDoctor : Activity
    {
        ListView listView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.view_programation);
            // Create your application here
            FindViews();
        }

        private void FindViews()
        {
            listView = FindViewById<ListView>(Resource.Id.procedureView);
        }



    }
}

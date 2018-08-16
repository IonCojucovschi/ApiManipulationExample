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
    [Activity(Label = "MedicLog", Theme = "@style/AppTheme.NoActionBar")]
    public class MedicLog : Activity
    {
        public TextView LogIn;
        public  TextView Register;
        public EditText LoginText;
        public EditText PaswordText;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.login);

            // Create your application here
            FindViews();
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
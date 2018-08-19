using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Medici.Repository;

namespace Medici
{
    [Activity(Label = "UserOrMed")]
    public class UserOrMed : Activity
    {
        private TextView User;
        private TextView Doctor;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.user_or_medic);
            ManagerContent some = new ManagerContent();


            FindViews();

            User.Click += (S, e) =>
            {
                var intent = new Intent();
                intent.PutExtra("user_type","user");
                intent.SetClass(this,typeof(UserLog));
                StartActivity(intent);
            };

            Doctor.Click += (S, e) =>
            {
                var intent = new Intent();
                intent.PutExtra("user_type", "user");
                intent.SetClass(this, typeof(MedicLog));
                StartActivity(intent);
            };

        }
        private void FindViews()
        {
            User = FindViewById<TextView>(Resource.Id.user_Button);
            Doctor = FindViewById<TextView>(Resource.Id.doctor_Button);
            User.SetBackgroundResource(Resource.Drawable.rounded_corner);
            Doctor.SetBackgroundResource(Resource.Drawable.rounded_corner);

        }
    }
}
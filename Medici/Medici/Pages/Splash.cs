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
    [Activity(Label = "Splash", Theme = "@style/SplashTheme", MainLauncher = true)]
    public class Splash : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            this.GoPage(typeof(UserOrMed));
            // Create your application here
        }
        protected override void OnRestart()
        {
            base.OnRestart();
            this.GoPage(typeof(UserOrMed));
        }

    }
}
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
    [Activity(Label = "BasePage")]
    public class BasePage : Activity
    {
        public override void OnBackPressed()
        {            
            base.OnBackPressed();
            this.OverridePendingTransition(Resource.Animation.side_out_right, Resource.Animation.side_in_left);
        }
    }
}
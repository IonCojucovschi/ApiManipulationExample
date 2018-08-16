using System;
using Android.App;
using Android.Content;

namespace Medici.Extensions
{
    public static class Extensions
    {
        public static void GoPage(this Activity activity, Activity name)
        {
            var intent = new Intent();
            intent.SetClass(activity, name.GetType());
            activity.StartActivity(intent);
        }
    }
}

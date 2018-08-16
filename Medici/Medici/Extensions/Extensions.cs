using System;
using Android.App;
using Android.Content;

namespace Medici.Extensions
{
    public static class Extensions
    {
        public static void GoPage(this Activity activity, Type name)
        {
            var intent = new Intent();
            intent.SetClass(activity, name);
            activity.StartActivity(intent);
        }
    }
}

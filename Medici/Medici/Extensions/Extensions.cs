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
            activity.OverridePendingTransition(Resource.Animation.side_in_right,Resource.Animation.side_out_left);
        }
        public static string DateFormatter(this string date)
        {
                if (date.Length == 8)
                {
                    date = date.Substring(0, 2) + "." + date.Substring(2, 2) + "." + date.Substring(4, 4);
                    return date;
                }

                if (date.Length == 7)
                {
                    date = date.Substring(0, 2) + "." + date.Substring(2, 1) + "." + date.Substring(3, 4);
                    return date;
                }
                if (date.Length == 6)
                {
                    date = date.Substring(0, 1) + "." + date.Substring(1, 1) + "." + date.Substring(2, 4);
                    return date;
                }
            
            return date;
        }
    }
}

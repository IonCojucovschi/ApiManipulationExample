using System;
using Android.App;
using Android.Content;
using Android.Net;

namespace Medici.Repository
{
    public static class InternetConnection
    {
        static ConnectivityManager connectivityManager;

        static InternetConnection()
        {
            connectivityManager = (ConnectivityManager)Application.Context.GetSystemService(
                Context.ConnectivityService);
        }

        public static bool IsNetConnected()
        {
            NetworkInfo networkInfo = connectivityManager.ActiveNetworkInfo;
            bool isOnline = networkInfo.IsConnected;
            return isOnline;
        }
    }
}

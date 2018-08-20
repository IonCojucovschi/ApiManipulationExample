using System;
using Android.App;
using Android.Content;
using Android.Net;
using Plugin.Connectivity;

namespace Medici.Repository
{
    public static class InternetConnection
    {
        static ConnectivityManager connectivityManager;

        static InternetConnection()
        {

        }

        public static bool IsNetConnected()
        {
            bool isOnline = CrossConnectivity.Current.IsConnected;
            return isOnline;
        }
    }
}

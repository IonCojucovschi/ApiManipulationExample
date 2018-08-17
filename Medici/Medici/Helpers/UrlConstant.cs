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

namespace Medici.Helpers
{
    public static class UrlConstant
    {
        public static string BaseUrl = "http://readabook.16mb.com/doctori";

        /// get all data 
        public static string GetAllDoctors = "/doctori/all/s";
        public static string GetAllUsers = "/user/all/s";
        public static string GetAllProcedure = "/procedure/all/s";
        public static string GetAllProgramation = "/programari/all/s";
        public static string GetAllAvailableDay = "/dayavailable/all/s";

        /// get data byId 
        public static string GetUserById = "/user/getbyid/";
        public static string GetDoctorById = "/doctori/getbyid/";
        public static string GetProgramationByIdDoctor = "/programari/getbyiddoctor/";

        /// register data 
        public static string RegisterDoctor = "/doctori/register/";
        public static string RegisterUser = "/user/register/";
        public static string RegisterProcedure = "/procedure/register/";
        public static string RegisterProgramation = "/programari/register/";
        public static string DayAvailabilityRegister = "/dayavailable/register/";

        /// update data 
        public static string DayAvailabilityUpdate = "/dayavailable/update/";
    }
}
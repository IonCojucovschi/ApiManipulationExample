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

namespace Medici.Models
{
    public class User : Entity
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string login { get; set; }
        public string pasword { get; set; }
        public string cellphone { get; set; }
        public string active { get; set; }
    }
}
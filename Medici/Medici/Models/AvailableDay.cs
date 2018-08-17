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
    public class AvailableDay : Entity
    {
        public string dayname { get; set; }
        public string hours_list { get; set; }
        public int work_hours { get; set; }
        public string doctor_id { get; set; }
    }
}
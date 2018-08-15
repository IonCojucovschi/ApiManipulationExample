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
   public class Programare:Entity
    {
        public string id_doctor { get; set; }
        public string id_user { get; set; }
        public string prog_name { get; set; }
        public string hour { get; set; }
        public string comments { get; set; }
        public string id_procedure { get; set; }
    }
}

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
using Medici.Models.AdapterHelpers;
using Medici.Repository;
using Medici.Models;
using System.Net.WebSockets;
using Medici.Adapters;

namespace Medici
{
    [Activity(Label = "ProgramationUser")]
    public class ProgramationUser : Activity
    {
        ListView listView;
        List<ProcedureModel> procedures = new List<ProcedureModel>();


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.view_programation);
            // Create your application here
            FindViews();
            InitializeProcedure();
            ProcedureUserAdapter adapter = new ProcedureUserAdapter(this, procedures);
            listView.Adapter = adapter;
        }

        private void FindViews()
        {
            listView = FindViewById<ListView>(Resource.Id.procedureView);
        }
        private void InitializeProcedure()
        {
            Services.GetAllDoctors();
            Services.GetAllProgramation();
            List<Programare> proceduresUser = Services.AllProgramationList.Where(itm => itm.id_user == Services.LoggedUser.id.ToString()).ToList();
            foreach (var item in proceduresUser)
            {
                string temp = GetDoctorName(item.id_doctor);
                procedures.Add(new ProcedureModel() { name = temp, date = item.prog_name,isExpanded=false,coment="", hour = item.hour });
            }

            //Services.LoggedUser.name
        }
        private string GetDoctorName(string id)
        {
            string dctname = Services.AllDoctorsList.Where(itm => itm.id.ToString() == id).Select(itm => itm.name + " " + itm.surname).ToList().FirstOrDefault();
            return dctname;
        }

    }
}

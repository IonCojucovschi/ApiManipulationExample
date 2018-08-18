
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
using Medici.Adapters;
using Medici.Models;
using Medici.Models.AdapterHelpers;
using Medici.Repository;

namespace Medici
{
    [Activity(Label = "ProgramationDoctor")]
    public class ProgramationDoctor : Activity
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
            HandleEvents();
        }

        private void HandleEvents()
        {
            listView.ItemClick -= List_ItemClicked;
            listView.ItemClick += List_ItemClicked;
        }

        private void List_ItemClicked(object s, AdapterView.ItemClickEventArgs e)
        {
            int ps = e.Position;
            var clickedprocedure = procedures[ps];
            if(clickedprocedure.isExpanded)
            clickedprocedure.isExpanded = false;
            else clickedprocedure.isExpanded = true;

            ProcedureUserAdapter adapter = new ProcedureUserAdapter(this, procedures);
            listView.Adapter = adapter;
        }

        private void FindViews()
        {
            listView = FindViewById<ListView>(Resource.Id.procedureView);
        }
        private void InitializeProcedure()
        {
            Services.GetAllUsers();
            Services.GetAllProgramation();
            List<Programare> proceduresUser = Services.AllProgramationList.Where(itm => itm.id_doctor == Services.LoggedDoctor.id.ToString()).ToList();
            foreach (var item in proceduresUser)
            {
                string temp = GetPacientName(item.id_user);
                procedures.Add(new ProcedureModel() { name = temp,isExpanded=false, date = item.prog_name, hour = item.hour,coment=item.comments});
            }

        }
        private string GetPacientName(string id)
        {
            var usrname = Services.AllUserList.Where(itm => itm.id.ToString() == id).FirstOrDefault();
            if (usrname == null)
            {
                return "";
            }
            return usrname.name+" "+usrname.surname;
        }



    }
}

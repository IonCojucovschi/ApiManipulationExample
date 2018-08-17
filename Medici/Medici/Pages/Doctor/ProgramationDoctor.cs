﻿
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
                procedures.Add(new ProcedureModel() { name = temp, date = item.prog_name, hour = item.hour });
            }

            //Services.LoggedUser.name
        }
        private string GetPacientName(string id)
        {
            string dctname = Services.AllUserList.Where(itm => itm.id.ToString() == id).Select(itm => itm.name + " " + itm.surname).ToList().FirstOrDefault();
            return dctname;
        }



    }
}
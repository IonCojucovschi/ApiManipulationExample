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
using Medici.Models.AdapterHelpers;
using Medici.Repository;

namespace Medici
{
    [Activity(Label = "DoctorsListView")]
    public class DoctorsListView : BasePage
    {
        ListView listView;
        TextView titleText; 
        List<ProcedureModel> procedures = new List<ProcedureModel>();


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.view_programation);
            // Create your application here
            FindViews();
            InitializeProcedure();

            titleText.Text = "Doctor's list";
            ProcedureUserAdapter adapter = new ProcedureUserAdapter(this, procedures);
            listView.Adapter = adapter;
        }

        private void FindViews()
        {
            listView = FindViewById<ListView>(Resource.Id.procedureView);
            titleText = FindViewById<TextView>(Resource.Id.title_text);
        }
        private void InitializeProcedure()
        {
            Services.GetAllDoctors();
            foreach (var item in Services.AllDoctorsList)
            {
                procedures.Add(new ProcedureModel() { name = item.name+"  "+item.surname, date ="", hour ="" });
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
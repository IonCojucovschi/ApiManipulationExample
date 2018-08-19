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
using Medici.Models;
using Medici.Repository;

namespace Medici
{
    [Activity(Label = "AddProcedure")]
    public class AddProcedure : Activity
    {
        Spinner ProcedureVuew;
        TextView AddProcedureToUser;
        EditText newProcedure;
        TextView AddNewProcedure;

        Procedura SelectedProcedure;

        List<string> listProcedureSpiner;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.add_procedure);
            // Create your application here\
            FindViews();
            HandleEvents();
            InitializeSpinerContent();
        }

        private void FindViews()
        {
            ProcedureVuew = FindViewById<Spinner>(Resource.Id.existing_procedure);
            AddNewProcedure = FindViewById<TextView>(Resource.Id.add_new_procedure);
            newProcedure = FindViewById<EditText>(Resource.Id.create_procedure);
            AddProcedureToUser = FindViewById<TextView>(Resource.Id.add_procedure);
        }
        private void HandleEvents()
        {
            AddProcedureToUser.Click -= AddProcedureToDoc_Clicked;
            AddProcedureToUser.Click += AddProcedureToDoc_Clicked;
            AddNewProcedure.Click -= AddNewProcedureClicked;
            AddNewProcedure.Click += AddNewProcedureClicked;

        }
        private void InitializeSpinerContent()
        {
            var relationProcDoc = Services.AllProcedureDocRelationsList.Where(itm => itm.doc_id == Services.LoggedDoctor.id).Select(itm => itm.proc_id);
            var docProcedures = Services.GetAllProcedure().Where(item => !relationProcDoc.Contains(item.id));
            List<string> availableProcedures = new List<string>();

            foreach (var item in docProcedures)
            {
                availableProcedures.Add(item.name);
            }

            ArrayAdapter procedure_adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, availableProcedures);
            ProcedureVuew.Adapter = procedure_adapter;

            ProcedureVuew.ItemSelected -= new EventHandler<AdapterView.ItemSelectedEventArgs>(procedure_spiner_ItemSelected);
            ProcedureVuew.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(procedure_spiner_ItemSelected);
        }

        private void procedure_spiner_ItemSelected(object s, AdapterView.ItemSelectedEventArgs e)
        {
            SelectedProcedure = Services.GetAllProcedure().Where(nitm => nitm.name == ProcedureVuew.GetItemAtPosition(e.Position).ToString()).FirstOrDefault();
        }

        private void AddProcedureToDoc_Clicked(object s,EventArgs e)
        {
            if (SelectedProcedure != null)
            {
                Services.RegisterDocProcedureRelation(SelectedProcedure.id, Services.LoggedDoctor.id);
                InitializeSpinerContent();
                Toast.MakeText(this, SelectedProcedure.name+" is added!", ToastLength.Short).Show();
            }
            else
            {
                Toast.MakeText(this,"No procedure selected!!!",ToastLength.Short).Show();
            }
        }

        private void AddNewProcedureClicked(object s,EventArgs e)
        {
            if (newProcedure.Text != null | newProcedure.Text != "")
            {
                var thisProc = Services.GetAllProcedure().Where(itm=>itm.name==newProcedure.Text).FirstOrDefault();
                if (thisProc == null)
                {
                    if (InternetConnection.IsNetConnected())
                    {
                        Services.RegisterProcedure(newProcedure.Text);
                        InitializeSpinerContent();
                        newProcedure.Text = "";
                        Toast.MakeText(this, newProcedure.Text+ " is added.", ToastLength.Long).Show();
                    }
                    else Toast.MakeText(this, "No internet connection!!!", ToastLength.Short).Show();
                }
                else
                {
                    Toast.MakeText(this, "This procedure exist!!!", ToastLength.Short).Show();

                }
            }
            else
            {
                Toast.MakeText(this, "Imput is naked!", ToastLength.Short).Show();
            }
        }
    }
}
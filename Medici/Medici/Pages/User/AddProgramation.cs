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
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using static Android.App.DatePickerDialog;
using Medici.Models;
using Medici.Repository;
using Medici.Extensions;

namespace Medici
{
    [Activity(Label = "AddProgramation")]
    public class AddProgramation : Activity, IOnDateSetListener
    {
        Spinner doctorsSpin;
        Spinner procedureSpin;
        Spinner hourSpin;
        TextView selectDate;
        Spinner availableHours;
        EditText coment;
        TextView createProgramation;

        Programare programareaCurenta;
        Doctor selectedDoctor;
        AvailableDay selectedDay;
        bool isDayRegistred = false;
        /// asdfasdf
        List<AvailableDay> avaylableDays;
        const int DATE_DIALOG = 1;
        List<int> hours = new List<int> { 8, 9, 10, 11, 12, 13, 15, 16, 17 };
        private int year, month, day;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.add_programation);

            programareaCurenta = new Programare();
            programareaCurenta.id_user = Services.LoggedUser.id.ToString();
            FindViews();
            HndleEvents();
            AddSpinerContent();
            // Create your application here
        }

        public void FindViews()
        {
            doctorsSpin = FindViewById<Spinner>(Resource.Id.doctors_spinner);
            procedureSpin = FindViewById<Spinner>(Resource.Id.procedure_spinner);
            availableHours = FindViewById<Spinner>(Resource.Id.hour_spinner);
            coment = FindViewById<EditText>(Resource.Id.programation_comment);
            hourSpin = FindViewById<Spinner>(Resource.Id.hour_spinner);
            selectDate = FindViewById<TextView>(Resource.Id.select_date);
            createProgramation = FindViewById<TextView>(Resource.Id.create_programation);
            Toast.MakeText(this, "Select Programation Date", ToastLength.Short).Show();
        }
        private void AddSpinerContent()
        {
            var doctor = Services.GetAllDoctors().Select(item => item.name + " " + item.surname).ToList(); ;
            ArrayAdapter adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, doctor);
            doctorsSpin.Adapter = adapter;
            doctorsSpin.ItemSelected -= new EventHandler<AdapterView.ItemSelectedEventArgs>(doctor_spiner_ItemSelected);
            doctorsSpin.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(doctor_spiner_ItemSelected);

            var procedure = Services.GetAllProcedure().Select(item => item.name).ToList();
            ArrayAdapter procedure_adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, procedure);
            procedureSpin.Adapter = procedure_adapter;
            procedureSpin.ItemSelected -= new EventHandler<AdapterView.ItemSelectedEventArgs>(procedure_spiner_ItemSelected);
            procedureSpin.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(procedure_spiner_ItemSelected);


            ArrayAdapter hours_adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, hours);
            hourSpin.Adapter = hours_adapter;
            hourSpin.ItemSelected -= new EventHandler<AdapterView.ItemSelectedEventArgs>(hours_spiner_ItemSelected);
            hourSpin.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(hours_spiner_ItemSelected);


        }

        private void doctor_spiner_ItemSelected(object s, AdapterView.ItemSelectedEventArgs e)
        {
            string[] selectedDct = doctorsSpin.GetItemAtPosition(e.Position).ToString().Split(' ');
            selectedDoctor = Services.AllDoctorsList.Where(itm => itm.name == selectedDct[0] & itm.surname == selectedDct[1]).FirstOrDefault();
            programareaCurenta.id_doctor = selectedDoctor.id.ToString();
            avaylableDays = Services.GetAvailableDay();

            var relationProcDoc = Services.AllProcedureDocRelationsList.Where(itm => itm.doc_id == selectedDoctor.id).Select(itm => itm.proc_id);
            var docProcedures = Services.GetAllProcedure().Where(item => relationProcDoc.Contains(item.id));
            List<string> availableProcedures = new List<string>();

            foreach (var item in docProcedures)
            {
                availableProcedures.Add(item.name);
            }

            ArrayAdapter procedure_adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, availableProcedures);
            procedureSpin.Adapter = procedure_adapter;
        }
        private void procedure_spiner_ItemSelected(object s, AdapterView.ItemSelectedEventArgs e)
        {
            Procedura prc = Services.AllProcedureList.Where(itm => itm.name == procedureSpin.GetItemAtPosition(e.Position).ToString()).FirstOrDefault();
            programareaCurenta.id_procedure = prc.id.ToString();
        }
        private void hours_spiner_ItemSelected(object s, AdapterView.ItemSelectedEventArgs e)
        {
            programareaCurenta.hour = hourSpin.GetItemAtPosition(e.Position).ToString();
        }

        private void HndleEvents()
        {
            selectDate.Click += delegate
            {
                ShowDialog(DATE_DIALOG);
            };

            createProgramation.Click -= Create_Button_Clicked;
            createProgramation.Click += Create_Button_Clicked;
        }

        private void Create_Button_Clicked(object s, EventArgs e)
        {
            programareaCurenta.comments = coment.Text;

            if (programareaCurenta.prog_name != "" & programareaCurenta.id_doctor != "" &
                programareaCurenta.id_procedure != "" & programareaCurenta.hour != ""
                & programareaCurenta.id_user != "" & programareaCurenta.comments != "")
            {
                AvailableDay day = Services.AllAvailableDayLilst.Where(itm => itm.dayname == programareaCurenta.prog_name & itm.doctor_id == selectedDoctor.id.ToString()).FirstOrDefault();
                if (day == null)
                {
                    Services.RegisterProgramation(programareaCurenta);
                    AvailableDay dday = new AvailableDay()
                    {
                        dayname = programareaCurenta.prog_name,
                        work_hours = 1,
                        hours_list = programareaCurenta.hour + ",",
                        doctor_id = selectedDoctor.id.ToString()
                    };
                    Services.RegisterDayAvailability(dday);
                    this.OnBackPressed();
                }
                else
                {
                    if (selectedDay.hours_list.Split(',').Length < 9)
                    {
                        selectedDay.hours_list += programareaCurenta.hour + ",";
                        selectedDay.work_hours++;
                        Services.UpdateDayAvailability(selectedDay);
                        Services.RegisterProgramation(programareaCurenta);
                        //this.GoPage(typeof(HomeUser));
                        this.OnBackPressed();
                    }
                    else
                    {
                        Toast.MakeText(this, "This day is busy", ToastLength.Short).Show();
                    }
                }
            }
            else
            {
                Toast.MakeText(this, "All Procedure content is not completed", ToastLength.Short).Show();
            }

        }

        public override void OnBackPressed()
        {
            base.OnBackPressed();
            Finish();
        }



        protected override Dialog OnCreateDialog(int id)
        {
            switch (id)
            {
                case DATE_DIALOG:
                    {
                        return new DatePickerDialog(this, this, year, month, day);
                    }
                default: break;
            }
            return null;

        }
        public void OnDateSet(DatePicker view, int _year, int _month, int _day)
        {
            this.year = _year;
            this.month = _month + 1;
            this.day = _day;
            programareaCurenta.prog_name = day + "" + month + "" + year;
            avaylableDays = Services.GetAvailableDay();
            selectDate.Text = "Selected date: " + day + "/" + month + "/" + year;
            selectedDay = Services.AllAvailableDayLilst.Where(itm => itm.dayname == programareaCurenta.prog_name & itm.doctor_id == selectedDoctor.id.ToString()).FirstOrDefault();

            if (selectedDay != null)
            {
                List<string> usedHoursList = selectedDay.hours_list.Split(',').ToList();
                List<int> unUsedHoursList = new List<int>();

                foreach (var item in hours)
                {
                    if (!usedHoursList.Contains(item + ""))
                    {
                        unUsedHoursList.Add(item);
                    }
                }

                ArrayAdapter hours_adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, unUsedHoursList);
                hourSpin.Adapter = hours_adapter;
            }
            else
            {
                ArrayAdapter hours_adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, hours);
                hourSpin.Adapter = hours_adapter;
            }

        }


    }
}
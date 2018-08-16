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

namespace Medici
{
    [Activity(Label = "AddProgramation")]
    public class AddProgramation : Activity, IOnDateSetListener
    {
        Spinner doctorsSpin;
        Spinner procedureSpin;
        TextView selectDate;
        Spinner availableHours;
        EditText coment;

        Programare programareaCurenta;
        /// asdfasdf
        const int DATE_DIALOG = 1;
        List<int> hours = new List<int> { 8, 9, 10, 11, 12, 13, 15, 16, 17 };
        private int year, month, day;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.add_programation);

            programareaCurenta = new Programare();

            // Create your application here
        }

        public void FindViews()
        {
            doctorsSpin = FindViewById<Spinner>(Resource.Id.doctors_spinner);
            procedureSpin = FindViewById<Spinner>(Resource.Id.procedure_spinner);
            availableHours = FindViewById<Spinner>(Resource.Id.hour_spinner);
            coment = FindViewById<EditText>(Resource.Id.programation_comment);
            selectDate = FindViewById<TextView>(Resource.Id.select_date);
        }
        private void HndleEvents()
        {
            selectDate.Click += delegate
            {
                ShowDialog(DATE_DIALOG);
            };
        }

        protected override Dialog OnCreateDialog(int id)
        {
            switch (id)
            {
                case DATE_DIALOG:
                    {
                        return new DatePickerDialog(this, this, year, month, day);
                    }
                    break;
                default: break;
            }
            return null;

        }
        public void OnDateSet(DatePicker view, int year, int month, int day)
        {
            this.year = year;
            this.month = month + 1;
            this.day = day;
            programareaCurenta.prog_name = day + "" + month + "" + year;
        }


    }
}
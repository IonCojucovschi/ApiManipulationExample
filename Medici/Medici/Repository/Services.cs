using System;
using System.Collections.Generic;
using Medici.Models;

namespace Medici.Repository
{
    public static class Services
    {
        public static ManagerContent _resources;
        public static User CurentUser;
        public static Doctor CurentDoctor;

        public static List<Doctor> AllDoctorsList;
        public static List<User> AllUserList;
        public static List<AvailableDay> AllAvailableDayLilst;
        public static List<Procedura> AllProcedureList;
        public static List<Programare> AllProgramationList;
        public static List<RelationProcedureDoctor> AllProcedureDocRelationsList;

        public static User LoggedUser;
        public static Doctor LoggedDoctor;
        static Services()
        {
            _resources = new ManagerContent();
            GetAllProcedure();
            GetAllProcedureDocrelation();
        }

        #region GEt Content
        public static List<User> GetAllUsers()
        {
            AllUserList = _resources.GetAllUsers();
            return AllUserList;
        }
        public static List<Doctor> GetAllDoctors()
        {
            AllDoctorsList = _resources.GetAllDoctors();
            return AllDoctorsList;
        }
        public static List<Procedura> GetAllProcedure()
        {
            AllProcedureList = _resources.GetAllProcedure();
            return AllProcedureList;
        }
        public static List<Programare> GetAllProgramation()
        {
            AllProgramationList = _resources.GetAllProgramation();
            return AllProgramationList;
        }
        public static List<Programare> GetAllDoctorProgramation(int DctID)
        {
            var prg = _resources.GetDoctorProgramations(DctID);
            return prg;
        }
        public static List<AvailableDay> GetAvailableDay()
        {
            AllAvailableDayLilst = _resources.GetAllAvailableDays();
            return AllAvailableDayLilst;
        }
        public static List<RelationProcedureDoctor> GetAllProcedureDocrelation()
        {
            AllProcedureDocRelationsList = _resources.GetAllProcedureDocRelations();
            return AllProcedureDocRelationsList;
        }



        #endregion

        #region Login Region
        public static User LogUser(string login, string password)
        {
            LoggedUser = _resources.GetUserLog(login, password);
            return LoggedUser;
        }
        public static Doctor LogDoctor(string login, string password)
        {
            LoggedDoctor = _resources.GetDoctorLog(login, password);
            return LoggedDoctor;
        }
        #endregion

        #region register
        public static void RegisterUser(User user)
        {
            _resources.RegisterUser(user);
            CurentUser = user;
        }
        public static void RegisterDoctor(Doctor dct, Procedura procedura)
        {
            _resources.RegisterDoctor(dct, procedura);
            CurentDoctor = dct;
        }
        public static void RegisterProgramation(Programare procedura)
        {
            _resources.RegisterProgramation(procedura);
        }

        public static void RegisterDayAvailability(AvailableDay day)
        {
            _resources.RegisterDayAvailability(day);
        }

        public static void RegisterDocProcedureRelation(int proc_id, int doc_id)
        {
            _resources.REgisterDoc_ProcedRelation(proc_id, doc_id);
        }
        public static void RegisterProcedure(string name)
        {
            _resources.RegisterProcedure(name);
        }
        #endregion

        #region Update 
        public static void UpdateDayAvailability(AvailableDay day)
        {
            _resources.UpdateDayAvailability(day);
        }
        #endregion

    }
}

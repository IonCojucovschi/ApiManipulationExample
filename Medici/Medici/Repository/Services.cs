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

        public static User LoggedUser;
        public static Doctor LoggedDoctor;
        static Services()
        {
            _resources = new ManagerContent();
        }

        #region GEt Content
        public static List<User> GetAllUsers()
        {
            var users = _resources.GetAllUsers();
            return users;
        }
        public static List<Doctor> GetAllDoctors()
        {
            var dct = _resources.GetAllDoctors();
            return dct;
        }
        public static List<Procedura> GetAllProcedure()
        {
            var prc = _resources.GetAllProcedure();
            return prc;
        }
        public static List<Programare> GetAllProgramation()
        {
            var prg = _resources.GetAllProgramation();
            return prg;
        }
        public static List<Programare> GetAllDoctorProgramation(int DctID)
        {
            var prg = _resources.GetDoctorProgramations(DctID);
            return prg;
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

    }
}

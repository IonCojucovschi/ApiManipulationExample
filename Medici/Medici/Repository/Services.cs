using System;
using System.Collections.Generic;
using Medici.Models;

namespace Medici.Repository
{
    public static class Services
    {
        public static ManagerContent _resources;

        static Services()
        {
            _resources = new ManagerContent();
        }

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
        public static User LogUser(string login, string password)
        {
            var log = _resources.GetUserLog(login, password);
            return log;
        }
        public static Doctor LogDoctor(string login, string password)
        {
            var log = _resources.GetDoctorLog(login, password);
            return log;
        }


    }
}

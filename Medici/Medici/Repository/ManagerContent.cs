using System;
using System.Collections.Generic;
using System.Net;
using Medici.Helpers;
using Medici.Models;
using Newtonsoft.Json;
using System.Linq;

namespace Medici.Repository
{
    public class ManagerContent
    {
        public List<Doctor> doctors;
        public List<User> users;
        public List<Procedura> procedures;
        public List<Programare> programare_dct;
        public List<Programare> programari;
        public List<AvailableDay> availableDays;


        public Doctor curentDoctor;
        public User curentUser;



        public ManagerContent()
        {
            GetAllDoctors();
            GetAllUsers();

        }
        #region Get
        public List<Doctor> GetAllDoctors()
        {
            string responseJsonString = null;
            using (var httpClient = new WebClient())
            {
                try
                {
                    responseJsonString = httpClient.DownloadString(UrlConstant.BaseUrl + UrlConstant.GetAllDoctors);
                    var data = new DeserializeData<ResponseData<Doctor>>(responseJsonString);
                    doctors = data.DeserializedObject.data;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return doctors;
        }
        public List<User> GetAllUsers()
        {
            string responseJsonString = null;
            using (var httpClient = new WebClient())
            {
                try
                {
                    responseJsonString = httpClient.DownloadString(UrlConstant.BaseUrl + UrlConstant.GetAllUsers);
                    var data = new DeserializeData<ResponseData<User>>(responseJsonString);
                    users = data.DeserializedObject.data;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return users;
        }
        public List<Procedura> GetAllProcedure()
        {
            string responseJsonString = null;
            using (var httpClient = new WebClient())
            {
                try
                {
                    responseJsonString = httpClient.DownloadString(UrlConstant.BaseUrl + UrlConstant.GetAllProcedure);
                    var data = new DeserializeData<ResponseData<Procedura>>(responseJsonString);
                    procedures = data.DeserializedObject.data;
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return procedures;
        }
        public List<Programare> GetAllProgramation()
        {
            string responseJsonString = null;
            using (var httpClient = new WebClient())
            {
                try
                {
                    responseJsonString = httpClient.DownloadString(UrlConstant.BaseUrl + UrlConstant.GetAllProgramation);
                    var data = new DeserializeData<ResponseData<Programare>>(responseJsonString);
                    programari = data.DeserializedObject.data;
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return programari;
        }
        public List<AvailableDay> GetAllAvailableDays()
        {
            string responseJsonString = null;
            using (var httpClient = new WebClient())
            {
                try
                {
                    responseJsonString = httpClient.DownloadString(UrlConstant.BaseUrl + UrlConstant.GetAllAvailableDay);
                    var data = new DeserializeData<ResponseData<AvailableDay>>(responseJsonString);
                    availableDays = data.DeserializedObject.data;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return availableDays;
        }
        public List<Programare> GetDoctorProgramations(int DoctorId)
        {
            string responseJsonString = null;
            using (var httpClient = new WebClient())
            {
                try
                {
                    responseJsonString = httpClient.DownloadString(UrlConstant.BaseUrl + UrlConstant.GetProgramationByIdDoctor + DoctorId);
                    var data = new DeserializeData<ResponseData<Programare>>(responseJsonString);
                    programare_dct = data.DeserializedObject.data;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return programare_dct;
        }

        public User GetUserLog(string login, string password)
        {
            List<User> loggedUser;
            string responseJsonString = null;
            using (var httpClient = new WebClient())
            {
                try
                {
                    responseJsonString = httpClient.DownloadString(UrlConstant.BaseUrl + UrlConstant.GetUserById + login + '.' + password);
                    var data = new DeserializeData<ResponseData<User>>(responseJsonString);
                    loggedUser = data.DeserializedObject.data;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return loggedUser.FirstOrDefault();
        }
        public Doctor GetDoctorLog(string login, string password)
        {
            List<Doctor> loggedDoctor;
            string responseJsonString = null;
            using (var httpClient = new WebClient())
            {
                try
                {
                    responseJsonString = httpClient.DownloadString(UrlConstant.BaseUrl + UrlConstant.GetDoctorById + login + '.' + password);
                    var data = new DeserializeData<ResponseData<Doctor>>(responseJsonString);
                    loggedDoctor = data.DeserializedObject.data;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return loggedDoctor.FirstOrDefault();
        }




        #endregion

        #region Register
        public void RegisterDoctor(Doctor doctor, Procedura procedura)
        {
            string responseJsonString = null;
            using (var httpClient = new WebClient())
            {
                try
                {
                    responseJsonString = httpClient.DownloadString(UrlConstant.BaseUrl + UrlConstant.RegisterDoctor + doctor.login + '.' +
                        doctor.password + '.' + doctor.name + '.' + doctor.surname + '.' + procedura.id);
                }
                catch (Exception)
                {
                    throw;
                }
            }

        }
        public void RegisterUser(User user)
        {
            string responseJsonString = null;
            using (var httpClient = new WebClient())
            {
                try
                {
                    responseJsonString = httpClient.DownloadString(UrlConstant.BaseUrl + UrlConstant.RegisterUser + user.login + '.' +
                        user.pasword + '.' + user.name + '.' + user.surname + '.' + user.cellphone);
                }
                catch (Exception)
                {
                    throw;
                }

            }

        }
        public void RegisterProcedure(Procedura procedura)
        {
            string responseJsonString = null;
            using (var httpClient = new WebClient())
            {
                try
                {
                    responseJsonString = httpClient.DownloadString(UrlConstant.BaseUrl + UrlConstant.RegisterProcedure + procedura.name);
                }
                catch (Exception)
                {
                    throw;
                }

            }
        }
        public void RegisterDayAvailability(AvailableDay day)
        {
            string responseJsonString = null;
            using (var httpClient = new WebClient())
            {
                try
                {
                    responseJsonString = httpClient.DownloadString(UrlConstant.BaseUrl + UrlConstant.DayAvailabilityRegister +
                        day.dayname + '.' +
                                                                   day.hours_list + '.' + day.work_hours + '.' + day.doctor_id);
                }
                catch (Exception)
                {
                    throw;
                }

            }
        }
        public void RegisterProgramation(Programare programare)
        {
            string responseJsonString = null;
            using (var httpClient = new WebClient())
            {
                try
                {
                    responseJsonString = httpClient.DownloadString(UrlConstant.BaseUrl + UrlConstant.RegisterProgramation +
                                                                    programare.id_doctor + '.' +
                                                                    programare.id_user + '.' +
                                                                    programare.prog_name + '.' +
                                                                    programare.hour + '.' +
                                                                    programare.comments + '.' +
                                                                    programare.id_procedure);
                }
                catch (Exception)
                {
                    throw;
                }

            }
        }



        #endregion

        public void UpdateDayAvailability(AvailableDay newday)
        {
            string responseJsonString = null;
            using (var httpClient = new WebClient())
            {
                try
                {
                    responseJsonString = httpClient.DownloadString(UrlConstant.BaseUrl + UrlConstant.DayAvailabilityUpdate +
                        newday.id + '.' +
                        newday.hours_list + '.' + newday.work_hours);
                }
                catch (Exception)
                {
                    throw;
                }

            }
        }
    }

    #region GenericDeserialize
    public class DeserializeData<T> where T : class
    {
        public T DeserializedObject;

        public DeserializeData(string jsonFormat)
        {
            DeserializeFromJson(jsonFormat);
        }
        public T DeserializeFromJson(string jsonString)
        {
            DeserializedObject = JsonConvert.DeserializeObject<T>(jsonString);
            return DeserializedObject;
        }

    }

    public class ResponseData<T> where T : class
    {
        public List<T> data;
        public string text;
    }
    #endregion
}
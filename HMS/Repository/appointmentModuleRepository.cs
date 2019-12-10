using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HMS.Interface;
using HMS.Models;
using Microsoft.Ajax.Utilities;
using Microsoft.Owin.Security.Provider;


namespace HMS.Repository
{
    public class appointmentModuleRepository : Repository<appointmentModule>, IAppointmentModuleRepository
    {
        public appointmentModuleRepository(ApplicationDbContext context) : base(context)
        {

        }

        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }
       
        public  IEnumerable<appointmentModule> GetDoctorIdFromAppointmentModules(int id)
        {
            return ApplicationDbContext.AppointmentModules.Where(c => c.DoctorsId == id).ToList();

        }
         

    }
}
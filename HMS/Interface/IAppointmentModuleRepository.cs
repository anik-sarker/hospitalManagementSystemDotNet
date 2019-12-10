using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HMS.Models;

namespace HMS.Interface
{
    public interface IAppointmentModuleRepository :IRepository<appointmentModule>
    {
        IEnumerable<appointmentModule> GetDoctorIdFromAppointmentModules(int id);

    }
}
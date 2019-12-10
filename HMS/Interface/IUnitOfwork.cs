using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.Interface;
using HMS.Repository;

namespace HMS.UnitOfWork
{
   public interface IUnitOfwork :IDisposable
    {
        IAppointmentModuleRepository AppointmentModule { get; }
        IDoctorRepository Doctor { get; }
        IPatientRepository Patient { get; }
        IPaymentRepository Payment { get; }
        IStaffRepository Staff { get; }
        IUserInfoRepository UserInfo { get; }

        int Complete();
    }
}

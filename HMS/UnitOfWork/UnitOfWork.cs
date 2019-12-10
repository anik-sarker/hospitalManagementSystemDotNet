using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HMS.Interface;
using HMS.Models;
using HMS.Repository;

namespace HMS.UnitOfWork
{
    public class UnitOfWork : IUnitOfwork
    {
        private readonly ApplicationDbContext _context;

        public IAppointmentModuleRepository AppointmentModule { get; private set; }
        public IDoctorRepository Doctor { get; private set; }
        public IPatientRepository Patient { get; private set; }
        public IStaffRepository Staff { get; private set; }
        public IPaymentRepository Payment { get; private set; }
        public IUserInfoRepository UserInfo { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            AppointmentModule = new appointmentModuleRepository(_context);
            Doctor = new doctorRepository(_context);
            Patient = new patientRepository(_context);
            Staff = new staffRepository(_context);
            Payment = new paymentRepository(_context);
            UserInfo = new userInfoRepository(_context);
        }

      
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
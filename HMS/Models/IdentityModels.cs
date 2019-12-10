using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Services.Protocols;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HMS.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
                                                    //DATABASE
        public DbSet<doctor> Doctors { get; set; }
        public  DbSet<admin> Admins{ get; set; }
        public DbSet<helpdesk> Helpdesks { get; set; }
        public DbSet<labReport> LabReports { get; set; }
        public DbSet<nurse> Nurses { get; set; }
        public DbSet<patient> Patients { get; set; }
        public DbSet<payment> Payments { get; set; }
        public DbSet<staff> Staves { get; set; }
        public DbSet<userInfo> UserInfos { get; set; }
        public DbSet<ward> Wards { get; set; }
        public DbSet<appointmentModule> AppointmentModules { get; set; }


            public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<HMS.Models.patientReport> patientReports { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HMS.Interface;
using HMS.Models;

namespace HMS.Repository
{
    public class staffRepository : Repository<staff>,IStaffRepository
    {
        public staffRepository(ApplicationDbContext context) : base(context)
        {

        }
        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}
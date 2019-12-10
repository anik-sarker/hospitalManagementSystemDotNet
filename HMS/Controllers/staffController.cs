using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HMS.Models;

namespace HMS.Controllers
{
    public class staffController : Controller
    {
        private ApplicationDbContext _context;

        public staffController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult allPatient()
        {
            return View();
        }
        public ActionResult NewPatient()
        {
            return View();
        }

        public ActionResult createAppointment()
        {
            return View();
        }

        public ActionResult createHelpdesk()
        {
            return View();
        }

        public ActionResult makePayment()
        {
            return View();
        }

        public ActionResult test()
        {
            return View();
        }
        // GET: satff
        public ActionResult Home()
        {
            return View();
        }



    }
}
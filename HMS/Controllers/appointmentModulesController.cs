using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HMS.Models;
using HMS.UnitOfWork;

namespace HMS.Controllers
{
    public class appointmentModulesController : Controller
    {
        public int docId;
        public ActionResult getDocId(int id)
        {
            var unitOfWork = new UnitOfWork.UnitOfWork(new ApplicationDbContext());

            var am1 = unitOfWork.AppointmentModule.GetDoctorIdFromAppointmentModules(id);
            var d = docId;
            foreach (var k in am1)
            {
                d = k.DoctorsId;
            }

            int docInt = int.Parse(d.ToString());
            //int intID = int.Parse(varID.ToString());
            var docInfo = unitOfWork.Doctor.GetById(docInt);
  
            return View(docInfo);
        }




        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: appointmentModules
        public ActionResult Index()
        {
            var appointmentModules = db.AppointmentModules.Include(a => a.Doctors).Include(a => a.Patients);
            return View(appointmentModules.ToList());
        }

        // GET: appointmentModules/Details/5
        public ActionResult Details(int id)
        {
            var unitOfWork = new UnitOfWork.UnitOfWork(db);
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            appointmentModule appointmentModule = unitOfWork.AppointmentModule.GetById(id);
            if (appointmentModule == null)
            {
                return HttpNotFound();
            }
            return View(appointmentModule);
        }

        // GET: appointmentModules/Create
        public ActionResult Create()
        {
            ViewBag.DoctorsId = new SelectList(db.Doctors, "Id", "Name");
            ViewBag.PatientsId = new SelectList(db.Patients, "Id", "Name");
            return View();
        }

        // POST: appointmentModules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PatientsId,DoctorsId,AppointmentDateTime,Sickness")] appointmentModule appointmentModule)
        {
            var unitOfWork = new UnitOfWork.UnitOfWork(db);
            if (ModelState.IsValid)
            {
                unitOfWork.AppointmentModule.Insert(appointmentModule);
                unitOfWork.AppointmentModule.Complete();
                return RedirectToAction("Index");
            }

            ViewBag.DoctorsId = new SelectList(db.Doctors, "Id", "Name", appointmentModule.DoctorsId);
            ViewBag.PatientsId = new SelectList(db.Patients, "Id", "Name", appointmentModule.PatientsId);
            return View(appointmentModule);
        }

        // GET: appointmentModules/Edit/5
        public ActionResult Edit(int id)
        {
            var unitOfWork = new UnitOfWork.UnitOfWork(db);
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            appointmentModule appointmentModule = unitOfWork.AppointmentModule.GetById(id);
            if (appointmentModule == null)
            {
                return HttpNotFound();
            }
            ViewBag.DoctorsId = new SelectList(db.Doctors, "Id", "Name", appointmentModule.DoctorsId);
            ViewBag.PatientsId = new SelectList(db.Patients, "Id", "Name", appointmentModule.PatientsId);
            return View(appointmentModule);
        }

        // POST: appointmentModules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PatientsId,DoctorsId,AppointmentDateTime,Sickness")] appointmentModule appointmentModule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appointmentModule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DoctorsId = new SelectList(db.Doctors, "Id", "Name", appointmentModule.DoctorsId);
            ViewBag.PatientsId = new SelectList(db.Patients, "Id", "Name", appointmentModule.PatientsId);
            return View(appointmentModule);
        }

        // GET: appointmentModules/Delete/5
        public ActionResult Delete(int id)
        {
            var unitOfWork = new UnitOfWork.UnitOfWork(db);
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            appointmentModule appointmentModule = unitOfWork.AppointmentModule.GetById(id);
            if (appointmentModule == null)
            {
                return HttpNotFound();
            }
            return View(appointmentModule);
        }

        // POST: appointmentModules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var unitOfWork = new UnitOfWork.UnitOfWork(db);
            appointmentModule appointmentModule = unitOfWork.AppointmentModule.GetById(id);
            unitOfWork.AppointmentModule.Delete(appointmentModule);
            unitOfWork.Complete();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

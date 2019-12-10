using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HMS.Models;

namespace HMS.Controllers
{
    public class doctorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: doctors
        public ActionResult Index()
        {
            var unitOfWork = new UnitOfWork.UnitOfWork(db);
            return View(unitOfWork.Doctor.GetAll());
        }

        // GET: doctors/Details/5
        public ActionResult Details(int id)
        {
            var unitOfWork = new UnitOfWork.UnitOfWork(db);
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            doctor doctor = unitOfWork.Doctor.GetById(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // GET: doctors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: doctors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,Address,JoinDateTime,Education,Specialty,Location,Available,RunningPatients,Password")] doctor doctor)
        {
            var unitOfWork = new UnitOfWork.UnitOfWork(db);
            if (ModelState.IsValid)
            {
                unitOfWork.Doctor.Insert(doctor); 
                unitOfWork.Doctor.Complete();
                return RedirectToAction("Index");
            }

            return View(doctor);
        }

        // GET: doctors/Edit/5
        public ActionResult Edit(int id)
        {
            var unitOfWork = new UnitOfWork.UnitOfWork(db);
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            doctor doctor = unitOfWork.Doctor.GetById(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // POST: doctors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email,Address,JoinDateTime,Education,Specialty,Location,Available,RunningPatients,Password")] doctor doctor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(doctor);
        }

        // GET: doctors/Delete/5
        public ActionResult Delete(int id)
        {
            var unitOfWork = new UnitOfWork.UnitOfWork(db);
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            doctor doctor = unitOfWork.Doctor.GetById(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // POST: doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var unitOfWork = new UnitOfWork.UnitOfWork(db);
            doctor doctor = unitOfWork.Doctor.GetById(id);
            unitOfWork.Doctor.Delete(doctor);
            unitOfWork.Doctor.Complete();
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

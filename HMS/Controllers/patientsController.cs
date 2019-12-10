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
    public class patientsController : Controller
    {

        public ActionResult Home()
        {
            return View();
        }
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: patients
        public ActionResult Index()
        {
            var unitOfWork = new UnitOfWork.UnitOfWork(db);
            return View(unitOfWork.Patient.GetAll());
        }

        // GET: patients/Details/5
        public ActionResult Details(int id)
        {
            var unitOfWork = new UnitOfWork.UnitOfWork(db);
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            patient patient = unitOfWork.Patient.GetById(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // GET: patients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: patients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,PhoneNumber,Gender,DateOfBirth,Address,Sickness,Allergies,Password")] patient patient)
        {
     
            var unitOfWork = new UnitOfWork.UnitOfWork(db);


            if (ModelState.IsValid)
            {

                unitOfWork.Patient.Insert(patient);

                userInfo u1=new userInfo();
                u1.Email = patient.Email;
                u1.Password = patient.Password;
                u1.Post = "patient";


               // db.Patients.Add(patient);
                unitOfWork.Patient.Complete();
                return RedirectToAction("Index","userInfo",u1);
            }

            return View(patient);
        }

        // GET: patients/Edit/5
        public ActionResult Edit(int id)
        {
            var unitOfWork = new UnitOfWork.UnitOfWork(db);
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            patient patient = unitOfWork.Patient.GetById(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: patients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email,PhoneNumber,Gender,DateOfBirth,Address,Sickness,Allergies,Password")] patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patient);
        }

        // GET: patients/Delete/5
        public ActionResult Delete(int id)
        {
            var unitOfWork = new UnitOfWork.UnitOfWork(db);
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            patient patient = unitOfWork.Patient.GetById(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var unitOfWork = new UnitOfWork.UnitOfWork(db);
            patient patient = unitOfWork.Patient.GetById(id);
            db.Patients.Remove(patient);
            db.SaveChanges();
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

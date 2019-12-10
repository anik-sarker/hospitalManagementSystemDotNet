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
    public class paymentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: payments
        public ActionResult Index()
        {
            var payments = db.Payments.Include(p => p.Doctors).Include(p => p.Patients);
            return View(payments.ToList());
        }

        // GET: payments/Details/5
        public ActionResult Details(int id)
        {
            var unitOfWork = new UnitOfWork.UnitOfWork(db);
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            payment payment = unitOfWork.Payment.GetById(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // GET: payments/Create
        public ActionResult Create()
        {
            ViewBag.DoctorsId = new SelectList(db.Doctors, "Id", "Name");
            ViewBag.PatientsId = new SelectList(db.Patients, "Id", "Name");
            return View();
        }

        // POST: payments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PatientsId,DoctorsId,Amount")] payment payment)
        {
            var unitOfWork = new UnitOfWork.UnitOfWork(db);
            if (ModelState.IsValid)
            {
                unitOfWork.Payment.Insert(payment);
                unitOfWork.Payment.Complete();
                return RedirectToAction("Index");
            }

            ViewBag.DoctorsId = new SelectList(db.Doctors, "Id", "Name", payment.DoctorsId);
            ViewBag.PatientsId = new SelectList(db.Patients, "Id", "Name", payment.PatientsId);
            return View(payment);
        }

        // GET: payments/Edit/5
        public ActionResult Edit(int id)
        {
            var unitOfWork = new UnitOfWork.UnitOfWork(db);
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            payment payment = unitOfWork.Payment.GetById(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            ViewBag.DoctorsId = new SelectList(db.Doctors, "Id", "Name", payment.DoctorsId);
            ViewBag.PatientsId = new SelectList(db.Patients, "Id", "Name", payment.PatientsId);
            return View(payment);
        }

        // POST: payments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PatientsId,DoctorsId,Amount")] payment payment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(payment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DoctorsId = new SelectList(db.Doctors, "Id", "Name", payment.DoctorsId);
            ViewBag.PatientsId = new SelectList(db.Patients, "Id", "Name", payment.PatientsId);
            return View(payment);
        }

        // GET: payments/Delete/5
        public ActionResult Delete(int id)
        {
            var unitOfWork = new UnitOfWork.UnitOfWork(db);
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            payment payment = unitOfWork.Payment.GetById(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // POST: payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var unitOfWork = new UnitOfWork.UnitOfWork(db);
            payment payment = unitOfWork.Payment.GetById(id);
            unitOfWork.Payment.Delete(payment);
            unitOfWork.Payment.Complete();
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

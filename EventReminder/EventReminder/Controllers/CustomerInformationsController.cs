using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EventReminder.Models;

namespace EventReminder.Controllers
{
    public class CustomerInformationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CustomerInformations
        public ActionResult Index()
        {
            return View(db.CustomerInformation.ToList());
        }

        // GET: CustomerInformations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerInformation customerInformation = db.CustomerInformation.Find(id);
            if (customerInformation == null)
            {
                return HttpNotFound();
            }
            return View(customerInformation);
        }

        // GET: CustomerInformations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerInformations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "customerInfoID,FirstName,LastName,Phone,Address,City,State,ZipCode,Email")] CustomerInformation customerInformation)
        {
            if (ModelState.IsValid)
            {
                db.CustomerInformation.Add(customerInformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customerInformation);
        }

        // GET: CustomerInformations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerInformation customerInformation = db.CustomerInformation.Find(id);
            if (customerInformation == null)
            {
                return HttpNotFound();
            }
            return View(customerInformation);
        }

        // POST: CustomerInformations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "customerInfoID,FirstName,LastName,Phone,Address,City,State,ZipCode,Email")] CustomerInformation customerInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerInformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customerInformation);
        }

        // GET: CustomerInformations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerInformation customerInformation = db.CustomerInformation.Find(id);
            if (customerInformation == null)
            {
                return HttpNotFound();
            }
            return View(customerInformation);
        }

        // POST: CustomerInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerInformation customerInformation = db.CustomerInformation.Find(id);
            db.CustomerInformation.Remove(customerInformation);
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

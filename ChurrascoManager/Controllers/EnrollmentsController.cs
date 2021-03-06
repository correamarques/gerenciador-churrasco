﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using ChurrascoManager.DAL;
using ChurrascoManager.Models;

namespace ChurrascoManager.Controllers
{
    public class EnrollmentsController : Controller
    {
        private ChurrascoContext db = new ChurrascoContext();

        // GET: Enrollments
        public ViewResult Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            var enrollments = db.Enrollments.Include(e => e.Event).Include(e => e.Person).ToList();
            return View(enrollments.ToPagedList(pageNumber, pageSize));
        }

        // GET: Enrollments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = db.Enrollments.Find(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            return View(enrollment);
        }

        // GET: Enrollments/Create
        public ActionResult Create()
        {
            ViewBag.EventList = new SelectList(db.Events, "ID", "Description", Request.QueryString["e"]);
            ViewBag.PersonList = new SelectList(db.Persons, "ID", "Name", Request.QueryString["p"]);

            return View();
        }

        // POST: Enrollments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,EventID,PersonID,Paid,Drink,Amount,Observation")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                if (enrollment.Amount > 0 && !enrollment.Paid)
                    enrollment.Paid = true;

                db.Enrollments.Add(enrollment);
                db.SaveChanges();
                return RedirectToAction("Details", "Events", new { id = enrollment.EventID});
            }

            ViewBag.EventList = new SelectList(db.Events, "ID", "Description", enrollment.EventID);
            ViewBag.PersonList = new SelectList(db.Persons, "ID", "Name", enrollment.PersonID);
            return View(enrollment);
        }

        // GET: Enrollments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = db.Enrollments.Find(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventList = new SelectList(db.Events, "ID", "Description", enrollment.EventID);
            ViewBag.PersonList = new SelectList(db.Persons, "ID", "Name", enrollment.PersonID);
            return View(enrollment);
        }

        // POST: Enrollments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,EventID,PersonID,Paid,Drink,Amount,Observation")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enrollment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "Events", new { id = enrollment.EventID });
            }
            ViewBag.EventList = new SelectList(db.Events, "ID", "Description", enrollment.EventID);
            ViewBag.PersonList = new SelectList(db.Persons, "ID", "Name", enrollment.PersonID);
            return View(enrollment);
        }

        // GET: Enrollments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = db.Enrollments.Find(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            return View(enrollment);
        }

        // POST: Enrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Enrollment enrollment = db.Enrollments.Find(id);
            db.Enrollments.Remove(enrollment);
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

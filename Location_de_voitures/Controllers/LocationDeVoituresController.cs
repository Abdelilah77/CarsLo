using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Location_de_voitures.Context;
using Location_de_voitures.Models;

namespace Location_de_voitures.Controllers
{
    public class LocationDeVoituresController : Controller
    {
        private DbCont db = new DbCont();

        // GET: LocationDeVoitures
        public ActionResult Index()
        {
            return View(db.LocationDeVoitures.ToList());
        }

        // GET: LocationDeVoitures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocationDeVoiture locationDeVoiture = db.LocationDeVoitures.Find(id);
            if (locationDeVoiture == null)
            {
                return HttpNotFound();
            }
            return View(locationDeVoiture);
        }

        // GET: LocationDeVoitures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LocationDeVoitures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idlocation,dateReservation,datePaiment,Montant,idCli,idV")] LocationDeVoiture locationDeVoiture)
        {
            if (ModelState.IsValid)
            {
                db.LocationDeVoitures.Add(locationDeVoiture);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(locationDeVoiture);
        }

        // GET: LocationDeVoitures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocationDeVoiture locationDeVoiture = db.LocationDeVoitures.Find(id);
            if (locationDeVoiture == null)
            {
                return HttpNotFound();
            }
            return View(locationDeVoiture);
        }

        // POST: LocationDeVoitures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idlocation,dateReservation,datePaiment,Montant,idCli,idV")] LocationDeVoiture locationDeVoiture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(locationDeVoiture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(locationDeVoiture);
        }

        // GET: LocationDeVoitures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocationDeVoiture locationDeVoiture = db.LocationDeVoitures.Find(id);
            if (locationDeVoiture == null)
            {
                return HttpNotFound();
            }
            return View(locationDeVoiture);
        }

        // POST: LocationDeVoitures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LocationDeVoiture locationDeVoiture = db.LocationDeVoitures.Find(id);
            db.LocationDeVoitures.Remove(locationDeVoiture);
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Location_de_voitures.Context;
using Location_de_voitures.Models;

namespace Location_de_voitures.Controllers
{
    public class AdminController : Controller
    {
        private DbCont db = new DbCont();

        // GET: Admin
        public ActionResult Index()
        {
            @Session["RegisterMessage"] = null;
            return View(db.Voitures.ToList());
        }
        public ActionResult Indexx()
        {
            @Session["RegisterMessage"] = null;
            return View(db.Voitures.ToList());
        }

        // GET: Admin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voiture voiture = db.Voitures.Find(id);
            if (voiture == null)
            {
                return HttpNotFound();
            }
            return View(voiture);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Vmatricule,Name,PrixKm,datePriseduKm,kilometrage,ImgUrl")] Voiture voiture)
        {
            if (Request.Files.Count > 0)
            {

                HttpPostedFileBase files = Request.Files[0];

                string chemin = "";

                if (files.ContentLength > 0)
                {
                    chemin = files.FileName;
                    voiture.ImgUrl = chemin;

                    var path = Path.Combine(Server.MapPath("~/carsImg"), chemin);
                    files.SaveAs(path);




                }
            }
            if (ModelState.IsValid)
            {
                db.Voitures.Add(voiture);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(voiture);
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voiture voiture = db.Voitures.Find(id);
            if (voiture == null)
            {
                return HttpNotFound();
            }
            return View(voiture);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Vmatricule,Name,PrixKm,datePriseduKm,kilometrage,ImgUrl")] Voiture voiture)
        {

            var a = db.Voitures.AsNoTracking().FirstOrDefault(c => c.Vmatricule == voiture.Vmatricule).Vmatricule;

            string fullPath = Request.MapPath("~/carsImg/" + a);
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }

            if (Request.Files.Count > 0)
            {

                HttpPostedFileBase files = Request.Files[0];

                if (files.ContentLength > 0)
                {
                    voiture.ImgUrl = files.FileName;



                }
            }
            if (ModelState.IsValid)
            {
                db.Entry(voiture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(voiture);
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voiture voiture = db.Voitures.Find(id);
            if (voiture == null)
            {
                return HttpNotFound();
            }
            return View(voiture);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Voiture voiture = db.Voitures.Find(id);
            db.Voitures.Remove(voiture);
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

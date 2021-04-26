using Location_de_voitures.Context;
using Location_de_voitures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Location_de_voitures.Controllers
{
    public class HomeController : Controller
    {
        DbCont db = new DbCont();

        public ActionResult Index()
        {
            return View(db.Voitures.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
      [HttpPost]
        public ActionResult Login(Client Clinet)
        {
          
            var CheckDataIfExists = db.Clients.SingleOrDefault(C => C.email.Equals(Clinet.email) && C.Password.Equals(Clinet.Password));
            if (CheckDataIfExists != null)
            {
                Session["RegisterMessage"] = null;
                Session["Login"] = "on";
                Session["idc"] = db.Clients.FirstOrDefault(C => C.email.Equals(Clinet.email)).Id_cli;
                Session["name"] = CheckDataIfExists.email;
                return RedirectToAction("index");
            }
            else if (Clinet.email.ToUpper() == "admin@1.com".ToUpper()
                 && Clinet.Password.ToUpper()=="admin".ToUpper())
            {
                Session["name"] = "Admin Mode";
                Session["Login"] = "on";

                return RedirectToAction("index","Admin");
            }
            Session["Login"] = "off";

            Session["RegisterMessage"] = "Hello User, You have aproblem in your password or email";
            return RedirectToAction("Login");
         

        }
        public ActionResult register()
        {
            return View();
        }
        
        public ActionResult Logout()
        {
            Session["Login"] = "off";

            Session["name"] = null;
            return RedirectToAction("Login");
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Nom,adresseClient,Tel,email,Password")] Client client)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        int autoIncreament = 0;
        //        var req = (from cli in db.Clients
        //                   select cli.Id_cli).Last();
        //        if (req != 0) autoIncreament = req++;
        //        client.Id_cli = autoIncreament;
        //        db.Clients.Add(client);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(client);
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_cli,Nom,adresseClient,Tel,email,Password")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(client);
        }
    }
}
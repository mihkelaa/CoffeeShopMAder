using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CoffeeShop.Models;

namespace CoffeeShop.Controllers
{
    public class KohviautomaatsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //GET: Kohviautomaats
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Kohviautomaat.ToList());
        }

        // GET: Kohviautomaats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kohviautomaat kohviautomaat = db.Kohviautomaat.Find(id);
            if (kohviautomaat == null)
            {
                return HttpNotFound();
            }
            return View(kohviautomaat);
        }

        // GET: Kohviautomaats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kohviautomaats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,JoogiNimi,TopsePakis,TopseJuua")] Kohviautomaat kohviautomaat)
        {
            if (ModelState.IsValid)
            {
                db.Kohviautomaat.Add(kohviautomaat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kohviautomaat);
        }

        // GET: Kohviautomaats/Edit/5
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kohviautomaat kohviautomaat = db.Kohviautomaat.Find(id);
            if (kohviautomaat == null)
            {
                return HttpNotFound();
            }
            return View(kohviautomaat);
        }

        // POST: Kohviautomaats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,JoogiNimi,TopsePakis,TopseJuua,PakkeLisatud")] Kohviautomaat kohviautomaat,string btn_halda)
        {
            if (ModelState.IsValid)
            {
                if (btn_halda == "Save")
                {
                    if(kohviautomaat.PakkeLisatud == 1)
                    {
                        kohviautomaat.TopseJuua += 50;
                        kohviautomaat.PakkeLisatud = 0;
                    }
                    if (kohviautomaat.PakkeLisatud ==2)
                    {
                        kohviautomaat.TopseJuua += 100;
                        kohviautomaat.PakkeLisatud = 0;
                    }

                }
                db.Entry(kohviautomaat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kohviautomaat);
        }

        // GET: Kohviautomaats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kohviautomaat kohviautomaat = db.Kohviautomaat.Find(id);
            if (kohviautomaat == null)
            {
                return HttpNotFound();
            }
            return View(kohviautomaat);
        }

        // POST: Kohviautomaats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kohviautomaat kohviautomaat = db.Kohviautomaat.Find(id);
            db.Kohviautomaat.Remove(kohviautomaat);
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
        [Authorize]
        public ActionResult Haldus([Bind(Include = "Id,JoogiNimi,TopsePakis,TopseJuua")] Kohviautomaat kohviautomaat ,string btn)
        {
            if (ModelState.IsValid)
            {   
                db.Entry(kohviautomaat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kohviautomaat);

        }
        public ActionResult Telli(string btn_telli,Kohviautomaat kohviautomaat)
        {
            if (ModelState.IsValid)
            {
                if (btn_telli == "Save")
                {
                    kohviautomaat.TopseJuua -= 1;
                    return View(db.Kohviautomaat.ToList());
                }
            }
            return View(db.Kohviautomaat.ToList());
        }
        


    }
}

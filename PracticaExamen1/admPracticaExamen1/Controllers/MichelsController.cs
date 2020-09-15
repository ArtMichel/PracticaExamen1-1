using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using admPracticaExamen1.Models;

namespace admPracticaExamen1.Controllers
{
    public class MichelsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Michels
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Michels.ToList());
        }

        // GET: Michels/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Michel michel = db.Michels.Find(id);
            if (michel == null)
            {
                return HttpNotFound();
            }
            return View(michel);
        }

        // GET: Michels/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Michels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MichelID,FriendofMichel,Place,Email,Birthday")] Michel michel)
        {
            if (ModelState.IsValid)
            {
                db.Michels.Add(michel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(michel);
        }

        // GET: Michels/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Michel michel = db.Michels.Find(id);
            if (michel == null)
            {
                return HttpNotFound();
            }
            return View(michel);
        }

        // POST: Michels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MichelID,FriendofMichel,Place,Email,Birthday")] Michel michel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(michel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(michel);
        }

        // GET: Michels/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Michel michel = db.Michels.Find(id);
            if (michel == null)
            {
                return HttpNotFound();
            }
            return View(michel);
        }

        // POST: Michels/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Michel michel = db.Michels.Find(id);
            db.Michels.Remove(michel);
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

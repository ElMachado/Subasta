using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using feria.Models;

namespace feria.Controllers
{
    public class CompradorsController : Controller
    {
        private DBsubastaEntities db = new DBsubastaEntities();

        // GET: Compradors
        public ActionResult Index()
        {
            var comprador = db.Comprador.Include(c => c.Roles).Include(c => c.Usuarios);
            return View(comprador.ToList());
        }

        // GET: Compradors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comprador comprador = db.Comprador.Find(id);
            if (comprador == null)
            {
                return HttpNotFound();
            }
            return View(comprador);
        }

        // GET: Compradors/Create
        public ActionResult Create()
        {
            ViewBag.IDrol = new SelectList(db.Roles, "IDrol", "Descripcion");
            ViewBag.IDusuario = new SelectList(db.Usuarios, "IDusuario", "Nombre");
            return View();
        }

        // POST: Compradors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDusuario,NombreUsuario,ContraseñaUsuario,IDrol")] Comprador comprador)
        {
            if (ModelState.IsValid)
            {
                db.Comprador.Add(comprador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDrol = new SelectList(db.Roles, "IDrol", "Descripcion", comprador.IDrol);
            ViewBag.IDusuario = new SelectList(db.Usuarios, "IDusuario", "Nombre", comprador.IDusuario);
            return View(comprador);
        }

        // GET: Compradors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comprador comprador = db.Comprador.Find(id);
            if (comprador == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDrol = new SelectList(db.Roles, "IDrol", "Descripcion", comprador.IDrol);
            ViewBag.IDusuario = new SelectList(db.Usuarios, "IDusuario", "Nombre", comprador.IDusuario);
            return View(comprador);
        }

        // POST: Compradors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDusuario,NombreUsuario,ContraseñaUsuario,IDrol")] Comprador comprador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comprador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDrol = new SelectList(db.Roles, "IDrol", "Descripcion", comprador.IDrol);
            ViewBag.IDusuario = new SelectList(db.Usuarios, "IDusuario", "Nombre", comprador.IDusuario);
            return View(comprador);
        }

        // GET: Compradors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comprador comprador = db.Comprador.Find(id);
            if (comprador == null)
            {
                return HttpNotFound();
            }
            return View(comprador);
        }

        // POST: Compradors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comprador comprador = db.Comprador.Find(id);
            db.Comprador.Remove(comprador);
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

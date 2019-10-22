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
    public class VendedorsController : Controller
    {
        private DBsubastaEntities db = new DBsubastaEntities();

        // GET: Vendedors
        public ActionResult Index()
        {
            var vendedor = db.Vendedor.Include(v => v.Roles).Include(v => v.Usuarios);
            return View(vendedor.ToList());
        }

        // GET: Vendedors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendedor vendedor = db.Vendedor.Find(id);
            if (vendedor == null)
            {
                return HttpNotFound();
            }
            return View(vendedor);
        }

        // GET: Vendedors/Create
        public ActionResult Create()
        {
            ViewBag.IDrol = new SelectList(db.Roles, "IDrol", "Descripcion");
            ViewBag.IDusuario = new SelectList(db.Usuarios, "IDusuario", "Nombre");
            return View();
        }

        // POST: Vendedors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDusuario,NombreUsuario,ContrasenaUsuario,IDrol")] Vendedor vendedor)
        {
            if (ModelState.IsValid)
            {
                db.Vendedor.Add(vendedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDrol = new SelectList(db.Roles, "IDrol", "Descripcion", vendedor.IDrol);
            ViewBag.IDusuario = new SelectList(db.Usuarios, "IDusuario", "Nombre", vendedor.IDusuario);
            return View(vendedor);
        }

        // GET: Vendedors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendedor vendedor = db.Vendedor.Find(id);
            if (vendedor == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDrol = new SelectList(db.Roles, "IDrol", "Descripcion", vendedor.IDrol);
            ViewBag.IDusuario = new SelectList(db.Usuarios, "IDusuario", "Nombre", vendedor.IDusuario);
            return View(vendedor);
        }

        // POST: Vendedors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDusuario,NombreUsuario,ContrasenaUsuario,IDrol")] Vendedor vendedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vendedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDrol = new SelectList(db.Roles, "IDrol", "Descripcion", vendedor.IDrol);
            ViewBag.IDusuario = new SelectList(db.Usuarios, "IDusuario", "Nombre", vendedor.IDusuario);
            return View(vendedor);
        }

        // GET: Vendedors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendedor vendedor = db.Vendedor.Find(id);
            if (vendedor == null)
            {
                return HttpNotFound();
            }
            return View(vendedor);
        }

        // POST: Vendedors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vendedor vendedor = db.Vendedor.Find(id);
            db.Vendedor.Remove(vendedor);
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

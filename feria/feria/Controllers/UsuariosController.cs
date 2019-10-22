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
    public class UsuariosController : Controller
    {
        private DBsubastaEntities db = new DBsubastaEntities();

        // GET: Usuarios
        public ActionResult Index()
        {
            var usuarios = db.Usuarios.Include(u => u.Comprador).Include(u => u.Roles).Include(u => u.Vendedor);
            return View(usuarios.ToList());
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios usuarios = db.Usuarios.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            return View(usuarios);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            ViewBag.IDusuario = new SelectList(db.Comprador, "IDusuario", "NombreUsuario");
            ViewBag.RolActual = new SelectList(db.Roles, "IDrol", "Descripcion");
            ViewBag.IDusuario = new SelectList(db.Vendedor, "IDusuario", "NombreUsuario");
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DocNumero,IDusuario,Nombre,Apellido,RolActual")] Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios.Add(usuarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDusuario = new SelectList(db.Comprador, "IDusuario", "NombreUsuario", usuarios.IDusuario);
            ViewBag.RolActual = new SelectList(db.Roles, "IDrol", "Descripcion", usuarios.RolActual);
            ViewBag.IDusuario = new SelectList(db.Vendedor, "IDusuario", "NombreUsuario", usuarios.IDusuario);
            return View(usuarios);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios usuarios = db.Usuarios.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDusuario = new SelectList(db.Comprador, "IDusuario", "NombreUsuario", usuarios.IDusuario);
            ViewBag.RolActual = new SelectList(db.Roles, "IDrol", "Descripcion", usuarios.RolActual);
            ViewBag.IDusuario = new SelectList(db.Vendedor, "IDusuario", "NombreUsuario", usuarios.IDusuario);
            return View(usuarios);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DocNumero,IDusuario,Nombre,Apellido,RolActual")] Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDusuario = new SelectList(db.Comprador, "IDusuario", "NombreUsuario", usuarios.IDusuario);
            ViewBag.RolActual = new SelectList(db.Roles, "IDrol", "Descripcion", usuarios.RolActual);
            ViewBag.IDusuario = new SelectList(db.Vendedor, "IDusuario", "NombreUsuario", usuarios.IDusuario);
            return View(usuarios);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios usuarios = db.Usuarios.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            return View(usuarios);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuarios usuarios = db.Usuarios.Find(id);
            db.Usuarios.Remove(usuarios);
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

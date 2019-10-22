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
    public class VentaArticuloesController : Controller
    {
        private DBsubastaEntities db = new DBsubastaEntities();

        // GET: VentaArticuloes
        public ActionResult Index()
        {
            var ventaArticulo = db.VentaArticulo.Include(v => v.Articulo).Include(v => v.Comprador);
            return View(ventaArticulo.ToList());
        }

        // GET: VentaArticuloes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VentaArticulo ventaArticulo = db.VentaArticulo.Find(id);
            if (ventaArticulo == null)
            {
                return HttpNotFound();
            }
            return View(ventaArticulo);
        }

        // GET: VentaArticuloes/Create
        public ActionResult Create()
        {
            ViewBag.IDarticulo = new SelectList(db.Articulo, "IDarticulo", "Descripcion");
            ViewBag.IDcomprador = new SelectList(db.Comprador, "IDusuario", "NombreUsuario");
            return View();
        }

        // POST: VentaArticuloes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDarticulo,Fecha,IDcomprador,PrecioSalida,PrecioVenta")] VentaArticulo ventaArticulo)
        {
            if (ModelState.IsValid)
            {
                db.VentaArticulo.Add(ventaArticulo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDarticulo = new SelectList(db.Articulo, "IDarticulo", "Descripcion", ventaArticulo.IDarticulo);
            ViewBag.IDcomprador = new SelectList(db.Comprador, "IDusuario", "NombreUsuario", ventaArticulo.IDcomprador);
            return View(ventaArticulo);
        }

        // GET: VentaArticuloes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VentaArticulo ventaArticulo = db.VentaArticulo.Find(id);
            if (ventaArticulo == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDarticulo = new SelectList(db.Articulo, "IDarticulo", "Descripcion", ventaArticulo.IDarticulo);
            ViewBag.IDcomprador = new SelectList(db.Comprador, "IDusuario", "NombreUsuario", ventaArticulo.IDcomprador);
            return View(ventaArticulo);
        }

        // POST: VentaArticuloes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDarticulo,Fecha,IDcomprador,PrecioSalida,PrecioVenta")] VentaArticulo ventaArticulo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ventaArticulo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDarticulo = new SelectList(db.Articulo, "IDarticulo", "Descripcion", ventaArticulo.IDarticulo);
            ViewBag.IDcomprador = new SelectList(db.Comprador, "IDusuario", "NombreUsuario", ventaArticulo.IDcomprador);
            return View(ventaArticulo);
        }

        // GET: VentaArticuloes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VentaArticulo ventaArticulo = db.VentaArticulo.Find(id);
            if (ventaArticulo == null)
            {
                return HttpNotFound();
            }
            return View(ventaArticulo);
        }

        // POST: VentaArticuloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VentaArticulo ventaArticulo = db.VentaArticulo.Find(id);
            db.VentaArticulo.Remove(ventaArticulo);
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

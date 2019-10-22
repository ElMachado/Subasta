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
    public class PujasController : Controller
    {
        private DBsubastaEntities db = new DBsubastaEntities();

        // GET: Pujas
        public ActionResult Index()
        {
            var ventaArticulo = db.VentaArticulo.Include(v => v.Articulo).Include(v => v.Comprador);
            return View(ventaArticulo.ToList());
        }

        // GET: Pujas/Details/5
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

        // GET: Pujas/Create
        public ActionResult Create()
        {
            ViewBag.IDarticulo = new SelectList(db.Articulo, "IDarticulo", "Descripcion");
            ViewBag.IDcomprador = new SelectList(db.Comprador, "IDusuario", "NombreUsuario");
            return View();
        }

        // POST: Pujas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Pujas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VentaArticulo ventaArticulo = db.VentaArticulo.SingleOrDefault(model => model.IDarticulo == id); ;
            if (ventaArticulo == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDarticulo = new SelectList(db.Articulo, "IDarticulo", "Descripcion", ventaArticulo.IDarticulo);
            ViewBag.IDcomprador = new SelectList(db.Comprador, "IDusuario", "NombreUsuario", ventaArticulo.IDcomprador);
            return View(ventaArticulo);
        }

        // POST: Pujas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDarticulo,IDusuario,Fecha,PrecioSalida,PrecioVenta")] VentaArticulo ventaArticulo)
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

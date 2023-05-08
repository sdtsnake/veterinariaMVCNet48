using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VeterinariaFramework.Models;

namespace VeterinariaFramework.Controllers
{
    public class MascotaController : Controller
    {
        private VeterinariaDbContext db = new VeterinariaDbContext();

        // GET: Mascota
        public ActionResult Index()
        {
            var mascotas = db.Mascotas.Include(m => m.Usuario);
            return View(mascotas.ToList());
        }

        // GET: Mascota/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mascota mascota = db.Mascotas.Find(id);
            if (mascota == null)
            {
                return HttpNotFound();
            }
            return View(mascota);
        }

        // GET: Mascota/Create
        public ActionResult Create()
        {
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "UsuarioId", "Nombre");
            return View();
        }

        // POST: Mascota/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MascotaId,Nombre,Raza,Sexo,UsuarioId")] Mascota mascota)
        {
            if (ModelState.IsValid)
            {
                db.Mascotas.Add(mascota);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UsuarioId = new SelectList(db.Usuarios, "UsuarioId", "Nombre", mascota.UsuarioId);
            return View(mascota);
        }

        // GET: Mascota/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mascota mascota = db.Mascotas.Find(id);
            if (mascota == null)
            {
                return HttpNotFound();
            }
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "UsuarioId", "Nombre", mascota.UsuarioId);
            return View(mascota);
        }

        // POST: Mascota/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MascotaId,Nombre,Raza,Sexo,UsuarioId")] Mascota mascota)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mascota).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "UsuarioId", "Nombre", mascota.UsuarioId);
            return View(mascota);
        }

        // GET: Mascota/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mascota mascota = db.Mascotas.Find(id);
            if (mascota == null)
            {
                return HttpNotFound();
            }
            return View(mascota);
        }

        // POST: Mascota/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mascota mascota = db.Mascotas.Find(id);
            db.Mascotas.Remove(mascota);
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

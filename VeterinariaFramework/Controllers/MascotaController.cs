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
        private readonly VeterinariaDbContext _dbContext;

        public MascotaController(VeterinariaDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        // GET: Mascota
        public ActionResult Index()
        {
            var mascotas = _dbContext.Mascotas.Include(m => m.Usuario);
            return View(mascotas.ToList());
        }

        // GET: Mascota/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mascota mascota = _dbContext.Mascotas.Find(id);
            if (mascota == null)
            {
                return HttpNotFound();
            }
            return View(mascota);
        }

        // GET: Mascota/Create
        public ActionResult Create()
        {
            ViewBag.UsuarioId = new SelectList(_dbContext.Usuarios, "UusarioId", "Nombre");
            return View();
        }

        // POST: Mascota/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MascotaId,Nombre,Raza,UsuarioId")] Mascota mascota)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Mascotas.Add(mascota);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UsuarioId = new SelectList(_dbContext.Usuarios, "UusarioId", "Nombre", mascota.UsuarioId);
            return View(mascota);
        }

        // GET: Mascota/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mascota mascota = _dbContext.Mascotas.Find(id);
            if (mascota == null)
            {
                return HttpNotFound();
            }
            ViewBag.UsuarioId = new SelectList(_dbContext.Usuarios, "UusarioId", "Nombre", mascota.UsuarioId);
            return View(mascota);
        }

        // POST: Mascota/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MascotaId,Nombre,Raza,UsuarioId")] Mascota mascota)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Entry(mascota).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UsuarioId = new SelectList(_dbContext.Usuarios, "UusarioId", "Nombre", mascota.UsuarioId);
            return View(mascota);
        }

        // GET: Mascota/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mascota mascota = _dbContext.Mascotas.Find(id);
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
            Mascota mascota = _dbContext.Mascotas.Find(id);
            _dbContext.Mascotas.Remove(mascota);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

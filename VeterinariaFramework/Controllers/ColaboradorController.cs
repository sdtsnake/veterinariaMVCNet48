using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;
using VeterinariaFramework.Models;

namespace VeterinariaFramework.Controllers
{
    public class ColaboradorController : Controller
    {
        private readonly VeterinariaDbContext _dbContext;

        public ColaboradorController(VeterinariaDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        // GET: Colaborador
        public ActionResult Index()
        {            
            return View(_dbContext.Colaboradores.ToList());            
        }

        [HttpGet]
        // GET: Colaborador/Details/5
        public ActionResult Details(int id)
        {
            Colaborador colaborador = _dbContext.Colaboradores.Find(id);
            if (colaborador == null)
            {
                return HttpNotFound();
            }
            return View(colaborador);
        }

        // POST: Colaborador/Create        
        public ActionResult Create()
        {         
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nombre,apellido,cargo,especialidad,tipoDocumento,DocumentoIdentificacion")] Colaborador colaborador)
        {
            int documento;
            if (int.TryParse(colaborador.DocumentoIdentificacion.ToString(), out documento))
            {
                colaborador.DocumentoIdentificacion = documento;
                if (ModelState.IsValid)
                {
                    _dbContext.Colaboradores.Add(colaborador);
                    _dbContext.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            // Si no se puede convertir el valor ingresado a un número entero válido,
            // o si el modelo no es válido, redirecciona al usuario a la vista "Create"
            return View(colaborador);
        }

        // GET: Mascota/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colaborador colaborador = _dbContext.Colaboradores.Find(id);
            if (colaborador == null)
            {
                return HttpNotFound();
            }
            return View(colaborador);
        }

        // POST: Colaborador/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,apellido,cargo,especialidad,tipoDocumento,DocumentoIdentificacion")] Colaborador colaborador)
        {
            int documento;
            if (int.TryParse(colaborador.DocumentoIdentificacion.ToString(), out documento))
            {
                colaborador.DocumentoIdentificacion = documento;
                if (ModelState.IsValid)
                {
                    _dbContext.Entry(colaborador).State = System.Data.Entity.EntityState.Modified;
                    _dbContext.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            // Si no se puede convertir el valor ingresado a un número entero válido,
            // o si el modelo no es válido, redirecciona al usuario a la vista "Create"
            return View(colaborador);
         }

        // GET: Mascota/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colaborador colaborador = _dbContext.Colaboradores.Find(id);
            if (colaborador == null)
            {
                return HttpNotFound();
            }
            return View(colaborador);
        }


        // POST: Colaborador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Colaborador colaborador = _dbContext.Colaboradores.Find(id);
            _dbContext.Colaboradores.Remove(colaborador);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

























    }
}
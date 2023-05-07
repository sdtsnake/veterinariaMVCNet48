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
        public ActionResult Create(string tipoDocumento, string numeroDocumento, string nombre, string apellido, string cargo, string especialidad)
        {
            int documentoIdentificacion;
            if (!int.TryParse(numeroDocumento, out documentoIdentificacion))
            {
                // La conversión falló, así que podrías devolver una vista de error o tomar otra acción
                return View();
            }


            // Crea un nuevo objeto Colaborador con los datos recibidos del formulario
            var colaborador = new Colaborador
            {
                TipoDocumento = tipoDocumento,
                DocumentoIdentificacion = documentoIdentificacion,
                Nombre = nombre,
                Apellido = apellido,
                Cargo = cargo,
                Especialidad = especialidad
            };

            // Guarda el nuevo objeto Colaborador en la base de datos utilizando el contexto de base de datos
            _dbContext.Colaboradores.Add(colaborador);
            _dbContext.SaveChanges();

            // Redirecciona al usuario a la vista Index de Colaboradores
            return RedirectToAction("Index");
        }

        // POST: Colaborador/Edit/5
        [HttpPost]
        public ActionResult Edit(Colaborador colaborador)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Entry(colaborador).State = System.Data.Entity.EntityState.Modified;
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(colaborador);
        }

        // POST: Colaborador/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Colaborador colaborador = _dbContext.Colaboradores.Find(id);
            _dbContext.Colaboradores.Remove(colaborador);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
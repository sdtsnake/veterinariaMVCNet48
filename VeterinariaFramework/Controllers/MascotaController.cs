using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VeterinariaFramework.Models;
using VeterinariaFramework.Resository;
using VeterinariaFramework.Resositorys;

namespace VeterinariaFramework.Controllers
{
    public class MascotaController : Controller
    {
        private readonly IMascotaRepository _mascotaRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        public MascotaController(IMascotaRepository mascotaRepository, IUsuarioRepository usuarioRepository)
        {
            _mascotaRepository = mascotaRepository ?? throw new ArgumentNullException(nameof(mascotaRepository));
            _usuarioRepository = usuarioRepository ?? throw new ArgumentNullException(nameof(usuarioRepository));
        }
        // GET: Mascota
        public ActionResult Index()
        {
            var mascotas = _mascotaRepository.GetAllMascotas();
            return View(mascotas.ToList());
        }
        // GET: Mascota/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }            
            Mascota mascota = _mascotaRepository.GetMascotaById(id.Value);
            if (mascota == null)
            {
                return HttpNotFound();
            }
            return View(mascota);
        }
        // GET: Mascota/Create
        public ActionResult Create()
        {
            var usuarios = _usuarioRepository.GetAllUsuarios();
            ViewBag.UsuarioId = new SelectList(usuarios, "UsuarioId", "Nombre");
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
                _mascotaRepository.UpdateMascota(mascota);
                return RedirectToAction("Index");
            }

            var usuarios = _usuarioRepository.GetAllUsuarios();
            ViewBag.UsuarioId = new SelectList(usuarios, "UsuarioId", "Nombre", mascota.UsuarioId);
            return View(mascota);
        }

        // GET: Mascota/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }            
            Mascota mascota = _mascotaRepository.GetMascotaById(id.Value);
            if (mascota == null)
            {
                return HttpNotFound();
            }
            var usuarios = _usuarioRepository.GetAllUsuarios();
            ViewBag.UsuarioId = new SelectList(usuarios, "UsuarioId", "Nombre", mascota.UsuarioId);
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
                _mascotaRepository.UpdateMascota(mascota);
                return RedirectToAction("Index");
            }
            var usuarios = _usuarioRepository.GetAllUsuarios();
            ViewBag.UsuarioId = new SelectList(usuarios, "UsuarioId", "Nombre", mascota.UsuarioId);
            return View(mascota);
        }
        // GET: Mascota/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mascota mascota = _mascotaRepository.GetMascotaById(id.Value);
            if (mascota == null)
            {
                return HttpNotFound();
            }
            return View(mascota);
        }

        // POST: Mascota/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {          
            _mascotaRepository.DeleteMascota(id.Value);
            return RedirectToAction("Index");
        }









        






        



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VeterinariaFramework.Models;

namespace VeterinariaFramework.Controllers
{
    public class ColaboradorController : Controller
    {
        private readonly VeterinariaDbContext dbContext;

        public ColaboradorController(VeterinariaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: Colaborador
        public ActionResult Index()
        {            
            return View(dbContext.Colaboradores.ToList());
        }
    }
}
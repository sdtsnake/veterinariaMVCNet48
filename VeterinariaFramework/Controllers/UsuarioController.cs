using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using VeterinariaFramework.Services;

namespace VeterinariaFramework.Controllers
{
    public class UsuarioController : Controller
    {

        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // GET: Usuario
        public async Task<ActionResult> Index()
        {
            var usuarios = await _usuarioService.ObtenerUsuariosAsync();
            return View(usuarios);
        }
    }
}
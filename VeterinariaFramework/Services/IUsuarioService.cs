using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinariaFramework.Models;

namespace VeterinariaFramework.Services
{
    public interface IUsuarioService
    {
        Task<List<Usuario>> ObtenerUsuariosAsync();
    }
}

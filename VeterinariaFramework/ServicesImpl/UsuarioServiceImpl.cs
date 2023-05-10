using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using VeterinariaFramework.Models;
using VeterinariaFramework.Services;
using Newtonsoft.Json;

namespace VeterinariaFramework.ServicesImpl
{
    public class UsuarioServiceImpl : IUsuarioService
    {
        private const string UrlApiUsuarios = "https://localhost:7040/api/veterinaria/Usuario";

        public async Task<List<Usuario>> ObtenerUsuariosAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync(UrlApiUsuarios);
                var usuarios = JsonConvert.DeserializeObject<List<Usuario>>(response);
                return usuarios;
            }
        }
    }
}
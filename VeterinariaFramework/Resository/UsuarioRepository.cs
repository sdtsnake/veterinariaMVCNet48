using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VeterinariaFramework.Models;

namespace VeterinariaFramework.Resository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly VeterinariaDbContext _dbContext;

        public UsuarioRepository(VeterinariaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Usuario> GetAllUsuarios()
        {
            return _dbContext.Usuarios.ToList();
        }

        public Usuario GetUsuarioById(int id)
        {
            return _dbContext.Usuarios.Find(id);
        }

        public void AddUsuario(Usuario usuario)
        {
            _dbContext.Usuarios.Add(usuario);
            _dbContext.SaveChanges();
        }

        public void UpdateUsuario(Usuario usuario)
        {
            _dbContext.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteUsuario(int id)
        {
            var usuario = _dbContext.Usuarios.Find(id);
            if (usuario != null)
            {
                _dbContext.Usuarios.Remove(usuario);
                _dbContext.SaveChanges();
            }
        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
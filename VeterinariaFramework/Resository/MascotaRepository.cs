using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using VeterinariaFramework.Models;
using VeterinariaFramework.Resositorys;

namespace VeterinariaFramework.Resository
{
    public class MascotaRepository : IMascotaRepository
    {
       
        private readonly VeterinariaDbContext _dbContext;

        public MascotaRepository(VeterinariaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Mascota> GetAllMascotas()
        {
            return _dbContext.Mascotas.Include(m => m.Usuario).ToList();
        }

        public Mascota GetMascotaById(int id)
        {
            return _dbContext.Mascotas.Find(id);
        }

        public void AddMascota(Mascota mascota)
        {
            _dbContext.Mascotas.Add(mascota);
        }

        public void UpdateMascota(Mascota mascota)
        {
            _dbContext.Entry(mascota).State = EntityState.Modified;
        }

        public void DeleteMascota(int id)
        {
            Mascota mascota = _dbContext.Mascotas.Find(id);
            _dbContext.Mascotas.Remove(mascota);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }   
}
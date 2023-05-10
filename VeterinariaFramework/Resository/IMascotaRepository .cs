using System;
using System.Collections.Generic;
using VeterinariaFramework.Models;

namespace VeterinariaFramework.Resositorys
{
    public interface IMascotaRepository : IDisposable
    {
        IEnumerable<Mascota> GetAllMascotas();
        Mascota GetMascotaById(int id);
        void AddMascota(Mascota mascota);
        void UpdateMascota(Mascota mascota);
        void DeleteMascota(int id);
    }
}

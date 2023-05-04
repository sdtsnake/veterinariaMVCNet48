using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinariaFramework.Models;

namespace VeterinariaFramework.Interfaz
{
    internal interface IVeterinariaDbContext
    {
        DbSet<Colaborador> Colaboradores { get; set; }
        DbSet<DetalleHistoriaClinica> DetallesHistoriasClinicas { get; set; }
        DbSet<Usuario> Usuarios { get; set; }
        DbSet<Mascota> Mascotas { get; set; }
        DbSet<HistoriaClinica> HistoriasClinicas { get; set; }
    }
}


﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VeterinariaFramework.Models
{
    public class VeterinariaDbContext : DbContext
    {
        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<DetalleHistoriaClinica> DetallesHistoriasClinicas { get; set; }
        public DbSet<HistoriaClinica> HistoriasClinicas { get; set; }
        public DbSet<Mascota> Mascotas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
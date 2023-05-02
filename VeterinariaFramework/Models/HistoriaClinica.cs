using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VeterinariaFramework.Models;

namespace VeterinariaFramework.Models
{
    [Table("HistoriasClinicas")]
    public class HistoriaClinica
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HistoriaClinicaId { get; set; }

        public int MascotaId { get; set; }
        
        [ForeignKey("MascotaId")]
        public virtual Mascota Mascota { get; set; }

        [Required]
        public Nullable<DateTime> FechaCreacion { get; set; }

        [NotMapped]
        private ICollection<DetalleHistoriaClinica> detalleHistoriaClinica = new List<DetalleHistoriaClinica>();
        public virtual ICollection<DetalleHistoriaClinica> DetalleHistoriaClinica
        {
            get { return detalleHistoriaClinica; }
            set { detalleHistoriaClinica = value; }
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VeterinariaFramework.Models
{
    [Table("DetallesHistoriasClinicas")]
    public class DetalleHistoriaClinica
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Temperatura { get; set; }
        
        [Required]
        public float? Peso { get; set; }

        public float? FrecuenciaCardiaca { get; set; }

        public float? FrecuenciaRespiratoria { get; set; }
        
        [Required]
        public DateTime? FechaHora { get; set; }

        public string Alimentacion { get; set; }

        public string Habitad { get; set; }
        
        [Required]
        public string Observacion { get; set; }

        public int ColaboradorId { get; set; }
        
        [ForeignKey("ColaboradorId")]
        public virtual Colaborador Colaborador { get; set; }

        public int HistoriaClinicaId { get; set; }

        [ForeignKey("HistoriaClinicaId")]
        public virtual HistoriaClinica HistoriaClinica { get; set; }

    }
}
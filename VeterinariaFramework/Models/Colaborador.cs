using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeterinariaFramework.Models
{
    [Table("Colaboradors")]
    public class Colaborador
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Nombre { get; set; }
        
        [Required]
        [MaxLength(150)]
        public string Apellido { get; set; }

        [Required]
        [MaxLength(150)]
        public string Cargo { get; set; }

        [Required]
        [MaxLength(150)]
        public string Especialidad { get; set; }

        [Required]
        [MaxLength(2)]
        public string TipoDocumento { get; set; }

        [Required]        
        public Nullable<int> DocumentoIdentificacion { get; set; }

        [NotMapped]
        private ICollection<DetalleHistoriaClinica> detalleHistoriaClinica = new List<DetalleHistoriaClinica>();
        public virtual ICollection<DetalleHistoriaClinica> DetallesHistoriasClinicas
        {
            get { return detalleHistoriaClinica; }
            set { detalleHistoriaClinica = value; }
        }
    }
}

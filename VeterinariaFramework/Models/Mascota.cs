using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeterinariaFramework.Models
{
    [Table("Mascotas")]
    public class Mascota
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MascotaId { get; set; }

        [Required]
        [MaxLength(150)]
        public string Nombre { get; set; }
        
        [Required]
        [MaxLength(150)]
        public string Raza { get; set; }
        
        [Required]
        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public virtual Usuario Usuario { get; set; }
        
        [Required]        
        public char Sexo { get; set; }
                
        [NotMapped]
        private ICollection<HistoriaClinica> historiasClinicas = new List<HistoriaClinica>();
        public virtual ICollection<HistoriaClinica> HistoriasClinicas
        {
            get { return historiasClinicas; }
            set { historiasClinicas = value; }
        }

    }
}

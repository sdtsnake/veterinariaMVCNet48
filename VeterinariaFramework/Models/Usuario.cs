using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeterinariaFramework.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UsuarioId { get; set; }

        [Required]
        [MaxLength(150)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(150)]
        public string Apellido { get; set; }

        [Required]
        [MaxLength(2)]
        public string TipoDocumento { get; set; }

        [Required]        
        public Nullable<int> DocumentoIdentificacion { get; set; }

        [Required]
        [MaxLength(1)]
        public string Estado { get; set; }

        [Required]
        [Column("Sexo")]
        public char Sexo { get; set; }

        [NotMapped]
        private ICollection<Mascota> mascotas = new List<Mascota>();
        public virtual ICollection<Mascota> Mascota
        {
            get { return mascotas; }
            set { mascotas = value; }
        }
    }
}

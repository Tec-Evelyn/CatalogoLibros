using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoLibros.EntidadesDeNegocio
{
    public class Autor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "Maximo 100 caracteres")]
        public string Nombre { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }
        public List<Libro> Libro { get; set; }
    }
}

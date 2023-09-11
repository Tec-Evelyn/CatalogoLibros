using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoLibros.EntidadesDeNegocio
{
    public class Genero
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Nombre es obligatorio")]
        [StringLength(50,ErrorMessage ="Maximo 50 caracteres")]
        public string Nombre { get; set; }
        [NotMapped]
        public int top_aux { get; set; }

    }
}

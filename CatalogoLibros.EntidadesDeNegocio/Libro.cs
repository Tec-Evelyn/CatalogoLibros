using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoLibros.EntidadesDeNegocio
{
    public class Libro
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Autor")]
        [Required(ErrorMessage = "El autor es requerido")]
        [Display(Name = "Autor")]
        public int IdAutor { get; set; }

        [ForeignKey("Categoria")]
        [Required(ErrorMessage = "La categoria es requerido")]
        [Display(Name = "Categoria")]
        public int IdCategoria { get; set; }

        [ForeignKey("Genero")]
        [Required(ErrorMessage = "El Género es requerido")]
        [Display(Name = "Genero")]
        public int IdGenero { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(100, ErrorMessage = "El largo máximo es de 100 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La imagen es requerida")]
        [MaxLength(200, ErrorMessage = "El máximo es 200 caracteres")]
        public string Imagen { get; set; }

        [Required(ErrorMessage = "El numPaginas es requerido")]
        [Display(Name = "Número de Paginas")]
        public int NumPaginas { get; set; }

        [Required(ErrorMessage = "La FechaPublicacion es requerida")]
        [MaxLength(15, ErrorMessage = "El máximo es 15 caracteres")]
        public string FechaPublicacion { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }

        [ValidateNever]
        public Autor Autor { get; set; }

        [ValidateNever]
        public Categoria Categoria { get; set; }

        [ValidateNever]
        public Genero Genero { get; set; }
    }
}

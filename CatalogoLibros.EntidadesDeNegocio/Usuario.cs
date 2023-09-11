using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoLibros.EntidadesDeNegocio
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Rol") ]
        [Required(ErrorMessage = "Rol es obligatorio" )]
        //Display: En lugar de mostrar IdRol mostrará la palabra Rol
        [Display (Name = "Rol") ]
        public int IdRol { get; set; }


        [Required(ErrorMessage = "Nombre obligatorio")]
        //StringLength: Longitud máxima
        [StringLength (30, ErrorMessage = "Máximo 30 caractere")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "Apellido es obligatorio")]
        [StringLength(30, ErrorMessage = "Máximo 30 caracteres")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Login es obligatorio")]
        [StringLength(25, ErrorMessage = "Máximo 25 caracteres")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Password es obligatorio")]
        //DataType: Especifica que es un campo de contarseña, en lugar de mostrar el texto muestra los puntos
        [DataType(DataType.Password)]
                     //32(Máximo)                                                    //5 (Mínimo)
        [StringLength(32,ErrorMessage = "Password debe estar entre 5 a 32 carateres", MinimumLength = 5)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Estatus es obligatorio")]
        public byte Estatus { get; set; }

        public Rol Rol { get; set; }

        //NotMapped: indica que el top_aux no es tomado en cuenta en el mapeo
        [NotMapped]
        public int Top_Aux { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Confirmar el password")]
        [StringLength(32, ErrorMessage = "Password debe estar entre 5 a  32 caracteres", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password y confirmar password deben ser iguales")]
        [Display(Name = "Confirmar password")]
        public string ConfirmPassword_aux { get; set; }
    }
    public enum Estatus_Usuario
    {
        ACTIVO = 1,
        INACTIVO = 2 
    }
}

using System.ComponentModel.DataAnnotations;

namespace ConfeccionInformesMVC.Models.DTOs
{
    public class CreateAlumnoDTO
    {

            [Required]
            [Display(Name = "Matrícula")]
            public string Matricula { get; set; } = null!;

            [Required]
            public string Nombre { get; set; } = null!;

            [Required]
            [EmailAddress]
            public string Email { get; set; } = null!;

            [Required]
            public string Sexo { get; set; } = null!;

            public bool Repetidor { get; set; }

            public bool Activo { get; set; }
        }

    
}

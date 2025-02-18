using System.ComponentModel.DataAnnotations;

namespace ConfeccionInformesMVC.Models.DTOs
{
    public class UpdateAlumnoDTO: CreateAlumnoDTO
    {
        [Required]
        public int Id { get; set; }
    }
}

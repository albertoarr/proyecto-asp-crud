using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConfeccionInformesMVC.Models;

public partial class Alumno
{
    public int Id { get; set; }

    [Display(Name = "Matrícula")]
    public string Matricula { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Sexo { get; set; } = null!;

    public bool Repetidor { get; set; }

    public bool Activo { get; set; }
}

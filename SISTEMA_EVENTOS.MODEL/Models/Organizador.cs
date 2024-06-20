using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SISTEMA_EVENTOS.MODEL.Models;

public partial class Organizador
{
    [Display(Name = "OrganizadorId")]
    public int Id { get; set; }
    [Display(Name = "Nome")]
    public string Nome { get; set; } = null!;
    [Display(Name = "Email")]
    public string Email { get; set; } = null!;
    [Display(Name = "Telefone")]
    public string? Telefone { get; set; }

    public virtual ICollection<Evento> Eventos { get; set; } = new List<Evento>();
}

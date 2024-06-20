using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SISTEMA_EVENTOS.MODEL.Models;

public partial class Local
{
    [Display(Name = "LocalId")]
    public int Id { get; set; }
    [Display(Name = "Nome")]
    public string Nome { get; set; } = null!;
    [Display(Name = "Endereço")]
    public string? Endereco { get; set; }
    [Display(Name = "Cidade")]
    public string? Cidade { get; set; }
    [Display(Name = "Estado")]
    public string? Estado { get; set; }
    [Display(Name = "País")]
    public string? Pais { get; set; }

    public virtual ICollection<Evento> Eventos { get; set; } = new List<Evento>();
}

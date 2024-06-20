using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace SISTEMA_EVENTOS.MODEL.Models;

public class Evento
{
    [Display(Name = "Id")]
    public int Id { get; set; }
    [Display(Name = "OrganizadorID")]
    public int OrganizadorId { get; set; }
    [Display(Name = "LocalId")]
    public int LocalId { get; set; }
    [Display(Name = "Nome")]
    public string Nome { get; set; } = null!;
    [Display(Name = "Data")]
    public DateOnly Data { get; set; }
    [Display(Name = "Descrição")]
    public string? Descricao { get; set; }

    public virtual ICollection<Inscricao> Inscricaos { get; set; } = new List<Inscricao>();

    public virtual Local Local { get; set; } = null!;

    public virtual Organizador Organizador { get; set; } = null!;
}

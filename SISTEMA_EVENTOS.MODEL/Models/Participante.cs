using System;
using System.Collections.Generic;

namespace SISTEMA_EVENTOS.MODEL.Models;

public partial class Participante
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Telefone { get; set; } = null!;

    public virtual ICollection<Inscricao> Inscricaos { get; set; } = new List<Inscricao>();
}

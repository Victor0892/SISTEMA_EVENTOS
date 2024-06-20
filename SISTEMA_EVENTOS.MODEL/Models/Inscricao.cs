using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SISTEMA_EVENTOS.MODEL.Models;

public partial class Inscricao
{
    [Display(Name = "IncricaoId")]
    public int Id { get; set; }
    [Display(Name = "ParticipanteId")]
    public int ParticipanteId { get; set; }
    [Display(Name = "EventoId")]
    public int EventoId { get; set; }
    [Display(Name = "DataInscricao")]
    public DateOnly DataInscricao { get; set; }

    public virtual Evento Evento { get; set; } = null!;

    public virtual Participante Participante { get; set; } = null!;
}

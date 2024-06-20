using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_EVENTOS.MODEL.DTO
{
    public class EventoDTO
    {
        public int Id { get; set; }
        public int OrganizadorId { get; set; }
        public int LocalId { get; set; }
        public string Nome { get; set; } = null!;
        public DateOnly Data { get; set; }
        public string? Descricao { get; set; }
    }
}


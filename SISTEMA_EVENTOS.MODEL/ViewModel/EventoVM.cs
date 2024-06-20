using Microsoft.EntityFrameworkCore;
using SISTEMA_EVENTOS.MODEL.Models;

using SISTEMA_EVENTOS.MODEL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_EVENTOS.MODEL.ViewModel
{
    public class EventoVM
    {
        public int Id { get; set; }
        public int OrganizadorId { get; set; }
        public int LocalId { get; set; }
        public string Nome { get; set; } = null!;
        public DateOnly Data { get; set; }
        public string? Descricao { get; set; }
        public string NomeOrganizador { get; set; } = null!;
        public string NomeLocal { get; set; } = null!;

        public EventoVM()
        {

        }
        public async Task<List<EventoVM>> GetEventoVMs()
        {
            var db = new GerenciamentoEventosContext();

            return await (from eve in db.Eventos
                          select new EventoVM
                          {
                              Id = eve.Id,
                              OrganizadorId = eve.OrganizadorId,
                              LocalId = eve.LocalId,
                              Nome = eve.Nome,
                              Data = eve.Data,
                              Descricao = eve.Descricao,
                              NomeOrganizador = eve.Organizador.ToString()
                          }).ToListAsync();
        }
    }
}
using SISTEMA_EVENTOS.MODEL.DTO;
using SISTEMA_EVENTOS.MODEL.Models;
using SISTEMA_EVENTOS.MODEL.Repositories;
using SISTEMA_EVENTOS.MODEL.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SISTEMA_EVENTOS.MODEL.Services
{
    public class ServiceEvento
    {
        public RepositoryBase<Evento> oRepositoryEvento { get; set; }

        private GerenciamentoEventosContext _context;

        public ServiceEvento(GerenciamentoEventosContext context)
        {
            _context = context;
            oRepositoryEvento = new RepositoryBase<Evento>(context, true);
        }

        public async Task<EventoVM> IncluirEventoAsync(EventoDTO eventoDTO)
        {
            var evento = new Evento
            {
                OrganizadorId = eventoDTO.OrganizadorId,
                LocalId = eventoDTO.LocalId,
                Nome = eventoDTO.Nome,
                Data = eventoDTO.Data,
                Descricao = eventoDTO.Descricao
            };

            var novoEvento = await oRepositoryEvento.IncluirAsync(evento);
            return MapToEventoVM(novoEvento);
        }

        public async Task<EventoVM> AlterarEventoAsync(EventoDTO eventoDTO)
        {
            var evento = new Evento
            {
                Id = eventoDTO.Id,
                OrganizadorId = eventoDTO.OrganizadorId,
                LocalId = eventoDTO.LocalId,
                Nome = eventoDTO.Nome,
                Data = eventoDTO.Data,
                Descricao = eventoDTO.Descricao
            };

            var eventoAtualizado = await oRepositoryEvento.AlterarAsync(evento);
            return MapToEventoVM(eventoAtualizado);
        }

        public async Task ExcluirEventoAsync(int id)
        {
            await oRepositoryEvento.ExcluirAsync(id);
        }

        public async Task<EventoVM> ObterEventoPorIdAsync(int id)
        {
            var evento = await oRepositoryEvento.SelecionarChaveAsync(id);
            return MapToEventoVM(evento);
        }

        public async Task<List<EventoVM>> ObterTodosEventosAsync()
        {
            var eventos = await oRepositoryEvento.SelecionarTodosAsync();
            var eventosVM = new List<EventoVM>();

            foreach (var evento in eventos)
            {
                eventosVM.Add(MapToEventoVM(evento));
            }

            return eventosVM;
        }

        private EventoVM MapToEventoVM(Evento evento)
        {
            return new EventoVM
            {
                Id = evento.Id,
                OrganizadorId = evento.OrganizadorId,
                LocalId = evento.LocalId,
                Nome = evento.Nome,
                Data = evento.Data,
                Descricao = evento.Descricao,
                NomeOrganizador = evento.Organizador?.Nome ?? "Desconhecido",
                NomeLocal = evento.Local?.Nome ?? "Desconhecido"
            };
        }
    }
}

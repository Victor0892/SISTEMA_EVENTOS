using SISTEMA_EVENTOS.MODEL.DTO;
using SISTEMA_EVENTOS.MODEL.Models;
using SISTEMA_EVENTOS.MODEL.Repositories;
using SISTEMA_EVENTOS.MODEL.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SISTEMA_EVENTOS.MODEL.Services
{
    public class ServiceParticipante
    {
        public RepositoryBase<Participante> oRepositoryParticipante { get; set; }

        private GerenciamentoEventosContext _context;

        public ServiceParticipante(GerenciamentoEventosContext context)
        {
            _context = context;
            oRepositoryParticipante = new RepositoryBase<Participante>(context, true);
        }

        public async Task<ParticipanteVM> IncluirParticipanteAsync(ParticipanteDTO participanteDTO)
        {
            var participante = new Participante
            {
                Nome = participanteDTO.Nome,
                Email = participanteDTO.Email,
                Telefone = participanteDTO.Telefone
            };

            var novoParticipante = await oRepositoryParticipante.IncluirAsync(participante);
            return MapToParticipanteVM(novoParticipante);
        }

        public async Task<ParticipanteVM> AlterarParticipanteAsync(ParticipanteDTO participanteDTO)
        {
            var participante = new Participante
            {
                Id = participanteDTO.Id,
                Nome = participanteDTO.Nome,
                Email = participanteDTO.Email,
                Telefone = participanteDTO.Telefone
            };

            var participanteAtualizado = await oRepositoryParticipante.AlterarAsync(participante);
            return MapToParticipanteVM(participanteAtualizado);
        }

        public async Task ExcluirParticipanteAsync(int id)
        {
            await oRepositoryParticipante.ExcluirAsync(id);
        }

        public async Task<ParticipanteVM> ObterParticipantePorIdAsync(int id)
        {
            var participante = await oRepositoryParticipante.SelecionarChaveAsync(id);
            return MapToParticipanteVM(participante);
        }

        public async Task<List<ParticipanteVM>> ObterTodosParticipantesAsync()
        {
            var participantes = await oRepositoryParticipante.SelecionarTodosAsync();
            var participantesVM = new List<ParticipanteVM>();

            foreach (var participante in participantes)
            {
                participantesVM.Add(MapToParticipanteVM(participante));
            }

            return participantesVM;
        }

        private ParticipanteVM MapToParticipanteVM(Participante participante)
        {
            return new ParticipanteVM
            {
                Id = participante.Id,
                Nome = participante.Nome,
                Email = participante.Email,
                Telefone = participante.Telefone
            };
        }
    }
}

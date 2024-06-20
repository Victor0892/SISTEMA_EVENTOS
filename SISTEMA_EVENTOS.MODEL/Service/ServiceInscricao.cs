using SISTEMA_EVENTOS.MODEL.DTO;
using SISTEMA_EVENTOS.MODEL.Models;
using SISTEMA_EVENTOS.MODEL.Repositories;
using SISTEMA_EVENTOS.MODEL.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SISTEMA_EVENTOS.MODEL.Services
{
    public class ServiceInscricao
    {
        public RepositoryBase<Inscricao> oRepositoryInscricao { get; set; }

        private GerenciamentoEventosContext _context;

        public ServiceInscricao(GerenciamentoEventosContext context)
        {
            _context = context;
            oRepositoryInscricao = new RepositoryBase<Inscricao>(context, true);
        }

        public async Task<InscricaoVM> RealizarInscricaoAsync(InscricaoDTO inscricaoDTO)
        {
            var inscricao = new Inscricao
            {
                EventoId = inscricaoDTO.EventoId,
                ParticipanteId = inscricaoDTO.ParticipanteId,
            };

            var novaInscricao = await oRepositoryInscricao.IncluirAsync(inscricao);
            return MapToInscricaoVM(novaInscricao);
        }

        public async Task<InscricaoVM> CancelarInscricaoAsync(int inscricaoId)
        {
            await oRepositoryInscricao.ExcluirAsync(inscricaoId);
            // Poderia retornar uma confirmação de cancelamento, se necessário
            return null; // Exemplo simples, ajuste conforme necessidade
        }

        public async Task<InscricaoVM> ObterInscricaoPorIdAsync(int inscricaoId)
        {
            var inscricao = await oRepositoryInscricao.SelecionarChaveAsync(inscricaoId);
            return MapToInscricaoVM(inscricao);
        }

        public async Task<List<InscricaoVM>> ObterInscricoesPorEventoAsync(int eventoId)
        {
            var inscricoes = await oRepositoryInscricao.SelecionarChaveAsync(eventoId);
            var inscricoesVM = new List<InscricaoVM>();

            //foreach (var inscricao in inscricoes)
            //{
            //    inscricoesVM.Add(MapToInscricaoVM(inscricao));
            //}

            return inscricoesVM;
        }

        private InscricaoVM MapToInscricaoVM(Inscricao inscricao)
        {
            return new InscricaoVM
            {
                Id = inscricao.Id,
                EventoId = inscricao.EventoId,
                ParticipanteId = inscricao.ParticipanteId,
                //DataInscricao = inscricao.DataInscricao,
                // Mapear outras propriedades necessárias da InscricaoVM
            };
        }
    }
}
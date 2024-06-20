using SISTEMA_EVENTOS.MODEL.DTO;
using SISTEMA_EVENTOS.MODEL.Models;
using SISTEMA_EVENTOS.MODEL.Repositories;
using SISTEMA_EVENTOS.MODEL.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SISTEMA_EVENTOS.MODEL.Services
{
    public class ServiceOrganizador
    {
        public RepositoryBase<Organizador> oRepositoryOrganizador { get; set; }

        private GerenciamentoEventosContext _context;

        public ServiceOrganizador(GerenciamentoEventosContext context)
        {
            _context = context;
            oRepositoryOrganizador = new RepositoryBase<Organizador>(context, true);
        }

        public async Task<OrganizadorVM> IncluirOrganizadorAsync(OrganizadorDTO organizadorDTO)
        {
            var organizador = new Organizador
            {
                Nome = organizadorDTO.Nome,
                Email = organizadorDTO.Email,
                Telefone = organizadorDTO.Telefone
            };

            var novoOrganizador = await oRepositoryOrganizador.IncluirAsync(organizador);
            return MapToOrganizadorVM(novoOrganizador);
        }

        public async Task<OrganizadorVM> AlterarOrganizadorAsync(OrganizadorDTO organizadorDTO)
        {
            var organizador = new Organizador
            {
                //Id = organizadorDTO.Id, 
                Nome = organizadorDTO.Nome,
                Email = organizadorDTO.Email,
                Telefone = organizadorDTO.Telefone
            };

            var organizadorAtualizado = await oRepositoryOrganizador.AlterarAsync(organizador);
            return MapToOrganizadorVM(organizadorAtualizado);
        }

        public async Task ExcluirOrganizadorAsync(int id)
        {
            await oRepositoryOrganizador.ExcluirAsync(id);
        }

        public async Task<OrganizadorVM> ObterOrganizadorPorIdAsync(int id)
        {
            var organizador = await oRepositoryOrganizador.SelecionarChaveAsync(id);
            return MapToOrganizadorVM(organizador);
        }

        public async Task<List<OrganizadorVM>> ObterTodosOrganizadoresAsync()
        {
            var organizadores = await oRepositoryOrganizador.SelecionarTodosAsync();
            var organizadoresVM = new List<OrganizadorVM>();

            foreach (var organizador in organizadores)
            {
                organizadoresVM.Add(MapToOrganizadorVM(organizador));
            }

            return organizadoresVM;
        }

        private OrganizadorVM MapToOrganizadorVM(Organizador organizador)
        {
            return new OrganizadorVM
            {
                Id = organizador.Id,
                Nome = organizador.Nome,
                Email = organizador.Email,
                Telefone = organizador.Telefone
            };
        }
    }
}

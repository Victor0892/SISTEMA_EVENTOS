using SISTEMA_EVENTOS.MODEL.DTO;
using SISTEMA_EVENTOS.MODEL.Models;
using SISTEMA_EVENTOS.MODEL.Repositories;
using SISTEMA_EVENTOS.MODEL.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SISTEMA_EVENTOS.MODEL.Services
{
    public class ServiceLocal
    {
        public RepositoryBase<Local> oRepositoryLocal { get; set; }

        private GerenciamentoEventosContext _context;

        public ServiceLocal(GerenciamentoEventosContext context)
        {
            _context = context;
            oRepositoryLocal = new RepositoryBase<Local>(context, true);
        }

        public async Task<LocalVM> IncluirLocalAsync(LocalDTO localDTO)
        {
            var local = new Local
            {
                Nome = localDTO.Nome,
                Endereco = localDTO.Endereco,
                Cidade = localDTO.Cidade,
                Estado = localDTO.Estado,
                Pais = localDTO.Pais
            };

            var novoLocal = await oRepositoryLocal.IncluirAsync(local);
            return MapToLocalVM(novoLocal);
        }

        public async Task<LocalVM> AlterarLocalAsync(LocalDTO localDTO)
        {
            var local = new Local
            {
                Id = localDTO.Id,
                Nome = localDTO.Nome,
                Endereco = localDTO.Endereco,
                Cidade = localDTO.Cidade,
                Estado = localDTO.Estado,
                Pais = localDTO.Pais
            };

            var localAtualizado = await oRepositoryLocal.AlterarAsync(local);
            return MapToLocalVM(localAtualizado);
        }

        public async Task ExcluirLocalAsync(int id)
        {
            await oRepositoryLocal.ExcluirAsync(id);
        }

        public async Task<LocalVM> ObterLocalPorIdAsync(int id)
        {
            var local = await oRepositoryLocal.SelecionarChaveAsync(id);
            return MapToLocalVM(local);
        }

        public async Task<List<LocalVM>> ObterTodosLocaisAsync()
        {
            var locais = await oRepositoryLocal.SelecionarTodosAsync();
            var locaisVM = new List<LocalVM>();

            foreach (var local in locais)
            {
                locaisVM.Add(MapToLocalVM(local));
            }

            return locaisVM;
        }

        private LocalVM MapToLocalVM(Local local)
        {
            return new LocalVM
            {
                Id = local.Id,
                Nome = local.Nome,
                Endereco = local.Endereco,
                Cidade = local.Cidade,
                Estado = local.Estado,
                Pais = local.Pais
            };
        }
    }
}

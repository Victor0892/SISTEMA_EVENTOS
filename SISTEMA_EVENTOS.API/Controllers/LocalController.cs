using Microsoft.AspNetCore.Mvc;
using SISTEMA_EVENTOS.MODEL.DTO;
using SISTEMA_EVENTOS.MODEL.Services;
using SISTEMA_EVENTOS.MODEL.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SISTEMA_EVENTOS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocalController : ControllerBase
    {
        private readonly ServiceLocal _serviceLocal;

        public LocalController(ServiceLocal serviceLocal)
        {
            _serviceLocal = serviceLocal;
        }

        [HttpGet]
        public async Task<ActionResult<List<LocalVM>>> Get()
        {
            return await _serviceLocal.ObterTodosLocaisAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LocalVM>> Get(int id)
        {
            var local = await _serviceLocal.ObterLocalPorIdAsync(id);
            if (local == null)
            {
                return NotFound();
            }
            return local;
        }

        [HttpPost]
        public async Task<ActionResult<LocalVM>> Post(LocalDTO localDTO)
        {
            var novoLocal = await _serviceLocal.IncluirLocalAsync(localDTO);
            return CreatedAtAction(nameof(Get), new { id = novoLocal.Id }, novoLocal);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, LocalDTO localDTO)
        {
            if (id != localDTO.Id)
            {
                return BadRequest("O ID fornecido na rota não corresponde ao ID na DTO.");
            }

            var localExistente = await _serviceLocal.ObterLocalPorIdAsync(id);

            if (localExistente == null)
            {
                return NotFound("Local não encontrado.");
            }

            // Atualiza apenas os campos relevantes com os dados da DTO
            localExistente.Nome = localDTO.Nome;
            localExistente.Endereco = localDTO.Endereco;
            localExistente.Cidade = localDTO.Cidade;
            localExistente.Estado = localDTO.Estado;
            localExistente.Pais = localDTO.Pais;

            await _serviceLocal.AlterarLocalAsync(localDTO);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _serviceLocal.ExcluirLocalAsync(id);
            return NoContent();
        }

        [HttpPost("PostLocal")]
        public async Task<IActionResult> PostLocal(LocalDTO local)
        {
            //await _serviceEvento.oRepositoryEvento.IncluirAsync(evento);
            return Ok("Local cadastrado com sucesso");
        }
    }
}

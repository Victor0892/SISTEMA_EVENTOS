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
    public class OrganizadorController : ControllerBase
    {
        private readonly ServiceOrganizador _serviceOrganizador;

        public OrganizadorController(ServiceOrganizador serviceOrganizador)
        {
            _serviceOrganizador = serviceOrganizador;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrganizadorVM>>> Get()
        {
            var organizadores = await _serviceOrganizador.ObterTodosOrganizadoresAsync();
            return organizadores;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrganizadorVM>> Get(int id)
        {
            var organizador = await _serviceOrganizador.ObterOrganizadorPorIdAsync(id);
            if (organizador == null)
            {
                return NotFound();
            }
            return organizador;
        }

        [HttpPost]
        public async Task<ActionResult<OrganizadorVM>> Post(OrganizadorDTO organizadorDTO)
        {
            var novoOrganizador = await _serviceOrganizador.IncluirOrganizadorAsync(organizadorDTO);
            return CreatedAtAction(nameof(Get), new { id = novoOrganizador.Id }, novoOrganizador);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, OrganizadorDTO organizadorDTO)
        {
            if (id != organizadorDTO.Id)
            {
                return BadRequest("O ID fornecido na rota não corresponde ao ID na DTO.");
            }

            await _serviceOrganizador.AlterarOrganizadorAsync(organizadorDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _serviceOrganizador.ExcluirOrganizadorAsync(id);
            return NoContent();
        }

        [HttpPost("PostOrganizador")]
        public async Task<IActionResult> PostLocal(OrganizadorDTO organizador)
        {
            //await _serviceEvento.oRepositoryEvento.IncluirAsync(evento);
            return Ok("Organizador cadastrado com sucesso");
        }
    }
}

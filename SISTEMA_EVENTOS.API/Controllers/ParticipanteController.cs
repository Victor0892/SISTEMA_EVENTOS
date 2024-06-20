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
    public class ParticipanteController : ControllerBase
    {
        private readonly ServiceParticipante _serviceParticipante;

        public ParticipanteController(ServiceParticipante serviceParticipante)
        {
            _serviceParticipante = serviceParticipante;
        }

        [HttpGet]
        public async Task<ActionResult<List<ParticipanteVM>>> Get()
        {
            var participantes = await _serviceParticipante.ObterTodosParticipantesAsync();
            return participantes;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ParticipanteVM>> Get(int id)
        {
            var participante = await _serviceParticipante.ObterParticipantePorIdAsync(id);
            if (participante == null)
            {
                return NotFound();
            }
            return participante;
        }

        [HttpPost]
        public async Task<ActionResult<ParticipanteVM>> Post(ParticipanteDTO participanteDTO)
        {
            var novoParticipante = await _serviceParticipante.IncluirParticipanteAsync(participanteDTO);
            return CreatedAtAction(nameof(Get), new { id = novoParticipante.Id }, novoParticipante);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ParticipanteDTO participanteDTO)
        {
            if (id != participanteDTO.Id)
            {
                return BadRequest("O ID fornecido na rota não corresponde ao ID na DTO.");
            }

            await _serviceParticipante.AlterarParticipanteAsync(participanteDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _serviceParticipante.ExcluirParticipanteAsync(id);
            return NoContent();
        }
        [HttpPost("PostParticipante")]
        public async Task<IActionResult> PostInscricao(ParticipanteDTO participante)
        {
            //await _serviceEvento.oRepositoryEvento.IncluirAsync(evento);
            return Ok("Participante cadastrado com sucesso");
        }
    }
}

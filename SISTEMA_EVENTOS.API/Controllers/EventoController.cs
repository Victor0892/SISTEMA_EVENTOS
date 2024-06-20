using Microsoft.AspNetCore.Mvc;
using SISTEMA_EVENTOS.MODEL.DTO;
using SISTEMA_EVENTOS.MODEL.Services;
using SISTEMA_EVENTOS.MODEL.ViewModel;
using SISTEMA_EVENTOS.MODEL.DTO;
using SISTEMA_EVENTOS.MODEL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SISTEMA_EVENTOS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly ServiceEvento _serviceEvento;

        public EventoController(ServiceEvento serviceEvento)
        {
            _serviceEvento = serviceEvento;
        }

        [HttpGet]
        public async Task<ActionResult<List<EventoVM>>> Get()
        {
            return await _serviceEvento.ObterTodosEventosAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventoVM>> Get(int id)
        {
            var evento = await _serviceEvento.ObterEventoPorIdAsync(id);
            if (evento == null)
            {
                return NotFound();
            }
            return evento;
        }

        [HttpPost]
        public async Task<ActionResult<EventoVM>> Post(EventoDTO eventoDTO)
        {
            var novoEvento = await _serviceEvento.IncluirEventoAsync(eventoDTO);
            return CreatedAtAction(nameof(Get), new { id = novoEvento.Id }, novoEvento);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, EventoDTO eventoDTO)
        {
            if (id != eventoDTO.Id)
            {
                return BadRequest();
            }

            await _serviceEvento.AlterarEventoAsync(eventoDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _serviceEvento.ExcluirEventoAsync(id);
            return NoContent();
        }
        [HttpPost("PostEvento")]
        public async Task<IActionResult> PostEvento(EventoDTO evento)
        {
            //await _serviceEvento.oRepositoryEvento.IncluirAsync(evento);
            return Ok("Evento cadastrado com sucesso");
        }
    }
}

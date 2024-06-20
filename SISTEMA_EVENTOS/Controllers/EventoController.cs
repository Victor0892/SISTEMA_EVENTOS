using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SISTEMA_EVENTOS.MODEL.Models;
using SISTEMA_EVENTOS.MODEL.ViewModel;
using System.Reflection.Metadata.Ecma335;




namespace SISTEMA_EVENTOS.Controllers
{
    public class EventoController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var db = new GerenciamentoEventosContext();

            return View(await db.Eventos.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //public async Task<IActionResult> Create(EventoVM eventoVM)
        public async Task<IActionResult> Create(EventoVM eventoVM)
        {
            var db = new GerenciamentoEventosContext();
            var evento = new Evento
            {
                Id = eventoVM.Id,
                OrganizadorId = eventoVM.OrganizadorId,
                LocalId = eventoVM.LocalId,
                Nome = eventoVM.Nome,
                Data = eventoVM.Data,
                Descricao = eventoVM.Descricao
            };

            db.Entry(evento).State = EntityState.Added;
            await db.SaveChangesAsync();
            ViewData["Mensagem"] = "Evento criado com sucesso.";
            return View(eventoVM);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var db = new GerenciamentoEventosContext();
            var evento = await db.Eventos.FindAsync(id);
            return View(evento);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Evento evento)
        {
            var db = new GerenciamentoEventosContext();
            db.Entry(evento).State = EntityState.Modified;
            await db.SaveChangesAsync();
            ViewData["Mensagem"] = "Dados alterados com sucesso.";
            return View(evento);
        }

        public async Task<IActionResult> Details(int id)
        {
            var db = new GerenciamentoEventosContext();
            var evento = await db.Eventos.FirstOrDefaultAsync(x => x.Id == id);
            return View(evento);

        }

        public async Task<IActionResult> Delete(int id)
        {
            var db = new GerenciamentoEventosContext();
            var evento = await db.Eventos.FirstOrDefaultAsync(x => x.Id == id);
            return View(evento);

        }

        [HttpPost]
        public async Task<IActionResult> Delete(Evento evento)
        {
            var db = new GerenciamentoEventosContext();
            db.Entry(evento).State = EntityState.Deleted;
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
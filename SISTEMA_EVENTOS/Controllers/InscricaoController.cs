using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SISTEMA_EVENTOS.MODEL.Models;
using SISTEMA_EVENTOS.MODEL.ViewModel;
using System.Reflection.Metadata.Ecma335;

namespace SISTEMA_EVENTOS.Controllers
{
    public class InscricaoController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var db = new GerenciamentoEventosContext();

            return View(await db.Inscricaos.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(InscricaoVM inscricaoVM)
        {
            var db = new GerenciamentoEventosContext();
            var inscricao = new Inscricao()
            {
                Id = inscricaoVM.Id,
                ParticipanteId = inscricaoVM.ParticipanteId,
                EventoId = inscricaoVM.EventoId,
                DataInscricao = DateOnly.FromDateTime(inscricaoVM.DataInscricao)
            };
            db.Entry(inscricao).State = EntityState.Added;
            await db.SaveChangesAsync();
            ViewData["Mensagem"] = "Dados alterados com sucesso.";
            return View(inscricaoVM);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var db = new GerenciamentoEventosContext();
            var inscricao = await db.Inscricaos.FindAsync(id);
            return View(inscricao);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Inscricao inscricao)
        {
            var db = new GerenciamentoEventosContext();
            db.Entry(inscricao).State = EntityState.Modified;
            await db.SaveChangesAsync();
            ViewData["Mensagem"] = "Dados alterados com sucesso.";
            return View(inscricao);
        }

        public async Task<IActionResult> Details(int id)
        {
            var db = new GerenciamentoEventosContext();
            var inscricao = await db.Inscricaos.FirstOrDefaultAsync(x => x.Id == id);
            return View(inscricao);

        }

        public async Task<IActionResult> Delete(int id)
        {
            var db = new GerenciamentoEventosContext();
            var inscricao = await db.Inscricaos.FirstOrDefaultAsync(x => x.Id == id);
            return View(inscricao);

        }

        [HttpPost]
        public async Task<IActionResult> Delete(Inscricao inscricao)
        {
            var db = new GerenciamentoEventosContext();
            db.Entry(inscricao).State = EntityState.Deleted;
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
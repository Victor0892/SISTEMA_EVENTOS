using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SISTEMA_EVENTOS.MODEL.Models;
using System.Reflection.Metadata.Ecma335;

namespace SISTEMA_EVENTOS.Controllers
{
    public class ParticipanteController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var db = new GerenciamentoEventosContext();

            return View(await db.Participantes.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Participante participante)
        {
            var db = new GerenciamentoEventosContext();
            if (ModelState.IsValid)
            {
                db.Entry(participante).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                await db.SaveChangesAsync();
                ViewData["Mensagem"] = "Dados salvos com sucesso. ";
            }
            else
            {
                ViewData["MensagemErro"] = "Ocorreu um erro ao salvar os dados.";
            }
            return View(participante);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var db = new GerenciamentoEventosContext();
            var participante = await db.Participantes.FindAsync(id);
            return View(participante);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Participante participante)
        {
            var db = new GerenciamentoEventosContext();
            if (ModelState.IsValid)
            {
                db.Entry(participante).State = EntityState.Modified;
                await db.SaveChangesAsync();
                ViewData["Mensagem"] = "Dados alterados com sucesso.";
            }
            else
            {
                ViewData["MensagemErro"] = "Ocorreu um erro ao alterar os dados.";
            }
            return View(participante);
        }

        public async Task<IActionResult> Details(int id)
        {
            var db = new GerenciamentoEventosContext();
            var participante = await db.Participantes.FirstOrDefaultAsync(x => x.Id == id);
            return View(participante);

        }

        public async Task<IActionResult> Delete(int id)
        {
            var db = new GerenciamentoEventosContext();
            var participante = await db.Participantes.FirstOrDefaultAsync(x => x.Id == id);
            return View(participante);

        }

        [HttpPost]
        public async Task<IActionResult> Delete(Participante participante)
        {
            var db = new GerenciamentoEventosContext();
            db.Entry(participante).State = EntityState.Deleted;
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}

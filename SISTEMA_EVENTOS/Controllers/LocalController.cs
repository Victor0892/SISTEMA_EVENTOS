using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SISTEMA_EVENTOS.MODEL.Models;
using System.Reflection.Metadata.Ecma335;

namespace SISTEMA_EVENTOS.Controllers
{
    public class LocalController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var db = new GerenciamentoEventosContext();

            return View(await db.Locals.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Local local)
        {
            var db = new GerenciamentoEventosContext();
            if (ModelState.IsValid)
            {
                db.Entry(local).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                await db.SaveChangesAsync();
                ViewData["Mensagem"] = "Dados salvos com sucesso. ";
            }
            else
            {
                ViewData["MensagemErro"] = "Ocorreu um erro ao salvar os dados.";
            }
            return View(local);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var db = new GerenciamentoEventosContext();
            var local = await db.Locals.FindAsync(id);
            return View(local);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Local local)
        {
            var db = new GerenciamentoEventosContext();
            if (ModelState.IsValid)
            {
                db.Entry(local).State = EntityState.Modified;
                await db.SaveChangesAsync();
                ViewData["Mensagem"] = "Dados alterados com sucesso.";
            }
            else
            {
                ViewData["MensagemErro"] = "Ocorreu um erro ao alterar os dados.";
            }
            return View(local);
        }

        public async Task<IActionResult> Details(int id)
        {
            var db = new GerenciamentoEventosContext();
            var local = await db.Locals.FirstOrDefaultAsync(x => x.Id == id);
            return View(local);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var db = new GerenciamentoEventosContext();
            var local = await db.Locals.FirstOrDefaultAsync(x => x.Id == id);
            return View(local);

        }

        [HttpPost]
        public async Task<IActionResult> Delete(Local local)
        {
            var db = new GerenciamentoEventosContext();
            db.Entry(local).State = EntityState.Deleted;
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}

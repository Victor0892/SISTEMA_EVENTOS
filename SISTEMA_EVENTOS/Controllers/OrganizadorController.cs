using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SISTEMA_EVENTOS.MODEL.Models;
using System.Reflection.Metadata.Ecma335;

namespace SISTEMA_EVENTOS.Controllers
{
    public class OrganizadorController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var db = new GerenciamentoEventosContext();

            return View(await db.Organizadors.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Organizador organizador)
        {
            var db = new GerenciamentoEventosContext();
            if (ModelState.IsValid)
            {
                db.Entry(organizador).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                await db.SaveChangesAsync();
                ViewData["Mensagem"] = "Dados salvos com sucesso. ";
            }
            else
            {
                ViewData["MensagemErro"] = "Ocorreu um erro ao salvar os dados.";
            }
            return View(organizador);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var db = new GerenciamentoEventosContext();
            var organizador = await db.Organizadors.FindAsync(id);
            return View(organizador);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Organizador organizador)
        {
            var db = new GerenciamentoEventosContext();
            if (ModelState.IsValid)
            {
                db.Entry(organizador).State = EntityState.Modified;
                await db.SaveChangesAsync();
                ViewData["Mensagem"] = "Dados alterados com sucesso.";
            }
            else
            {
                ViewData["MensagemErro"] = "Ocorreu um erro ao alterar os dados.";
            }
            return View(organizador);
        }

        public async Task<IActionResult> Details(int id)
        {
            var db = new GerenciamentoEventosContext();
            var organizador = await db.Organizadors.FirstOrDefaultAsync(x => x.Id == id);
            return View(organizador);

        }

        public async Task<IActionResult> Delete(int id)
        {
            var db = new GerenciamentoEventosContext();
            var organizador = await db.Organizadors.FirstOrDefaultAsync(x => x.Id == id);
            return View(organizador);

        }

        [HttpPost]
        public async Task<IActionResult> Delete(Organizador organizador)
        {
            var db = new GerenciamentoEventosContext();
            db.Entry(organizador).State = EntityState.Deleted;
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}

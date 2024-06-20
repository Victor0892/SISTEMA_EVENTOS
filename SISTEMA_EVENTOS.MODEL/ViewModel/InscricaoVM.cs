using Microsoft.EntityFrameworkCore;
using SISTEMA_EVENTOS.MODEL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SISTEMA_EVENTOS.MODEL.ViewModel
{
    public class InscricaoVM
    {
        public int Id { get; set; }
        public int ParticipanteId { get; set; }
        public int EventoId { get; set; }
        public DateTime DataInscricao { get; set; }

        public InscricaoVM()
        {

        }
        public async static Task<List<InscricaoVM>> GetInscricaoVMs()
        {
            var db = new GerenciamentoEventosContext();
            var listaInscricao = await db.Inscricaos.ToListAsync();
            return await (from ins in db.Inscricaos
                          join end in db.Inscricaos on ins.Id equals end.Id
                          select new InscricaoVM
                          {
                              Id = ins.Id,
                              ParticipanteId = ins.ParticipanteId,
                              EventoId = ins.EventoId,
                              DataInscricao = ins.DataInscricao.ToDateTime(TimeOnly.MinValue)
                          }).ToListAsync();
        }
    }
}
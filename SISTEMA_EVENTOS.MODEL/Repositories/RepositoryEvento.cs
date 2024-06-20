using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SISTEMA_EVENTOS.MODEL.Models;

namespace SISTEMA_EVENTOS.MODEL.Repositories
{
    public class RepositoryEvento : RepositoryBase<Evento>
    {
        public RepositoryEvento(GerenciamentoEventosContext context, bool saveChanges) : base(context, saveChanges)
        {
        }
    }
}

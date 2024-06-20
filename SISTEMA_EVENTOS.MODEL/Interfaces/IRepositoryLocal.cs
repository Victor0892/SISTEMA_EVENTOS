using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SISTEMA_EVENTOS.Interfaces;
using SISTEMA_EVENTOS.MODEL.Models;

namespace SISTEMA_EVENTOS.MODEL.Interfaces
{
    public interface IRepositoryLocal : IRepositoryBase<Local>
    {
    }
}

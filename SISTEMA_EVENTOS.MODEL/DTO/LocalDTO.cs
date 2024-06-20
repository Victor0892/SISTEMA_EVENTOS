using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_EVENTOS.MODEL.DTO
{
    public class LocalDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string? Endereco { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? Pais { get; set; }
 
    }
}

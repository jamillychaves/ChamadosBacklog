using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacklogChamados.Models
{
    public class Movimentacao
    {
        public int Id { get; set; }
        public int ChamadoId { get; set; } 
        public string StatusAnterior { get; set; }
        public string StatusNovo { get; set;}
        public DateTime DataMovimentacao { get; set; }
        public string NumeroChamado { get;  set; }
    }
}

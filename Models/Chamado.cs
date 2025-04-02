using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacklogChamados.Models
{
    public class Chamado
    {
        public int Id { get; set; }
        public string NumeroChamado { get; set; }
        public string Telefone { get; set; }
        public string Status { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataUltimaMovimentacao { get; set; }
        public int UsuarioId { get; set; }
    }
}

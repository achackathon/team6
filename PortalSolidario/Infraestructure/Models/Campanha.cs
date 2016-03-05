using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Models
{
    class Campanha
    {
        public int Id_campanha{ get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public string nome { get; set; }
        public Usuario Usuario { get; set; }
        public List<Doacao> Doacao { get; set; }

    }
}

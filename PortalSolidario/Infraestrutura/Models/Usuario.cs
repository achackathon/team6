using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Models
{
    public class Usuario
    {
        public int id_Usuario { get; set; }
        public Perfl Perfil { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cep { get; set; }
        public string Documento { get; set; }
    }
}

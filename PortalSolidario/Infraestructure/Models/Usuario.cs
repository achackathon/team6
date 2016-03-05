using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Models
{
    public class Usuario
    {
        public int Id_usuario { get; set; }
        public Perfil Perfil { get; set; }
        public int id_perfil { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Cep { get; set; }
        public string Documento { get; set; }
    }
}

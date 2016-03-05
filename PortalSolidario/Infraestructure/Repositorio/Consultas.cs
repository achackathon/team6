using Dapper;
using Infraestrutura.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Repositorio
{
    public class Consultas
    {

        internal static string ConnectionString = "Data Source=ETACARINAE;" +
                                                "Initial Catalog=PortalSolidario;" +
                                                "Integrated Security=SSPI;";

        internal static IEnumerable<T> Query<T>(string sql, object param = null)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                return conn.Query<T>(sql, param);
            }
        }

        internal static int Execute(string sql, object param = null)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                return conn.Execute(sql, param);
            }
        }

        public List<Perfil> BuscarPerfil() {
            const string sql = "Select id_perfil, descricao from perfil";
            return Query<Perfil>(sql).ToList();
        }
    }
}

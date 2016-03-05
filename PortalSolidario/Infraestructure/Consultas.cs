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

        public Perfil BuscarPerfilUsuario(Usuario usuario)
        {
            const string sql = @"select per.id_perfil,per.descricao
                                   from usuario usu
                                   join perfil per on (usu.id_perfil = per.id_perfil)
                                 where usu.id_usuario = @id_usuario";
            return Query<Perfil>(sql, usuario).FirstOrDefault();
        }

        public List<Usuario> BuscarUsuarios()
        {
            const string sql = @"SELECT TOP 1000 [id_usuario]
                                                ,[nome]
                                                ,[email]
                                                ,[cep]
                                                ,[endereco]
                                                ,[documento]
                                                ,[id_perfil]
                                            FROM [PortalSolidario].[dbo].[usuario]";
            return Query<Usuario>(sql).ToList();
        }

        public int InsereAluno(Usuario usuario)
        {
            const string sql = @"INSERT INTO [dbo].[usuario]
                                                   ([nome]
                                                   ,[email]
                                                   ,[cep]
                                                   ,[endereco]
                                                   ,[documento]
                                                   ,[id_perfil])
                                             VALUES
                                                   (@nome
                                                   ,@email
                                                   ,@cep
                                                   ,@endereco
                                                   ,@documento
                                                   ,@id_perfil)";
            return Execute(sql, usuario);
        }

        public List<Usuario> BuscarUsuarios(Usuario usuario)
        {
            const string sql = @"SELECT TOP 1000 [id_usuario]
                                                ,[nome]
                                                ,[email]
                                                ,[cep]
                                                ,[endereco]
                                                ,[documento]
                                                ,[id_perfil]
                                            FROM [PortalSolidario].[dbo].[usuario]
                                           where id_usuario = @id_usuario";
            return Query<Usuario>(sql, usuario).ToList();
        }
        public List<Perfil> BuscarPerfil(Perfil perfil)
        {
            const string sql = "Select id_perfil, descricao from perfil where id_perfil = @id_perfil";
            return Query<Perfil>(sql, perfil).ToList();
        }
    }
}

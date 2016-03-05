using Infraestrutura.Models;
using Infraestrutura.Repositorio;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PortalSolidarioApi.Controllers
{
    [RoutePrefix("portalsolidario")]
    public class PortalSolidarioController : ApiController
    {
        [Route("perfils")]
        public HttpResponseMessage Get()
        {
            try
            {
                var consulta = new Consultas();
                var perfil = consulta.BuscarPerfil();
                if (perfil == null)
                    return Request.CreateResponse(HttpStatusCode.NotFound);

                return Request.CreateResponse(HttpStatusCode.OK, perfil);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("perfils/{codigo}")]
        public HttpResponseMessage Get(int codigo)
        {
            try
            {
                var consulta = new Consultas();
                var perfilRecebido = new Perfil() { Id_perfil = codigo };
                var perfil = consulta.BuscarPerfil(perfilRecebido);
                if (perfil == null)
                    return Request.CreateResponse(HttpStatusCode.NotFound);

                return Request.CreateResponse(HttpStatusCode.OK, perfil);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("usuarios")]
        public HttpResponseMessage GetUsuarios()
        {
            try
            {
                var consulta = new Consultas();
                var response = consulta.BuscarUsuarios();
                for (int i = 0; i < response.Count; i++)
                {
                    response[i].Perfil = consulta.BuscarPerfilUsuario(new Usuario() { Id_usuario = response[i].Id_usuario });
                }
                if (response == null)
                    return Request.CreateResponse(HttpStatusCode.NotFound);

                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
        [Route("usuarios/{codigo}")]
        public HttpResponseMessage GetUsuarios(int codigo)
        {
            try
            {
                var consulta = new Consultas();
                var usuario = new Usuario() { Id_usuario = codigo };
                var response = consulta.BuscarUsuarios(usuario);

                for (int i = 0; i < response.Count; i++)
                {
                    response[i].Perfil = consulta.BuscarPerfilUsuario(new Usuario() { Id_usuario = response[i].Id_usuario });
                }

                if (response == null)
                    return Request.CreateResponse(HttpStatusCode.NotFound);

                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
        [Route("usuarios")]
        public HttpResponseMessage PostUsuarios([FromBody]Usuario usuario)
        {
            try
            {
                var consulta = new Consultas();
                usuario.id_perfil = usuario.Perfil.Id_perfil;
                var response = consulta.InsereAluno(usuario);
                
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

    }
}

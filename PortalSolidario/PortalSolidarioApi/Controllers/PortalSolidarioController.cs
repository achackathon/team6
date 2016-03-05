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
    }
}

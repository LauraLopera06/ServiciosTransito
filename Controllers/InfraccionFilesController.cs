using ServiciosTransito.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ServiciosTransito.Controllers
{
    [RoutePrefix("InfraccionFiles")]
    public class InfraccionFilesController : ApiController
    {
        [HttpPost]

        public async Task<HttpResponseMessage> GrabarArchivo(HttpRequestMessage Request, string Datos, string proceso)
        {
            ClasInfraccion InfraccionFiles = new ClasInfraccion();
            InfraccionFiles.request = Request;
            InfraccionFiles.Datos = Datos;
            InfraccionFiles.Proceso = proceso;

            return await InfraccionFiles.GrabarArchivo(false);
        }
        [HttpGet]

        public HttpResponseMessage Get(string NombreFoto)
        {
            ClasInfraccion infraccion = new ClasInfraccion();
            return infraccion.ConsultarArchivo(NombreFoto);
        }

        [HttpPut]

        public async Task<HttpResponseMessage> ActualizarArchivo(HttpRequestMessage Request, string Datos, string proceso)
        {
            ClasInfraccion InfraccionFiles = new ClasInfraccion();
            InfraccionFiles.request = Request;
            InfraccionFiles.Datos = Datos;
            InfraccionFiles.Proceso = proceso;

            return await InfraccionFiles.GrabarArchivo(true);
        }
        [HttpDelete]
        public HttpResponseMessage EliminarArchivo(string NombreFoto)
        {
            ClasInfraccion infraccion = new ClasInfraccion();
            return infraccion.EliminarArchivo(NombreFoto);
        }
    }

}

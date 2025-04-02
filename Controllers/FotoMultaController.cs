using ServiciosTransito.Clases;
using ServiciosTransito.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServiciosTransito.Controllers
{
    [RoutePrefix("api/Fotomultas")]
    public class FotoMultaController : ApiController
    {
        private ClasFotoMulta clasFotoMulta = new ClasFotoMulta();

        [HttpPost]
        [Route("registrar")]
        public HttpResponseMessage Registrar([FromBody] RegistroFotomulta datos)
        {
            if (datos == null || datos.Vehiculo == null || datos.Infraccion == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Datos incompletos.");
            }

            try
            {
                string resultado = clasFotoMulta.RegistrarFotomulta(datos.Vehiculo, datos.Infraccion);
                return Request.CreateResponse(HttpStatusCode.OK, new { mensaje = resultado });
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error en el servidor: " + ex.Message);
            }
        }
    }

    public class RegistroFotomulta
    {
        public Vehiculo Vehiculo { get; set; }
        public Infraccion Infraccion { get; set; }
    }
}
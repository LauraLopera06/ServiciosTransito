using ServiciosTransito.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServiciosTransito.Controllers
{
    [RoutePrefix("api/Vehiculos")]
    public class VehiculosController : ApiController
    {

        [HttpGet]
        [Route("ConsultarFotos")]

        public IQueryable ConsultarFotos(string PlacaVehiculo)
        {
            ClasVehiculo vehiculo = new ClasVehiculo();
            return vehiculo.ConsultarFotosPorPlaca(PlacaVehiculo);
        }
    }
}
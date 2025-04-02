using ServiciosTransito.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosTransito.Clases
{
    public class ClasVehiculo
    {

        private TransitoEntities transito = new TransitoEntities();

        public Vehiculo vehiculo { get; set; }
            public IQueryable ConsultarFotosPorPlaca(string placaVehiculo)
        {
            return from V in transito.Set<Vehiculo>()
                   join I in transito.Set<Infraccion>()
                   on V.Placa equals I.PlacaVehiculo
                   join FI in transito.Set<FotoInfraccion>()
                   on I.idFotoMulta equals FI.idInfraccion
                   where V.Placa == placaVehiculo
                   orderby FI.NombreFoto
                   select new
                   {
                       Placa = V.Placa,
                       TipoVehiculo = V.TipoVehiculo,
                       Marca = V.Marca,
                       Color = V.Color,
                       idFotoMulta = I.idFotoMulta,
                       FechaInfraccion = I.FechaInfraccion,
                       TipoInfraccion = I.TipoInfraccion,
                       idFoto = FI.idFoto,
                       NombreFoto = FI.NombreFoto
                   };
        }
    }
    }

using ServiciosTransito.Models;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace ServiciosTransito.Clases
{
    public class ClasFotoMulta
    {
        private TransitoEntities db = new TransitoEntities();

        public string RegistrarFotomulta(Vehiculo vehiculo, Infraccion infraccion)
        {
            try
            {
                // Verificar si el vehículo ya existe en la base de datos
                var vehiculoExistente = db.Vehiculoes.FirstOrDefault(v => v.Placa == vehiculo.Placa);

                if (vehiculoExistente == null)
                {
                    // Si no existe, lo registramos
                    db.Vehiculoes.Add(vehiculo);
                    db.SaveChanges();
                }

                // Asociar la infracción con la placa del vehículo
                infraccion.PlacaVehiculo = vehiculo.Placa;
                db.Infraccions.Add(infraccion);
                db.SaveChanges();

                return "Fotomulta registrada con éxito.";
            }
            catch (Exception ex)
            {
                return "Error al registrar la fotomulta: " + ex.Message;
            }

        }
    }
}
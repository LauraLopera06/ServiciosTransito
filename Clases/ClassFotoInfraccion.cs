using ServiciosTransito.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosTransito.Clases
{
    public class ClassFotoInfraccion
    {
        private TransitoEntities transito = new TransitoEntities();
        public string idInfraccion { get; set; }
        public List<string> Archivos { get; set; }
            public string GrabarFotos()
        {
            try
            {
                if (Archivos.Count > 0)
                {
                    foreach (string Archivo in Archivos)
                    {
                        FotoInfraccion Foto = new FotoInfraccion();
                        if (!int.TryParse(idInfraccion, out int id))
                        {
                            return "ID de infracción inválido";
                        }
                        Foto.idInfraccion = id; Foto.NombreFoto = Archivo;
                        transito.FotoInfraccions.Add(Foto);
                        transito.SaveChanges();

                    }
                    return "Foto guardada correctamente";
                }
                else
                {
                    return "No se enviaron archivos para guardar";

                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
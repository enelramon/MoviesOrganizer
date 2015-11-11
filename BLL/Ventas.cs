using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
   public  class Ventas
    {
        public static DataTable Listado(string Campos, string Condicion, string Orden)
        {
            ConexionDb conexion = new ConexionDb();
            return conexion.ObtenerDatos("Select Fecha,Sum(Monto) as Monto from Ventas group by Fecha");
        }
    }
}

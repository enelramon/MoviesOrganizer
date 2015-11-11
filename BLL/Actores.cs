using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;

namespace BLL
{

    public class Actores : ClaseMaestra
    {
        public int ActorId { get; set; }
        public string Nombre { get; set; }

        ConexionDb conexion = new ConexionDb();
        public Actores()
        {
            this.ActorId = 0;
            this.Nombre = "";
        }

        public Actores(int actorId, string nombre)
        {
            this.ActorId = actorId;
            this.Nombre = nombre;
        }

        public override bool Insertar()
        {
            bool retorno = false;
            conexion.Ejecutar(String.Format("Insert Into Actores (Nombre) values('{0}')", this.Nombre));
            return retorno;
        }

        public override bool Editar()
        {
            bool retorno = false;
            conexion.Ejecutar(String.Format("update Actores set Nombre= '{0}' where ActorId = '{1}'", this.Nombre, this.ActorId));
            return retorno;
        }

        public override bool Eliminar()
        {
            bool retorno = false;
            conexion.Ejecutar(String.Format("Delete  Actores where ActorId ='{0}'", this.ActorId));
            return retorno;
        }

        public override bool Buscar(int idBuscado)
        {
            DataTable dt = new DataTable();
            dt = (conexion.ObtenerDatos(String.Format("Select ActorId, Nombre from where AcotresId = '{0}'", this.ActorId)));
            if (dt.Rows.Count > 0)
            {
                this.ActorId = (int)dt.Rows[0]["ActorId"];
                this.Nombre = dt.Rows[0]["Nombre"].ToString();
            }
            return dt.Rows.Count > 0;
        }

        public override DataTable Listado(string campos, string condicion, string orden)
        {
            string ordenFinal = "";
            if (!orden.Equals(""))
                ordenFinal = " orden by  " + orden;

            return conexion.ObtenerDatos(("Select " + campos +
                " from Actores where " + condicion + ordenFinal));
        }
    }

}

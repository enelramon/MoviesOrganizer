using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class Categorias
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public Categorias()
        {
            this.Id = 0;
            this.Descripcion = "";
        }

        public Categorias(int id, string descripcion)
        {
            this.Id = id;
            this.Descripcion = descripcion;
        }


        private bool Insertar()
        {
            bool retorno = false;

            ConexionDb conexion = new ConexionDb();

            conexion.Ejecutar(String.Format("Insert Into Categorias (Descripcion) Values('{0}')", this.Descripcion));

            return retorno;

        }

    }
}

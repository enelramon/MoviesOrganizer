using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;

namespace BLL
{
    public class Categorias: ClaseMaestra
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


        public override bool Insertar()
        {
            bool retorno = false;

            ConexionDb conexion = new ConexionDb();

            conexion.Ejecutar(String.Format("Insert Into Categorias (Descripcion) Values('{0}')", this.Descripcion));

            return retorno;

        }


        public override bool Editar()
        {
            throw new NotImplementedException();
        }

        public override bool Eliminar()
        {
            throw new NotImplementedException();
        }

        public override bool Buscar(int IdBuscado)
        {
            throw new NotImplementedException();
        }

        public override  DataTable Listado(string Campos, string Condicion, string Orden)
        {
            throw new NotImplementedException();
        }
    }
}

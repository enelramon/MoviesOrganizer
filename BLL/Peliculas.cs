using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;
namespace BLL
{
    class Peliculas : ClaseMaestra

    {

        ConexionDb conexion = new ConexionDb();


        public int PeliculaId { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int Ano { get; set; }
        public int Calificacion { get; set; }
        public int IMDB { get; set; }
        public int CategoriaId { get; set; }


        public List<Actores> Actores { get; set; }

        public Peliculas()
        {
            Actores = new List<Actores>();

        }

        public void AgregarActor(int ActorId, string Nombre)
        {
            this.Actores.Add(new Actores(ActorId, Nombre));
        }

        public override bool Insertar()
        {
            bool retorno = false;
            StringBuilder Comando = new StringBuilder();

           // retorno = conexion.Ejecutar(String.Format("insert into Peliculas(Titulo,Descripcion,Ano,Calificacion,IMBD, CategoriaId,Foto,Video,Genero,Actor,Estudio) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')", this.Titulo, this.Descripcion, this.Ano, this.Calificacion, this.Imbd, this.categoriaId, this.Direccion, this.Video, this.Genero, this.Actor, this.Estudio));
            if (retorno)
            {
                this.PeliculaId = (int)conexion.ObtenerValor("Select Max(PeliculaId) from Peliculas");

                foreach (var autor in this.Actores)
                {
                    Comando.AppendLine( String.Format("insert into PeliculasActores(PeliculaId,ActorId) Values({0},{1});",this.PeliculaId ,autor.ActorId ));

                }

                retorno = conexion.Ejecutar(Comando.ToString());
            }

            return retorno;
        }


        public override bool Editar()
        {
            bool retorno = false;
            StringBuilder Comando = new StringBuilder();

            retorno = conexion.Ejecutar(string.Format("update Peliculas set Titulo = '{0}',Descripcion = '{1}',Ano = '{2}', Calificacion = '{3}',IMDB = '{4}' where PeliculaId = '{5}'", 
                Titulo, Descripcion, Ano, Calificacion, IMDB, this.PeliculaId));


            if (retorno)
            {
                conexion.Ejecutar("Delete From PeliculasActores Where PeliculaId=" + this.PeliculaId );

                foreach (var autor in this.Actores)
                {
                    Comando.AppendLine(String.Format("insert into PeliculasActores(PeliculaId,ActorId) Values({0},{1});", this.PeliculaId, autor.ActorId));

                }

                retorno = conexion.Ejecutar(Comando.ToString());
            }


            return retorno;
        }

        public override bool Eliminar()
        {
            bool retorno = false;

            retorno = conexion.Ejecutar( "delete  from Peliculas where PeliculaId= "+this.PeliculaId + "; " +
                                            "Delete From PeliculasActores Where PeliculaId=" + this.PeliculaId); 

            return retorno;
        }

        public override bool Buscar(int IdBuscado)
        {
            DataTable dt = new DataTable();
DataTable dtActores = new DataTable();
            dt = conexion.ObtenerDatos(String.Format("select  PeliculaId,Titulo,Descripcion,Ano,Calificacion,IMBD, CategoriaId,Foto,Video from Peliculas where PeliculaId='{0}'", IdBuscado));
            if (dt.Rows.Count > 0)
            {
                this.PeliculaId = (int)dt.Rows[0]["PeliculaId"];
                this.Titulo = dt.Rows[0]["Titulo"].ToString();
                this.Descripcion = dt.Rows[0]["Descripcion"].ToString();
                this.Ano = (int)dt.Rows[0]["Ano"];
                this.Calificacion = (int)dt.Rows[0]["Calificacion"];


                dtActores = conexion.ObtenerDatos("Select p.ActorId,a.Nombre "+ 
                                                    "From PeliculasActores p " +
                                                    "Inner Join Actores a On p.ActorId=a.ActorId" + 
                                                    "Where p.PeliculaId=" + this.PeliculaId );

                foreach (DataRow  row in dtActores.Rows)
                {
                    this.AgregarActor((int)row["ActorId"],row["Nombre"].ToString());
                }
            }

            return dt.Rows.Count > 0;
        }

        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {

            string ordenFinal = ""; //!orden.Equals("") ? " orden by  " + orden : "";
            if (!Orden.Equals(""))
                ordenFinal = " orden by  " + Orden;

            return conexion.ObtenerDatos(("Select " + Campos +
                " from Pelicula where " + Condicion + ordenFinal));
        }
    }
}

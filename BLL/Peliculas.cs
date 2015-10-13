using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    class Peliculas: ClaseMaestra

    {

        public int PeliculaId { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int Ano { get; set; }
        public int Calificacion { get; set; }
        public int IMDB { get; set; }
        public int CategoriaId { get; set; }


        public List<Autor> Autores { get; set; }

        public Peliculas()
        {
            Autores = new List<Autor>();

        }

        public void AgregarAutor(int AutorId,string Nombres)
        {
            this.Autores.Add(new Autor(AutorId, Nombres));
        }

        public override bool Insertar()
        {


            foreach (var autor in this.Autores)
            {
                //Insert into PeliculasAutores() Values() ,autor.id,autor.nombres
            }
            return true;
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

        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    class Autor
    {
        public int AutorId { get; set; }
        public string Nombres { get; set; }

        public Autor()
        {

        }

        public Autor(int autorId, string nombres)
        {
            this.AutorId = autorId;
            this.Nombres = nombres;
        }
    }
}

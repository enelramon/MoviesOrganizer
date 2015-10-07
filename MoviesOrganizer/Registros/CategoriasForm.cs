using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
namespace MoviesOrganizer.Registros
{
    public partial class CategoriasForm : Form
    {
        public CategoriasForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Categorias categoria = new Categorias();

            categoria.Descripcion = DescripciontextBox.Text;

            categoria.Insertar();
        }

        private void textBox1_Validated(object sender, EventArgs e)
        {
            Categorias categoria = new Categorias();

            if (CategoriaIDtextBox.Text.Length > 0 )
            {
              if(  categoria.Buscar(int.Parse(CategoriaIDtextBox.Text)))
                {
                    DescripciontextBox.Text = categoria.Descripcion;
                }

            }
        }
    }
}

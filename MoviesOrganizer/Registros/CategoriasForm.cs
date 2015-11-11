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


            //HACER UN CICLO PARA RECORER EL LISTBOX PELICULA.AgregarAutor()
            
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

        DataTable table = new DataTable();
        DateTime date = DateTime.Now;
        private void Graficobutton_Click(object sender, EventArgs e)
        {
            
        }

        private void Graficobutton_Click_1(object sender, EventArgs e)
        {
Categorias categoria = new Categorias();

            table = Ventas.Listado("", "", "");

            chart.Series.Add("Ventas");
            chart.Series["Series1"].XValueMember = "Fecha";
            chart.Series["Series1"].YValueMembers = "Monto";
            chart.DataSource = table;
            chart.DataBind();
        }
    }
}

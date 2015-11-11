using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MoviesOrganizer
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registros.CategoriasForm categorias = new Registros.CategoriasForm();
            categorias.Show();
        }
    }
}

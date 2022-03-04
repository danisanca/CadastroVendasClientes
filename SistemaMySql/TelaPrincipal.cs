using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaMySql.Telas;

namespace SistemaMySql
{
    public partial class TelaPrincipal : Form
    {
        public TelaPrincipal()
        {
            InitializeComponent();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            frmClientes form = new frmClientes();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmVendas form = new frmVendas();
            form.Show();
        }

    }
}

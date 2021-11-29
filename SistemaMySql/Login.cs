using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaMySql.Entidades;
using SistemaMySql.Model;

namespace SistemaMySql
{
    public partial class Login : Form
    {
        UsuarioModel model = new UsuarioModel();
        public Login()
        {
            InitializeComponent();
        }
        public void logar(User dado)
        {
            try
            {
                if (txtUsuario.Text == "")
                {
                    MessageBox.Show("Logue com um usuario!");
                    txtUsuario.Focus();
                    return;
                }
                if (txtSenha.Text == "")
                {
                    MessageBox.Show("insira uma senha!");
                    txtUsuario.Focus();
                    return;
                }
                dado.Usuario = txtUsuario.Text;
                dado.Senha = txtSenha.Text;

               dado = model.Login(dado);

                if (dado.Usuario == null)
                {
                    lblMsg.Text = "Usuario incorreto";
                    lblMsg.ForeColor = Color.Red;
                    return;
                }
                TelaPrincipal form = new TelaPrincipal();
                this.Hide();
                form.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao logar." + ex.Message);
            }

        }

        private void btnlogar_Click(object sender, EventArgs e)
        {
            User usuario = new User();
            logar(usuario);
        }
    }
}

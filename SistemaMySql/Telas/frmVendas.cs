using SistemaMySql.Entidades;
using SistemaMySql.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaMySql.Telas
{
    public partial class frmVendas : Form
    {
        ClienteModel Clientemodel = new ClienteModel();
        VendaModel model = new VendaModel();
        public frmVendas()
        {
            InitializeComponent();
        }
        public void HabilitarCampos()
        {
            txtValor.Enabled = true;
            cbCliente.Enabled = true;
            dtVenda.Enabled = true;
        }
        public void DesabilitarCampos()
        {
            txtValor.Enabled = false;
            cbCliente.Enabled = false;
            dtVenda.Enabled = false;
        }
        public void LimparCampos()
        {
            txtValor.Text = "";
            dtVenda.Text = "";
        }
        public void Listar()
        {
            try
            {
                grid.DataSource = model.Listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Listar os Dados" + ex.Message);
            }
        }
        public void Salvar(Vendas dado)
        {
            try
            {
                dado.Data = Convert.ToDateTime(dtVenda.Text);
                dado.Valor = Convert.ToDecimal(txtValor.Text);
                dado.Id_cliente = Convert.ToInt32(cbCliente.SelectedValue);

                model.Salvar(dado);
                MessageBox.Show("Venda Salva com Sucesso !");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Salvar os Venda." + ex.Message);
            }
        }
        public void Editar(Vendas dado)
        {
            try
            {
                dado.Id = Convert.ToInt32(txtCodigo.Text);
                dado.Data = Convert.ToDateTime(dtVenda.Text);
                dado.Valor = Convert.ToDecimal(txtValor.Text);
                dado.Id_cliente = Convert.ToInt32(cbCliente.SelectedValue);
                model.Editar(dado);
                MessageBox.Show("Editado com Sucesso !");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Editar os Dados" + ex.Message);
            }
        }
        public void Excluir(Vendas dado)
        {
            try
            {
                dado.Id = Convert.ToInt32(txtCodigo.Text);
                model.Excluir(dado);
                MessageBox.Show("Excluido com Sucesso !");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Excluir os Dados" + ex.Message);
            }
        }
        public void Buscar(Vendas dado)
        {
            try
            {
                dado.Id_cliente = Convert.ToInt32(cbBuscar.SelectedValue);
                grid.DataSource = model.Buscar(dado);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Listar os Dados" + ex.Message);
            }
        }
        private void frmVendas_Load(object sender, EventArgs e)
        {
           
            cbCliente.DataSource = Clientemodel.Listar();
            cbCliente.ValueMember = "id";
            cbCliente.DisplayMember = "nome";

            cbBuscar.DataSource = Clientemodel.Listar();
            cbBuscar.ValueMember = "id";
            cbBuscar.DisplayMember = "nome";
            Listar();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            HabilitarCampos();
            LimparCampos();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Vendas cdados = new Vendas();
            Salvar(cdados);
            Listar();
            LimparCampos();
            DesabilitarCampos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
            {
                MessageBox.Show("Selecione um cliente na tabela para editar!");
                return;
            }
            Vendas cdados = new Vendas();
            Editar(cdados);
            Listar();
            LimparCampos();
            DesabilitarCampos();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
            {
                MessageBox.Show("Selecione um cliente na tabela para Excluir!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Selecione um cliente na tabela para Excluir!", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }
            Vendas cdados = new Vendas();
            Excluir(cdados);
            Listar();
            LimparCampos();
            DesabilitarCampos();
        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigo.Text = grid.CurrentRow.Cells[0].Value.ToString();
            dtVenda.Text = grid.CurrentRow.Cells[1].Value.ToString();
            txtValor.Text = grid.CurrentRow.Cells[2].Value.ToString();
            cbCliente.SelectedValue = grid.CurrentRow.Cells[3].Value.ToString();
            HabilitarCampos();
        }

        

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Vendas cdados = new Vendas();
            Buscar(cdados);

            if (cbBuscar.Text=="")
            {
                Listar();
                return;
            }
        }
    }
}

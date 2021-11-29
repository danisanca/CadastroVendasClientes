using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SistemaMySql.Entidades;

namespace SistemaMySql.DAO
{
    class VendaDAO
    {
        MySqlCommand sql;
        Conexao con = new Conexao();

        public DataTable Listar()
        {
            try
            {
                con.AbriConexao();
                sql = new MySqlCommand("SELECT * FROM vendas ORDER BY ID DESC", con.con);
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = sql;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Salvar(Vendas dado)
        {
            try
            {
                con.AbriConexao();
                sql = new MySqlCommand("INSERT INTO vendas(data, valor, id_cliente) VALUES(@data, @valor, @id_cliente)", con.con);
                sql.Parameters.AddWithValue("@data", dado.Data);
                sql.Parameters.AddWithValue("@valor", dado.Valor);
                sql.Parameters.AddWithValue("@id_cliente", dado.Id_cliente);
                sql.ExecuteNonQuery();
                con.FecharConexao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("erro ao salvar Vendas" + ex.Message);
                con.FecharConexao();
            }
        }

        public DataTable Buscar(Vendas dado)
        {
            try
            {
                con.AbriConexao();
                sql = new MySqlCommand("SELECT * FROM vendas where id_cliente = @cliente", con.con);
                sql.Parameters.AddWithValue("@cliente", dado.Id_cliente);
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = sql;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Excluir(Vendas dado)
        {
            try
            {
                con.AbriConexao();
                sql = new MySqlCommand("DELETE FROM vendas WHERE id = @id", con.con);
                sql.Parameters.AddWithValue("@id", dado.Id);
                sql.ExecuteNonQuery();
                con.FecharConexao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("erro ao Excluir Clientes" + ex.Message);
                con.FecharConexao();
            }
        }

        public void Editar(Vendas dado)
        {
            try
            {
                con.AbriConexao();
                sql = new MySqlCommand("UPDATE vendas SET data = @data, valor = @valor, id_cliente = @cliente WHERE id = @id", con.con);
                sql.Parameters.AddWithValue("@data", dado.Data);
                sql.Parameters.AddWithValue("@valor", dado.Valor);
                sql.Parameters.AddWithValue("@cliente", dado.Id_cliente);
                sql.Parameters.AddWithValue("@id", dado.Id);
                sql.ExecuteNonQuery();
                con.FecharConexao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao editar clientes" + ex.Message);
                con.FecharConexao();
            }
        }
    }
}

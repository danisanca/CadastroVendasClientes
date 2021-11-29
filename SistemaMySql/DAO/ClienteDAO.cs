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
    class ClienteDAO
    {
      
        MySqlCommand  sql;
        Conexao con = new Conexao();

        public DataTable Listar()
        {
            try
            {
                con.AbriConexao();
                sql = new MySqlCommand("SELECT * FROM clientes ORDER BY ID DESC", con.con);
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = sql;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch(Exception)
            {
                throw;
            }
        }
        public void Salvar(Clientes dado)
        {
            try
            {
                con.AbriConexao();
                sql = new MySqlCommand("INSERT INTO clientes(nome, sexo, nascimento) VALUES(@nome, @sexo, @nascimento)",con.con);
                sql.Parameters.AddWithValue("@nome",dado.Nome);
                sql.Parameters.AddWithValue("@sexo", dado.Sexo);
                sql.Parameters.AddWithValue("@nascimento", dado.Nascimento);
                sql.ExecuteNonQuery();
                con.FecharConexao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("erro ao salvar Clientes"+ex.Message);
                con.FecharConexao();
            }
        }

        public DataTable Buscar(Clientes dado)
        {
            try
            {
                con.AbriConexao();
                sql = new MySqlCommand("SELECT * FROM clientes where nome LIKE @nome", con.con);
                sql.Parameters.AddWithValue("@nome", dado.Nome + "%");
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

        public void Excluir(Clientes dado)
        {
            try
            {
                con.AbriConexao();
                sql = new MySqlCommand("DELETE FROM clientes WHERE id = @id", con.con);
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

        public void Editar(Clientes dado)
        {
            try
            {
                con.AbriConexao();
                sql = new MySqlCommand("UPDATE clientes SET nome = @nome, sexo = @sexo, nascimento = @nascimento WHERE id = @id", con.con);
                sql.Parameters.AddWithValue("@nome", dado.Nome);
                sql.Parameters.AddWithValue("@sexo", dado.Sexo);
                sql.Parameters.AddWithValue("@nascimento", dado.Nascimento);
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

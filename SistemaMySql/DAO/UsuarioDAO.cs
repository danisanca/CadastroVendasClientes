using SistemaMySql.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SistemaMySql.DAO
{
    class UsuarioDAO
    {
        MySqlCommand sql;
        Conexao con = new Conexao();
        public User Login(User dado)
        {

            try
            {
                con.AbriConexao();
                sql = new MySqlCommand("SELECT * FROM usuarios where usuario =@usuario AND senha = @senha", con.con);
                sql.Parameters.AddWithValue("@usuario", dado.Usuario);
                sql.Parameters.AddWithValue("@senha", dado.Senha);
                MySqlDataReader dr;
                dr = sql.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        dado.Usuario = Convert.ToString(dr["usuario"]);
                        dado.Senha = Convert.ToString(dr["senha"]);
                    }
                   
                }
                else
                {
                    dado.Usuario = null;
                    dado.Senha = null;
                 
                }

                return dado;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}

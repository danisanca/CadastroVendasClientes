using SistemaMySql.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SistemaMySql.DAO;

namespace SistemaMySql.Model
{
    public class UsuarioModel
    {
        UsuarioDAO dao = new UsuarioDAO();
        public User Login(User dado)
        {

            try
            {
                return dao.Login(dado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

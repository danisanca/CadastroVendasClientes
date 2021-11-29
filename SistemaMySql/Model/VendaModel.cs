using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaMySql.DAO;
using SistemaMySql.Entidades;

namespace SistemaMySql.Model
{
    class VendaModel
    {

        VendaDAO dao = new VendaDAO();
        public DataTable Listar()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = dao.Listar();
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
                dao.Salvar(dado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void Editar(Vendas dado)
        {
            try
            {
                dao.Editar(dado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Excluir(Vendas dado)
        {
            try
            {
                dao.Excluir(dado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object Buscar(Vendas dado)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = dao.Buscar(dado);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

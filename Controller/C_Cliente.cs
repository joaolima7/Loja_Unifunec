using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja_Unifunec.Controller
{
    internal class C_Cliente
    {

        SqlConnection con; 
        SqlCommand cmd;

        public DataTable carregarClientes()
        {
            DataTable clientes = new DataTable();
            return clientes;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja_Unifunec.Conection
{
    internal class Conexao
    {
        SqlConnection con;
        string connectionString = "Data Source=localhost;Initial Catalog=lojafunec;Integrated Security=True;";

        public SqlConnection conectaSQL()
        {
            con = new SqlConnection(connectionString);
            return con;
        }
    }
}

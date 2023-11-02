using Loja_Unifunec.Conection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja_Unifunec.Controller
{
    public static class C_Funcionario
    {

        static Conexao conection = new Conexao();
        static SqlConnection con;
        static SqlCommand cmd;
        static DataTable dtUf;

    }
}

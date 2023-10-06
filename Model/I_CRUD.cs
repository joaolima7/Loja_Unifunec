using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loja_Unifunec
{
    internal interface I_CRUD
    {
        DataTable carregarDados();
        void excluirDados(int cod);
        void inserirDados(Object obj);

    }
}

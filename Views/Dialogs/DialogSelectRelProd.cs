using Loja_Unifunec.Controller;
using Loja_Unifunec.Model;
using Loja_Unifunec.Views.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loja_Unifunec.Views.Dialogs
{
    public partial class DialogSelectRelProd : Form
    {
        public DialogSelectRelProd()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                comboBox2.Enabled = true;
                comboBox2.DataSource = C_Tipo.carregarComboBoxTipo();
                comboBox2.ValueMember = "codtipo";
                comboBox2.DisplayMember = "nometipo";
            }
            else if (checkBox1.Checked == false)
            {
                comboBox2.Enabled = false;
                comboBox2.DataSource = null;
                comboBox2.ValueMember = null;
                comboBox2.DisplayMember = null;
                comboBox2.Text = "Todos Tipos";
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                comboBox1.Enabled = true;
                comboBox1.DataSource = C_Marca.carregarComboBoxMarca();
                comboBox1.ValueMember = "codmarca";
                comboBox1.DisplayMember = "nomemarca";
            }
            else if (checkBox2.Checked == false)
            {
                comboBox1.Enabled = false;
                comboBox1.DataSource = null;
                comboBox1.ValueMember = null;
                comboBox1.DisplayMember = null;
                comboBox1.Text = "Todas Marcas";
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                textBox1.Enabled = true;
                textBox1.Text = null;
            }
            else if (checkBox3.Checked == false)
            {
                textBox1.Enabled = false;
                textBox1.Text = "Todos Produtos";
            }
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            Produto prod = new Produto();
            prod.Marca = new Marca();
            prod.Tipo = new Tipo();
            string sql = "select p.codproduto as CÓDIGO, p.nomeproduto as PRODUTO, p.quantidade as ESTOQUE," +
            "p.valor as VALOR, m.nomemarca as MARCA, t.nometipo as TIPO from produto p join marca m on m.codmarca = p.codmarca_fk join tipo t" +
            " on t.codtipo = p.codtipo_fk ";


            if (checkBox3.Checked)
            {
                if (textBox1.Text != null)
                {
                    sql = sql + " where p.nomeproduto = "+ textBox1.Text;
                }
                else
                {
                    MessageBox.Show("Selecione Produto!", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox1.Focus();
                }
            }


            if (checkBox2.Checked)
            {
                if (checkBox3.Checked)
                {
                    sql = sql + " and p.codmarca_fk = "+comboBox1.SelectedValue.ToString();
                }
                else
                {
                    sql = sql + " where p.codmarca_fk = " + comboBox1.SelectedValue.ToString();
                }
            }


            if (checkBox1.Checked)
            {
                if (checkBox3.Checked || checkBox2.Checked)
                {
                    sql = sql + " and p.codtipo_fk = " + comboBox2.SelectedValue.ToString();
                }
                else
                {
                    sql = sql + " where p.codtipo_fk = " + comboBox2.SelectedValue.ToString();
                }
            }


            sql = sql + "order by p.nomeproduto";
            Frm_Report_Produtos frm = new Frm_Report_Produtos(sql);
            frm.ShowDialog();
        }
    }
}

namespace Loja_Unifunec.Views
{
    partial class Frm_Vendas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Vendas));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_imprimir = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_codVenda = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbl_dataVenda = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btn_imprimir);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(0, 550);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(634, 42);
            this.panel1.TabIndex = 0;
            // 
            // btn_imprimir
            // 
            this.btn_imprimir.Enabled = false;
            this.btn_imprimir.Image = global::Loja_Unifunec.Properties.Resources.imprimir__1_;
            this.btn_imprimir.Location = new System.Drawing.Point(571, 4);
            this.btn_imprimir.Name = "btn_imprimir";
            this.btn_imprimir.Size = new System.Drawing.Size(45, 32);
            this.btn_imprimir.TabIndex = 3;
            this.btn_imprimir.UseVisualStyleBackColor = true;
            this.btn_imprimir.EnabledChanged += new System.EventHandler(this.button6_EnabledChanged);
            // 
            // button5
            // 
            this.button5.Enabled = false;
            this.button5.Location = new System.Drawing.Point(462, 5);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(95, 30);
            this.button5.TabIndex = 2;
            this.button5.Text = "Excluir Venda";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.EnabledChanged += new System.EventHandler(this.button5_EnabledChanged);
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(351, 5);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(95, 30);
            this.button4.TabIndex = 1;
            this.button4.Text = "Editar Venda";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.EnabledChanged += new System.EventHandler(this.button4_EnabledChanged);
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(239, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(95, 30);
            this.button3.TabIndex = 1;
            this.button3.Text = "Fechar Venda";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.EnabledChanged += new System.EventHandler(this.button3_EnabledChanged);
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(124, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 30);
            this.button2.TabIndex = 1;
            this.button2.Text = "Pesquisar Venda";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.EnabledChanged += new System.EventHandler(this.button2_EnabledChanged);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(8, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 30);
            this.button1.TabIndex = 0;
            this.button1.Text = "Iniciar Venda";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.EnabledChanged += new System.EventHandler(this.button1_EnabledChanged);
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(7, 144);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ShowCellErrors = false;
            this.dataGridView1.ShowRowErrors = false;
            this.dataGridView1.Size = new System.Drawing.Size(617, 402);
            this.dataGridView1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.Controls.Add(this.lbl_codVenda);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(95, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(177, 34);
            this.panel2.TabIndex = 2;
            // 
            // lbl_codVenda
            // 
            this.lbl_codVenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_codVenda.ForeColor = System.Drawing.Color.White;
            this.lbl_codVenda.Location = new System.Drawing.Point(109, 1);
            this.lbl_codVenda.Name = "lbl_codVenda";
            this.lbl_codVenda.Size = new System.Drawing.Size(65, 33);
            this.lbl_codVenda.TabIndex = 3;
            this.lbl_codVenda.Text = "-";
            this.lbl_codVenda.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(1, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cód. Venda:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.LightGray;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Location = new System.Drawing.Point(0, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(634, 42);
            this.panel3.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.SteelBlue;
            this.panel4.Controls.Add(this.lbl_dataVenda);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Location = new System.Drawing.Point(360, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(177, 34);
            this.panel4.TabIndex = 3;
            // 
            // lbl_dataVenda
            // 
            this.lbl_dataVenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_dataVenda.ForeColor = System.Drawing.Color.White;
            this.lbl_dataVenda.Location = new System.Drawing.Point(67, 1);
            this.lbl_dataVenda.Name = "lbl_dataVenda";
            this.lbl_dataVenda.Size = new System.Drawing.Size(110, 33);
            this.lbl_dataVenda.TabIndex = 3;
            this.lbl_dataVenda.Text = "__/__/____";
            this.lbl_dataVenda.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(1, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 33);
            this.label3.TabIndex = 0;
            this.label3.Text = "Data:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(9, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Cliente:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(349, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Funcionário:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(8, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "Produto:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(349, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 15);
            this.label6.TabIndex = 7;
            this.label6.Text = "Quantidade:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(493, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 15);
            this.label7.TabIndex = 8;
            this.label7.Text = "Valor:";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(66, 58);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(277, 20);
            this.textBox1.TabIndex = 9;
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(433, 58);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(188, 20);
            this.textBox2.TabIndex = 10;
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(66, 104);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(277, 20);
            this.textBox3.TabIndex = 11;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            this.textBox3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox3_KeyDown);
            // 
            // textBox4
            // 
            this.textBox4.Enabled = false;
            this.textBox4.Location = new System.Drawing.Point(433, 104);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(57, 20);
            this.textBox4.TabIndex = 12;
            this.textBox4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox4_KeyDown);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.SteelBlue;
            this.panel5.Controls.Add(this.label8);
            this.panel5.Location = new System.Drawing.Point(537, 105);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(84, 19);
            this.panel5.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 19);
            this.label8.TabIndex = 1;
            this.label8.Text = "R$";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Frm_Vendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(633, 592);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_Vendas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vendas";
            this.Load += new System.EventHandler(this.Frm_Vendas_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_codVenda;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lbl_dataVenda;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_imprimir;
    }
}
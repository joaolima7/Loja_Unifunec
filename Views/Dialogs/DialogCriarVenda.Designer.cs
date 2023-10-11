namespace Loja_Unifunec.Views.Dialogs
{
    partial class DialogCriarVenda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogCriarVenda));
            this.Txb_nomecliente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Txb_noemfunc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // Txb_nomecliente
            // 
            this.Txb_nomecliente.Enabled = false;
            this.Txb_nomecliente.Location = new System.Drawing.Point(101, 44);
            this.Txb_nomecliente.Margin = new System.Windows.Forms.Padding(4);
            this.Txb_nomecliente.Name = "Txb_nomecliente";
            this.Txb_nomecliente.Size = new System.Drawing.Size(543, 22);
            this.Txb_nomecliente.TabIndex = 11;
            this.Txb_nomecliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txb_nomecliente_KeyDown);
            this.Txb_nomecliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txb_nomecliente_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 18);
            this.label2.TabIndex = 10;
            this.label2.Text = "Cliente:";
            // 
            // Txb_noemfunc
            // 
            this.Txb_noemfunc.Enabled = false;
            this.Txb_noemfunc.Location = new System.Drawing.Point(139, 116);
            this.Txb_noemfunc.Margin = new System.Windows.Forms.Padding(4);
            this.Txb_noemfunc.Name = "Txb_noemfunc";
            this.Txb_noemfunc.Size = new System.Drawing.Size(505, 22);
            this.Txb_noemfunc.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 119);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 18);
            this.label1.TabIndex = 12;
            this.label1.Text = "Funcionário:";
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(274, 173);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(127, 37);
            this.button3.TabIndex = 14;
            this.button3.Text = "Iniciar Venda";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(101, 73);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(154, 20);
            this.checkBox1.TabIndex = 15;
            this.checkBox1.Text = "Não possui cadastro";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // DialogCriarVenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 235);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.Txb_noemfunc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Txb_nomecliente);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DialogCriarVenda";
            this.Text = "Iniciar Venda";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Txb_nomecliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Txb_noemfunc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}
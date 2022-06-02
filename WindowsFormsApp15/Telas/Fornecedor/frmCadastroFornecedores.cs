﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp15.Telas
{
    public partial class frmCadastroFornecedores : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        public frmCadastroFornecedores()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            Business.FornecedorBusiness business = new Business.FornecedorBusiness();

            Model.tb_fornecedor model = new Model.tb_fornecedor();

        }

        private void btnEntrar_Click_1(object sender, EventArgs e)
        {

            try
            {

                Business.FornecedorBusiness business = new Business.FornecedorBusiness();

                Model.tb_fornecedor modelo = new Model.tb_fornecedor();

                //*Informações básicas*

                modelo.ds_celular = txtCelular.Text;
                modelo.ds_cnpj = txtCNPJ.Text;
                modelo.nm_empresa = txtEmpresa.Text;
                modelo.nm_fornecedor = txtNome.Text;
                modelo.ds_telefone = txtTelefone.Text;

                //*Endereço*

                modelo.ds_cep = txtCEP.Text;
                modelo.ds_cidade = txtCidade.Text;
                modelo.ds_complemento = txtComplemento.Text;
                modelo.ds_endereco = txtEndereco.Text;
                modelo.ds_UF = txtUF.Text;

                business.CadastrarFornecedor(modelo);

                MessageBox.Show("Cadastrado com sucesso");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void Move_Form(IntPtr Handle, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            Move_Form(Handle, e);
        }

        private void lblMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void lblSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

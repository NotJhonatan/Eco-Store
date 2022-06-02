﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp15.Model;

namespace WindowsFormsApp15.Telas.Folha_de_Pagamento
{
    public partial class frmConsultarFolha : Form
    {
        public frmConsultarFolha()
        {
            InitializeComponent();

            this.CarregarFuncionario();
        }

        private void CarregarFuncionario()
        {
            Business.FuncionarioBusiness business = new Business.FuncionarioBusiness();

            List<tb_funcionario> lista = business.ConsultarFuncionario();

            cboFuncionario.DisplayMember = nameof(tb_funcionario.nm_funcionario);
            cboFuncionario.DataSource = lista;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboFuncionario_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string func = cboFuncionario.Text;

                Business.FolhaDePagamentoBusiness business = new Business.FolhaDePagamentoBusiness();

                List<tb_folhapagamento> lista = business.ConsultarFolhaFunc(func);

                dgvConsultarFuncionario.AutoGenerateColumns = false;
                dgvConsultarFuncionario.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtpContrat_onValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime data = dtpContrat.Value.Date;

                Business.FolhaDePagamentoBusiness business = new Business.FolhaDePagamentoBusiness();

                List<tb_folhapagamento> lista = business.ConsultarFolhaData(data);

                dgvConsultarFuncionario.AutoGenerateColumns = false;
                dgvConsultarFuncionario.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

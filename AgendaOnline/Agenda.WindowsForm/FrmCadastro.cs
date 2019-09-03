using AgendaOnline.Dominio;
using AgendaOnline.Dominio.Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agenda.WindowsForm
{
    public partial class FrmCadastro : Form
    {
        //variaveis globais utilizam por padrao o underline
        private AcaoNaTela _acaoNaTela;


        public FrmCadastro(AcaoNaTela acaoNaTela, Cliente cliente)
        {
            _acaoNaTela = acaoNaTela;

            InitializeComponent();
            //utilizado para deixar o campo codigo somente como leitura e nao editavel
            txtCodigo.ReadOnly = true;
            txtCodigo.TabStop = false;

            if(acaoNaTela == AcaoNaTela.Consultar)
            {
                txtCodigo.ReadOnly = true;
                txtCodigo.TabStop = false;
                txtCodigo.Text = cliente.IDCLIENTE.ToString();

                txtNome.ReadOnly = true;
                txtNome.TabStop = false;
                txtNome.Text = cliente.NOME.ToString();

                txtSobrenome.ReadOnly = true;
                txtSobrenome.TabStop = false;
                txtSobrenome.Text = cliente.SOBRENOME.ToString();

                txtCpfCnpj.ReadOnly = true;
                txtCpfCnpj.TabStop = false;
                txtCpfCnpj.Text = cliente.CPF_CNPJ.ToString();

                txtConjuge.ReadOnly = true;
                txtConjuge.TabStop = false;
                txtConjuge.Text = cliente.CONJUGE.ToString();

                cmbTipo.Text = cliente.ID_TIPO.ToString();

                //usado para desativar o botao na hora de mostrar o formulario
                //ele aparece na tela mas nao é clicavel 
                btnSalvar.Enabled = false;

            }

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click_1(object sender, EventArgs e)
        {

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            ClienteNegocios clienteNegocios = new ClienteNegocios();
            Cliente cliente = new Cliente();

            cliente.NOME = txtNome.Text;
            cliente.SOBRENOME = txtSobrenome.Text;
            cliente.CPF_CNPJ = txtCpfCnpj.Text;
            cliente.CONJUGE = txtConjuge.Text;
            cliente.ID_TIPO = cmbTipo.SelectedIndex;

            var retorno = clienteNegocios.Salvar(cliente);
            try
            {
                int ID = Convert.ToInt32(retorno);
                MessageBox.Show("Cliente" + retorno + "inserido com sucesso!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Cliente não pode ser inserido", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private void CmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void CmbTipo_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
        
        private void FrmCadastro_load(object sender, EventArgs e)
        {
            TipoClienteNegocios tipoCliente = new TipoClienteNegocios();
            tipoCliente.ListarTodos();
            int tamanho = tipoCliente.tamanho;

            for(int i = 1; i <= tamanho; i++)
            {
                cmbTipo.Items.Add(tipoCliente.ListarTipoClientes(i).IDTIPO);
                cmbTipo.DisplayMember = tipoCliente.ListarTipoClientes(i).TIPO;
            }
            
            
        }

    }
}

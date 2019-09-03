using AgendaOnline.Dominio;
using AgendaOnline.Dominio.Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agenda.WindowsForm
{
    public partial class FrmConsultaCliente : Form
    {
        public FrmConsultaCliente()
        {
            InitializeComponent();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            ClienteNegocios clienteNegocios = new ClienteNegocios();
            Cliente cliente = new Cliente();

            cliente = clienteNegocios.ListarClienteNome(txtConsulta.Text);

            if(cliente == null)
            {
                MessageBox.Show("Cliente não localizado", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            FrmCadastro frm = new FrmCadastro(AcaoNaTela.Consultar, cliente);
            frm.ShowDialog();
        }
    }
}

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
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void SairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //metodo utilizado para abrir a tela de cadastro ao clicar no menu
        private void ClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //quando for inserir um cliente ele ainda nao existe, logo o paramentro é nulo
            FrmCadastro frm = new FrmCadastro(AcaoNaTela.inserir, null);
            frm.ShowDialog();
        }

        private void ConsultaClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConsultaCliente frm = new FrmConsultaCliente();
            frm.ShowDialog();
        }
    }
}

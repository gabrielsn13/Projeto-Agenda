using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaOnline.AcessoDados;
using AgendaOnline.AcessoDados.Interface;

namespace AgendaOnline.Dominio.Repositorios 
{
    public class TipoClienteRepositorio : Contexto, IRepositorio<TipoCliente>
    {
        public int tamanho;
        public TipoCliente BuscarId(int id)
        {
            throw new NotImplementedException();
        }

        public string Deletar(TipoCliente entidade)
        {
            throw new NotImplementedException();
        }

        public string Salvar(TipoCliente entidade)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TipoCliente> ListarTodos()
        {
            try
            {

                DataTable dtTipoCliente = new DataTable();
                IList<TipoCliente> tiposClientes = new List<TipoCliente>();
                dtTipoCliente = ExecutarConsulta(CommandType.StoredProcedure, "listarTipoClientes");
                foreach (DataRow linha in dtTipoCliente.Rows)
                {
                    TipoCliente tipoCliente = new TipoCliente();
                    tipoCliente.IDTIPO = Convert.ToInt32(linha["IDTIPO"]);
                    tipoCliente.TIPO = linha["TIPO"].ToString();
                    tiposClientes.Add(tipoCliente);
                }
                this.tamanho = tiposClientes.Count();
                return tiposClientes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public TipoCliente BuscarId(string cpf)
        {
            throw new NotImplementedException();
        }
    }
}

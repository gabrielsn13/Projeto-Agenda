using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaOnline.AcessoDados;
using AgendaOnline.AcessoDados.Interface;
using System.Data;

namespace AgendaOnline.Dominio.Repositorios
{
    public class TipoTelefoneRepositorio : Contexto, IRepositorio<TipoTelefone>
    {
        public int tamanho;
        public TipoTelefone BuscarId(int id)
        {
            throw new NotImplementedException();
        }

        public TipoTelefone BuscarId(string cpf)
        {
            throw new NotImplementedException();
        }

        public string Deletar(TipoTelefone entidade)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TipoTelefone> ListarTodos()
        {
            try
            {

                DataTable dtTipoTelefone = new DataTable();
                IList<TipoTelefone> tipoTelefones = new List<TipoTelefone>();
                dtTipoTelefone = ExecutarConsulta(CommandType.StoredProcedure, "listarTipoTelefones");
                foreach (DataRow linha in dtTipoTelefone.Rows)
                {
                    TipoTelefone tipoTelefone = new TipoTelefone();
                    tipoTelefone.IDTIPOTEL = Convert.ToInt32(linha["IDTIPOTEL"]);
                    tipoTelefone.TIPO = linha["TIPO"].ToString();
                    tipoTelefones.Add(tipoTelefone);
                }
                this.tamanho = tipoTelefones.Count();
                return tipoTelefones;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public string Salvar(TipoTelefone entidade)
        {
            throw new NotImplementedException();
        }
    }
}

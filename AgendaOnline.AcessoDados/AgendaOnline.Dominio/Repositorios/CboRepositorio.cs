using AgendaOnline.AcessoDados;
using AgendaOnline.AcessoDados.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaOnline.Dominio.Repositorios
{
    public class CboRepositorio : Contexto, IRepositorio<Cbo>
    {
        public int tamanho;
        public Cbo BuscarId(int id)
        {
            throw new NotImplementedException();
        }

        public Cbo BuscarId(string cpf)
        {
            throw new NotImplementedException();
        }

        public string Deletar(Cbo entidade)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cbo> ListarTodos()
        {
            try
            {

                DataTable dtCbo = new DataTable();
                IList<Cbo> cbos = new List<Cbo>();
                dtCbo = ExecutarConsulta(CommandType.StoredProcedure, "listarCbo");
                foreach (DataRow linha in dtCbo.Rows)
                {
                    Cbo cbo = new Cbo();
                    cbo.IDCBO = Convert.ToInt32(linha["IDCBO"]);
                    cbo.CBO = Convert.ToInt32(linha["CBO"]);
                    cbo.PROFISSAO = linha["PROFISSAO"].ToString();
                    cbo.ID_CLASSIFICACAO = Convert.ToInt32(linha["ID_CLASSIFICACAO"]);
                    cbos.Add(cbo);
                }
                this.tamanho = cbos.Count();
                return cbos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public string Salvar(Cbo entidade)
        {
            throw new NotImplementedException();
        }
    }
}

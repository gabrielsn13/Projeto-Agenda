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
    public class CidadeRepositorio : Contexto, IRepositorio<Cidade>
    {
        public int tamanho;

        public IEnumerable<Cidade> ListarTodos()
        {
            try
            {

                DataTable dtCidades = new DataTable();
                IList<Cidade> cidades = new List<Cidade>();
                dtCidades = ExecutarConsulta(CommandType.StoredProcedure, "listarCidades");
                foreach (DataRow linha in dtCidades.Rows)
                {
                    Cidade cidade = new Cidade();
                    cidade.IDCIDADE = Convert.ToInt32(linha["IDCIDADE"]);
                    cidade.CIDADE = linha["CIDADE"].ToString();
                    cidades.Add(cidade);
                }
                this.tamanho = cidades.Count();
                return cidades;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public string Salvar(Cidade entidade)
        {
            throw new NotImplementedException();
        }

        public string Deletar(Cidade entidade)
        {
            throw new NotImplementedException();
        }

        Cidade IRepositorio<Cidade>.BuscarId(int id)
        {
            throw new NotImplementedException();
        }

        public Cidade BuscarId(string cpf)
        {
            throw new NotImplementedException();
        }
    }
}

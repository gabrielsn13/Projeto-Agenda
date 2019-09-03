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
    public class StatusSalaRepositorio : Contexto, IRepositorio<StatusSala>
    {
        public int tamanho;

        public string Salvar(StatusSala entidade)
        {
            throw new NotImplementedException();
        }

        public string Deletar(StatusSala entidade)
        {
            throw new NotImplementedException();
        }

        StatusSala IRepositorio<StatusSala>.BuscarId(string cpf)
        {
            throw new NotImplementedException();
        }

        StatusSala IRepositorio<StatusSala>.BuscarId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StatusSala> ListarTodos()
        {
            try
            {

                DataTable dtStatusSala = new DataTable();
                IList<StatusSala> statusSalas = new List<StatusSala>();
                dtStatusSala = ExecutarConsulta(CommandType.StoredProcedure, "listarStatusSala");
                foreach (DataRow linha in dtStatusSala.Rows)
                {
                    StatusSala statusSala = new StatusSala();
                    statusSala.IDSTATUS = Convert.ToInt32(linha["IDSTATUS"]);
                    statusSala.STATUS = linha["STATUS"].ToString();
                    statusSalas.Add(statusSala);
                }
                this.tamanho = statusSalas.Count();
                return statusSalas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}


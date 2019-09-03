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
    public class AgendamentoRepositorio : Contexto, IRepositorio<Agendamento>
    {
        public Agendamento BuscarId(string cpf)
        {
            throw new NotImplementedException();
        }

        public Agendamento BuscarId(int id)
        {
            try
            {
                LimparParametro();
                AdicionarParametros("@ID", id);
                DataTable dtAgendamento = new DataTable();
                Agendamento agendamento = new Agendamento();
                dtAgendamento = ExecutarConsulta(CommandType.StoredProcedure, "buscarAgendamentoId");
                foreach (DataRow linha in dtAgendamento.Rows)
                {
                    agendamento.IDAGENDAMENTO = Convert.ToInt32(linha["IDAGENDAMENTO"]);
                    agendamento.TITULO = linha["TITULO"].ToString();
                    agendamento.ID_SALA = Convert.ToInt32(linha["ID_SALA"]);
                    agendamento.ID_CLIENTE = Convert.ToInt32(linha["ID_CLIENTE"]);
                    agendamento.DATA = Convert.ToDateTime(linha["DATA"]);
                    agendamento.OBSERVACOES = linha["OBSERVACOES"].ToString();

                }
                return agendamento;
            }
            catch (Exception EX)
            {
                throw new Exception(EX.Message);
            }
        }

        public string Deletar(Agendamento entidade)
        {
            try
            {
                LimparParametro();
                AdicionarParametros("IDAGENDAMENTO", entidade.IDAGENDAMENTO);
                string retorno = ExecutarComando(CommandType.StoredProcedure, "excluirAgendamento").ToString();
                return retorno;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public IEnumerable<Agendamento> ListarTodos()
        {
            try
            {
                LimparParametro();
                DataTable dtAgendamento = new DataTable();
                IList<Agendamento> agendamentos = new List<Agendamento>();
                dtAgendamento = ExecutarConsulta(CommandType.StoredProcedure, "listarAgendamento");
                foreach (DataRow linha in dtAgendamento.Rows)
                {
                    Agendamento agendamento = new Agendamento();
                    agendamento.IDAGENDAMENTO = Convert.ToInt32(linha["IDAGENDAMENTO"]);
                    agendamento.TITULO = linha["TITULO"].ToString();
                    agendamento.DATA = Convert.ToDateTime(linha["DATA"]);
                    agendamento.ID_SALA = Convert.ToInt32(linha["ID_SALA"]);
                    agendamento.ID_CLIENTE = Convert.ToInt32(linha["ID_CLIENTE"]);
                    agendamento.OBSERVACOES = linha["OBSERVACOES"].ToString();

                    agendamentos.Add(agendamento);
                }
                return agendamentos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string Salvar(Agendamento entidade)
        {
            string retorno = "";

            // se o IDCLIENTE for <=0  o cliente não existe no banco, logo podemos inserir
            if (entidade.IDAGENDAMENTO <= 0)
            {
                retorno = Inserir(entidade);
            }
            // se o IDCLIENTE for >0 o cliente ja existe e logo podemos realizar a alteracao no banco de dados
            if (entidade.IDAGENDAMENTO > 0)
            {
                retorno = Alterar(entidade);
            }

            return retorno;
        }

        public string Alterar(Agendamento entidade)
        {
            {
                try
                {
                    LimparParametro();
                    AdicionarParametros("IDAGENDAMENTO", entidade.IDAGENDAMENTO);
                    AdicionarParametros("TITULO", entidade.TITULO);
                    AdicionarParametros("ID_SALA", entidade.ID_SALA);
                    AdicionarParametros("ID_CLIENTE", entidade.ID_CLIENTE);
                    AdicionarParametros("DATA", entidade.DATA);
                    AdicionarParametros("OBSERVACOES", entidade.OBSERVACOES);
                    string retorno = ExecutarConsulta(CommandType.StoredProcedure, "alterarAgendamento").ToString();
                    return retorno;
                }
                catch (Exception EX)
                {
                    throw new Exception(EX.Message);
                }
            }
        }

        private string Inserir(Agendamento entidade)
        {
            try
            {
                LimparParametro();
                AdicionarParametros("@TITULO", entidade.TITULO);
                AdicionarParametros("@ID_SALA", entidade.ID_SALA);
                AdicionarParametros("@ID_CLIENTE", entidade.ID_CLIENTE);
                AdicionarParametros("@DATA", entidade.DATA);
                AdicionarParametros("@OBSERVACOES", entidade.OBSERVACOES);
                //como a procedure inserirCliente esta retornando um tipo string, iremos armazenar em uma variavel string 
                // chamada 'retorno'
                string retorno = ExecutarComando(CommandType.StoredProcedure, "inserirAgendamento").ToString();
                return retorno;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
        public IEnumerable<ListagemAgendamento> ListarAgendamentos()
        {
            try
            {
                LimparParametro();
                DataTable dtAgendamentos = new DataTable();
                IList<ListagemAgendamento> agendamentos = new List<ListagemAgendamento>();
                dtAgendamentos = ExecutarConsulta(CommandType.StoredProcedure, "listarAgendamentos");
                foreach (DataRow linha in dtAgendamentos.Rows)
                {
                    ListagemAgendamento agendamento = new ListagemAgendamento();
                    agendamento.CODIGO = Convert.ToInt32(linha["CODIGO"]);
                    agendamento.TITULO = linha["TITULO"].ToString();
                    agendamento.SALA = linha["SALA"].ToString();
                    agendamento.CLIENTE = linha["NOME"].ToString();
                    agendamento.DATA = Convert.ToDateTime(linha["DATA"]);
                    agendamento.OBSERVACOES = linha["OBSERVACOES"].ToString();

                    agendamentos.Add(agendamento);
                }
                return agendamentos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

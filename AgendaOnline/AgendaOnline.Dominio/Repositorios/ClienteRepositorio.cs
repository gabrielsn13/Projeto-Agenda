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
    public class ClienteRepositorio : Contexto, IRepositorio<Cliente>
    {
        public Cliente BuscarId(string cpf)
        {
            try
            {
                LimparParametro();
                AdicionarParametros("@CPF", cpf);
                DataTable dtCliente = new DataTable();
                Cliente cliente = new Cliente();
                dtCliente = ExecutarConsulta(CommandType.StoredProcedure, "buscarClienteCpf");
                foreach (DataRow linha in dtCliente.Rows)
                {
                    cliente.IDCLIENTE = Convert.ToInt32(linha["IDCLIENTE"]);
                    cliente.CPF_CNPJ = linha["CPF_CNPJ"].ToString();
                    cliente.NOME = linha["NOME"].ToString();
                    cliente.SOBRENOME = linha["SOBRENOME"].ToString();
                    cliente.CONJUGE = linha["CONJUGE"].ToString();
                    cliente.ID_TIPO = Convert.ToInt32(linha["ID_TIPO"]);
                    cliente.ID_CBO = Convert.ToInt32(linha["ID_CBO"]);
                    cliente.ID_CIDADE = Convert.ToInt32(linha["ID_CIDADE"]);
                }

                return cliente;
            }
            catch(Exception EX)
            {
                throw new Exception(EX.Message);
            }
        }

        private string Inserir(Cliente entidade)
        {
            try
            {
                LimparParametro();
                AdicionarParametros("@CPF_CNPJ", entidade.CPF_CNPJ);
                AdicionarParametros("@NOME", entidade.NOME);
                AdicionarParametros("@SOBRENOME", entidade.SOBRENOME);
                AdicionarParametros("@CONJUGE", entidade.CONJUGE);
                AdicionarParametros("@ID_TIPO", entidade.ID_TIPO);
                AdicionarParametros("@ID_CBO", entidade.ID_CBO);
                AdicionarParametros("@ID_CIDADE", entidade.ID_CIDADE);
                //como a procedure inserirCliente esta retornando um tipo string, iremos armazenar em uma variavel string 
                // chamada 'retorno'
                string retorno = ExecutarComando(CommandType.StoredProcedure, "inserirCliente").ToString();
                return retorno;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public string Alterar(Cliente entidade)
        {
            {
                try
                {
                    LimparParametro();
                    AdicionarParametros("IDCLIENTE", entidade.IDCLIENTE);
                    AdicionarParametros("CPF_CNPJ", entidade.CPF_CNPJ);
                    AdicionarParametros("NOME", entidade.NOME);
                    AdicionarParametros("SOBRENOME", entidade.SOBRENOME);
                    AdicionarParametros("CONJUGE", entidade.CONJUGE);
                    AdicionarParametros("ID_TIPO", entidade.ID_TIPO);
                    AdicionarParametros("ID_CBO", entidade.ID_CBO);
                    AdicionarParametros("ID_CIDADE", entidade.ID_CIDADE);
                    string retorno = ExecutarConsulta(CommandType.StoredProcedure, "alterarCliente").ToString();
                    return retorno;
                }
                catch (Exception EX)
                {
                    throw new Exception(EX.Message);
                }
            }
        }

        public string Deletar(Cliente entidade)
        {
            try
            {
                LimparParametro();
                AdicionarParametros("IDCLIENTE", entidade.IDCLIENTE);
                string retorno = ExecutarComando(CommandType.StoredProcedure, "excluirCliente").ToString();
                return retorno;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }

        public IEnumerable<Cliente> ListarTodos()
         {
              try
              {
                  LimparParametro();
                  DataTable dtCliente = new DataTable();
                  IList<Cliente> clientes = new List<Cliente>();
                  dtCliente = ExecutarConsulta(CommandType.StoredProcedure, "listarClientes");
                  foreach (DataRow linha in dtCliente.Rows)
                  {
                      Cliente cliente = new Cliente();
                      cliente.IDCLIENTE = Convert.ToInt32(linha["IDCLIENTE"]);
                      cliente.CPF_CNPJ = linha["CPF_CNPJ"].ToString();
                      cliente.NOME = linha["NOME"].ToString();
                      cliente.SOBRENOME = linha["SOBRENOME"].ToString();
                      cliente.CONJUGE = linha["CONJUGE"].ToString();
                      cliente.ID_TIPO = Convert.ToInt32(linha["ID_TIPO"]);
                      cliente.ID_CBO = Convert.ToInt32(linha["ID_CBO"]);
                      cliente.ID_CIDADE = Convert.ToInt32(linha["ID_CIDADE"]);

                    clientes.Add(cliente);
                  }
                  return clientes;
              }
              catch (Exception ex)
              {
                  throw new Exception(ex.Message);
              }

         }
          
        public string Salvar(Cliente entidade)
        {
            string retorno = "";

            // se o IDCLIENTE for <=0  o cliente não existe no banco, logo podemos inserir
            if (entidade.IDCLIENTE <= 0)
            {
                retorno = Inserir(entidade);
            }
            // se o IDCLIENTE for >0 o cliente ja existe e logo podemos realizar a alteracao no banco de dados
            if (entidade.IDCLIENTE > 0)
            {
                retorno = Alterar(entidade);
            }

            return retorno;
        }

        public Cliente BuscarId(int id)
        {
            try
            {
                LimparParametro();
                AdicionarParametros("@ID", id);
                DataTable dtCliente = new DataTable();
                Cliente cliente = new Cliente();
                dtCliente = ExecutarConsulta(CommandType.StoredProcedure, "buscarClienteId");
                foreach (DataRow linha in dtCliente.Rows)
                {
                    cliente.IDCLIENTE = Convert.ToInt32(linha["IDCLIENTE"]);
                    cliente.CPF_CNPJ = linha["CPF_CNPJ"].ToString();
                    cliente.NOME = linha["NOME"].ToString();
                    cliente.SOBRENOME = linha["SOBRENOME"].ToString();
                    cliente.CONJUGE = linha["CONJUGE"].ToString();
                    cliente.ID_TIPO = Convert.ToInt32(linha["ID_TIPO"]);
                    cliente.ID_CBO = Convert.ToInt32(linha["ID_CBO"]);
                    cliente.ID_CIDADE = Convert.ToInt32(linha["ID_CIDADE"]);
                }

                return cliente;
            }
            catch (Exception EX)
            {
                throw new Exception(EX.Message);
            }

        }
    
        public string BuscarCpf(string cpf)
        {
            try
            {
                LimparParametro();
                AdicionarParametros("@CPF", cpf);
                DataTable dtCliente = new DataTable();
                Cliente cliente = new Cliente();
                dtCliente = ExecutarConsulta(CommandType.StoredProcedure, "buscarClienteCpf");
                foreach (DataRow linha in dtCliente.Rows)
                {
                    cliente.IDCLIENTE = Convert.ToInt32(linha["IDCLIENTE"]);
                    cliente.CPF_CNPJ = linha["CPF_CNPJ"].ToString();
                    cliente.NOME = linha["NOME"].ToString();
                    cliente.SOBRENOME = linha["SOBRENOME"].ToString();
                    cliente.CONJUGE = linha["CONJUGE"].ToString();
                    cliente.ID_TIPO = Convert.ToInt32(linha["ID_TIPO"]);
                    cliente.ID_CBO = Convert.ToInt32(linha["ID_CBO  "]);
                    cliente.ID_CIDADE = Convert.ToInt32(linha["ID_CIDADE"]);
                }

                return cliente.CPF_CNPJ;
            }
            catch (Exception EX)
            {
                throw new Exception(EX.Message);
            }

        }

        public int BuscarAgendamento(int idCliente)
        {
            try
            {
                LimparParametro();
                AdicionarParametros("@IDCLIENTE", idCliente);
                DataTable dtAgendamento = new DataTable();
                Agendamento agendamento = new Agendamento();
                 dtAgendamento = ExecutarConsulta(CommandType.StoredProcedure, "buscarAgendamento");
                int contagem = Convert.ToInt32(dtAgendamento.Rows[0]["CONTAGEM_AGENDAMENTO"]);

                return contagem;
            }
            catch (Exception EX)
            {
                throw new Exception(EX.Message);
            }

        }


    }
}

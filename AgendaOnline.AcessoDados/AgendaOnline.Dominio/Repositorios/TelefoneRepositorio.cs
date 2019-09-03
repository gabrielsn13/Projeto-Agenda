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
    public class TelefoneRepositorio : Contexto, IRepositorio<Telefone>
    {
        public int tamanho;
        public Telefone BuscarId(int id)
        {
            throw new NotImplementedException();
        }

        public string Deletar(Telefone entidade)
        {
            try
            {
                LimparParametro();
                AdicionarParametros("ID_CLIENTE", entidade.ID_CLIENTE);
                string retorno = ExecutarComando(CommandType.StoredProcedure, "excluirTelefone").ToString();
                return retorno;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public IEnumerable<Telefone> ListarTodos()
        {
            try
            {

                DataTable dtTelefones = new DataTable();
                IList<Telefone> Telefones = new List<Telefone>();
                dtTelefones = ExecutarConsulta(CommandType.StoredProcedure, "listarTelefones");
                foreach (DataRow linha in dtTelefones.Rows)
                {
                    Telefone telefone = new Telefone();
                    telefone.IDTELEFONE = Convert.ToInt32(linha["IDTELEFONE"]);
                    telefone.DDD = linha["DDD"].ToString();
                    telefone.TELEFONE = linha["TELEFONE"].ToString();
                    telefone.ID_TIPOTEL = Convert.ToInt32(linha["ID_TIPOTEL"]);
                    telefone.ID_CLIENTE = Convert.ToInt32(linha["ID_CLIENTE"]);
                    Telefones.Add(telefone);
                }
                this.tamanho = Telefones.Count();
                return Telefones;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string Salvar(Telefone entidade)
        {
            string retorno = "";

            // se o IDCLIENTE for <=0  o cliente não existe no banco, logo podemos inserir
            if (entidade.IDTELEFONE <= 0)
            {
                retorno = Inserir(entidade);
            }
            // se o IDCLIENTE for >0 o cliente ja existe e logo podemos realizar a alteracao no banco de dados
            if (entidade.IDTELEFONE > 0)
            {
                retorno = Alterar(entidade);
            }

            return retorno;
        }

        private string Inserir(Telefone entidade)
        {
            try
            {
                LimparParametro();
                AdicionarParametros("@DDD", entidade.DDD);
                AdicionarParametros("@TELEFONE", entidade.TELEFONE);
                AdicionarParametros("@ID_TIPOTEL", entidade.ID_TIPOTEL);
                AdicionarParametros("@ID_CLIENTE", entidade.ID_CLIENTE);
                //como a procedure inserirCliente esta retornando um tipo string, iremos armazenar em uma variavel string 
                // chamada 'retorno'
                string retorno = ExecutarComando(CommandType.StoredProcedure, "inserirTelefone").ToString();
                return retorno;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }


        }

        public string Alterar(Telefone entidade)
        {
            {
                try
                {
                    LimparParametro();
                    AdicionarParametros("IDTELEFONE", entidade.IDTELEFONE);
                    AdicionarParametros("DDD", entidade.DDD);
                    AdicionarParametros("TELEFONE", entidade.TELEFONE);
                    AdicionarParametros("ID_TIPOTEL", entidade.ID_TIPOTEL);
                    AdicionarParametros("ID_CLIENTE", entidade.ID_CLIENTE);
                    string retorno = ExecutarConsulta(CommandType.StoredProcedure, "alterarTelefone").ToString();
                    return retorno;
                }
                catch (Exception EX)
                {
                    throw new Exception(EX.Message);
                }
            }
        }
        public Telefone BuscarIdTelefone(int id)
        {
            try
            {
                LimparParametro();
                AdicionarParametros("@ID_CLIENTE", id);
                DataTable dtTelefone = new DataTable();
                Telefone telefone = new Telefone();
                dtTelefone = ExecutarConsulta(CommandType.StoredProcedure, "buscarIdTelefone");
                foreach (DataRow linha in dtTelefone.Rows)
                {
                    telefone.IDTELEFONE = Convert.ToInt32(linha["IDTELEFONE"]);
                    telefone.DDD = linha["DDD"].ToString();
                    telefone.TELEFONE = linha["TELEFONE"].ToString();
                    telefone.ID_TIPOTEL = Convert.ToInt32(linha["ID_TIPOTEL"]);
                    telefone.ID_CLIENTE = Convert.ToInt32(linha["ID_CLIENTE"]);
                }

                return telefone;
            }
            catch (Exception EX)
            {
                throw new Exception(EX.Message);
            }
        }
        public Telefone BuscarId(string cpf)
        {
            throw new NotImplementedException();
        }
    }
}

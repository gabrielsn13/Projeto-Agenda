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
    public class SalaRepositorio : Contexto, IRepositorio<Sala>
    {
        public Sala BuscarId(string cpf)
        {
            throw new NotImplementedException();
        }

        public ListagemSala BuscarIdLista(int id)
        {
            try
            {
                LimparParametro();
                AdicionarParametros("@IDSALA", id);
                DataTable dtSala = new DataTable();
                ListagemSala sala = new ListagemSala();
                dtSala = ExecutarConsulta(CommandType.StoredProcedure, "listarSalasId");
                foreach (DataRow linha in dtSala.Rows)
                {
                    sala.IDSALA = Convert.ToInt32(linha["IDSALA"]);
                    sala.SALA = linha["SALA"].ToString();
                    sala.STATUS = linha["STATUS"].ToString();
                }

                return sala;
            }
            catch (Exception EX)
            {
                throw new Exception(EX.Message);
            }
        }

        public string Deletar(Sala entidade)
        {
            try
            {
                LimparParametro();
                AdicionarParametros("IDSALA", entidade.IDSALA);
                string retorno = ExecutarComando(CommandType.StoredProcedure, "excluirSala").ToString();
                return retorno;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        private string Inserir(Sala entidade)
        {
            try
            {
                LimparParametro();
                AdicionarParametros("@SALA", entidade.SALA);
                AdicionarParametros("@ID_STATUS", entidade.ID_STATUS);
                //como a procedure inserirCliente esta retornando um tipo string, iremos armazenar em uma variavel string 
                // chamada 'retorno'
                string retorno = ExecutarComando(CommandType.StoredProcedure, "inserirSala").ToString();
                return retorno;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }


        }
        public string Salvar(Sala entidade)
        {
            string retorno = "";

            // se o IDCLIENTE for <=0  a sala não existe no banco, logo podemos inserir
            if (entidade.IDSALA <= 0)
            {
                retorno = Inserir(entidade);
            }
            // se o IDCLIENTE for >0 a sala ja existe e logo podemos realizar a alteracao no banco de dados
            if (entidade.IDSALA > 0)
            {
                retorno = Alterar(entidade);
            }

            return retorno;
        }

        public string Alterar(Sala entidade)
        {
            {
                try
                {
                    LimparParametro();
                    AdicionarParametros("IDSALA", entidade.IDSALA);
                    AdicionarParametros("SALA", entidade.SALA);
                    AdicionarParametros("ID_STATUS", entidade.ID_STATUS);
                    string retorno = ExecutarConsulta(CommandType.StoredProcedure, "alterarSala").ToString();
                    return retorno;
                }
                catch (Exception EX)
                {
                    throw new Exception(EX.Message);
                }
            }
        }

        public IEnumerable<ListagemSala> ListarSalas()
        {
            try
            {
                LimparParametro();
                DataTable dtSala = new DataTable();
                IList<ListagemSala> salas = new List<ListagemSala>();
                dtSala = ExecutarConsulta(CommandType.StoredProcedure, "listarSalasStatus");
                foreach (DataRow linha in dtSala.Rows)
                {
                    ListagemSala sala = new ListagemSala();
                    sala.IDSALA = Convert.ToInt32(linha["IDSALA"]);
                    sala.SALA = linha["SALA"].ToString();
                    sala.STATUS = linha["STATUS"].ToString();

                    salas.Add(sala);
                }
                return salas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        IEnumerable<Sala> IRepositorio<Sala>.ListarTodos()
        {
            throw new NotImplementedException();
        }

        public Sala BuscarId(int id)
        {
            {
                try
                {
                    LimparParametro();
                    AdicionarParametros("@IDSALA", id);
                    DataTable dtSala = new DataTable();
                    Sala sala = new Sala();
                    dtSala = ExecutarConsulta(CommandType.StoredProcedure, "BuscarSalaId");
                    foreach (DataRow linha in dtSala.Rows)
                    {
                        sala.IDSALA = Convert.ToInt32(linha["IDSALA"]);
                        sala.SALA = linha["SALA"].ToString();
                        sala.ID_STATUS = Convert.ToInt32(linha["ID_STATUS"]);
                    }
                    return sala;
                }
                catch (Exception EX)
                {
                    throw new Exception(EX.Message);
                }
            }
        }
    }
}

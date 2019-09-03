using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;

namespace AgendaOnline.AcessoDados
{
    public class Contexto
    {
        private SqlConnection conexao;

        private SqlConnection CriarConexao()
        {
            //cria a comunicação com o banco
            //a biblioteca System.Data foi usada para criar o objeto de conexao
            //a biblioteca System.Configuration foi usada para utilizar o metodo connection string e conectar ao banco de dados
            //o nome da string de conexao tem que ser exatamente o mesmo que o do arquivo XML app.config
            conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["strConexao"].ConnectionString);
            return conexao;
        }

        private SqlParameterCollection sqlParameterCollection = new SqlCommand().Parameters;
        
        private SqlCommand CriarComando(CommandType cmdType, string nomeProcedure)
        {
            //necessario criar um objeto de conexao com o banco antes de criar o comando
            conexao = CriarConexao();
            conexao.Open();
            // cria o objeto de comando 
            SqlCommand cmd = conexao.CreateCommand();
            //passa o tipo de comando para o objeto comando
            cmd.CommandType = cmdType;
            // passa o nome da procedure para o objeto de comando;
            cmd.CommandText = nomeProcedure;
            //se dentro de 7200ms ele fexa a conexão com o banco automaticamente 
            cmd.CommandTimeout = 7200;

            foreach(SqlParameter sqlParameter in sqlParameterCollection)
            {
                cmd.Parameters.Add(new SqlParameter(sqlParameter.ParameterName, sqlParameter.Value));
            }

            return cmd;
        }

        protected void AdicionarParametros(string nomeParametro, object valorParametro) {

            sqlParameterCollection.AddWithValue(nomeParametro, valorParametro);
        }

        protected void LimparParametro()
        {
            sqlParameterCollection.Clear();
        }
        // metodo que executa a persistencia no banco de dados (insert, alter, delete..)
        protected object ExecutarComando(CommandType cmdType, string nomeProcedure)
        {
            try
            {
                SqlCommand cmd = CriarComando(cmdType , nomeProcedure);

                //metodo utilizado para efetuar os comandos insert, alter, delete... no banco de dados
                return cmd.ExecuteScalar();
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        // metodo que executa a consulta no banco de dados (select)
        protected DataTable ExecutarConsulta(CommandType cmdType, String nomeProcedure)
        {
            try
            {
                SqlCommand cmd = CriarComando(cmdType, nomeProcedure);
                DataTable dt = new DataTable();
                //objeto usado para popular o datatable
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                //metodo utilizado para popular a grid
                sqlDataAdapter.Fill(dt);

                return dt;
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}

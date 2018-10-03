using ExemploBD.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ExercicioBD.Models.DAO
{
    public class OS_ServicoDAO
    {
        private ConexaoBD conn;
        public OS_ServicoDAO()
        {
            conn = new ConexaoBD();
        }


        public bool Inserir(OS_Servico os_servico)
        {
            try
            {
                string sql = "INSERT INTO os_servico(servico_id_servico,ordem_de_servico_numero, quantidade, valor, prazo) " +
                    "VALUES (@servico_id_servico,@ordem_de_servico_numero,@quantidade,@valor,@prazo)";
                conn.Comando.CommandText = sql;
                conn.Comando.Parameters.AddWithValue("@servico_id_servico", os_servico.servico.Codigo);
                conn.Comando.Parameters.AddWithValue("@ordem_de_servico_numero", os_servico.ordemServico.Numero);
                conn.Comando.Parameters.AddWithValue("@quantidade", os_servico.Quantidade);
                conn.Comando.Parameters.AddWithValue("@valor", os_servico.Valor);
                conn.Comando.Parameters.AddWithValue("@prazo", os_servico.Prazo);

                int retorno = conn.Comando.ExecuteNonQuery();
                if (retorno > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                conn.Conexao.Close();
            }
        }

        public DataTable ListarTodos()
        {
            try
            {
                DataTable table = new DataTable();
                MySqlDataAdapter sqlData;
                sqlData = new MySqlDataAdapter("SELECT * FROM os_servico", conn.Conexao);
                sqlData.Fill(table);

                return table;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                conn.Conexao.Close();
            }

        }
    }
}


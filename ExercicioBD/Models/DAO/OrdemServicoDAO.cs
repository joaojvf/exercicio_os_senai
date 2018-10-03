using ExemploBD.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ExercicioBD.Models.DAO
{
    public class OrdemServicoDAO
    {
        private ConexaoBD conn;
        public OrdemServicoDAO()
        {
            conn = new ConexaoBD();
        }

        public DataTable ListarTodos()
        {
            try
            {
                DataTable table = new DataTable();
                MySqlDataAdapter sqlData;
                sqlData = new MySqlDataAdapter("SELECT * FROM ordem_de_servico", conn.Conexao);
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

        public OrdemServico BuscarPorNumero(int numero)
        {
            try
            {
                string comando = "SELECT * from ordem_de_servico WHERE numero= @numero";
                conn.Comando.CommandText = comando;
                conn.Comando.Parameters.AddWithValue("@numero", numero);

                MySqlDataReader reader = conn.Comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();

                    return new OrdemServico()
                    {
                        Numero = Convert.ToInt32(reader["numero"]),
                        DataSolicitacao = reader["data_solicitacao"].ToString(),
                        PrazoEntrega = Convert.ToInt32(reader["prazo_entrega"]),
                        Total = Convert.ToDouble(reader["total"]),
                        Status = reader["status"].ToString()
                    };
                }
                else
                    return null;
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

        public OrdemServico Inserir(OrdemServico os)
        {
            try
            {
                string sql = "INSERT INTO ordem_de_servico(data_solicitacao,prazo_entrega,total,status,cliente_id) " +
                    "VALUES (@data_solicitacao,@prazo_entrega,@total,@status,@cliente_id)";
                conn.Comando.CommandText = sql;
                conn.Comando.Parameters.AddWithValue("@data_solicitacao", os.DataSolicitacao);
                conn.Comando.Parameters.AddWithValue("@prazo_entrega", os.PrazoEntrega);
                conn.Comando.Parameters.AddWithValue("@total", os.Total);
                conn.Comando.Parameters.AddWithValue("@status", os.Status);
                conn.Comando.Parameters.AddWithValue("@cliente_id", os.Cliente.Id);

                int retorno = conn.Comando.ExecuteNonQuery();
                if (retorno > 0)
                {
                    os.Numero = Convert.ToInt32(conn.Comando.LastInsertedId.ToString());
                    return os;
                }
                else
                {
                    return null;
                }
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

        public OrdemServico Alterar(OrdemServico os)
        {
            try
            {
                string sql = "UPDATE ordem_de_servico SET data_solicitacao=@data_solicitacao,prazo_entrega=@prazo_entrega," +
                    "total=@total,status=@status,cliente_id=@cliente_id WHERE numero = @numero";
                conn.Comando.CommandText = sql;
                conn.Comando.Parameters.AddWithValue("@data_solicitacao", os.DataSolicitacao);
                conn.Comando.Parameters.AddWithValue("@prazo_entrega", os.PrazoEntrega);
                conn.Comando.Parameters.AddWithValue("@total", os.Total);
                conn.Comando.Parameters.AddWithValue("@status", os.Status);
                conn.Comando.Parameters.AddWithValue("@numero", os.Numero);
                int retorno = conn.Comando.ExecuteNonQuery();
                return retorno > 0 ? os : null;
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

        public bool Deletar(OrdemServico os)
        {
            try
            {
                conn = new ConexaoBD();
                conn.Comando.CommandText = "DELETE FROM ordem_de_servico WHERE numero = @numero;";
                conn.Comando.Parameters.AddWithValue("@numero", os.Numero);
                int retorno = conn.Comando.ExecuteNonQuery();
                return retorno > 0 ? true : false;
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
    }
}
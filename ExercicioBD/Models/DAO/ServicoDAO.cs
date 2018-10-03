using ExemploBD.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ExercicioBD.Models.DAO
{
    public class ServicoDAO
    {
        private ConexaoBD conn;
        public ServicoDAO()
        {
            conn = new ConexaoBD();
        }

        public DataTable ListarCarrinho(OrdemServico os)
        {
            try
            {
                DataTable table = new DataTable();
                MySqlDataAdapter sqlData;
                sqlData = new MySqlDataAdapter("SELECT id_os_servico, servico.cod_servico, servico.nome, servico.valor, servico.tempo_medio, quantidade FROM os_servico, servico" +
                                                                                            "WHERE servico.cod_servico = os_servico.servico_id_servico AND " +
                                                                                                    "os_servico.ordem_de_servico_numero=" + os.Numero, conn.Conexao);
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

        public DataTable ListarTodos()
        {
            try
            {
                DataTable table = new DataTable();
                MySqlDataAdapter sqlData;
                sqlData = new MySqlDataAdapter("SELECT * FROM servico", conn.Conexao);
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

        public Servico BuscarPorNumero(int codigo)
        {
            try
            {
                string comando = "SELECT * from servico WHERE cod_servico= @cod_servico";
                conn.Comando.CommandText = comando;
                conn.Comando.Parameters.AddWithValue("@cod_servico", codigo);

                MySqlDataReader reader = conn.Comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();

                    return new Servico()
                    {
                        Codigo = Convert.ToInt32(reader["cod_servico"]),
                        Nome = reader["nome"].ToString(),
                        Valor = Convert.ToDouble(reader["valor"]),
                        TempoMedio = Convert.ToInt32(reader["tempo_medio"])
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
    }
}
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ExemploBD.Models.DAO
{
    public class EnderecoDAO
    {
        private ConexaoBD conn;
        public EnderecoDAO()
        {
            conn = new ConexaoBD();
        }

        public DataTable ListarTodos()
        {
            try
            {
                DataTable table = new DataTable();
                MySqlDataAdapter sqlData = new MySqlDataAdapter("SELECT * FROM endereco", conn.Conexao);
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

        public Endereco BuscarPorCod(int cod)
        {
            try
            {
                ClienteDAO cDao = new ClienteDAO();

                string comando = "SELECT * from endereco WHERE cod= @cod";
                conn.Comando.CommandText = comando;
                conn.Comando.Parameters.AddWithValue("@cod", cod);

                MySqlDataReader reader = conn.Comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    return new Endereco()
                    {
                        Cod = Convert.ToInt32(reader["cod"].ToString()),
                        Rua = reader["rua"].ToString(),
                        Bairro = reader["bairro"].ToString(),
                        CEP = reader["cep"].ToString(),
                        Complemento = reader["complemento"].ToString(),
                        Numero = Convert.ToInt32(reader["numero"].ToString()),
                        Cliente = cDao.BuscarPorId(Convert.ToInt32(reader["cliente_id"]))
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


        public Endereco BuscarPorCliente(int id)
        {
            try
            {
                ClienteDAO cDao = new ClienteDAO();

                string comando = "SELECT * from endereco WHERE cliente_id= @cliente_id";
                conn.Comando.CommandText = comando;
                conn.Comando.Parameters.AddWithValue("@cliente_id", id);

                MySqlDataReader reader = conn.Comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    return new Endereco()
                    {
                        Cod = Convert.ToInt32(reader["cod"].ToString()),
                        Rua = reader["rua"].ToString(),
                        Bairro = reader["bairro"].ToString(),
                        CEP = reader["cep"].ToString(),
                        Complemento = reader["complemento"].ToString(),
                        Numero = Convert.ToInt32(reader["numero"].ToString()),
                        Cliente = cDao.BuscarPorId(Convert.ToInt32(reader["cliente_id"].ToString()))
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

        public Endereco Inserir(Endereco end)
        {
            try
            {

                string sql = "INSERT INTO endereco(rua,bairro,cep,complemento,numero,cliente_id) " +
                    "VALUES (@rua,@bairro,@cep,@complemento,@numero,@cliente_id)";
                conn.Comando.CommandText = sql;
                conn.Comando.Parameters.AddWithValue("@rua", end.Rua);
                conn.Comando.Parameters.AddWithValue("@bairro", end.Bairro);
                conn.Comando.Parameters.AddWithValue("@cep", end.CEP);
                conn.Comando.Parameters.AddWithValue("@complemento", end.Complemento);
                conn.Comando.Parameters.AddWithValue("@numero", end.Numero);
                conn.Comando.Parameters.AddWithValue("@cliente_id", end.Cliente.Id);

                if (conn.Comando.ExecuteNonQuery() > 0)
                {
                    end.Cod = Convert.ToInt32(conn.Comando.LastInsertedId.ToString());
                    return end;
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


        public Endereco Alterar(Endereco endereco)
        {
            try
            {
                string sql = "UPDATE endereco SET rua=@rua,bairro=@bairro,cep=@cep,complemento=@complemento,numero=@numero WHERE cod=@id";
                conn.Comando.CommandText = sql;
                conn.Comando.Parameters.AddWithValue("@rua", endereco.Rua);
                conn.Comando.Parameters.AddWithValue("@bairro", endereco.Bairro);
                conn.Comando.Parameters.AddWithValue("@cep", endereco.CEP);
                conn.Comando.Parameters.AddWithValue("@complemento", endereco.Complemento);
                conn.Comando.Parameters.AddWithValue("@numero", endereco.Numero);
                conn.Comando.Parameters.AddWithValue("@id", endereco.Cod);
                int retorno = conn.Comando.ExecuteNonQuery();
                return retorno > 0 ? endereco : null;
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

        public bool Deletar(int cod)
        {
            try
            {
                conn.Comando.CommandText = "DELETE FROM endereco WHERE cod= @id;";
                conn.Comando.Parameters.AddWithValue("@id", cod);
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
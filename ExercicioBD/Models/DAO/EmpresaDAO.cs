using ExemploBD.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ExercicioBD.Models.DAO
{
    public class EmpresaDAO
    {
        private ConexaoBD conn;
        public EmpresaDAO()
        {
            conn = new ConexaoBD();
        }

        public Empresa Inserir(Empresa e)
        {
            try
            {
                string sql = "INSERT INTO empresa(razao_social, cnpj, email, senha) VALUES (@razao_social,@cnpj,@email, @senha)";
                conn.Comando.CommandText = sql;
                conn.Comando.Parameters.AddWithValue("@razao_social", e.RazaoSocial);
                conn.Comando.Parameters.AddWithValue("@cnpj", e.RazaoSocial);
                conn.Comando.Parameters.AddWithValue("@email", e.Email);
                conn.Comando.Parameters.AddWithValue("@senha", e.Senha);                

                int retorno = conn.Comando.ExecuteNonQuery();
                if (retorno > 0)
                {
                    return e;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception exp)
            {
                return null;
            }
            finally
            {
                conn.Conexao.Close();
            }
        }

        public Empresa ValidarLogin(string email, string senha)
        {
            try
            {
                string comando = "SELECT * from empresa WHERE email= @email AND " +
                    "senha = @senha";
                conn.Comando.CommandText = comando;
                conn.Comando.Parameters.AddWithValue("@email", email);
                conn.Comando.Parameters.AddWithValue("@senha", senha);

                MySqlDataReader reader = conn.Comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    Empresa e = new Empresa()
                    {
                        RazaoSocial = reader["razao_social"].ToString(),
                        Cnpj = reader["cnpj"].ToString(),
                        Senha = reader["senha"].ToString(),
                        Email = reader["email"].ToString()

                    };
                    return e;
                }
                else
                    return null;
            }
            catch (Exception ex)
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
    }
}
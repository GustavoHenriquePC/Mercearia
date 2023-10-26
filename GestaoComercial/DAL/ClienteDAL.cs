

using Models;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace DAL
{
    public class ClienteDAL
    {
        public void Inserir(Cliente _cliente)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"INSERT INTO Produto(Nome, Telefone)
                 VALUES(@Nome, @Telefone)";

                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.AddWithValue("@Nome", _cliente.Nome);
                cmd.Parameters.AddWithValue("@Telefone", _cliente.Telefone);
 
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Ocorreu um erro ao tentar inserir um Usuário no Banco de Dados", ex);
            }
            finally
            {
                cn.Close();

            }
        }
        public void Alterar(Cliente _cliente)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"UPDATE Cliente 
                                  SET Nome = @Nome, Telefone = @Telefone
                                  WHERE Id = @Id";

                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.AddWithValue("@Id", _cliente.Id);
                cmd.Parameters.AddWithValue("@Nome", _cliente.Nome);
                cmd.Parameters.AddWithValue("@Telefone", _cliente.Telefone);

                cn.Open();
                cmd.ExecuteNonQuery();

            }

            catch (Exception ex)
            {

                throw new Exception("Ocorreu um erro ao tentar inserir um Usuário no Banco de Dados", ex);
            }
            finally
            {
                cn.Close();

            }
        }
        public void Excluir(int _id)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"DELETE FROM Cliente
                                  WHERE Id = @Id";

                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.AddWithValue("@Id", _id);

                cn.Open();
                cmd.ExecuteNonQuery();

            }

            catch (Exception ex)
            {

                throw new Exception("Ocorreu um erro ao tentar inserir um Usuário no Banco de Dados", ex);
            }
            finally
            {
                cn.Close();

            }
        }
        public List<Cliente> BuscarTodos()
        {
            List<Cliente> clienteList = new List<Cliente>();
            Cliente cliente;

            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);

            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"SELECT FROM Id, Nome, Telefone FROM CLIENTE";

                cmd.CommandType = System.Data.CommandType.Text;

                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        cliente = PreencherObjeto(rd);
                        clienteList.Add(cliente);
                    }
                }
                return clienteList;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar Buscar o Usuário no Banco de Dados",ex);
            }
            finally
            {
                cn.Close();
            }     
        }

        private static Cliente PreencherObjeto(SqlDataReader rd)
        {
            Cliente cliente = new Cliente();
            cliente.Id = (int)rd["Id"];
            cliente.Nome = rd["Nome"].ToString();
            cliente.Telefone = rd["Telefone"].ToString();
            
            return cliente;
        }

        public Cliente BuscarPorId(int _id)
        {
            Cliente cliente;

            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);

            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"SELECT Id, Nome, Telefone FROM Cliente WHERE Id = @Id";
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.AddWithValue(@"Id", _id);

                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    cliente = new Cliente();
                    if (rd.Read())
                    {
                        cliente = new Cliente();
                        cliente.Id = (int)rd["Id"];
                        cliente.Nome = rd["Nome"].ToString();
                        cliente.Telefone = rd["Telefone"].ToString();
                    }
                }
                return cliente;
            }
            catch (Exception ex)
            {

                throw new Exception("Ocorreu um erro ao tentar Buscar o Usuário no Banco de Dados");
            }
            finally
            {
                cn.Close();
            }
        }
        public List<Cliente> BuscarPorNome(string _nome)
        {
            List<Cliente> clienteLista = new List<Cliente>();
            Cliente cliente;
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);

            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"SELECT Id, Nome, Telefone
                                    FROM CLIENTE
                                    WHERE Nome LIKE @Nome";

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue(@"Nome", "%" + _nome + "%");

                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        cliente = new Cliente();
                        cliente.Id = (int)rd["Id"];
                        cliente.Nome = rd["Nome"].ToString();
                        cliente.Telefone = rd["Telefone"].ToString();
                        clienteLista.Add(cliente);
                    }
                }

                return clienteLista;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar buscar um cliente por nome no banco de dados.", ex);
            }
            finally
            {
                cn.Close();
            }
        }
        public Cliente BuscarPorNomeUsuario(string _nomeCliente)
        {
            Cliente cliente;

            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);

            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"SELECT  Id, Nome, Telefone
                                    FROM CLIENTE
                                    WHERE NomeCliente = @NomeCliente";
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.AddWithValue("@NomeCliente", _nomeCliente);


                cn.Open();

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    cliente = new Cliente();
                    while (rd.Read())
                    {
                        cliente.Id = (int)rd["Id"];
                        cliente.Nome = rd["Nome"].ToString();
                        cliente.Telefone = rd["Telefone"].ToString();
                    }
                }

                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar buscar um nome de cliente no banco de dados.", ex);
            }
            finally
            {
                cn.Close();
            }
        }

    }
}

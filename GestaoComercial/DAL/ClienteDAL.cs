

using Models;
using System.Data.SqlClient;

namespace DAL
{
    public class ClienteDAL
    {
        public void Inserir(Cliente _cliente)
        {
            SqlConnection cn = new SqlConnection(Constantes.StringDeConexao);
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
            SqlConnection cn = new SqlConnection(Constantes.StringDeConexao);
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"UPDATE Cliente 
                                  SET Nome = @Nome, Telefone = @Telefone
                                  WHERE Id = @Id";

                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.AddWithValue("@Id", _cliente.Nome);
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
            SqlConnection cn = new SqlConnection(Constantes.StringDeConexao);
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
            throw new NotImplementedException();
        }
    }
}

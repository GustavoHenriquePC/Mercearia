

using Models;
using System.Data.SqlClient;

namespace DAL
{
    public class ProdutoDAL
    {
        public void Inserir(Produto _produto)
        {
            SqlConnection cn = new SqlConnection(Constantes.StringDeConexao);
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"INSERT INTO Produto(Nome, Preco, Estoque)
                 VALUES(@Nome, @Preco, @Estoque)";

                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.AddWithValue("@Nome", _produto.Nome);
                cmd.Parameters.AddWithValue("@Preco", _produto.Preco);
                cmd.Parameters.AddWithValue("@Estoque", _produto.Estoque);
                

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
        public void Alterar(Produto _produto)
        {
            SqlConnection cn = new SqlConnection(Constantes.StringDeConexao);
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"UPDATE Produto 
                                  SET Nome = @Nome, Preco = @Preco, Estoque = @Estoque
                                  WHERE Id = @Id";

                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.AddWithValue("@Id", _produto.Nome);
                cmd.Parameters.AddWithValue("@Nome", _produto.Nome);
                cmd.Parameters.AddWithValue("@Preco", _produto.Preco);
                cmd.Parameters.AddWithValue("@Estoque", _produto.Estoque);

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
                cmd.CommandText = @"DELETE FROM Produto
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
        public List<Produto> BuscarTodos()
        {
            throw new NotImplementedException();
        }
    }
}

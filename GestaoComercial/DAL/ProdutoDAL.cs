

using Models;
using System.Data.SqlClient;
using System.Security.Cryptography;

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
                                  SET Nome = @Nome, Preco = @Preco, Estoque = @Estoque, CodBarras = @CodBarras
                                  WHERE Id = @Id";

                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.AddWithValue("@Id", _produto.Nome);
                cmd.Parameters.AddWithValue("@Nome", _produto.Nome);
                cmd.Parameters.AddWithValue("@Preco", _produto.Preco);
                cmd.Parameters.AddWithValue("@Estoque", _produto.Estoque);
                cmd.Parameters.AddWithValue("@CodBarras", _produto.CodBarras);

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
            List<Produto> usuarioList = new List<Produto>();
            Produto produto;

            SqlConnection cn = new SqlConnection(Constantes.StringDeConexao);

            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"SELECT Id, Nome, NomeUsuario, Senha, Ativo FROM Produto";

                cmd.CommandType = System.Data.CommandType.Text;

                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        produto = new Produto();
                        produto.Id = (int)rd["Id"];
                        produto.Nome = rd["Nome"].ToString();
                        produto.Preco = (double)rd["Preço"];
                        produto.Estoque = (double)rd["Estoque"];
                        produto.CodBarras = rd["CodBarras"].ToString();
                    }
                }
                return usuarioList;
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
        public Produto BuscarPorId(int _id)
        {
            Produto produto;
            SqlConnection cn = new SqlConnection(Constantes.StringDeConexao);

            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"SELECT FROM Id, Nome, NomeUsuario, Senha, Ativo 
                                    FROM Produto 
                                    WHERE Id = @Id";
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.AddWithValue(@"Id", _id);

                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    produto = new Produto();
                    if (rd.Read())
                    {
                        produto = new Produto();
                        produto.Id = (int)rd["Id"];
                        produto.Nome = rd["Nome"].ToString();
                        produto.Preco = (double)rd["Preço"];
                        produto.Estoque = (double)rd["Estoque"];
                        produto.CodBarras = rd["CodBarras"].ToString();
                    }
                }
                return produto;
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
        public List<Produto> BuscarPorNome(string _nome)
        {
            List<Produto> produtoLista = new List<Produto>();
            Produto produto;
            SqlConnection cn = new SqlConnection(Constantes.StringDeConexao);

            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"SELECT Id, Nome, Preco, Estoque
                                    FROM PRODUTO
                                    WHERE Nome LIKE @Nome";

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue(@"Nome", "%" + _nome + "%");

                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        produto = new Produto();
                        produto.Id = (int)rd["Id"];
                        produto.Nome = rd["Nome"].ToString();
                        produto.Preco = (double)rd["Preco"];
                        produto.Estoque = (double)rd["Estoque"];
                        produtoLista.Add(produto);
                    }
                }

                return produtoLista;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar buscar um produto por nome no banco de dados.", ex);
            }
            finally
            {
                cn.Close();
            }
        }
        public Produto BuscarPorNomeUsuario(string _nomeUsuario)
        {
            Produto produto;

            SqlConnection cn = new SqlConnection(Constantes.StringDeConexao);

            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"SELECT  Id, Nome, Fone
                                    FROM PRODUTO
                                    WHERE NomeUsuario = @NomeUsuario";
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.AddWithValue("@NomeUsuario", _nomeUsuario);


                cn.Open();

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    produto = new Produto();
                    while (rd.Read())
                    {
                        produto.Id = (int)rd["Id"];
                        produto.Nome = rd["Nome"].ToString();
                        produto.Preco = (double)rd["Preco"];
                        produto.Estoque = (double)rd["Estoque"];
                        produto.CodBarras = rd["CodBarras"].ToString();
                    }
                }

                return produto;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar buscar um nome de produto no banco de dados.", ex);
            }
            finally
            {
                cn.Close();
            }
        }

        public Produto BuscarPorCodBarras(string _codBarras)
        {
            Produto produto;
            SqlConnection cn = new SqlConnection(Constantes.StringDeConexao);

            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"SELECT CodBarras, Nome, NomeUsuario, Senha, Ativo 
                                    FROM Produto 
                                    WHERE CodBarras = @CodBarras";
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.AddWithValue("@CodBarras", _codBarras);

                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    produto = new Produto();
                    if (rd.Read())
                    {
                        produto = new Produto();
                        produto.Id = (int)rd["Id"];
                        produto.Nome = rd["Nome"].ToString();
                        produto.Preco = (double)rd["Preço"];
                        produto.Estoque = (double)rd["Estoque"];
                        produto.CodBarras = rd["CodBarras"].ToString();
                    }
                }
                return produto;
            }
            catch (Exception ex)
            {

                throw new Exception("Ocorreu um erro ao tentar Buscar o Código de Barras no Banco de Dados");
            }
            finally
            {
                cn.Close();
            }
        }
    }
}

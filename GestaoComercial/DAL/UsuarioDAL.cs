﻿

using Models;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace DAL
{
    public class UsuarioDAL
    {
        public void Inserir(Usuario _usuario, SqlTransaction _transaction = null)
        {
            SqlTransaction transaction = _transaction;
            using (SqlConnection cn = new SqlConnection(Conexao.StringDeConexao))
            {
                using (SqlCommand cmd = new SqlCommand(@"INSERT INTO Usuario(Nome, NomeUsuario, Senha, Ativo)
                                      VALUES(@Nome, @NomeUsuario, @Senha,@Ativo)"))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.Text;

                        cmd.Parameters.AddWithValue("@Nome", _usuario.Nome);
                        cmd.Parameters.AddWithValue("@NomeUsuario", _usuario.NomeUsuario);
                        cmd.Parameters.AddWithValue("@Senha", _usuario.Senha);
                        cmd.Parameters.AddWithValue("@Ativo", _usuario.Ativo);

                        if (_transaction == null)
                        {
                            cn.Open();
                            transaction = cn.BeginTransaction();
                        }

                        cmd.Transaction = transaction;
                        cmd.Connection = transaction.Connection;

                        cmd.ExecuteNonQuery();

                        if (_transaction == null)
                            transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (transaction.Connection != null && transaction.Connection.State == ConnectionState.Open)
                            transaction.Rollback();
                        throw new Exception("Ocorreu um erro ao tentar inserir um Usuário no Banco de Dados", ex);
                    }
                }
            }
        }
        public void Alterar(Usuario _usuario, SqlTransaction _transaction = null)
        {
            SqlTransaction transaction = _transaction;
            using (SqlConnection cn = new SqlConnection(Conexao.StringDeConexao))
            {
                try
                {
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandText = @"UPDATE Usuario 
                                  SET Nome = @Nome, Senha = @Senha, Ativo = @Ativo 
                                  WHERE Id = @Id";

                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@Id", _usuario.Id);
                    cmd.Parameters.AddWithValue("@Nome", _usuario.Nome);
                    cmd.Parameters.AddWithValue("@NomeUsuario", _usuario.NomeUsuario);
                    cmd.Parameters.AddWithValue("@Senha", _usuario.Senha);
                    cmd.Parameters.AddWithValue("@Ativo", _usuario.Ativo);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Ocorreu um erro ao tentar inserir um Usuário no Banco de Dados", ex);
                }

            }
    }
    public void Excluir(int _id)
    {
        SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
        try
        {
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = @"DELETE FROM Usuario 
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
    public List<Usuario> BuscarTodos()
    {
        List<Usuario> usuarioList = new List<Usuario>();
        Usuario usuario;

        SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);

        try
        {
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = @"SELECT Id, Nome, NomeUsuario, Senha, Ativo FROM Usuario";

            cmd.CommandType = System.Data.CommandType.Text;

            cn.Open();
            using (SqlDataReader rd = cmd.ExecuteReader())
            {
                while (rd.Read())
                {
                    usuario = PreencherObjeto(rd);
                    usuarioList.Add(usuario);
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

    private static Usuario PreencherObjeto(SqlDataReader _rd)
    {
        Usuario usuario = new Usuario();
        usuario.Id = (int)_rd["Id"];
        usuario.Nome = _rd["Nome"].ToString();
        usuario.NomeUsuario = _rd["NomeUsuario"].ToString();
        usuario.Senha = _rd["Senha"].ToString();
        usuario.Ativo = Convert.ToBoolean(_rd["Ativo"]);
        return usuario;
    }

    public Usuario BuscarPorId(int _id)
    {
        Usuario usuario;

        SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);

        try
        {
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = @"SELECT FROM Id, Nome, NomeUsuario, Senha, Ativo FROM Usuario WHERE Id = @Id";
            cmd.CommandType = System.Data.CommandType.Text;

            cmd.Parameters.AddWithValue(@"Id", _id);

            cn.Open();
            using (SqlDataReader rd = cmd.ExecuteReader())
            {
                usuario = new Usuario();
                if (rd.Read())
                {
                    usuario = PreencherObjeto(rd);
                }
            }
            return usuario;
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

    public List<Usuario> BuscarPorNome(string _nome)
    {
        List<Usuario> usuarioList = new List<Usuario>();
        Usuario usuario;

        SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);

        try
        {
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = @"SELECT Id, Nome, NomeUsuario, Senha, Ativo 
                                    FROM Usuario 
                                    WHERE Nome LIKE @Nome";

            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.AddWithValue("@Nome", "%" + _nome + "%");

            cn.Open();
            using (SqlDataReader rd = cmd.ExecuteReader())
            {
                while (rd.Read())
                {
                    usuario = PreencherObjeto(rd);
                }
            }
            return usuarioList;
        }
        catch (Exception ex)
        {

            throw new Exception("Ocorreu um erro ao tentar Buscar o Usuário por nome no Banco de Dados");
        }
        finally
        {
            cn.Close();
        }
    }

    public Usuario BuscarPorNomeUsuario(string _nomeUsuario)
    {
        Usuario usuario;

        SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);

        try
        {
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = @"SELECT Id, Nome, NomeUsuario, Senha, Ativo 
                                    FROM Usuario 
                                    WHERE NomeUsuario = @NomeUsuario";
            cmd.CommandType = System.Data.CommandType.Text;

            cmd.Parameters.AddWithValue("@NomeUsuario", _nomeUsuario);

            cn.Open();
            using (SqlDataReader rd = cmd.ExecuteReader())
            {
                usuario = new Usuario();
                if (rd.Read())
                {
                    usuario = PreencherObjeto(rd);
                }
            }
            return usuario;
        }
        catch (Exception ex)
        {

            throw new Exception("Ocorreu um erro ao tentar Buscar o Nome do Usuário no Banco de Dados");
        }
        finally
        {
            cn.Close();
        }
    }
}
}

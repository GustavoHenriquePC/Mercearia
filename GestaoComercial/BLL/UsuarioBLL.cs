
using DAL;
using Models;
using System.Security.Cryptography;

namespace BLL
{
    public class UsuarioBLL
    {
        public void Inserir (Usuario _usuario)
        {
            if (string.IsNullOrEmpty(_usuario.Nome)) ;
            throw new Exception("Informe o nome do Ususário");
            new UsuarioDAL().Inserir(_usuario);
        }
        public void Alterar(Usuario _usuario)
        {
            new UsuarioDAL().Alterar(_usuario);
        }
        public void Excluir(int _id)
        {
            new UsuarioDAL().Excluir(_id);
        }
        public List<Usuario> BuscarTodos()
        {
            return new UsuarioDAL().BuscarTodos();
        }
        public Usuario BuscarPorId(int _id)
        {
            return new UsuarioDAL().BuscarPorId(_id);
        }

        public List<Usuario> BuscarPorNome(string _nome)
        {
            return new UsuarioDAL().BuscarPorNome(_nome);
        }

        public object BuscarPorNomeUsuario(string _nomeUsuario)
        {
            return new UsuarioDAL().BuscarPorNomeUsuario(_nomeUsuario);
        }
    }
}

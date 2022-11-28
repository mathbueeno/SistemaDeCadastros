using SistemaDeCadastros.Data;
using SistemaDeCadastros.Models;

namespace SistemaDeCadastros.Repositorios
{
    
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly DataContext _dataContext;

        // Injeção de dependência
        public UsuarioRepositorio(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            _dataContext.Usuarios.Add(usuario);
            _dataContext.SaveChanges();

            return usuario;
        }

        public bool Apagar(int id)
        {
            UsuarioModel usuarioDb = ListarPorId(id);

            if (usuarioDb == null) throw new Exception("Erro na deleção do contato");

            _dataContext.Usuarios.Remove(usuarioDb);
            _dataContext.SaveChanges();

            return true;



        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDb = ListarPorId(usuario.Id);
            if (usuarioDb == null) throw new Exception("Erro na atualização do contato");

            usuarioDb.Nome = usuario.Nome;
            usuarioDb.Login = usuario.Login;
            usuarioDb.Email = usuario.Email;
            usuarioDb.DataAtualizacao = DateTime.Now;
            

            _dataContext.Usuarios.Update(usuarioDb);
            _dataContext.SaveChanges();

            return usuarioDb;
        }

        public List<UsuarioModel> BuscarTodos()
        {
            return _dataContext.Usuarios.ToList();
        }

        public UsuarioModel ListarPorId(int id)
        {
                                                    // Claúsula - expressão
            return _dataContext.Usuarios.FirstOrDefault(x => x.Id == id);
        }
    }
}

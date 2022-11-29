using SistemaDeCadastros.Data;
using SistemaDeCadastros.Helper;
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
            usuario.DataCadastro = DateTime.Now;
            usuario.SenhaHash();
            _dataContext.Usuarios.Add(usuario);
            _dataContext.SaveChanges();

            return usuario;
        }

        public UsuarioModel AlterarSenha(AlterarSenhaModel alterarSenhaModel)
        {
            UsuarioModel usuarioDB = ListarPorId(alterarSenhaModel.Id);
            if (usuarioDB == null) throw new Exception("Houve um erro na atualização da senha, usuário não foi encontrado");

            if(!usuarioDB.SenhaValida(alterarSenhaModel.SenhaAtual)) throw new Exception("Senha atual não confere");

            if(usuarioDB.SenhaValida(alterarSenhaModel.NovaSenha)) throw new Exception("Nova senha deve ser diferente da senha atual");

            usuarioDB.SetNovaSenha(alterarSenhaModel.NovaSenha);
            usuarioDB.DataAtualizacao = DateTime.Now;

            _dataContext.Usuarios.Update(usuarioDB);
            _dataContext.SaveChanges();

            return usuarioDB;
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

        public UsuarioModel BuscarPorEmailELogin(string email, string login)
        {
            return _dataContext.Usuarios.FirstOrDefault(x => x.Email.ToUpper() == email.ToUpper() && x.Login.ToUpper() == login.ToUpper());
        }

        public UsuarioModel BuscarPorLogin(string login)
		{
            return _dataContext.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
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

using SistemaDeCadastros.Models;

namespace SistemaDeCadastros.Repositorios
{
    public interface IUsuarioRepositorio
    {
        UsuarioModel AlterarSenha(AlterarSenhaModel alterarSenhaModel);
        UsuarioModel BuscarPorEmailELogin(string email, string login);
        UsuarioModel BuscarPorLogin(string login);
        UsuarioModel ListarPorId(int id);

        List<UsuarioModel> BuscarTodos();
        
        // Adicionar o que? Adicionar um ContatoModel(parametro)
        UsuarioModel Adicionar(UsuarioModel usuario);
        UsuarioModel Atualizar(UsuarioModel usuario);

        bool Apagar(int id);

        
    }
}

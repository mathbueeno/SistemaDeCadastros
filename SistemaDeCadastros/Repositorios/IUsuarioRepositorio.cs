using SistemaDeCadastros.Models;

namespace SistemaDeCadastros.Repositorios
{
    public interface IUsuarioRepositorio
    {
        UsuarioModel ListarPorId(int id);

        List<UsuarioModel> BuscarTodos();
        
        // Adicionar o que? Adicionar um ContatoModel(parametro)
        UsuarioModel Adicionar(UsuarioModel usuario);
        UsuarioModel Atualizar(UsuarioModel usuario);

        bool Apagar(int id);

        
    }
}

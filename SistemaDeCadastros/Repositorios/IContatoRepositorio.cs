using SistemaDeCadastros.Models;

namespace SistemaDeCadastros.Repositorios
{
    public interface IContatoRepositorio
    {
        ContatoModel ListarPorId(int id);

        List<ContatoModel> BuscarTodos();
        
        // Adicionar o que? Adicionar um ContatoModel(parametro)
        ContatoModel Adicionar(ContatoModel contato);
        ContatoModel Atualizar(ContatoModel contato);

        bool Apagar(int id);

        
    }
}

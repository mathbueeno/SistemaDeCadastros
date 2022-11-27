using SistemaDeCadastros.Models;

namespace SistemaDeCadastros.Repositorios
{
    public interface IContatoRepositorio
    {
        // Adicionar o que? Adicionar um ContatoModel(parametro)
        ContatoModel Adicionar(ContatoModel contato);
    }
}

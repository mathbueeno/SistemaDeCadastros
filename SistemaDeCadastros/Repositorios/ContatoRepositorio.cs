using SistemaDeCadastros.Data;
using SistemaDeCadastros.Models;

namespace SistemaDeCadastros.Repositorios
{
    
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly DataContext _dataContext;

        // Injeção de dependência
        public ContatoRepositorio(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public ContatoModel Adicionar(ContatoModel contato)
        {
            _dataContext.Contatos.Add(contato);
            _dataContext.SaveChanges();

            return contato;

        }
    }
}

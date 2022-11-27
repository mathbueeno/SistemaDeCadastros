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

        public bool Apagar(int id)
        {
            ContatoModel contatoDb = ListarPorId(id);

            if (contatoDb == null) throw new Exception("Erro na deleção do contato");

            _dataContext.Contatos.Remove(contatoDb);
            _dataContext.SaveChanges();

            return true;



        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDb = ListarPorId(contato.Id);
            if (contatoDb == null) throw new Exception("Erro na atualização do contato");

            contatoDb.NomeContato = contato.NomeContato;
            contatoDb.Email = contato.Email;
            contatoDb.Telefone = contato.Telefone;

            _dataContext.Contatos.Update(contatoDb);
            _dataContext.SaveChanges();

            return contatoDb;
        }

        public List<ContatoModel> BuscarTodos()
        {
            return _dataContext.Contatos.ToList();
        }

        public ContatoModel ListarPorId(int id)
        {
                                                    // Claúsula - expressão
            return _dataContext.Contatos.FirstOrDefault(x => x.Id == id);
        }
    }
}

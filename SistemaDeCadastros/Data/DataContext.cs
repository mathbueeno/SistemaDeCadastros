using Microsoft.EntityFrameworkCore;
using SistemaDeCadastros.Models;

namespace SistemaDeCadastros.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<ContatoModel> Contatos { get; set; }

        public DbSet<UsuarioModel> Usuarios { get; set; }
    }
}

using Loja.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Loja.API.Data
{
    public class DataContext: DbContext
    {
       public DataContext(DbContextOptions<DataContext> options) :
       base(options) {}

       public DbSet<Produto> Produtos { get; set; }
       public DbSet<Cliente> Clientes { get; set; }
    }
}
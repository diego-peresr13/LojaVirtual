using Microsoft.EntityFrameworkCore;

namespace LojaVirtual.Models
{
    public class LojaVirtualContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public LojaVirtualContext(DbContextOptions<LojaVirtualContext> options) : base(options)
        {
        }
    }
}
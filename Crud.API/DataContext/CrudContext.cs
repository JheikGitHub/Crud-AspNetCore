using Crud.API.DataContext.Maps;
using Crud.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Crud.API.DataContext
{
    public class CrudContext : DbContext
    {
        public CrudContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PizzaBlazor.Shared.Model;

namespace PizzaBlazor.Server.Data
{
	public class AplicationDbContext:IdentityDbContext 
	{
        public AplicationDbContext(DbContextOptions options):base(options)
        {
            
        }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

		}
        public DbSet<Ingrediente> Ingredientes { get; set; }
		public DbSet<Tamanos> Tamanos { get; set; }
		public DbSet<TipoMasa> TipoMasa { get; set; }
    }
}

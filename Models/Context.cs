using Microsoft.EntityFrameworkCore;

namespace Demo.Models
{
	public class Context : DbContext
	{
		public DbSet<Store> Stores { get; set; }
		public DbSet<Item> Items { get; set; }
		public DbSet<StoreItem> ItemStore { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source =.; Initial Catalog = Demo1 ;Integrated Security = true ;TrustServerCertificate = true");
			base.OnConfiguring(optionsBuilder);
		}
		public Context()
		{

		}
		public Context(DbContextOptions options) : base(options) { }

	}
}

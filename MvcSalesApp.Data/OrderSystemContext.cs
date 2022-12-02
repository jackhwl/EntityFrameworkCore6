using MvcSalesApp.Domain;
using System.Data.Entity;

namespace MvcSalesApp.Data
{
	public class OrderSystemContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public OrderSystemContext() : base("name=OrderSystemContext")
        {
        }

		public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<NewCart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NewCart>().HasKey(c => c.CartId);
            modelBuilder.Ignore<RevisitedCart>();
            base.OnModelCreating(modelBuilder);
        }

        public class OrderSystemContextConfig : DbConfiguration
        {
            public OrderSystemContextConfig()
            {
                this.SetDatabaseInitializer(new NullDatabaseInitializer<OrderSystemContext>());
            }

        }

		public System.Data.Entity.DbSet<MvcSalesApp.Domain.Category> Categories { get; set; }
	}
}

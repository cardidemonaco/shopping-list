using Microsoft.EntityFrameworkCore;

namespace shopping_list.DataLayer
{
    public class Shopping_listDataContext : DbContext
    {
        public Shopping_listDataContext(DbContextOptions<Shopping_listDataContext> options)
            : base(options)
        {
           
        }

        public Shopping_listDataContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=shopping-list;Integrated Security=True");
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=shopping-list;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemLocation>().HasKey(k => new { k.ItemId, k.LocationId });
        }

        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<ItemLocation> ItemLocations { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
    }
}

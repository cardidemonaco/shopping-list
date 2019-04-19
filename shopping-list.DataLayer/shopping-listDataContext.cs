using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace shopping_list.DataLayer
{
    public class Shopping_listDataContext : DbContext
    {
        /// <summary>
        /// To migrate, use "Add-Migration [Name]" in Package Manager Console, after making EF changes
        /// </summary>
        /// <param name="options"></param>
        public Shopping_listDataContext(DbContextOptions<Shopping_listDataContext> options)
            : base(options)
        {
           
        }

        public Shopping_listDataContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=shopping-list;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            //Keys...
            mb.Entity<ItemBrand>().HasKey(k => new { k.ItemId, k.BrandId });
            mb.Entity<ItemCategory>().HasKey(k => new { k.ItemID, k.CategoryID });
            mb.Entity<ItemLocation>().HasKey(k => new { k.ItemId, k.LocationId });

            //Seed Data...

            //Items...
            mb.Entity<Item>().HasData(new Item { ItemId = 1, ItemName = "Paper Towel" });
            mb.Entity<Item>().HasData(new Item { ItemId = 2, ItemName = "Tissue" });
            mb.Entity<Item>().HasData(new Item { ItemId = 3, ItemName = "AA Batteries" });
            mb.Entity<Item>().HasData(new Item { ItemId = 4, ItemName = "AAA Batteries" });
            mb.Entity<Item>().HasData(new Item { ItemId = 5, ItemName = "Pop" });

            //Brands...
            mb.Entity<Brand>().HasData(new Brand { BrandId = 1, BrandName = "Faygo" });
            mb.Entity<Brand>().HasData(new Brand { BrandId = 2, BrandName = "Coca Cola" });
            mb.Entity<Brand>().HasData(new Brand { BrandId = 3, BrandName = "Pepsi" });
            mb.Entity<Brand>().HasData(new Brand { BrandId = 4, BrandName = "Kleenex" });
            mb.Entity<Brand>().HasData(new Brand { BrandId = 5, BrandName = "Charmin" });

            //Item Brands...
            mb.Entity<ItemBrand>().HasData(new DataLayer.ItemBrand { ItemId = 2, BrandId = 4 });
            mb.Entity<ItemBrand>().HasData(new DataLayer.ItemBrand { ItemId = 5, BrandId = 1 });
            mb.Entity<ItemBrand>().HasData(new DataLayer.ItemBrand { ItemId = 5, BrandId = 2 });

        }

        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Initiative> Initiatives { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<ItemBrand> ItemBrand { get; set; }
        public virtual DbSet<ItemCategory> ItemCategory { get; set; }
        public virtual DbSet<ItemLocation> ItemLocations { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
    }
}

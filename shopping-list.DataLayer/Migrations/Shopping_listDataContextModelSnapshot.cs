﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using shopping_list.DataLayer;

namespace shopping_list.DataLayer.Migrations
{
    [DbContext(typeof(Shopping_listDataContext))]
    partial class Shopping_listDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("shopping_list.DataLayer.Brand", b =>
                {
                    b.Property<int>("BrandId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrandName");

                    b.HasKey("BrandId");

                    b.ToTable("Brand");

                    b.HasData(
                        new { BrandId = 1, BrandName = "Faygo" },
                        new { BrandId = 2, BrandName = "Coca Cola" },
                        new { BrandId = 3, BrandName = "Pepsi" },
                        new { BrandId = 4, BrandName = "Kleenex" },
                        new { BrandId = 5, BrandName = "Charmin" }
                    );
                });

            modelBuilder.Entity("shopping_list.DataLayer.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName");

                    b.HasKey("CategoryID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("shopping_list.DataLayer.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ItemName");

                    b.HasKey("ItemId");

                    b.ToTable("Items");

                    b.HasData(
                        new { ItemId = 1, ItemName = "Paper Towel" },
                        new { ItemId = 2, ItemName = "Tissue" },
                        new { ItemId = 3, ItemName = "AA Batteries" },
                        new { ItemId = 4, ItemName = "AAA Batteries" },
                        new { ItemId = 5, ItemName = "Pop" }
                    );
                });

            modelBuilder.Entity("shopping_list.DataLayer.ItemBrand", b =>
                {
                    b.Property<int>("ItemId");

                    b.Property<int>("BrandId");

                    b.HasKey("ItemId", "BrandId");

                    b.HasIndex("BrandId");

                    b.ToTable("ItemBrand");

                    b.HasData(
                        new { ItemId = 2, BrandId = 4 },
                        new { ItemId = 5, BrandId = 1 },
                        new { ItemId = 5, BrandId = 2 }
                    );
                });

            modelBuilder.Entity("shopping_list.DataLayer.ItemCategory", b =>
                {
                    b.Property<int>("ItemID");

                    b.Property<int>("CategoryID");

                    b.HasKey("ItemID", "CategoryID");

                    b.HasIndex("CategoryID");

                    b.ToTable("ItemCategory");
                });

            modelBuilder.Entity("shopping_list.DataLayer.ItemLocation", b =>
                {
                    b.Property<int>("ItemId");

                    b.Property<int>("LocationId");

                    b.HasKey("ItemId", "LocationId");

                    b.HasIndex("LocationId");

                    b.ToTable("ItemLocations");
                });

            modelBuilder.Entity("shopping_list.DataLayer.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LocationName");

                    b.HasKey("LocationId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("shopping_list.DataLayer.ItemBrand", b =>
                {
                    b.HasOne("shopping_list.DataLayer.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("shopping_list.DataLayer.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("shopping_list.DataLayer.ItemCategory", b =>
                {
                    b.HasOne("shopping_list.DataLayer.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("shopping_list.DataLayer.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("shopping_list.DataLayer.ItemLocation", b =>
                {
                    b.HasOne("shopping_list.DataLayer.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("shopping_list.DataLayer.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

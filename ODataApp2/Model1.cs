using ODataApp2.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ODataApp2
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Brand> brands { get; set; }
        public virtual DbSet<Category> categories { get; set; }
        public virtual DbSet<Product> products { get; set; }
        public virtual DbSet<Stock> stocks { get; set; }
        public virtual DbSet<ProductRating> ProductRatings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>()
                .Property(e => e.brand_name)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.category_name)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.product_name)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.list_price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Stock>()
                .Property(e => e.quantity);

            //modelBuilder.Entity<ProductRating>();

        }
    }
}

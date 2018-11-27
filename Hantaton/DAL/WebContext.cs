using Hantaton.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection.Emit;
using System.Web;

namespace Hantaton.DAL
{
    public class WebContext : DbContext
    {
        public WebContext() : base("WebContext")
        { }
        public DbSet<City> Citys { get; set; }
        public DbSet<Drugstore> Drugstores { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //связь много-ко-многим между таблицами Teachers и Groups 
            modelBuilder.Entity<Drugstore>().HasMany(x => x.Products).WithMany(x => x.Drugstores).Map(
                a =>
                {
                    a.ToTable("DrugstoresProducts");
                    a.MapLeftKey("DrugstoreId");
                    a.MapRightKey("ProductId");
                }
            );
        }



    }

}

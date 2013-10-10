using System;
using MvcSku.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MvcSku.DAL
{
    public class LibraryContext : DbContext
    {
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Tagging> Taggings { get; set; }
        public DbSet<Can> Cans { get; set; }
        public DbSet<SoftPack> SoftPacks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
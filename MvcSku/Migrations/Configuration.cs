namespace MvcSku.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using MvcSku.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcSku.DAL.LibraryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MvcSku.DAL.LibraryContext context)
        {
            var manufacturers = new List<Manufacturer>
            {
                new Manufacturer { ManufacturerName = "Post" },
                new Manufacturer { ManufacturerName = "Campbell's" },
                new Manufacturer { ManufacturerName = "Kellogg's" }
            };
            manufacturers.ForEach(m => context.Manufacturers.AddOrUpdate(p => p.ManufacturerName, m));
            context.SaveChanges();

            var tags = new List<Tag>
            {
                new Tag { TagId = 1, TagKey = "Brand", TagValue = "Cheerios" },
                new Tag { TagId = 2, TagKey = "Recipe", TagValue = "Chicken Noodle" },
                new Tag { TagId = 3, TagKey = "Brand", TagValue = "Corn Flakes" }
            };
            tags.ForEach(t => context.Tags.AddOrUpdate(x => x.TagValue, t));
            context.SaveChanges();

            var units = new List<Unit>
            {   
                new Unit { UnitId = 1, UnitName = "Box of Cereal", Height = 12.06M, Width = 8.65M, Depth = 2.10M, Manufacturer = manufacturers.Single(m => m.ManufacturerName == "Post") },
                new Can { UnitId = 2, UnitName = "Can o' Soup", Height = 6.26M, Width = 3.34M, Depth = 3.24M, Manufacturer = manufacturers.Single(m => m.ManufacturerName == "Campbell's") },
                new SoftPack { UnitId = 3, UnitName = "Soft Pack of Cereal", Height = 24.22M, Width = 20.00M, Depth = 14.00M, Manufacturer = manufacturers.Single(m => m.ManufacturerName == "Kellogg's") }
            };
            units.ForEach(u => context.Units.AddOrUpdate(x => x.UnitName, u));
            context.SaveChanges();

            var taggings = new List<Tagging>
            {
              new Tagging { UnitId = units.Single(s => s.UnitName == "Box of Cereal").UnitId, TagId = tags.Single(c => c.TagValue == "Cheerios").TagId },
              new Tagging { UnitId = units.Single(s => s.UnitName == "Can o' Soup").UnitId, TagId = tags.Single(c => c.TagValue == "Chicken Noodle").TagId },
              new Tagging { UnitId = units.Single(s => s.UnitName == "Soft Pack of Cereal").UnitId, TagId = tags.Single(c => c.TagValue == "Corn Flakes").TagId }
            };
            foreach (Tagging t in taggings)
            {
                var taggingInDataBase = context.Taggings.Where(
                    s =>
                         s.Tag.TagId == t.TagId &&
                         s.Unit.UnitId == t.UnitId).SingleOrDefault();
                if (taggingInDataBase == null)
                {
                    context.Taggings.Add(t);
                }
            }
            context.SaveChanges();
        }
    }
}

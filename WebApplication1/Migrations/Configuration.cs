namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApplication1.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication1.DataAccess.SotreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebApplication1.DataAccess.SotreContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.

            //context.Items.AddOrUpdate(
            //    b=>b.ArticleNumber,
            //    new StockItem{ArticleNumber=1000, Name="Horse", Description="Fourlegged Vehicle", Price=1000, Quantity=3, ShelfPosition="HorseBox"},
            //    new StockItem{ArticleNumber=1001, Name="Cow", Description="Fourlegged drinkmaker", Price=1000, Quantity=2, ShelfPosition="CowBox"},
            //    new StockItem{ArticleNumber=1002, Name="Dog", Description="Fourlegged butler", Price=500, Quantity=4, ShelfPosition="DogBox"},
            //    new StockItem{ArticleNumber=1003, Name="Cat", Description="Fourlegged Annoying thing", Price=200, Quantity=10, ShelfPosition="CatBox"},
            //    new StockItem{ArticleNumber=1004, Name="Bird", Description="Twolegged maildelivering", Price=100, Quantity=20, ShelfPosition="Birdcage"}
            //    );
        }
    }
}

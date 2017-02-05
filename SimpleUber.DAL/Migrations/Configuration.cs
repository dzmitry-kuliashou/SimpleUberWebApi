using System.Data.Entity.Migrations;

namespace SimpleUber.DAL.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<SimpleUber.DAL.Context.SimpleUberContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SimpleUber.DAL.Context.SimpleUberContext context)
        {
            //context.Authors.AddOrUpdate(
            //    new Author() { Name = "Test1" },
            //    new Author() { Name = "Test2" }
            //    );

            //context.Comments.AddOrUpdate(
            //    new Comment() { Text = "Test comment 1", AuthorId = 1 },
            //    new Comment() { Text = "Test comment 2", AuthorId = 2 }
            //    );
        }
    }
}

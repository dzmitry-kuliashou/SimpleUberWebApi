using SimpleUber.DAL.Api.Entities;
using System.Data.Entity;

namespace SimpleUber.DAL.Context
{
    public class SimpleUberContext : DbContext
    {
        public SimpleUberContext() : base("SimpleUberContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SimpleUberContext, SimpleUber.DAL.Migrations.Configuration>("SimpleUberContext"));
        }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<ExceptionLog> ExceptionLogs { get; set; }

        public DbSet<Session> Sessions { get; set; }

        public DbSet<ServiceLog> ServiceLogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}

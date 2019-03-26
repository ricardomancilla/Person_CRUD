using Domain;
using Domain.Interfaces;
using System.Data.Entity;

namespace Data
{
    public class DBContext : DbContext, IDbContext
    {
        public DBContext() : base("name=ScotiabankDB")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<DBContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("sco");
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Person> People { get; set; }
    }
}

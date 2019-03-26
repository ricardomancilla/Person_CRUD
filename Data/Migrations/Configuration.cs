namespace Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DBContext context)
        {
            context.People.Add(new Domain.Person() { FirstName = "Luis Ricardo", LastName = "Mancilla Gil", Email = "luisricardomancilla@gmail.com" });
        }
    }
}

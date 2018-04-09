namespace AssessmentHC.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AssessmentHC.Models.PersonContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "AssessmentHC.Models.PersonContext";
        }

        protected override void Seed(AssessmentHC.Models.PersonContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.persons.AddOrUpdate(
             p => p.Id,
             new Person { FName = "John", LName = "lee", Age = 30, Address = "1651 North 500 East", Interests = "Programming", ProfileImgPath = "~/Content/ProfileImages/image1.png" },
             new Person { FName = "Peter", LName = "Anderson", Age = 25, Address = "651 North 500 East", Interests = "Coding", ProfileImgPath = "~/Content/ProfileImages/image2.png" },
             new Person { FName = "Arsh", LName = "Singh", Age = 24, Address = "1651 North 400 East", Interests = "Programming", ProfileImgPath = "~/Content/ProfileImages/image3.png" }

           );
        }
    }
}

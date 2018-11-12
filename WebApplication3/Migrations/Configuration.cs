using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using WebApplication3.Models;

namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication3.Models.StudentDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebApplication3.Models.StudentDBContext context)
        {

            context.Role.AddOrUpdate(r => r.RoleId,
                  new RoleViewModel() { RoleId = 1, RoleName = "Admin" },
                  new RoleViewModel() { RoleId = 2, RoleName = "User" }
              );

            context.Subjects.AddOrUpdate(s => s.SubjectId,
                new Subject() { SubjectId="SUBJ001", SubjectName="COLLEGE ALGEBRA"},
                new Subject() { SubjectId="SUBJ002", SubjectName="AUTOMATA"},
                new Subject() { SubjectId="SUBJ003", SubjectName="FUNDAMENTALS OF ICT"},
                new Subject() { SubjectId="SUBJ004", SubjectName= "ADVANCED ENGINEERING MATHEMATICS FOR CE" },
                new Subject() { SubjectId="SUBJ005", SubjectName="DIGITAL COMMUNICATIONS"}
                );

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}

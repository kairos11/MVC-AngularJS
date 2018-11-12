namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.Courses",
            //    c => new
            //        {
            //            CourseId = c.Int(nullable: false, identity: true),
            //            CourseName = c.String(),
            //        })
            //    .PrimaryKey(t => t.CourseId);

            //CreateTable(
            //    "dbo.Students",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //            DateOfBirth = c.DateTime(),
            //            EmailId = c.String(),
            //            Address = c.String(),
            //            City = c.String(),
            //            CourseId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
            //    .Index(t => t.CourseId);

            CreateTable(
              "dbo.Syllabus",
              c => new
              {
                  ID = c.Int(nullable: false, identity: true),
                  CourseId = c.Int(nullable: false),
                  SubjectId = c.String(nullable: false, maxLength: 128),
              })
              .PrimaryKey(t => t.ID)
              .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
              .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
              .Index(t => t.CourseId)
              .Index(t => t.SubjectId);

            CreateTable(
                "dbo.Subjects",
                c => new
                {
                    SubjectId = c.String(nullable: false, maxLength: 128),
                    SubjectName = c.String(),
                })
                .PrimaryKey(t => t.SubjectId);

        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.Students", "CourseId", "dbo.Courses");
            //DropIndex("dbo.Students", new[] { "CourseId" });
            //DropTable("dbo.Students");
            //DropTable("dbo.Courses");

            DropForeignKey("dbo.RegisterViewModels", "RoleId", "dbo.RoleViewModels");
            DropForeignKey("dbo.Students", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Syllabus", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Syllabus", "CourseId", "dbo.Courses");
            DropIndex("dbo.RegisterViewModels", new[] { "RoleId" });
            DropIndex("dbo.Students", new[] { "CourseId" });
            DropIndex("dbo.Syllabus", new[] { "SubjectId" });
            DropIndex("dbo.Syllabus", new[] { "CourseId" });
            DropTable("dbo.RoleViewModels");
            DropTable("dbo.RegisterViewModels");
            DropTable("dbo.LoginViewModels");
            DropTable("dbo.Students");
            DropTable("dbo.Subjects");
            DropTable("dbo.Syllabus");
            DropTable("dbo.Courses");
        }
    }
}

namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _Migration2019 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Student_Details");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Student_Details",
                c => new
                    {
                        Student_Id = c.Int(nullable: false, identity: true),
                        Birth_Date = c.String(),
                        Mothers_Name = c.String(),
                        Fathers_Name = c.String(),
                        Age = c.Int(nullable: false),
                        imagePath = c.String(),
                    })
                .PrimaryKey(t => t.Student_Id);
            
        }
    }
}

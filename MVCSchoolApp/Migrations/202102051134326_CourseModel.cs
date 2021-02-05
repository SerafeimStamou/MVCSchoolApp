namespace MVCSchoolApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CourseModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        HoursPerWeek = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Courses");
        }
    }
}

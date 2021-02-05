namespace MVCSchoolApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SomeFixes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Teachers", "ID", "dbo.Courses");
            DropIndex("dbo.Teachers", new[] { "ID" });
            DropPrimaryKey("dbo.Teachers");
            AddColumn("dbo.Courses", "Teacher_ID", c => c.Int());
            AlterColumn("dbo.Teachers", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Teachers", "ID");
            CreateIndex("dbo.Courses", "Teacher_ID");
            AddForeignKey("dbo.Courses", "Teacher_ID", "dbo.Teachers", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "Teacher_ID", "dbo.Teachers");
            DropIndex("dbo.Courses", new[] { "Teacher_ID" });
            DropPrimaryKey("dbo.Teachers");
            AlterColumn("dbo.Teachers", "ID", c => c.Int(nullable: false));
            DropColumn("dbo.Courses", "Teacher_ID");
            AddPrimaryKey("dbo.Teachers", "ID");
            CreateIndex("dbo.Teachers", "ID");
            AddForeignKey("dbo.Teachers", "ID", "dbo.Courses", "ID");
        }
    }
}

namespace MVCSchoolApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OneToOne : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Teachers");
            AlterColumn("dbo.Teachers", "ID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Teachers", "ID");
            CreateIndex("dbo.Teachers", "ID");
            AddForeignKey("dbo.Teachers", "ID", "dbo.Courses", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teachers", "ID", "dbo.Courses");
            DropIndex("dbo.Teachers", new[] { "ID" });
            DropPrimaryKey("dbo.Teachers");
            AlterColumn("dbo.Teachers", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Teachers", "ID");
        }
    }
}

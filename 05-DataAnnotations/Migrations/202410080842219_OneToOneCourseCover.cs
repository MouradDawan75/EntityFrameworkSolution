namespace _05_DataAnnotations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OneToOneCourseCover : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Covers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Course_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.t_course", t => t.Course_Id)
                .Index(t => t.Course_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Covers", "Course_Id", "dbo.t_course");
            DropIndex("dbo.Covers", new[] { "Course_Id" });
            DropTable("dbo.Covers");
        }
    }
}

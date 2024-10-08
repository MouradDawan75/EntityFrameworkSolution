namespace _05_DataAnnotations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OneToManyAuthorCourse : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.t_course",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        FullPrice = c.Single(nullable: false),
                        AuthorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true) //suppression en cascade -> la suppression d'un Author implique la suppression des courses associés
                .Index(t => t.AuthorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.t_course", "AuthorId", "dbo.Authors");
            DropIndex("dbo.t_course", new[] { "AuthorId" });
            DropTable("dbo.t_course");
            DropTable("dbo.Authors");
        }
    }
}

namespace _05_DataAnnotations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.t_utilisateurs",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Firstname = c.String(nullable: false, maxLength: 255),
                        LastName = c.String(nullable: false, maxLength: 255),
                        Email = c.String(nullable: false, maxLength: 2000),
                        Password = c.String(nullable: false),
                        DateNaissance = c.DateTime(nullable: false),
                        Adresse = c.String(maxLength: 3000),
                        Photo = c.String(),
                        Evaluation = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .Index(t => t.Email, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.t_utilisateurs", new[] { "Email" });
            DropTable("dbo.t_utilisateurs");
        }
    }
}

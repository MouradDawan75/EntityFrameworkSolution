namespace _03_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFournisseurClasse : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fournisseurs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            Sql("INSERT INTO Fournisseurs(Name) Values('Carrefour')");
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Fournisseurs");
        }
    }
}

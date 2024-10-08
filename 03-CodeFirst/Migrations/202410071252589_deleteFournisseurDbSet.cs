namespace _03_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteFournisseurDbSet : DbMigration
    {
        public override void Up()
        {
            //Création d'une table temporaire pour sauvegarder le contenu de la table à supprimer Fournisseurs

            CreateTable(
                "dbo._Fournisseurs",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Nom = c.String(),
                })
                .PrimaryKey(t => t.Id);

            Sql("INSERT INTO _Fournisseurs(Nom) Select Nom From Fournisseurs");

            DropTable("dbo.Fournisseurs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Fournisseurs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            Sql("INSERT INTO Fournisseurs(Nom) Select Nom From _Fournisseurs");

            DropTable("dbo._Fournisseurs");

        }
    }
}

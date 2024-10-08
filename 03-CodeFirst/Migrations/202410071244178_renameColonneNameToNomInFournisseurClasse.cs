namespace _03_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renameColonneNameToNomInFournisseurClasse : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fournisseurs", "Nom", c => c.String());

            //Récupérer le contenu de la coonne Name avant suppression
            Sql("Update Fournisseurs set Nom=Name");

            DropColumn("dbo.Fournisseurs", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Fournisseurs", "Name", c => c.String());
            Sql("Update Fournisseurs set Name=Nom");
            DropColumn("dbo.Fournisseurs", "Nom");
        }
    }
}

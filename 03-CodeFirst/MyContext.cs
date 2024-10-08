using System;
using System.Data.Entity;
using System.Linq;

namespace _03_CodeFirst
{
    public class MyContext : DbContext
    {
        // Votre contexte a été configuré pour utiliser une chaîne de connexion « MyContext » du fichier 
        // de configuration de votre application (App.config ou Web.config). Par défaut, cette chaîne de connexion cible 
        // la base de données « _03_CodeFirst.MyContext » sur votre instance LocalDb. 
        // 
        // Pour cibler une autre base de données et/ou un autre fournisseur de base de données, modifiez 
        // la chaîne de connexion « MyContext » dans le fichier de configuration de l'application.
        public MyContext()
            : base("name=MyContext")
        {
        }

        // Ajoutez un DbSet pour chaque type d'entité à inclure dans votre modèle. Pour plus d'informations 
        // sur la configuration et l'utilisation du modèle Code First, consultez http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public DbSet<Contact> Contacts { get; set; }
        //public DbSet<Fournisseur> Fournisseurs { get; set; }
    }

    /*Etapes de l'approche code first:
     * 1- Installer Entity Framework via nuget
     * 2- Créer les classes objets
     * 3- Choisir l'approche code first -> clic droit sur le projet -> ajouter nouvel élément -> type données ->
     *  -> choisir code first
     *  
     * 4- Dans la classe context générée -> ajoutez un DbSet pour chaque classe objet
     *  (possibilité de modifier dans app.config le nom de la base de données)
     *  
     * 5- Vérifier que le projet est définit par défaut dans la solution
     * 6- Affichez la console de gestionnaire de package nuget via le menu outils -> gestionnaire de packages nuget
     *  -> console de gestionnaire de packages (dans la console choisir le projet par défaut)
     * 
     * 7- Première commande à exécuter: enable-migrations
     * 8- Pour chaque mise à jours -> créer une migration via a commande: add-migration nom_migration
     * 9- Exécuter la commande update-database pour mettre à jours a base de données
     * 
     * Important:
     *  Les migrations non appliquées peuvent supprimées.
     *  Attention: ne pas supprimer les migrations appliquées via update-database
     * 
     * ******* Toute modification des classes implique une nouvelle migration + update-database
     * 
     * Pour revenir à un état précedent de la base de données:
     * update-database -TargetMigration: nom_migration
     * 
     * 
     * 
     * 
     */
}
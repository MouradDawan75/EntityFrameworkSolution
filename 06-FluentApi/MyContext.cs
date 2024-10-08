using System;
using System.Data.Entity;
using System.Linq;

namespace _06_FluentApi
{
    public class MyContext : DbContext
    {
        public MyContext()
            : base("name=MyContext")
        {
        }

        // Pour générer le script SQL de la création de la Base de données- commande à exécuter dans la console de 
        // de gestionnaire de package:
        //Update-Database -Script -SourceMigration:0  (0 pour prendre en compte toutes les migrations)

        public DbSet<Course> Courses { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Cover> Covers { get; set; }

        //FluentApi: override de la méthode OnModelCreating
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Gestion des contraintes et des relations en utilisant FluentApi

            #region Classe Course

            modelBuilder.Entity<Course>()
                .ToTable("t_course");

            modelBuilder.Entity<Course>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(255);

            //OneToMany avec Author
            modelBuilder.Entity<Course>()
                .HasRequired(c => c.Author)
                .WithMany(a => a.Courses)
                .HasForeignKey(c => c.AuthorId)
                .WillCascadeOnDelete(true);
            /*
             * Soit en partant de la casse Course - soit en partant de la classe Author -> mais pas les 2
            modelBuilder.Entity<Author>()
                .HasMany(a => a.Courses)
                .WithRequired(c => c.Author)
                .HasForeignKey(c => c.AuthorId)
                .WillCascadeOnDelete(true);
            */

            //ManyToMany avec classe Tag

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Tags)
                .WithMany(t => t.Courses)
                .Map(m =>
                            { 
                            m.ToTable("CourseTag")
                            .MapLeftKey("CourseId")
                            .MapRightKey("TagId");
                            });

            //OneToOne avec classe Cover: facilite la gestion du OneToOne dans les 2 sens contrairement aux DataAnnotations

            modelBuilder.Entity<Course>()
                .HasRequired(c => c.Cover)
                .WithRequiredPrincipal(cv => cv.Course);


            #endregion

            #region Classe Author

            modelBuilder.Entity<Author>()
                .Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(255);

            #endregion

            base.OnModelCreating(modelBuilder);
        }

        


    }

  
}
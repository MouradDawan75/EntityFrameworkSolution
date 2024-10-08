using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_DataAnnotations
{
    /*
     * Override des conventions d'Entity Framework en utilisant les data annotations
     */

    [Table("t_utilisateurs")] //modifier le nom de la table
    public class Utilisateur
    {
        //si la classe ne possède une propriété Id -> utilisez [Key] pour indiquer à Entity Framework la clé primaire
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // clé en autoincrement car c'est un type numérique
        public int UserId { get; set; }

        [Column("Firstname")] //modifier le nom de la colonne
        [Required] //colonne not null
        [MaxLength(255)]
        public string FirstName { get; set; }

        [Required] [MaxLength(255)]
        public string LastName { get; set; }

        //propriété dérivée -> combinaison de 2 ou plusieurs propriétés de la mm classe
        [NotMapped] //champs ignoré lors du mapping
        public string FullName { get { return FirstName + " " + LastName; } }

        [Required]
        [MaxLength(2000)]
        [Index(IsUnique = true)] // le champs email est unique en base de données
        [EmailAddress] // concerne les champs de saisie d'1 appli. web -> vérifier le format d'un email
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)] //concerne le champs de saisie d'un formuaire
        public string Password { get; set; }

        [NotMapped]        
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required]
        [DataType(DataType.DateTime)] // concerne le champs de saisie
        public DateTime DateNaissance { get; set; }

        [MaxLength(3000)]
        [DataType(DataType.MultilineText)] // concerne le champs de saisie
        public string Adresse { get; set; }

        [FileExtensions(Extensions = "png,jpg,jpeg,gif")]
        public string Photo { get; set; }

        [Required]
        [Range(1,10)]
        public int Evaluation { get; set; }
    }
}

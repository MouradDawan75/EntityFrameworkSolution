using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_DataAnnotations
{
    [Table("t_course")]
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float FullPrice { get; set; }

        [ForeignKey("AuthorId")] //pour personnaliser le com de clé étrangère dans la table
        public Author Author { get; set; }

        public int AuthorId { get; set; } // champs optionnel en cas de besoin

        //Lien ManyToMany avec la classe Tag
        public List<Tag> Tags { get; set; } = new List<Tag>();

        //Course est la casse principale -> la clé de jointure doit être définie dans Cover
        //Un course peut exister sans couverture ////////
        //Lien OneToOne avec la classe Cover
        //public Cover Cover { get; set; }
    }
}

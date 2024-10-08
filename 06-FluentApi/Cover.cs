using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_FluentApi
{
    public class Cover
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //[ForeignKey("Course_id")] //par défaut la clé est nommée: course_id - relation gérée via FluentApi
        public Course Course { get; set; }
        
        public int CourseId { get; set; } // champs optionnel
    }
}

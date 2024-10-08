using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_DataAnnotations
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Lien ManyToMany avec la classe Course
        public List<Course> Courses { get; set; } = new List<Course>();
    }
}

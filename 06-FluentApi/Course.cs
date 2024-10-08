using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _06_FluentApi
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float  FullPrice { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }
        public List<Tag> Tags { get; set; } = new List<Tag>();
        public Cover Cover { get; set; }
    }
}

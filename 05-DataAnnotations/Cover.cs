using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_DataAnnotations
{
    public class Cover
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Course Course { get; set; }
    }
}

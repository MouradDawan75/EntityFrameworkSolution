using _04_Crud.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace _04_Crud
{
    public class MyContext : DbContext
    {
        
        public MyContext()
            : base("name=MyContext")
        {
        }

        public DbSet<Produit>  Produits { get; set; }
    }

  
}
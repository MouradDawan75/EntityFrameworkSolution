using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_CodeFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new MyContext();
            Contact contact = new Contact() { Nom = "DUPONT", Prenom = "Jean" };
            context.Contacts.Add(contact);
            context.SaveChanges();
            Console.WriteLine("Contact inséré.....");

            Console.ReadLine();
        }
    }
}

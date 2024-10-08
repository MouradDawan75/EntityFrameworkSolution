using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _06_FluentApi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new MyContext();

            #region Chargement des relations

            /*
             * LazyLoading (chargement tardif - chargement à la demande)
             * EagerLoding: chargement immédiat
             * 
             * Par défaut les relations Many sont en LazyLoading
             * 
             */

            //List<Author> authorList = context.Authors.ToList();

            //Demande explicite du chargement des Courses associé à l'Author

            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>Relation Many:");

            //Par défaut les relations Many sont en LazyLoading

            List<Author> authorList = context.Authors.Include(a => a.Courses).ToList();

            foreach (var author in authorList)
            {
                Console.WriteLine($"Name: {author.Name}");

                Console.WriteLine(">>>>>>>>>>> Courses:");

                foreach(var course in author.Courses)
                {
                    Console.WriteLine($"Course Name: {course.Name}");   
                }
            }

            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>Relation One:");

            //Par défaut la relation One est chargement immédiat (EagerLoading)

            var course1 = context.Courses.Find(1);

            Console.WriteLine($"Course Name: {course1.Name}");
            Console.WriteLine($">>>Author name: {course1.Author.Name}");


            #endregion

            #region LINQ

            /*
             * LINQ: Language Integrated Query: propre à Microsoft- Contrairement au langage SQL, Linq permet d'interroger
             * n'importe quelle source de données: fichier, BD, listes....... 
             * 2 façon d'utiliser LINQ: 
             * - Soit sa syntaxe proche de sql
             * - Soit le chainage de méthodes
             */

            Console.WriteLine(">>>>>>>>>>>>>>Syntaxe de LINQ:");

            Console.WriteLine("********Restriction:");

            //Restriction: Author dont id = 1

            var query1 = from a in context.Authors
                         where a.Id == 1
                         select a;

            foreach (var item in query1)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("********OrderBy:");

            //Order: la liste des courses de author1 orderby courseName

            var query2 = from c in context.Courses
                         //where c.AuthorId == 1
                         orderby c.Name descending //par c'est ordre ascendant
                         select c;

            foreach (var item in query2) { 
            
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("********Projection:");

            //Nom des courses de author1 + nom de l'author1

            var query3 = from c in context.Courses
                         where c.AuthorId == 1

                         /*
                          * Option1: créer une classe qui contient les infos à extraire
                          */

                         //select new AuthorCourse { CourseName = c.Name , AuthorName = c.Author.Name};

                         // Option2: utiliser un objet anonyme (type anonyme)
                         select new {AuthorName = c.Author.Name, CourseName = c.Name};

            // Le type anonyme en c#:
            var student = new { Id = 1, Name = "Marc" };

            Console.WriteLine(student.Id);
            Console.WriteLine(student.Name);

            //student.Name = "Jean"; on ne peut pas modifier les prorpiétés d'un type anonyme

            //Sous types anonymes

            var student2 = new 
            { 
                Name = "Jean",
                Adresse = new {rue = "5 rue machine", code_postal = 75015}

            };

            //Le type anonyme est pratique pour un stockage temporaire

            Console.WriteLine("********GroupBy:");

            //La liste des courses groupés par prix

            var query4 = from c in context.Courses
                         group c by c.FullPrice
                         into g
                         select g; // on récupère une liste de groupes

            Console.WriteLine("Liste de groupes de cours par prix:");

            foreach (var groupe in query4)
            {
                //La clé du groupage (FullPrice):
                Console.WriteLine("Prix: "+groupe.Key);

                foreach (var c in groupe) {
                    Console.WriteLine($"\t {c.Name}");
                }


            }

            Console.WriteLine("********Jointures: inner join, group join, cross join");

            Console.WriteLine("\t Inner Join:");
            //nom du course + nom de Author
            
            var query5 = from c in context.Courses
                         join a in context.Authors on c.AuthorId equals a.Id
                         select new {AuthorName = c.Author, CourseName = c.Name};

            Console.WriteLine("\t Group Join:");

            var query6 = from a in context.Authors
                         join c in context.Courses on a.Id equals c.AuthorId into g //g contient les courses de l'author
                         select new { AuthorName = a.Name, NbCourses = g.Count() };

            Console.WriteLine("\t Cross Join:");
            //Cross Join: chaque ligne de la table de gauche avec chaque ligne de la table de droite

            var query7 = from a in context.Authors
                         from c in context.Courses
                         select new { AuthorName = c.Author, CourseName = c.Name };




            #endregion


            //Maintenir la console active
            Console.ReadKey();
        }
    }
}

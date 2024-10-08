using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_DbFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Connexion à la base de données
            var context = new dbfirstEntities();

            //Manipulation de données
            employes e = new employes() { nom = "DUPONT", prenom = "Jean" };
            context.employes.Add(e);

            /*
             * Les objets insérés dans le context possèdent un état:
             * Added: SaveChanges génère la commande sql insert
             * Removed: SaveChanges génère la commande sql delete
             * Updated: SaveChanges génère la commande sql update
             * 
             */

            //Console.WriteLine("Etat de 'objet après la méthode add: " + context.Entry(e).State);

            context.SaveChanges();

            //Console.WriteLine("Employé inséré.......");

            //employes e1 = context.employes.Find(1);

            // Console.WriteLine("Etat de l'objet après la méthode Find: "+context.Entry(e1).State); //Unchanged
            //e1.nom = "New_Name";

            //Console.WriteLine("Etat de l'objet après modification du nom: " + context.Entry(e1).State); //Modified

            //context.SaveChanges(); //commande sql update

            //context.employes.Remove(e1);

            //Console.WriteLine("Etat de l'objet après la méthode Remove: " + context.Entry(e1).State); //Deleted

            //context.SaveChanges(); //Commande sql delete

            // Charger des données dans le context sans les conserver dans le cache du context
            // L'état de ces n'est suivi par e context

            //Bonne pratique:
            // Les lectures en BD doivent se faire en mode AsNoTracking()

            employes e2 = context.employes.AsNoTracking().SingleOrDefault(emp => emp.Id == 2);

            Console.WriteLine("Etat de l'objet e2 avec AsNoTracking: " + context.Entry(e2).State); //Detached

            context.employes.Attach(e2); // Charger l'objet dans le context

            e2.nom = "nouveau_nom";

            Console.WriteLine("Etat de l'objet e2 après modification du nom: " + context.Entry(e2).State);

            //Func<employes, bool> fct = emp => emp.Id == 2;
            //Action<employes> afficher = employe => Console.WriteLine(employe);

            //Toute modification dans la base de données implique une mise à jours 
            // du modèle

            //maintenir la console active:
            Console.ReadLine();
        }


        //Equivalent en Expression Lambda: fonction anonyme -> params => instructions;
        // e => e.Id == 2;
        public static bool find_employes(employes e)
        {
            return e.Id == 2;
        }
    }
}

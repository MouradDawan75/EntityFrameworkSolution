using _04_Crud.Models;
using _04_Crud.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Crud
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ProduitService service = new ProduitService();

            while (true)
            {
                Console.WriteLine(@"
                    Menu:
                    1- Afficher la liste des produits
                    2- Insérer un produit
                    3- Mettre à jours un produit
                    4- Supprimer un produit
                    5- Rechercher un produit par son id
                    6- Rechercher sur les produits par mot clé
                    7- Quitter
                    
                    Votre choix:
            ");

                int choix = Convert.ToInt32(Console.ReadLine());
                if (choix == 7) { break; }

                switch (choix)
                {
                    case 1:
                        List<Produit> all = service.GetAll();
                        if(all.Count == 0) 
                        {
                            Console.WriteLine("Aucun produit trouvé.");
                        }
                        else
                        {
                            foreach (Produit produit in all)
                            {
                                Console.WriteLine(produit.Description+" "+produit.Prix);
                                Console.WriteLine("==================================");
                            }
                        }
                        break;

                        case 2:
                            Console.WriteLine("Nom produit: ");
                            string description = Console.ReadLine();

                            Console.WriteLine("Prix produit: ");
                            double prix = Convert.ToDouble(Console.ReadLine());

                            Produit p = new Produit() { Description = description, Prix = prix };
                        try
                        {
                            service.Insert(p);
                            Console.WriteLine("Produit inséré.........");
                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine(ex.Message);
                        }
                            

                            break;

                        case 3:
                            Console.WriteLine("Id du produit: ");
                            int id = Convert.ToInt32(Console.ReadLine());

                            if(service.Get(id) != null)
                                    {
                                        Console.WriteLine("Nom produit: ");
                                        string description1 = Console.ReadLine();

                                        Console.WriteLine("Prix produit: ");
                                        double prix1 = Convert.ToDouble(Console.ReadLine());

                                        Produit p1 = new Produit() { Id=id, Description=description1, Prix = prix1 };

                            try
                            {
                                service.Update(p1);
                                Console.WriteLine("Produit mis à jours.....");
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                                        
                        }
                        else
                        {
                            Console.WriteLine("Produit introuvable.....");
                        }
                        break;

                    case 4:
                        Console.WriteLine("Id du produit: ");
                        int id_to_delete = Convert.ToInt32(Console.ReadLine());
                        if(service.Get(id_to_delete ) != null)
                        {
                            service.Delete(id_to_delete);
                            Console.WriteLine("Produit supprimé.....");
                        }
                        else
                        {
                            Console.WriteLine("Produit introuvable....");
                        }


                        break;

                        case 5:
                            Console.WriteLine("Id du produit: ");
                            int id_to_find = Convert.ToInt32(Console.ReadLine());
                            Produit prodTrouve = service.Get(id_to_find);
                            if (prodTrouve != null)
                            {
                                Console.WriteLine("Produit trouvé: ");
                                Console.WriteLine(prodTrouve.Description+" "+prodTrouve.Prix);
                            }
                            else
                            {
                                Console.WriteLine("Produit introuvable..........");
                            }

                            break;

                        case 6:
                            Console.WriteLine("Mot clé: ");
                            string key = Console.ReadLine();
                            List<Produit> prods = service.FindByKey(key);
                            if(prods.Count == 0)
                            {
                                Console.WriteLine("Aucun produit trouvé...");
                            }
                            else
                            {
                                foreach (var prod in prods)
                                {
                                    Console.WriteLine(prod.Description+" "+prod.Prix);
                                }
                            }

                            break;

                    default:
                        Console.WriteLine("Choix invalide......");
                        break;
                }



            }

            Console.WriteLine("Fin du programme....");
            Console.ReadKey();
        }
    }
}

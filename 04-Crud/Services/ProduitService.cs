using _04_Crud.Models;
using _04_Crud.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace _04_Crud.Services
{
    public class ProduitService
    {
        /* Le service contient la logique métrier
         * Son rôle est de répondre aux besoins des utilisateurs finaux et de gérer les règles métiers
         *  Exemple d'une règle métier:
         *  Le prix d'un produit doit être compris entre 10 et 1000
         * 
         */

        //Dépendance entre service et repository
        private ProduitRepository repository = new ProduitRepository();

        public void Insert(Produit p)
        {
            if (p.Prix >= 10 && p.Prix <= 1000)
            {
                //Appel du repo pour insertion
                repository.Insert(p);
            }
            else
            {
                throw new Exception("Prix doit être compris entre 10 et 1000");
            }
        }

        public void Update(Produit p) 
        {
            if (p.Prix >= 10 && p.Prix <= 1000)
            {
                //Appel du repo pour insertion
                repository.Update(p);
            }
            else
            {
                throw new Exception("Prix doit être compris entre 10 et 1000");
            }
        }

        public void Delete(int id) { 
            repository.Delete(id);
        }

        public List<Produit> GetAll() { 
        return repository.GetAll();
        }

        public Produit Get(int id) 
        { 
            return repository.Get(id); 
        }

        public List<Produit> FindByKey(string key) 
        {
        return repository.FindByKey(key);
        }
    }
}

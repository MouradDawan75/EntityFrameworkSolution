using _04_Crud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Crud.Repositories
{
    public class ProduitRepository
    {
        //Dépendance du Context
        private MyContext context = new MyContext();

        public void Insert(Produit p)
        {
            context.Produits.Add(p);
            context.SaveChanges();
        }
        public void Update(Produit p) 
        {
            Produit prodDB = context.Produits.Find(p.Id);
            if (prodDB != null)
            {

                //context.Produits.AsNoTracking().SIngleOrDefault(pr => pr.Id ==p.Id );
                //context.Produits.Attach(p); // etat = Attached

                //Modification de l'état de l'objet dans le context
                //context.Entry(p).State = System.Data.Entity.EntityState.Modified;
                //context.SaveChanges();

                prodDB.Description = p.Description; 
                prodDB.Prix = p.Prix;
                context.SaveChanges();
            }
        }

        public void Delete(int id) 
        {
            Produit p = context.Produits.Find(id);
            if (p != null) { 
                context.Produits.Remove(p);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Produit introuvable.....");
            }
        }

        public List<Produit> GetAll() { 
        
            //AsNoTracking: renvoie la liste des Produits sans la conserver dans le cache du context
            return context.Produits.AsNoTracking().ToList();
        }

        public Produit Get(int id)
        {
            return context.Produits.AsNoTracking().SingleOrDefault(p => p.Id == id);
        }

        public List<Produit> FindByKey(string key) { 
            return context.Produits.AsNoTracking().Where(p => p.Description.Contains(key)).ToList();
        }

    }
}

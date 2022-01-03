using System;
using CodeFirst_Demo.Models;
using System.Collections.Generic;
using System.Linq;

namespace CodeFirst_Demo
{
    public class Program
    {
        static void Main(string[] args)
        {

            /*
            Console.WriteLine("Ajout de catégorie...");
            Console.WriteLine("Entrez le nom d'un libelle");
            string libel = Console.ReadLine();
            insertCategorie(libel);
            Console.WriteLine("Insertion avec succès");
            */
            /*
            readCategories();
            updateCategorie();
            readCategories();
            */

            //Console.WriteLine("Entrez un numéro d'Id");
            //int id1 = int.Parse(Console.ReadLine());

            //Console.WriteLine("Entrez le nom d'un libelle");
            //string lib = Console.ReadLine();

            //readCategories();                 //Lit le tableau Categories

            //updateCategorie(id1, lib);        //Met à jour le libelle de l'id id1 dans le tableau Categories

            //deleteCategorie();                //Supprime la première ligne de Categories

            //Console.WriteLine("****************************************");
            //Console.WriteLine("****************************************");

            //readCategories();                 //Lit après les modifications

            Console.WriteLine("Entrez un nouveau produit (Titre, Prix, Date, IdCategorie)"); // Exemple de OnetoMany


            string titre = Console.ReadLine();
            double prix = double.Parse(Console.ReadLine());
            DateTime date = DateTime.Parse(Console.ReadLine());
            int idCategorie = int.Parse(Console.ReadLine());


            insertProduit(titre, prix, date, idCategorie);  // Permet d'insérer un nouveau produit
            /*
            
            Console.WriteLine("Mettez à jour un produit (Id, Titre, Prix, Date, IdCategorie");

            int id1 = int.Parse(Console.ReadLine());
            string titre1 = Console.ReadLine();
            double prix1 = double.Parse(Console.ReadLine());
            DateTime date1 = DateTime.Parse(Console.ReadLine());
            int idCategorie1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Supprimez un produit (id)");
            int id2 = int.Parse(Console.ReadLine());
            deleteProduit(id2);
            */
            readProduit();


        }

        static void readProduit()               //Methode lecture tableau produit
        {

            using (var db = new EFContext())
            {

                List<Produit> produits = db.Produits.ToList();
                foreach (Produit p in produits)
                {
                    Console.WriteLine("*************************** ");
                    Console.WriteLine("{0} {1} {2} {3} {4}", p.Id, p.Titre, p.Prix, p.Date, p.IdCategorie);
                    Categorie c = db.Categories.Find(p.IdCategorie);
                    Console.WriteLine("{0} {1} {2} {3}", c.Id, c.Libelle, c.NbrProduits, c.IdFournisseur);
                    Fournisseur f = db.Fournisseurs.Find(c.IdFournisseur);
                    Console.WriteLine("{0} {1} ", f.Id, f.Nom);
                }

            }

        }
        static void updateProduit(int id, string titre, double prix, DateTime date, int idCategorie)        //Methode Mise à jour tableau produit
        {
            using (var db = new EFContext())
            {
                try
                {
                    Produit produit = db.Produits.Find(id);
                    produit.Titre = titre;
                    produit.Prix = prix;
                    produit.Date = date;
                    produit.IdCategorie = idCategorie;

                    db.SaveChanges();
                }
                catch (NullReferenceException e)
                {

                    Console.WriteLine("Entrez une Id valide");

                }




            }
            return;
        }

        static void deleteProduit(int id)       //Methode Suppression tableau produit
        {
            using (var db = new EFContext())
            {
                Produit produit = db.Produits.Find(id);
                db.Produits.Remove(produit);
                db.SaveChanges();
            }
            return;
        }


        static void insertProduit(string titre, double prix, DateTime date, int idCategorie)            //Methode insertion tableau produit
        {
            using (var db = new EFContext())
            {
                Produit produit = new Produit();
                produit.Titre = titre;
                produit.Prix = prix;
                produit.Date = date;
                produit.IdCategorie = idCategorie;
                db.Add(produit);
                db.SaveChanges();
            }

        }

        /*
        static void deleteCategorie()
        {
            using (var db = new EFContext())
            {
                Categorie categorie = db.Categories.Find(1);
                db.Categories.Remove(categorie);
                db.SaveChanges();
            }
            return;
        }

        static void updateCategorie(int i, string libel)
        {
            using (var db = new EFContext())
            {
                try
                {
                    Categorie categorie = db.Categories.Find(i);
                    categorie.Libelle = libel;
                    db.SaveChanges();
                }
                catch (NullReferenceException e)
                {

                    Console.WriteLine("Entrez une Id valide");

                }




            }
                return;
            }

            static void readCategories()
            {

                using (var db = new EFContext())
                {

                    List<Categorie> categories = db.Categories.ToList();
                    foreach (Categorie c in categories)
                    {
                        Console.WriteLine("{0} {1}", c.Id, c.Libelle);
                    }

                }

            }
            /*
            static void insertCategorie(string libel)
            {
                using (var db = new EFContext())
                {
                    Categorie categorie = new Categorie();
                    categorie.Libelle = libel;
                    //categorie.Libelle = "Sport";
                    db.Add(categorie);
                    //categorie = new Categorie();
                    //categorie.Libelle = "Food";
                    //db.Add(categorie);
                    db.SaveChanges();
                }
                return;
            }
           

         */

    }

}
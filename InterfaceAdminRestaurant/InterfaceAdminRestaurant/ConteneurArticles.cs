using System;
using System.Collections.Generic;
using System.Linq;

namespace InterfaceAdminRestaurant
{
    public class ConteneurArticles
    {
        private static readonly ConteneurArticles _instance = new ConteneurArticles();

        public static ConteneurArticles Instance => _instance;

        public List<Nouriture> Nouritures { get; private set; }
        public List<Boisson> Boissons { get; private set; }
        public List<Frites> Frites { get; private set; }
        public List<Menu> Menus { get; private set; }


        private ConteneurArticles()
        {
            Nouritures = new List<Nouriture>();
            Boissons = new List<Boisson>();
            Frites = new List<Frites>();
            Menus = new List<Menu>();
        }
        public void AjouterMenu(Menu menu)
        {
            Menus.Add(menu);
        }
        public void AjouterArticle(Article article)
        {
            switch (article)
            {
                case Nouriture n:
                    Nouritures.Add(n);
                    break;
                case Boisson b:
                    Boissons.Add(b);
                    break;
                case Frites f:
                    Frites.Add(f);
                    break;
                default:
                    throw new Exception("Type d'article inconnu.");
            }
        }

        public void SupprimerArticleById(int id)
        {
            var nouriture = Nouritures.FirstOrDefault(n => n.NumeroArticle == id);
            if (nouriture != null)
            {
                Nouritures.Remove(nouriture);
                return;
            }

            var boisson = Boissons.FirstOrDefault(b => b.NumeroArticle == id);
            if (boisson != null)
            {
                Boissons.Remove(boisson);
                return;
            }

            var frites = Frites.FirstOrDefault(f => f.NumeroArticle == id);
            if (frites != null)
            {
                Frites.Remove(frites);
                return;
            }

            Menus.RemoveAll(m =>
                (m.nouriture != null && m.nouriture.NumeroArticle == id) ||
                (m.boisson != null && m.boisson.NumeroArticle == id) ||
                (m.frites != null && m.frites.NumeroArticle == id)
            );
        }

        public void SupprimerMenuById(int id)
        {
            var menu = Menus.FirstOrDefault(m => m.idMenu == id);
            if (menu != null)
            {
                Menus.Remove(menu);
            }
        }



        public object? ObtenirArticleParId(int id)
        {
            var nouriture = Nouritures.FirstOrDefault(n => n.NumeroArticle == id);
            if (nouriture != null) return nouriture;

            var boisson = Boissons.FirstOrDefault(b => b.NumeroArticle == id);
            if (boisson != null) return boisson;

            var frites = Frites.FirstOrDefault(f => f.NumeroArticle == id);
            if (frites != null) return frites;

            return null;
        }

        public Menu? ObtenirMenuParId(int id)
        {
            Menu? menu = Menus.FirstOrDefault(m => m.idMenu == id);
            return menu;
        }


        public List<object> ObtenirTousLesArticlesSansMenus()
        {
            List<object> articlesSansMenus = new List<object>();

            articlesSansMenus.AddRange(Nouritures);
            articlesSansMenus.AddRange(Boissons);
            articlesSansMenus.AddRange(Frites);

            return articlesSansMenus;
        }

        public List<Menu> ObtenirTousLesMenus()
        {
            return Menus.ToList();
        }


        public void Vider()
        {
            Nouritures.Clear();
            Boissons.Clear();
            Frites.Clear();
            Menus.Clear();
        }
    }
}

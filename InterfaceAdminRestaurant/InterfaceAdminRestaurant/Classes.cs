using System;
using System.ComponentModel.DataAnnotations;

namespace InterfaceAdminRestaurant
{
    public class Article
    {
        private static int compteurArticle = 0;
        public int NumeroArticle { get; }
        public string Nom { get; set; }
        public decimal Prix { get; set; }
        public string cheminImage { get; set; }

        public Article(string nom, decimal prix, string cheminImage)
        {
            
            if (string.IsNullOrWhiteSpace(nom))
            {
                throw new ArticleException("Le nom ne doit pas être null ou vide.");
            }
            this.Nom = nom;
            if (prix < 0)
            {
                throw new ArticleException("Le prix doit être supérieur à zéro.");
            }
            this.Prix = prix;
            if (string.IsNullOrWhiteSpace(cheminImage))
            {
                throw new ArticleException("Le chemin de l'image n'est pas correct.");
            }
            this.cheminImage = cheminImage;
            NumeroArticle = ++compteurArticle;
        }

        public override string ToString()
        {
            return $"Numéro: {NumeroArticle}, Nom: {Nom}, Prix: {Prix}€, Image: {cheminImage}";
        }
    }

    public class Nouriture : Article
    {
        public char Taille { get; set; }
        public bool EstVegetarienne { get; set; }

        public Nouriture(string nom, decimal prix, char taille, bool estVegetarienne, string cheminImage)
            : base(nom, prix, cheminImage)
        {
            if (new[] { 'S', 'M', 'L' }.Contains(taille))
            {
                this.Taille = taille;
            }
            else
            {
                throw new NouritureException("La taille de la nourriture doit être S/M/L.");
            }
            EstVegetarienne = estVegetarienne;
        }

        public override string ToString()
        {
            return base.ToString() + $", Taille: {Taille}, Végétarien: {(EstVegetarienne ? "Oui" : "Non")}";
        }
    }

    public class Boisson : Article
    {
        public int Volume { get; set; }
        public bool EstSucree { get; set; }

        public Boisson(string nom, decimal prix, int volume, bool estSucree, string cheminImage)
            : base(nom, prix, cheminImage)
        {
            if (volume <= 0)
            {
                throw new BoissonException("Le volume de la boisson doit être supérieur à zéro.");
            }
            Volume = volume;
            EstSucree = estSucree;
        }

        public override string ToString()
        {
            return base.ToString() + $", Volume: {Volume}ml, Sucrée: {(EstSucree ? "Oui" : "Non")}";
        }
    }

    public class Frites : Article
    {
        public string Taille { get; set; }

        public Frites(string nom, decimal prix, string taille, string cheminImage)
            : base(nom, prix, cheminImage)
        {
            if (new[] { "S", "M", "L" }.Contains(taille))
            {
                Taille = taille;
            }
            else
            {
                throw new FritesException("La taille des frites doit être S/M/L.");
            }
        }

        public override string ToString()
        {
            return base.ToString() + $", Taille: {Taille}";
        }
    }

    public class Menu
    {
        static int compteurMenu = 0;
        public int idMenu { get; set; }
        public Nouriture nouriture { get; set; }
        public Boisson boisson { get; set; }
        public Frites frites { get; set; }

        public Menu(Nouriture nouriture, Boisson boisson, Frites frites)
        {
            if (nouriture == null || boisson == null || frites == null)
            {
                throw new MenuException("les trois articles doivent étre présents.");
            }
            compteurMenu++;
            this.idMenu = compteurMenu;
            this.nouriture = nouriture;
            this.boisson = boisson;
            this.frites = frites;
        }
        public override string ToString()
        {
            return $"le idmenu est : "+ this.idMenu +this.nouriture.ToString() + this.boisson.ToString() + this.frites.ToString();
        }
    }

}

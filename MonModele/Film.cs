using System;
using System.Collections.Generic;
using System.Text;

namespace MonModele
{
    [Serializable()]
    public class Film : IEquatable<Film>
    {
        /// <param name="titre"></param>
        /// <param name="description"></param>
        /// <param name="lienVideo"></param>
        /// <param name="lienImage"></param>
        /// <param name="numUtilisateur"></param>
        /// <param name="nom"></param>
        /// <param name="prenom"></param>
        /// 
        public Film (string titre,string description,string lienVideo,string lienImage,int numUtilisateur, string nom,string prenom)
        {
            Titre = titre; Description = description; LienVideo = lienVideo; LienImage = lienImage; NumUtilisateur = numUtilisateur;
            real = new Realisateur(nom,prenom);
        }

        public Film(string titre, string description, string lienVideo, string lienImage, int numUtilisateur, Realisateur realisateur)
        {
            Titre = titre; Description = description; LienVideo = lienVideo; LienImage = lienImage; NumUtilisateur = numUtilisateur;
            real = realisateur;
        }

        public Film()
        {
           
        }
        // PARTIE TITRE //
        public string Titre { get; }

        // PARTIE DESCRIPTION //
        public string Description { get; }

        // PARTIE LIEN VIDEO //
        public string LienVideo { get;  }

        // PARTIE LIEN IMAGE //
        public string LienImage { get; }
        
        // PARTIE NUMERO //
        public int NumUtilisateur { get; }

        public Realisateur real { get; private set;  }

        public bool Equals(Film other)
        {
            if (other.Titre == this.Titre) return true;
            return false;
        }
        
        /// <summary>
        /// Cette méthode prend un objet le compare.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)) return false; //vérifie pas nul
            if (ReferenceEquals(obj, this)) return true; //vérifie pas lui-même
            if (GetType() != obj.GetType()) return false; //vérifie le type
            return Equals(obj as Film);
        }
        
        public override int GetHashCode()
        {
            return Titre.GetHashCode();
        }
        
        /// <summary>
        /// Méthode ToString pour afficher le titre du film
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return  Titre.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace MonModele
{
    [Serializable()]
    public class Realisateur
    {
        
        /// <param name="nom"></param>
        /// <param name="prenom"></param>
        public Realisateur(string nom, string prenom)
        {
            Nom = nom; Prenom = prenom;
        }

        public Realisateur()
        {
        }
        // PARTIE NOM //
        public string Nom { get; }

        // PARTIE Prénom //
        public string Prenom { get; }

        public override string ToString()
        {
            return "Réalisé par : " + Nom.ToString() + " " + Prenom.ToString();
        }
    }
}

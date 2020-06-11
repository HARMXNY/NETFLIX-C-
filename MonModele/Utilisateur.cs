using System;
using System.Collections.Generic;
using System.Text;

namespace MonModele
{
    [Serializable()]
    public class Utilisateur
    {

        /// <param name="nom"></param>
        /// <param name="age"></param>
        /// <param name="avatar"></param>
        /// <param name="numero"></param>
        /// <param name="admin"></param>
        public Utilisateur(string nom, int age, string avatar, int numero, bool admin)
        {
            Nom = nom; Age = age; Avatar = avatar; Numero = numero; Admin = admin;
        }

        // PARTIE NOM //
        public string Nom {get; set;}

        // PARTIE AGE //
        public int Age { get; set;}
        
        // PARTIE AVATAR //
        public string Avatar { get; set; }

        // PARTIE NUMERO //
        //Le numéro sert pour les films et également savoir qui se connecte (de 1 à 4)
        public int Numero { get; set; }

        private bool Admin { get; }

        public override string ToString()
        {
            return $"{Nom} - {Age}";
        }
    }
}

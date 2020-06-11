using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace MonModele
{
    /// <summary>
    /// Classe de stockage d'utilisateur
    /// </summary>
    [Serializable]
    public class EnsembleUtilisateur : IPersistance
    {
        /// <summary>
        /// ObservableCollection d'utilisateurs
        /// </summary>
        public ObservableCollection<Utilisateur> LesUtilisateurs { get; set; }

        /// <summary>
        /// Constructeur d'un EnsembleUtilisateur
        /// </summary>
        public EnsembleUtilisateur()
        {
            LesUtilisateurs = new ObservableCollection<Utilisateur>();
        }

        /// <summary>
        /// Cette méthode ajoute un utilisateur en première position de la liste
        /// </summary>
        /// <param name="user"></param>
        public void ajouterUtilisateur(Utilisateur user)
        {
            LesUtilisateurs.Insert(0, user);           
        }

        /// <summary>
        /// Cette fonction retourne un utilisateur contenu dans la liste en donnant le nom de celui ci
        /// </summary>
        /// <param name="lenom"></param>
        /// <returns></returns>
        public Utilisateur this[string lenom]
        {
            get
            {
                foreach (Utilisateur n in LesUtilisateurs)
                {
                    if (n.Nom == lenom)
                    {
                        return n;
                    }
                }
                return null;
            }
        }

        /// <summary>
        /// Cette méthode sauvegarde l'enssemble film dans le fichier "user.bin"
        /// </summary>
        public void Sauvegarde()
        {
            //sauvegarde utilisateurs
            List<Utilisateur> mesUtilisateurs = new List<Utilisateur>();
            foreach (Utilisateur item in LesUtilisateurs)
            {
                mesUtilisateurs.Add(item);
            }
            
            using (Stream stream = File.Open("users.bin", FileMode.Create))
            {
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(stream, mesUtilisateurs);
            }
        }

        /// <summary>
        /// Cette méthode charge les utilisateurs contenu dans user.bin dans une liste. Et les ajoute ensuite dans un EnsembleUtilisateurs
        /// </summary>
        public void Chargement()
        {             
                 using (Stream stream = File.Open("users.bin", FileMode.Open))
                 {
                     BinaryFormatter bin = new BinaryFormatter();
            
                     var lizards2 = (List<Utilisateur>)bin.Deserialize(stream);
                     foreach (Utilisateur users in lizards2)
                     {
                         LesUtilisateurs.Add(users);
                     }
                 }
             
        }


    }
}

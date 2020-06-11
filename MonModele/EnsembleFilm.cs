using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MonModele
{
    /// <summary>
    /// Classe de stockage de film
    /// </summary>
    [Serializable]
    public class EnsembleFilm : IPersistance
    {
        /// <summary>
        /// ObservableCollection de films
        /// </summary>
        public ObservableCollection<Film> LesFilms { get; set; }

        /// <summary>
        /// Constructeur d'un EmsembleFilm
        /// </summary>
        public EnsembleFilm()
        {
            LesFilms = new ObservableCollection<Film>();
        }

        /// <summary>
        /// Cette méthode prend en paramétre un utilisateur et retourne un EnsembleFilm de films mis en ligne par l'utilisateur
        /// </summary>
        /// <param name="personne"></param>
        /// <returns></returns>
        public EnsembleFilm Trier(Utilisateur personne)
        {
            if(personne.Numero==0)
            {
                return this;
            }
            EnsembleFilm ListeTrié = new EnsembleFilm();
            foreach (Film item in LesFilms)
            {
                if (item.NumUtilisateur.Equals(personne.Numero))
                {
                    ListeTrié.LesFilms.Add(item);
                }
            }
            return ListeTrié;
        }
        /// <summary>
        /// Cette méthode retourne le Film correspondant au titre donné
        /// </summary>
        /// <param name="titre"></param>
        /// <returns></returns>
        public Film this[string titre]
        {
            get
            {
                foreach (Film n in LesFilms)
                {
                    if (n.Titre == titre)
                    {
                        return n;
                    }
                }
                return null;
            }
        }
        /// <summary>
        /// Cette méthode sauvegarde l'enssemble film dans le fichier "data.bin"
        /// </summary>
        public void Sauvegarde()
        {
            //sauvegarde films
            List<Film> mesFilms = new List<Film>();
            foreach (Film item in LesFilms)
            {
                mesFilms.Add(item);
            }
            
            using (Stream stream = File.Open("data.bin", FileMode.Create))
            {
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(stream, mesFilms);
            }
            
        }
        /// <summary>
        /// Cette méthode vérifie l'existance du fichier "data.bin" et charge les films dans une liste et ajoute les films dans ensemble film en vérifiant qu'ils n'y sont pas déjà
        /// </summary>
        public void Chargement()
        {
        
            if (File.Exists("data.bin"))
            {
                using (Stream stream = File.Open("data.bin", FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();
        
                    var lizards2 = (List<Film>)bin.Deserialize(stream);
                    foreach (Film filmin in lizards2)
                    {
                        //contains implémente equals
                        if(!LesFilms.Contains(filmin))
                        {
                            LesFilms.Add(filmin);
                        }
                        
                    }
                }
            }
        }

    }
}

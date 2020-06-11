using System;
using MonModele;
using Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Collections;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            EnsembleFilm listefilms = Data.Stub.CreeListfilmDeBase();
            EnsembleUtilisateur listeuser = Data.Stub.CreeUtilisateur();
            Console.WriteLine("===== Les Users =====");
            for (int i = 0; i < listeuser.LesUtilisateurs.Count; i++)
            {
                Console.WriteLine(listeuser.LesUtilisateurs[i].ToString());
            }
            //Ajout Films :
            listefilms.LesFilms.Add(new Film("Test1", "Description1", "Video1", "Img1", listeuser.LesUtilisateurs[0].Numero, new Realisateur("Real", "1")));
            listefilms.LesFilms.Add(new Film("Test2", "Description2", "Video2", "Img2", listeuser.LesUtilisateurs[1].Numero, new Realisateur("Real", "2")));
            listefilms.LesFilms.Add(new Film("Test3", "Description3", "Video3", "Img3", listeuser.LesUtilisateurs[2].Numero, new Realisateur("Real", "3")));
            listefilms.LesFilms.Add(new Film("Test4", "Description4", "Video4", "Img4", listeuser.LesUtilisateurs[3].Numero, new Realisateur("Real", "4")));
            Console.WriteLine("===== Les Films =====");
            for (int i = 0; i < listefilms.LesFilms.Count; i++)
            {
                Console.WriteLine(listefilms.LesFilms[i].ToString());
            }
            //Trier les films :
            Console.WriteLine("===== Les Films de l'utilisateur 1 =====");
            EnsembleFilm filmstrie1 = listefilms.Trier(listeuser.LesUtilisateurs[0]);
            for (int i = 0; i < filmstrie1.LesFilms.Count; i++)
            {
                Console.WriteLine(filmstrie1.LesFilms[i].ToString());
            }

            //Suppression de film :
            Console.WriteLine("===== Suppression Film =====");

            //usage film
            listefilms.LesFilms.Remove(new Film("Test1", "Description1", "Video1", "Img1", listeuser.LesUtilisateurs[0].Numero, new Realisateur("Real", "1")));
           
            //usage indexer
            if(listefilms["Test2"] != null)
            {
                listefilms.LesFilms.Remove(listefilms["Test2"]);
            }
            for (int i = 0; i < listefilms.LesFilms.Count; i++)
            {
                Console.WriteLine(listefilms.LesFilms[i].ToString());
            }
        }
    }
}

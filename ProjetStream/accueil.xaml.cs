using ProjetStream.UCF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Media;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Data;
using MonModele;
using MaterialDesignThemes.Wpf;

namespace ProjetStream
{
    /// <summary>
    /// Logique d'interaction pour Principal2.xaml
    /// </summary>
    public partial class accueil : Window
    {
        Utilisateur user;
        public Boolean colorflind = false;

        public accueil(Utilisateur unuser)
        {          
            InitializeComponent();            
            affichagefilms.DataContext = (Application.Current as App).allFilms;
            choixpersonne.DataContext = (Application.Current as App).allUtilisateur;
            (Application.Current as App).allUtilisateur.ajouterUtilisateur(new Utilisateur("Tous", 0, "", 0, false));
            this.user = unuser;
            //partie image
            icon.Source = new BitmapImage(new Uri(@user.Avatar, UriKind.RelativeOrAbsolute));

            if (user.Numero == 4)
            {
                this.Suppression.Visibility = Visibility.Visible;
            }
        }



        private void Profil(object sender, RoutedEventArgs e)
        {
            menu menuv1 = new menu(user, colorflind);
            (Application.Current as App).allUtilisateur.LesUtilisateurs.Remove((Application.Current as App).allUtilisateur["Tous"]);
            video.Display("");
            this.Close();
            menuv1.Show();
        }

        private void Ajout(object sender, RoutedEventArgs e)
        {
            AjoutFilm ajout = new AjoutFilm(user);
            var converter = new System.Windows.Media.BrushConverter();
            ajout.changecolorblind(colorflind);
            ajout.ShowDialog();
        }

        private void Deco(object sender, RoutedEventArgs e)
        {

            MainWindow co = new MainWindow();
            //supprimer le tous
            (Application.Current as App).allUtilisateur.LesUtilisateurs.Remove((Application.Current as App).allUtilisateur["Tous"]);
            video.Display("");
            this.Close();
            co.Show();
        }

        private void Fermer(object sender, RoutedEventArgs e)
        {
            (Application.Current as App).allUtilisateur.LesUtilisateurs.Remove((Application.Current as App).allUtilisateur["Tous"]);
            (Application.Current as App).allFilms.Sauvegarde();
            (Application.Current as App).allUtilisateur.Sauvegarde();
            this.Close();
        }

        private void Supprimer(object sender, RoutedEventArgs e)
        {
            SuppressionFilm co = new SuppressionFilm();
            co.changecolorblind(colorflind);
            co.ShowDialog();
        }   

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            (Application.Current as App).allUtilisateur.LesUtilisateurs.Remove((Application.Current as App).allUtilisateur["Tous"]);
            (Application.Current as App).allFilms.Sauvegarde();
            (Application.Current as App).allUtilisateur.Sauvegarde();
        }

        private void TrierLesFilms(object sender, SelectionChangedEventArgs e)
        {
            if (choixpersonne.SelectedItem != null)
            {
                Utilisateur test = (Utilisateur)choixpersonne.SelectedItem;
                affichagefilms.DataContext = (Application.Current as App).allFilms.Trier(test);
                affichagefilms.SelectedIndex = 0;
            }
        }

        private void Affichagefilms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (affichagefilms.SelectedItem != null)
            {
                //récupérer le film
                Film lefilm = (Film)affichagefilms.SelectedItem;
                video.Display(lefilm.LienVideo.ToString());
            }
            else
            {
                video.Display("");
            }           
        }

        //recherche de film
        private void BarreRecherche_TextChanged(object sender, TextChangedEventArgs e)
        {
            EnsembleFilm filmschange = new EnsembleFilm();
            if (string.IsNullOrEmpty(BarreRecherche.Text) == false)
            {
                foreach (Film item in (Application.Current as App).allFilms.LesFilms)
                {
                    string titrelower = item.Titre.ToLower();
                    if (titrelower.StartsWith(BarreRecherche.Text.ToLower()))
                    {
                        filmschange.LesFilms.Add(item);
                    }
                }
            }
            else if (BarreRecherche.Text == "")
            {
                foreach (Film item in (Application.Current as App).allFilms.LesFilms)
                {
                        filmschange.LesFilms.Add(item);
                }
            }
            affichagefilms.DataContext = filmschange;
            affichagefilms.SelectedIndex = 0;
        }

        //colorblind
        private void Colorblind(object sender, RoutedEventArgs e)
        {
            if (colorflind==false)
            {               
                colorflind = true;
                video.changecolorblind(colorflind);             
                
            }
            else
            {
                colorflind = false;
                video.changecolorblind(colorflind);
            }
        }

        private void Ecran_KeyUp(object sender, KeyEventArgs e)
        {
            int nb = (Application.Current as App).allFilms.LesFilms.Count;
            if (e.Key == Key.Right)
            {
                if (affichagefilms.SelectedIndex >= nb-1) { affichagefilms.SelectedIndex = 0; }
                else { affichagefilms.SelectedIndex += 1; }
            }
            else if(e.Key == Key.Left)
            {
                if (affichagefilms.SelectedIndex == 0) { affichagefilms.SelectedIndex = nb-1; }
                else { affichagefilms.SelectedIndex -= 1; }
            }
        }
    }

}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
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

namespace ProjetStream
{
    /// <summary>
    /// Cette page permet de modifier son profil en ayant le choix de modifier son pseudo, son age et son image de profil
    /// </summary>
    public partial class menu : Window
    {
        Utilisateur user;

        //Nous définissons un compteur et notre liste d'images
        private static int i;
        private static int compteur;
        private static string[] MaListeDImages = new string[]
        {
            "/Ressources;Component/img/avatar/monster/1.jpg",
            "/Ressources;Component/img/avatar/monster/2.jpg",
            "/Ressources;Component/img/avatar/monster/3.jpg",
            "/Ressources;Component/img/avatar/monster/4.jpg",
            "/Ressources;Component/img/avatar/monster/5.jpg",
            "/Ressources;Component/img/avatar/monster/6.jpg",
            "/Ressources;Component/img/avatar/monster/7.jpg",
            "/Ressources;Component/img/avatar/netflix/1.png",
            "/Ressources;Component/img/avatar/netflix/2.png",
            "/Ressources;Component/img/avatar/netflix/3.png",
            "/Ressources;Component/img/avatar/netflix/4.png",
        };

        bool macouleur;
        /// <summary>
        /// Lors de l'appel du menu, nous envoyons en paramétres un utilisateur et un booleen pour définir si l'utilisateur est daltonien ou non
        /// </summary>
        /// <param name="user"></param>
        /// <param name="color"></param>
        public menu(Utilisateur user, bool color)
        {
            InitializeComponent();
            //Maj de la couleur
            macouleur = color;
            changecolorblind(color);
            //Mise à jours des informations
            nom.Text = user.Nom;
            age.Text = user.Age.ToString();
            this.user = user;
            string lienimg = ComparaisonDebut();
            choiximage.Source = new BitmapImage(new Uri(lienimg, UriKind.RelativeOrAbsolute));
            i = user.Numero;
        }

        //Bouton pour annuler
        private void Annuler(object sender, RoutedEventArgs e)
        {
            accueil ecran = new accueil(user);
            ecran.video.changecolorblind(macouleur);
            ecran.colorflind = macouleur;
            this.Close();
            ecran.Show();
        }
        
        //Bouton pour valider et ainsi modifier les informations
        private void Valider(object sender, RoutedEventArgs e)
        {
            if (nom.Text.ToString() == "")
            {
                MessageBox.Show("Saisir un Nom");
            }
                
            else if (age.Text.ToString() == "")
            {                               
                MessageBox.Show("Saisir un Age");
            }           
            else if (compteur != 0){
                user.Nom = nom.Text;
                user.Age = int.Parse(age.Text);
                user.Avatar = MaListeDImages[compteur];
                accueil accueil = new accueil(user);
                accueil.video.changecolorblind(macouleur);
                accueil.colorflind = macouleur;
                this.Close();
                accueil.Show();
            }
            else
            {
                user.Nom = nom.Text;
                user.Age = int.Parse(age.Text);
                user.Avatar = ComparaisonDebut();
                accueil ma = new accueil(user);
                ma.video.changecolorblind(macouleur);
                ma.colorflind = macouleur;
                this.Close();
                ma.Show();
            }
            
            
        }

        private void VerificationNum(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private string ComparaisonDebut()
        {
            int i=0;
            String Imagebase = user.Avatar;
            foreach(String img in MaListeDImages)
            {
                if (img == Imagebase)
                {                    
                    return MaListeDImages[i];
                }
                i++;
            }
            return MaListeDImages[i];

        }

        private void ButonSuivant(object sender, RoutedEventArgs e)
        {
            compteur += 1;
            if (compteur == MaListeDImages.Length) compteur = 0;
            choiximage.Source = new BitmapImage(new Uri(MaListeDImages[compteur], UriKind.RelativeOrAbsolute));

        }
        //activer la sauvegarde et ferme l'appli
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            (Application.Current as App).allFilms.Sauvegarde();
            (Application.Current as App).allUtilisateur.Sauvegarde();
        }

        private void ButonPrecedant(object sender, RoutedEventArgs e)
        {            
            if (compteur == 0) compteur = MaListeDImages.Length;
            compteur -= 1;
            choiximage.Source = new BitmapImage(new Uri(MaListeDImages[compteur], UriKind.RelativeOrAbsolute));

        }

        public void changecolorblind(bool color)
        {
            if (color == true)
            {
                var converter = new System.Windows.Media.BrushConverter();
                var brush = (Brush)converter.ConvertFromString("#D3841D");
                bouttonvalider.Background = brush;
                flechegauche.Foreground = brush;
                flechedroite.Foreground = brush;
            }
            else
            {
                var converter = new System.Windows.Media.BrushConverter();
                var brush = (Brush)converter.ConvertFromString("#831010");
                bouttonvalider.Background = brush;
                flechegauche.Foreground = brush;
                flechedroite.Foreground = brush;
            }
        }
    }
}

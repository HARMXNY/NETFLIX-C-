using System;
using System.Collections.Generic;
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

namespace ProjetStream
{
    /// <summary>
    /// Logique d'interaction pour AjoutFilm.xaml
    /// </summary>
    public partial class AjoutFilm : Window
    {
        Utilisateur luser;
        public AjoutFilm(Utilisateur user)
        {
            InitializeComponent();
            this.luser = user;
        }

        private void validerfilm(object sender, RoutedEventArgs e)
        {
            if (image.Text.ToString() == "" || image.Text.ToString() == "Image")
            {
                MessageBox.Show("Saisir une image");
            }
            else if (video.Text.ToString() == "" || video.Text.ToString() == "Vidéo")
            {
                MessageBox.Show("Saisir une vidéo");
            }
            else if (titrefilm.Text.ToString() == "" || titrefilm.Text.ToString() == "Titre")
            {
                MessageBox.Show("Saisir un titre");
            }
            else if (description.Text.ToString() == "" || description.Text.ToString() == "Description")
            {
                MessageBox.Show("Saisir une description");
            }
            else
            {
                (Application.Current as App).allFilms.LesFilms.Add(new Film(titrefilm.Text.ToString(), description.Text.ToString(), video.Text.ToString(), image.Text.ToString(), luser.Numero,nomdurealisateur.Text.ToString(), prenomdurealisateur.Text.ToString()));
                Close();

            }

        }

        public void changecolorblind(bool color)
        {
            if (color == true)
            {
                var converter = new System.Windows.Media.BrushConverter();
                var brush = (Brush)converter.ConvertFromString("#D3841D");
                bouttonvalid.Background = brush;

            }
            else
            {
                var converter = new System.Windows.Media.BrushConverter();
                var brush = (Brush)converter.ConvertFromString("#831010");
                bouttonvalid.Background = brush;

            }
        }

        private void Annuler(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

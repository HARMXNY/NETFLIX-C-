using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Data;
using MonModele;

namespace ProjetStream
{
    /// <summary>
    /// Cette page est le code behind de la page de suppression
    /// </summary>
    public partial class SuppressionFilm : Window
    {
        /// <summary>
        /// Durant l'appel de la page, nous définissons le datacontext
        /// </summary>
        public SuppressionFilm()
        {
            InitializeComponent();
            affichagelistefilms.DataContext = (Application.Current as App).allFilms;
        }

        // La fonction de suppression permet de supprimer le film selectionné
        private void supprimerfilm(object sender, RoutedEventArgs e)
        {                           
            if(affichagelistefilms.SelectedItem != null)
            {
                (Application.Current as App).allFilms.LesFilms.Remove((Film)affichagelistefilms.SelectedItem);
                this.Close();
            }
        }

        //Ici, nous fermons la page quand nous cliquons sur le bouton annuler
        private void Annuler(object sender, RoutedEventArgs e)
        {
            Close();
        }

        //Cette fonction permet d'adapter les couleurs pour les personnes atteintent de daltonisme
        public void changecolorblind(bool color)
        {
            if (color == true)
            {
                var converter = new System.Windows.Media.BrushConverter();
                var brush = (Brush)converter.ConvertFromString("#D3841D");
                suppression.Background = brush;

            }
            else
            {
                var converter = new System.Windows.Media.BrushConverter();
                var brush = (Brush)converter.ConvertFromString("#831010");
                suppression.Background = brush;

            }
        }
    }
    
}

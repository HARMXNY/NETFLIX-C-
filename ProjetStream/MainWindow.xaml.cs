using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using ProjetStream.UCF;


namespace ProjetStream
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            afficheurUtilisateur.DataContext = (Application.Current as App).allUtilisateur;
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            (Application.Current as App).allFilms.Sauvegarde();
            (Application.Current as App).allUtilisateur.Sauvegarde();
        }

        private void ChoixProfil(object sender, MouseButtonEventArgs e)
        {
            if(afficheurUtilisateur.SelectedItem != null)
            {
                Utilisateur user = (Utilisateur)afficheurUtilisateur.SelectedItem;
                accueil accueil = new accueil(user);
                this.Close();
                accueil.Show();
            }            
        }
    }
}

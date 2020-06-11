using Data;
using MonModele;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ProjetStream
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public EnsembleFilm allFilms = Data.Stub.CreeListfilmDeBase();
        public EnsembleUtilisateur allUtilisateur = Data.Stub.CreeUtilisateur();

    }
}

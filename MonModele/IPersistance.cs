using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace MonModele
{
    /// <summary>
    /// Cette interface pointe sur EnsembleFilm et EnsembleUtilisateur, permetant la sauvegarde et le chargement
    /// </summary>
    interface IPersistance
    {
        void Sauvegarde();    
        void Chargement();             

    }
}

using System;
using MonModele;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;

namespace Data
{
    public class Stub
    {
       // public static Utilisateur CreeUtilisateur()
       // {
       //     Utilisateur Perso1 = new Utilisateur("François", 19, "", 1, false);
       //     EnsembleFilm listefilms = new EnsembleFilm();
       //
       //     listefilms.ajouterFilm(new Film("DoubleV", "", "", "", 2, "Cyril", "Toffin"));
       //
       //     return Perso1;
       // }

        public static EnsembleUtilisateur CreeUtilisateur()
        {
            EnsembleUtilisateur listeutilisateur = new EnsembleUtilisateur();
            if (File.Exists("users.bin"))
            {
                listeutilisateur.Chargement();
            }
            else
            {
                listeutilisateur.ajouterUtilisateur(new Utilisateur("Eminem", 46, "/Ressources;Component/img/avatar/monster/5.jpg", 4, true));
                listeutilisateur.ajouterUtilisateur(new Utilisateur("Yannis", 19, "/Ressources;Component/img/avatar/netflix/4.png", 3, false));
                listeutilisateur.ajouterUtilisateur(new Utilisateur("Jérémy", 19, "/Ressources;Component/img/avatar/monster/2.jpg", 2, false));
                listeutilisateur.ajouterUtilisateur(new Utilisateur("François", 19, "/Ressources;Component/img/avatar/monster/2.jpg", 1, false));
            }
            return listeutilisateur;
        }

        public static EnsembleFilm CreeListfilmDeBase()
        {
            EnsembleFilm listefilms = new EnsembleFilm();
            listefilms.LesFilms.Add(new Film("La Casa de papel", "La Casa de Papel, c’est avant tout l’histoire d’un braquage. La série raconte comment le professeur a tout préparé et organisé afin de commettre le braquage parfait au sein de la fabrique Nationale de monnaies et de timbres. Pour réussir son plan, le professeur a recruté 8 repris de justice qui se font appeler par des noms de villes afin de protéger leurs identités. Ainsi, Tokyo, Nairobi, Río, Moscou, Berlin, Denver, Helsinki et Oslo vont se retrouver enfermer durant une dizaine de jour dans la fabrique afin d’imprimer 2.4 milliards d’euros. Dans le même temps, le professeur jouera avec la police pour gagner du temps et anticiper leurs actions.", "https://www.youtube.com/watch?v=_yJxbWKN3zE", "https://static.lpnt.fr/images/2020/04/03/20218901lpw-20219011-article-jpg_7023192_1250x625.jpg", 0, new Realisateur("Test","lefameux")));
            listefilms.LesFilms.Add(new Film("Stranger Things", "En 1983, à Hawkins dans l'Indiana, Will Byers disparaît de son domicile. Ses amis se lancent alors dans une recherche semée d'embûches pour le retrouver. Pendant leur quête de réponses, les garçons rencontrent une étrange jeune fille en fuite.", "https://www.youtube.com/watch?v=wQoHfKDncLU", "https://media.virginradio.fr/article-4045254-head-f5/stranger-things-saison-4.jpg", 0, "Michel", "Micholac"));
            listefilms.LesFilms.Add(new Film("Locke & Key", "Après le meurtre de leur père dans d’étranges circonstances, les frères et sœurs Locke emménagent avec leur mère à Keyhouse, leur maison ancestrale, où ils découvrent des clés magiques potentiellement liées à la mort de leur père.  Alors que les enfants Locke explorent les pouvoirs uniques de ces clés, un mystérieux démon s'éveille et ne reculera devant rien pour les leur voler. ", "https://www.youtube.com/watch?v=Gc4iXDmSC_E", "https://fr.web.img4.acsta.net/newsv7/20/03/30/17/32/5333349.jpg", 0, "Michel", "Micholac"));
            listefilms.LesFilms.Add(new Film("Outer Banks", "En déterrant un secret enfoui depuis longtemps, des ados déclenchent une série d'événements malencontreux qui les entraînent dans des aventures inoubliables.", "https://www.youtube.com/watch?v=VVNmO3J8tYA", "https://www.telerama.fr/sites/tr_master/files/styles/simple_crop_ilustration_285px/public/outerbanks_101_sg_00002r2.jpg?itok=yw-CgCAf", 0, "Michel", "Micholac"));
            listefilms.LesFilms.Add(new Film("THE END OF THE F***ING WORLD", "Un ado psychopathe en herbe et une rebelle en quête d'aventure embarquent pour un road trip d'enfer dans cette série à l'humour noir inspirée d'un roman graphique. ", "https://www.youtube.com/watch?v=iwvpyzTvycE", "https://media.ouest-france.fr/v1/pictures/MjAxODAxMGQ4NmNhYzM4NmViZTAxYTdhOGVhZTQyNDMzYTAwNjE?width=480&height=270&focuspoint=50%2C25&cropresize=1&client_id=bpeditorial&sign=966d0e433ea7722da67a60f61e99bc62c0eb3d73f45c3640639bfb9c47ef5fff", 0, "Michel", "Micholac"));
            listefilms.LesFilms.Add(new Film("Elite", "Las Encinas est l’école la plus compétitive et huppée d’Espagne accueillant les enfants de l’élite. C’est également dans cette école que trois enfants de la classe ouvrière sont admis lorsque leur école est détruite et que les étudiants sont alors répartis dans plusieurs établissements. Ils pensaient être chanceux… mais peut-être ne le sont-ils pas tant que cela ? La confrontation entre ceux qui ont tout et ceux qui n’ont rien est explosive, et aboutira à un meurtre. Qui est vraiment derrière ce crime ? Est-ce l’un des nouveaux arrivants ? Ou se cache-t-il quelque chose de plus sombre ? ", "https://www.youtube.com/watch?v=pr8gOKsF6ek", "https://tel.img.pmdstatic.net/fit/http.3A.2F.2Fprd2-bone-image.2Es3-website-eu-west-1.2Eamazonaws.2Ecom.2Ftel.2F2020.2F03.2F13.2F835cccbf-2d9f-42de-a655-6a96f968ce56.2Ejpeg/1200x500/crop-from/top/quality/80/elite-netflix-y-aura-t-il-une-saison-4.jpg", 0, "Michel", "Micholac"));
            listefilms.LesFilms.Add(new Film("Avengers : Endgame", "Le Titan Thanos, ayant réussi à s'approprier les six Pierres d'Infinité et à les réunir sur le Gantelet doré, a pu réaliser son objectif de pulvériser la moitié de la population de l'Univers. Cinq ans plus tard, Scott Lang, alias Ant-Man, parvient à s'échapper de la dimension subatomique où il était coincé. Il propose aux Avengers une solution pour faire revenir à la vie tous les êtres disparus, dont leurs alliés et coéquipiers : récupérer les Pierres d'Infinité dans le passé.", "https://www.youtube.com/watch?v=wV-Q0o2OQjQ", "https://img.bfmtv.com/c/1256/708/73c/a386f5325ef57784d5318d94ccfac.jpeg", 0, "Michel", "Micholac"));
            listefilms.Chargement();
            return listefilms;
        }

        public static EnsembleFilm ajouterFilm(EnsembleFilm listefilms, Utilisateur personne, Film film)
        {
            listefilms.LesFilms.Add(film);
            return listefilms;
        }

    }
}

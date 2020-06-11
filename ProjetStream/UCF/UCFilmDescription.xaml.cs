using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
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


namespace ProjetStream.UCF
{

    /// <summary>
    /// Logique d'interaction pour UCFilmDescription.xaml
    /// </summary>
    public partial class UCFilmDescription : UserControl
    {
        public UCFilmDescription()
        {
            InitializeComponent();            
        }


        private Regex YouTubeURLIDRegex = new Regex(@"[\?&]v=(?<v>[^&]+)");
        public void Display(string url)
        {
            Match m = YouTubeURLIDRegex.Match(url);
            String id = m.Groups["v"].Value;
            string url1 = "http://www.youtube-nocookie.com/embed/" + id + "?rel=0&autoplay=1&amp&loop=1&enablejsapi=1";
            string page =
                 "<html style='height:100%;'>"
                + "<head><meta http-equiv='X-UA-Compatible' content='IE=11' />"
                + "<body style='Background-color:#141414; overflow : hidden; height:100%;'>" + "\r\n"
                + "<iframe src=\"" + url1 + "\" width=\"100%\" height=\"100%\" frameborder=\"0\" allowfullscreen></iframe>"
                + "</body></html>";
            webBrowser1.NavigateToString(page);
        }

        private void OuvrirNaviateur(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("cmd", "/C start" + " " + lienvid.Text);

        }

        public void changecolorblind(bool color)
        {
            if (color == true)
            {
                var converter = new System.Windows.Media.BrushConverter();
                var brush = (Brush)converter.ConvertFromString("#D3841D");
                boutonregarder.Background = brush;
            }
            else
            {
                var converter = new System.Windows.Media.BrushConverter();
                var brush = (Brush)converter.ConvertFromString("#831010");
                boutonregarder.Background = brush;
            }
        }

    }
}

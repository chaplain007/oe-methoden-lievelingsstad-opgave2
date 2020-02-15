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

namespace Lievelings.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string stad;
        string beginVanDeZin;

        const string BeginNed = "Je lievelingsstad is ";
        const string BeginEng = "Your favorite city is ";
        const string TitelNed = "Kies je lievelingsstad";
        const string TitelEng = "Choose your favorite city";

        public MainWindow()
        {
            InitializeComponent();
            beginVanDeZin = BeginNed;
        }

     /*   
        private void VerbergKnoppen()

        {
            btnEn.Visibility = Visibility.Hidden;
            btnNl.Visibility = Visibility.Hidden;
        }
        private void ToonKnoppen()
        {
            btnEn.Visibility = Visibility.Visible;
            btnNl.Visibility = Visibility.Visible;
        }

        */
        // Visibilty in de parameter wijst naar soort/type variable ( zoals int, string, ...)
        void WijzigZichtbaarheidTaalKnoppen(Visibility zichtbaarheid)
        {
            btnEn.Visibility = zichtbaarheid;
            btnNl.Visibility = zichtbaarheid;
        }

        private void VulLstSteden()
        {
            lstSteden.Items.Add("Antwerpen");
            lstSteden.Items.Add("Brugge");
            lstSteden.Items.Add("Brussel");
            lstSteden.Items.Add("Gent");
            lstSteden.Items.Add("Hasselt");
        }

        private void ToonEngelstaligeOpschriften()
        {
            beginVanDeZin = BeginEng;

            lblLievelingsStad.Content = $"{beginVanDeZin}{stad}";

            Title = TitelEng;
        }

        private void ToonNederlandstaligeOpschriften()
        {
            beginVanDeZin = BeginNed;

            lblLievelingsStad.Content = $"{beginVanDeZin}{stad}";

            Title = TitelNed;
        }

        void WijzigBeschikbaarheidTaalKnoppen(bool isBtnNederlandsBeschikbaar)
        {
            btnNl.IsEnabled = isBtnNederlandsBeschikbaar;
            btnEn.IsEnabled = !isBtnNederlandsBeschikbaar;

        }
        
        private void btnEn_Click(object sender, RoutedEventArgs e)
        {
            ToonEngelstaligeOpschriften();
            WijzigBeschikbaarheidTaalKnoppen(true);

        }

        private void btnNl_Click(object sender, RoutedEventArgs e)
        {
            ToonNederlandstaligeOpschriften();
            WijzigBeschikbaarheidTaalKnoppen(false);
        }
        
        private void lstSteden_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            stad = lstSteden.SelectedItem.ToString();
            lblLievelingsStad.Content = $"{beginVanDeZin}{stad}";

            //ToonKnoppen();
            WijzigZichtbaarheidTaalKnoppen(Visibility.Visible);

        }

        private void wndMainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            VulLstSteden();

            //VerbergKnoppen();
            WijzigZichtbaarheidTaalKnoppen(Visibility.Hidden);

            WijzigBeschikbaarheidTaalKnoppen(false);


            Title = TitelNed;
        }
    }
}
